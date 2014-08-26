using System;
using System.Linq;
using CRM.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.Data.DbContexts;
namespace CRM.Data.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      using (var context = new CRMContext())
      {
        context.Cities.Add(new City{ Name = "Mumbai"});
        var citycount = context.Cities.Count();
        var customCount = context.CustomFieldValues.Count();
        context.CustomFieldValues.Add(new CustomFieldValue() {Name ="Custom Field", CustomFieldName = "CustomField"});
        context.SaveChanges();

        Assert.IsTrue(context.Cities.Count() == citycount +1);
        Assert.IsTrue(context.CustomFieldValues.Count() == customCount+1);
      }
    }
  }
}
