using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;

namespace CRM.Utility
{
  public interface IWorkSheetHeader
  {
      ICellStyle HeaderCellStyle { get; set; }
      
    IRow GetHeaderRow();

  }

    public class NoWorksheetHeader : IWorkSheetHeader
    {

        public IRow GetHeaderRow()
        {
            return null;
        }

        public ICellStyle HeaderCellStyle
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}

