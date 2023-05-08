using System.Text.RegularExpressions;
using Cafe.Tab;
using Microsoft.AspNetCore.Mvc;

namespace WebFrontend.Controllers
{
    public class ChefController : Controller
    {
        public ActionResult Index()
        {
            return View(Domain.ChefTodoListQueries.GetTodoList());
        }

        public ActionResult MarkPrepared(Guid id, FormCollection form)
        {
            Domain.Dispatcher.SendCommand(new MarkFoodPrepared
            {
                Id = id,
                MenuNumbers = (from entry in form.Keys.Cast<string>()
                               where form[entry] != "false"
                               let m = Regex.Match(entry, @"prepared_\d+_(\d+)")
                               where m.Success
                               select int.Parse(m.Groups[1].Value)
                              ).ToList()
            });

            return RedirectToAction("Index");
        }
    }
}
