using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace CRM.Utility
{
    public abstract class WorksheetAbstractBuilder
    {
        protected ISheet WorkSheet;
        protected IWorkbook Workbook { get; set; }
        public IWorkSheetHeader HeaderBuilder { get; set; }
        public string WorkSheetName { get; set; }

        protected WorksheetAbstractBuilder(IExcelDatasource datasource)
        {
            
            Workbook = new HSSFWorkbook();
            this.DataSource = datasource;
        }
        protected WorksheetAbstractBuilder(string workSheetName, IExcelDatasource datasource)
            : this(datasource)
        {
            WorkSheetName = workSheetName;
        }

      
        public abstract void CreateWorkSheet();
        public abstract void CreateHeaderRow();
        public abstract void ApplyDatasource();

        
        
        public IWorkbook BuildWorkSheet()
        {
            CreateWorkSheet();
            CreateHeaderRow();
            ApplyDatasource();
            return Workbook;
        }

        public IExcelDatasource DataSource { get; set; }
    }
}