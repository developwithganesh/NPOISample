using System;
using System.IO;

namespace CRM.Utility
{
    public class WorksheetBuilder: WorksheetAbstractBuilder
    {
        public WorksheetBuilder(IExcelDatasource datasource) : base(datasource)
        {
        }

        public WorksheetBuilder(string workSheetName, IExcelDatasource datasource) : base(workSheetName, datasource)
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
            BuildWorkSheet();
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
            BuildWorkSheet();
            if (Workbook != null)
            {
                this.FileSaver = FileSaver ?? new OutputExcelSaver(fileName, Workbook);
                return FileSaver.Save();
            }
            return string.Empty;
        }

        public OutputExcelSaver FileSaver { get; set; }

    }
}