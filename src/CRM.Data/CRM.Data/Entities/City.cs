using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Data.Entities
{
  
    public class City 
    {
      public string Name { get; set; }
      #region IEntity Members
      public int Id { get; set; }
      #endregion
    }
   
}
