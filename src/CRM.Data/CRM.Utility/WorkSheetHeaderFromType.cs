using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;

namespace CRM.Utility
{
  public class WorkSheetHeaderFromType<T> : IWorkSheetHeader where T:class
  {

    private ISheet sheet;
    public WorkSheetHeaderFromType( ISheet sheet)
    {
      this.sheet = sheet;
    }

    public NPOI.SS.UserModel.IRow GetHeaderRow()
    {
      var row = sheet.CreateRow(0);
      var properties = typeof (T).GetProperties();
      
      
      for(int i=0; i<properties.Length; i++)
      {
        var cell = row.CreateCell(i);
        cell.SetCellValue(properties[i].Name);
        if (HeaderCellStyle != null)
            cell.CellStyle = HeaderCellStyle;
      }
      return row;
    }

    public ICellStyle HeaderCellStyle { get; set; }

  }

}
