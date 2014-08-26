
using System;
using System.IO;
using System.Runtime.Remoting.Messaging;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.NIO;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;

namespace CRM.Utility
{

    public abstract class WorkbookAbstractBuilder
    {
        protected ISheet WorkSheet;
        protected IWorkbook Workbook { get; set; }
        public IWorkSheetHeader HeaderBuilder { get; set; }
        public string WorkSheetName { get; set; }

        protected WorkbookAbstractBuilder(IExcelDatasource datasource)
        {

            Workbook = new HSSFWorkbook();
            this.DataSource = datasource;
        }
        protected WorkbookAbstractBuilder(string workSheetName, IExcelDatasource datasource)
            : this(datasource)
        {
            WorkSheetName = workSheetName;
        }

      
        public abstract void CreateWorkSheet();
        public abstract void CreateHeaderRow();
        public abstract void ApplyDatasource();

        public IWorkbook BuildWorkBook()
        {
            CreateWorkSheet();
            CreateHeaderRow();
            ApplyDatasource();
            return Workbook;
        }



        public IExcelDatasource DataSource { get; set; }
    }

    public class WorkbookBuilder: WorkbookAbstractBuilder
    {
        public WorkbookBuilder(IExcelDatasource datasource) : base(datasource)
        {
        }

        public WorkbookBuilder(string workSheetName, IExcelDatasource datasource) : base(workSheetName, datasource)
        {
        }

        public override void CreateWorkSheet()
        {
            INameFormatter nameFormatter = new NameFormatter(WorkSheetName);
            WorkSheet = this.Workbook.CreateSheet(nameFormatter.Name);
        }

        public override void CreateHeaderRow()
        {
            if (HeaderBuilder != null)
            {
                HeaderBuilder.GetHeaderRow();

            }
        }

        public override void ApplyDatasource()
        {
            DataSource.ApplyDatasource(Workbook);
        }

        public byte[] GetStream()
        {
            BuildWorkBook();
            byte[] byteArray;
            using (var buffer = new MemoryStream())
            {

                Workbook.Write(buffer);

                byteArray = new Byte[buffer.Length];
                buffer.Read(byteArray, 0, (int)buffer.Length);


            }

            return byteArray;

        }

        public string SaveFile(string fileName)
        {
            BuildWorkBook();
            if (Workbook != null)
            {
                this.FileSaver = FileSaver ?? new OutputExcelSaver(fileName, Workbook);
                return FileSaver.Save();
            }
            return string.Empty;
        }

        public OutputExcelSaver FileSaver { get; set; }

    }

    public interface IOutputFileSaver
    {
        string Save();
    }

    public class OutputExcelSaver : IOutputFileSaver
    {
        private readonly string _fileName;
        private IWorkbook _workbook;

        public OutputExcelSaver(string fileName, IWorkbook workbook)
        {
            _fileName = fileName;
            _workbook = workbook;
        }

        public string Save()
        {
            using (var fs = new FileStream(_fileName, FileMode.Create))
            {
                _workbook.Write(fs);
                //_workbook = new HSSFWorkbook(fs, true);
                fs.Close();
            }
            return _fileName;
        }
    }

    public class WorkbookBuilderFromType<TE> : WorkbookBuilder where TE:class 
    {
        public WorkbookBuilderFromType(IExcelDatasource datasource) : base(datasource)
        {
        }

        public WorkbookBuilderFromType(string workSheetName, IExcelDatasource datasource) : base(workSheetName, datasource)
        {
        }

        public override void CreateHeaderRow()
        {
            HeaderBuilder = new WorkSheetHeaderFromType<TE>(WorkSheet);
            base.CreateHeaderRow();
        }

    }
}
