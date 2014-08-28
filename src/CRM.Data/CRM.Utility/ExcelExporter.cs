using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Utility;

namespace CRM.Utility
{
  public class ExcelExporter
  {
    private WorksheetAbstractBuilder exbuilder;

    public ExcelExporter(WorksheetAbstractBuilder builder)
    {
      exbuilder = builder;
    }

  }
}
