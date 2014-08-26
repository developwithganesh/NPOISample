using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.Text;

namespace CRMServices
{
  // Use a data contract as illustrated in the sample below to add composite types to service operations.
  [DataContract]
  public class CustomFieldValueDTO
  {

    #region Primitive Properties

    [DataMember]
    public long Id
    {
      get;
      set;
    }

    [DataMember]
    public string PublicId
    {
      get;
      set;
    }

    [DataMember]
    public string Name
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<bool> IsActive
    {
      get;
      set;
    }

    [DataMember]
    public int CompanyId
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<long> CustomObjectId
    {
      get;
      set;
    }

    [DataMember]
    public string CustomObjectName
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<long> CustomFieldId
    {
      get;
      set;
    }

    [DataMember]
    public string CustomFieldName
    {
      get;
      set;
    }

    [DataMember]
    public string CustomFieldFormulaName
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<long> CustomObjectRecordId
    {
      get;
      set;
    }

    [DataMember]
    public string CustomObjectRecordPublicId
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<long> LookupObjectId
    {
      get;
      set;
    }

    [DataMember]
    public string LookupObjectIds
    {
      get;
      set;
    }

    [DataMember]
    public string FieldType
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<int> FieldTypeId
    {
      get;
      set;
    }

    [DataMember]
    public string VariableType
    {
      get;
      set;
    }

    [DataMember]
    public string SqlColumnPosfix
    {
      get;
      set;
    }

    [DataMember]
    public string InputHtmlType
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<bool> IsMultipleValue
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<bool> IsCalculated
    {
      get;
      set;
    }

    [DataMember]
    public string SystemLookupName
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<bool> ValueBoolean
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<System.DateTime> ValueDateTime
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<decimal> ValueDecimal
    {
      get;
      set;
    }

    [DataMember]
    public string ValueString
    {
      get;
      set;
    }

    [DataMember]
    public string ValueStringMax
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<long> ValueInt64
    {
      get;
      set;
    }

    [DataMember]
    public long CreatedBy
    {
      get;
      set;
    }

    [DataMember]
    public System.DateTime CreatedAt
    {
      get;
      set;
    }

    [DataMember]
    public long UpdatedBy
    {
      get;
      set;
    }

    [DataMember]
    public System.DateTime UpdatedAt
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<long> DeletedBy
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<System.DateTime> DeletedAt
    {
      get;
      set;
    }

    [DataMember]
    public Nullable<bool> IsDeleted
    {
      get;
      set;
    }

    #endregion

  }
}
