 
using System.Collections.Generic;
using System.Linq;
using CRM.Data.DbContexts;
using CRM.Data.Entities;

namespace CRM.Repository
{
  public class CustomFieldValueRepository: GenericRepository<CustomFieldValue>
  {
    public CustomFieldValueRepository(CRMContext context) : base(context)
    {
      
    }

    public CustomFieldValueRepository():base( new CRMContext())
    {
    }

    public List<CustomFieldValue> GetCustomFieldValues()
    {
      List<CustomFieldValue> list = new List<CustomFieldValue>();
      using (CRMContext cont = new CRMContext())
      {
       list = cont.CustomFieldValues.ToList();
      }
      return list;
    }
  }
}
