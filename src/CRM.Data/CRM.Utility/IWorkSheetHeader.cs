using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;

namespace CRM.Utility
{
  public interface IWorkSheetHeader
  {
    IRow GetHeaderRow(NPOI.SS.UserModel.ICellStyle style);

  }

  
}

