using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.Formula.Functions;

namespace CRM.Utility
{
  public class ListExcelDatasource<TEntity> : IExcelDatasource where TEntity : class
  {
    private readonly IEnumerable<TEntity> _source;

    public ListExcelDatasource(IEnumerable<TEntity> source )
    {
      _source = source;
    }

    public void ApplyDatasource(NPOI.SS.UserModel.ISheet sheet)
    {
      if (_source == null)
        return;
      var properties = typeof(TEntity).GetProperties();
      int rowindex = 1;
      foreach (var item in _source)
      {
        var row = sheet.CreateRow(rowindex++);
        for (int i = 0; i < properties.Length; i++)
        {
          var cell = row.CreateCell(i);
          var val = properties[i].GetValue(item, null);
          if(val != null)
            cell.SetCellValue(val.ToString());
        }
      }
    }
  }
}
