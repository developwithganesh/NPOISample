﻿using System.Collections.Generic;
using CRM.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.UserModel;

namespace CRM.Utility.Tests
{
  [TestClass]
  public class ExcelExporterTest
  {
    [TestMethod]
    public void ShouldCreateSheet()
    {
      var list = new List<CustomFieldValue>
      {
        new CustomFieldValue(){Id = 1, CompanyId = 2, Name = "test2"},
        new CustomFieldValue(){Id = 2, CompanyId = 3, Name = "test3"},
        new CustomFieldValue(){Id = 3, CompanyId = 4, Name = "test4"},
        new CustomFieldValue(){Id = 4, CompanyId = 5, Name = "test5"},
        new CustomFieldValue(){Id = 5, CompanyId = 6, Name = "test6"},
      };

        ListExcelDatasource<CustomFieldValue> datasource = new ListExcelDatasource<CustomFieldValue>(list);
      

    }

    [TestMethod]
    public void ShouldCreateWorksheet()
    {
      WorkbookBuilder<CustomFieldValue> wbuilder = new WorkbookBuilder<CustomFieldValue>("newsheet", new ListExcelDatasource<CustomFieldValue>(new List<CustomFieldValue>()));
      var workBook =  wbuilder.BuildWorkBook();
      Assert.IsTrue(workBook.NumberOfSheets >0);
      
    }


    #region Formatting Name of the worksheet
    [TestMethod]
    public void ShouldFormatNameByRemovingSlash()
    {
      WorkbookBuilder<CustomFieldValue> wbuilder = new WorkbookBuilder<CustomFieldValue>("new/sheet", new ListExcelDatasource<CustomFieldValue>(new List<CustomFieldValue>()));
      var workBook = wbuilder.BuildWorkBook();
      Assert.IsTrue(workBook.GetSheetAt(0).SheetName == "new-sheet");
    }

    [TestMethod]
    public void ShouldFormatNameByRemovingDoubleSlash()
    {
      WorkbookBuilder<CustomFieldValue> wbuilder = new WorkbookBuilder<CustomFieldValue>("new\\sheet", new ListExcelDatasource<CustomFieldValue>(new List<CustomFieldValue>()));
      var workBook = wbuilder.BuildWorkBook();
      Assert.IsTrue(workBook.GetSheetAt(0).SheetName == "new sheet");
    }

    [TestMethod]
    public void ShouldFormatNameByRemovingquestionmark()
    {
      WorkbookBuilder<CustomFieldValue> wbuilder = new WorkbookBuilder<CustomFieldValue>("new\\s?he?et", new ListExcelDatasource<CustomFieldValue>(new List<CustomFieldValue>()));
      var workBook = wbuilder.BuildWorkBook();
      Assert.IsTrue(workBook.GetSheetAt(0).SheetName == "new sheet");
    }

    [TestMethod]
    public void ShouldFormatNameByCuttingLongName()
    {
      WorkbookBuilder<CustomFieldValue> wbuilder = new WorkbookBuilder<CustomFieldValue>("newsheetnewsheetnewsheetnewsheetnewsheetnewsheetnewsheetnewsheet", new ListExcelDatasource<CustomFieldValue>(new List<CustomFieldValue>()));
      var workBook = wbuilder.BuildWorkBook();

      Assert.IsTrue(workBook.GetSheetAt(0).SheetName == "newsheetnewsheetnews");
    }
    
    #endregion
    
    [TestMethod]
    public void ShouldInsertHeaderRows()
    {
      var list = new List<CustomFieldValue>
      {
        new CustomFieldValue(){Id = 1, CompanyId = 2, Name = "test2"},
        new CustomFieldValue(){Id = 2, CompanyId = 3, Name = "test3"},
        new CustomFieldValue(){Id = 3, CompanyId = 4, Name = "test4"},
        new CustomFieldValue(){Id = 4, CompanyId = 5, Name = "test5"},
        new CustomFieldValue(){Id = 5, CompanyId = 6, Name = "test6"},
      };
      WorkbookBuilder<CustomFieldValue> wbuilder = new WorkbookBuilder<CustomFieldValue>("newsheet", new ListExcelDatasource<CustomFieldValue>( list));
      var row = wbuilder.BuildWorkBook().GetSheetAt(0).GetRow(0);
      Assert.IsTrue(row.GetCell(0).StringCellValue == "Id");
      var cellCount = row.PhysicalNumberOfCells ;
      Assert.IsTrue(cellCount  == typeof(CustomFieldValue).GetProperties().Length);
    }

    [TestMethod]
    public void ShouldInsertRows()
    {
      var list = new List<CustomFieldValue>
      {
        new CustomFieldValue(){Id = 1, CompanyId = 2, Name = "test2"},
        new CustomFieldValue(){Id = 2, CompanyId = 3, Name = "test3"},
        new CustomFieldValue(){Id = 3, CompanyId = 4, Name = "test4"},
        new CustomFieldValue(){Id = 4, CompanyId = 5, Name = "test5"},
        new CustomFieldValue(){Id = 5, CompanyId = 6, Name = "test6"},
      };
      WorkbookBuilder<CustomFieldValue> wbuilder = new WorkbookBuilder<CustomFieldValue>("newsheet", new ListExcelDatasource<CustomFieldValue>(list));
      IWorkbook buildWorkBook = wbuilder.BuildWorkBook();
      ISheet sheetAt = buildWorkBook.GetSheetAt(0);
      var rowCount = sheetAt.PhysicalNumberOfRows;
      Assert.IsTrue(rowCount == list.Count + 1);

      var row = sheetAt.GetRow(1);
      Assert.IsTrue(row.GetCell(0).StringCellValue == "1");
      Assert.IsTrue(row.GetCell(1).StringCellValue == "2");

      Assert.IsTrue(row.GetCell(3).StringCellValue == "test2");


    }
    
  }
}