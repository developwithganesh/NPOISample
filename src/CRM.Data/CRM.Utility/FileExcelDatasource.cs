using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.HSSF.Record.Common;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CRM.Utility
{
    public class FileExcelDatasource : IExcelDatasource
    {
        private readonly string _fileName;

        public FileExcelDatasource(string fileName)
        {
            _fileName = fileName;
        }

        public void ApplyDatasource(IWorkbook workbook)
        {
            if (_fileName == null)
                return;
             FileInfo f = new FileInfo(_fileName);
            
                using (FileStream fs = new FileStream(_fileName, FileMode.Open))
                {
                    if (f.Extension == ".xls")
                    {
                        workbook = new HSSFWorkbook(fs, true);
                    }
                    else if (f.Extension == ".xlsx")
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else
                    {
                        throw new Exception("Invalid file extension");
                    }
                }
            
        }
    }
}
