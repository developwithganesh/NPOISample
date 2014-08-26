using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Web.ServiceReference1;

namespace CRM.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

      CustomFieldValueServiceClient client = 
        new CustomFieldValueServiceClient("BasicHttpBinding_ICustomFieldValueService");
      client.ExportData(null);


      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}
