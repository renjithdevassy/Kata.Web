using Kata.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kata.Web.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            ItemsModel model = new ItemsModel();
            List<ItemModel> items = new List<ItemModel>
            {
                new ItemModel{Id=1,ItemName="A",Price=10,Qty=1},
                new ItemModel{Id=2,ItemName="B",Price=15,Qty=1},
                new ItemModel{Id=3,ItemName="C",Price=40,Qty=1},
                new ItemModel{Id=4,ItemName="D",Price=55,Qty=1}
            };
            model.Items = items.ToList();
            return View(model);
        }
    }
}
