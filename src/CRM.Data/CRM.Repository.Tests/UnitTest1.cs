using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CRM.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.Repository.Tests
{
  [TestClass]
  public class CustomFieldRepositoryTest
  {
    [TestMethod]
    public void ShouldReturnRows()
   { 
      CustomFieldValueRepository repo = new CustomFieldValueRepository();
      IEnumerable<CustomFieldValue> entities = repo.Get();
      Assert.IsTrue(entities.Count()>0);
    }
  }
}
