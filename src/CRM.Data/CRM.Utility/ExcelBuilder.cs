
using System;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;

namespace CRM.Utility
{
  public abstract class WorkbookAbstractBuilder
  {
    protected string WorkSheetName;
    protected ISheet WorkSheet;

    private ICellStyle headerCellStyle;

    public ICellStyle HeaderCellStyle
    {
      get { return headerCellStyle; }
      set { headerCellStyle = value; }
    }


    public WorkbookAbstractBuilder(string workbookName, IExcelDatasource datasource)
    {
      this.WorkSheetName = workbookName;
      Workbook = new HSSFWorkbook();
      this.DataSource = datasource;
    }

    protected IWorkbook Workbook { get; set; }

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

  public class WorkbookBuilder<TE> : WorkbookAbstractBuilder where TE : class
  {

    public WorkbookBuilder(string workbookName, IExcelDatasource datasource) :
      base(workbookName, datasource)
    {

    }

    public override void CreateWorkSheet()
    {
      INameFormatter nameFormatter = new NameFormatter(WorkSheetName);
      WorkSheet = this.Workbook.CreateSheet(nameFormatter.Name);
    }

    public override void CreateHeaderRow()
    {
      IWorkSheetHeader headerBuilder = new WorkSheetHeaderFromType<TE>(WorkSheet);
      headerBuilder.GetHeaderRow(this.HeaderCellStyle);
    }

    public override void ApplyDatasource()
    {
      DataSource.ApplyDatasource(sheet: WorkSheet);
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
        this.FileSaver = FileSaver ?? new OutputExcelSaver(fileName,Workbook);
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
    private   IWorkbook _workbook;

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
}
