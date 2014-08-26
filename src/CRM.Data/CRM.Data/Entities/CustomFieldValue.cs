using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Data.Entities
{
  public partial class CustomFieldValue
  {
    #region Primitive Properties

    public virtual long Id
    {
      get;
      set;
    }

    public virtual int CompanyId
    {
      get;
      set;
    }

    public virtual string PublicId
    {
      get;
      set;
    }

    public virtual string Name
    {
      get;
      set;
    }

    public virtual Nullable<bool> IsActive
    {
      get;
      set;
    }


    public virtual Nullable<long> CustomObjectId
    {
      get;
      set;
    }

    public virtual string CustomObjectName
    {
      get;
      set;
    }

    public virtual Nullable<long> CustomFieldId
    {
      get;
      set;
    }

    public virtual string CustomFieldName
    {
      get;
      set;
    }

    public virtual string CustomFieldFormulaName
    {
      get;
      set;
    }

    public virtual Nullable<long> CustomObjectRecordId
    {
      get;
      set;
    }

    public virtual string CustomObjectRecordPublicId
    {
      get;
      set;
    }

    public virtual Nullable<long> LookupObjectId
    {
      get;
      set;
    }

    public virtual string LookupObjectIds
    {
      get;
      set;
    }

    public virtual string FieldType
    {
      get;
      set;
    }

    public virtual Nullable<int> FieldTypeId
    {
      get;
      set;
    }

    public virtual string VariableType
    {
      get;
      set;
    }

    public virtual string SqlColumnPosfix
    {
      get;
      set;
    }

    public virtual string InputHtmlType
    {
      get;
      set;
    }

    public virtual Nullable<bool> IsMultipleValue
    {
      get;
      set;
    }

    public virtual Nullable<bool> IsCalculated
    {
      get;
      set;
    }

    public virtual string SystemLookupName
    {
      get;
      set;
    }

    public virtual Nullable<bool> ValueBoolean
    {
      get;
      set;
    }

    public virtual Nullable<System.DateTime> ValueDateTime
    {
      get;
      set;
    }

    public virtual Nullable<decimal> ValueDecimal
    {
      get;
      set;
    }

    public virtual string ValueString
    {
      get;
      set;
    }

    public virtual string ValueStringMax
    {
      get;
      set;
    }

    public virtual Nullable<long> ValueInt64
    {
      get;
      set;
    }

    public virtual long CreatedBy
    {
      get;
      set;
    }

    public virtual System.DateTime CreatedAt
    {
      get;
      set;
    }

    public virtual long UpdatedBy
    {
      get;
      set;
    }

    public virtual System.DateTime UpdatedAt
    {
      get;
      set;
    }

    public virtual Nullable<long> DeletedBy
    {
      get;
      set;
    }

    public virtual Nullable<System.DateTime> DeletedAt
    {
      get;
      set;
    }

    public virtual Nullable<bool> IsDeleted
    {
      get;
      set;
    }

    #endregion

  }

}
