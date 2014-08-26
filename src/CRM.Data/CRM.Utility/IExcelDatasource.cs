using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;

namespace CRM.Utility
{
  public interface IExcelDatasource
  {
     
      void ApplyDatasource(IWorkbook workbook);

  }
}
