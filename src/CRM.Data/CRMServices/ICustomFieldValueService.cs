using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMServices
{
  [ServiceContract]
  public interface ICustomFieldValueService
  {

    [OperationContract]
    string GetData(int value);

    [OperationContract]
     string ExportData(DataExportRequest request);
  }
}