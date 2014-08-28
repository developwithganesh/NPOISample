using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using CRM.Data.Entities;
using CRM.Repository;
using CRM.Utility;

namespace CRMServices
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
  [ServiceBehavior]
  public class CustomFieldValueService: ICustomFieldValueService
  {
    public string GetData(int value)
    {
      return string.Format("You entered: {0}", value);
    }

    [OperationBehavior]
    public string ExportData(DataExportRequest request)
    {
       CustomFieldValueRepository repo = new CustomFieldValueRepository();
       var entities = repo.Get();
       WorksheetBuilderFromType<CustomFieldValue> wbuilder = new WorksheetBuilderFromType<CustomFieldValue>("newsheet", new ListExcelDatasource<CustomFieldValue>(entities));

      string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)+ "\\UploadedFiles";
      string filename = filePath+"\\"+ Guid.NewGuid().ToString()+".xls";

      string success = wbuilder.SaveFile(filename);

      //using (FileStream fstream = new FileStream(filePath+"\\"+filename, FileMode.Create))
      //{
      //  fstream.Write(byteArray, 0, (int)byteArray.Length);
         
      //}



      return filename;

    }

  }
}
