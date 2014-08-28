using System.Runtime.Remoting.Messaging;
using NPOI.POIFS.NIO;
using NPOI.SS.Formula.Functions;

namespace CRM.Utility
{
    public class WorksheetBuilderFromType<TE> : WorksheetBuilder where TE:class 
    {
        public WorksheetBuilderFromType(IExcelDatasource datasource) : base(datasource)
        {
        }

        public WorksheetBuilderFromType(string workSheetName, IExcelDatasource datasource) : base(workSheetName, datasource)
        {
        }

        public override void CreateHeaderRow()
        {
            HeaderBuilder = new WorkSheetHeaderFromType<TE>(WorkSheet);
            base.CreateHeaderRow();
        }

    }
}
