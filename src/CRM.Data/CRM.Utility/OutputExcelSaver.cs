using System.IO;
using NPOI.SS.UserModel;

namespace CRM.Utility
{
    public class OutputExcelSaver : IOutputFileSaver
    {
        private readonly string _fileName;
        private IWorkbook _workbook;

        public OutputExcelSaver(string fileName, IWorkbook workbook)
        {
            _fileName = fileName;
            _workbook = workbook;
        }

        public string Save()
        {
            using (var fs = new FileStream(_fileName, FileMode.Create))
            {
                _workbook.Write(fs);
                //_workbook = new HSSFWorkbook(fs, true);
                fs.Close();
            }
            return _fileName;
        }
    }
}