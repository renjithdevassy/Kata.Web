using Kata.Web.Application;
using Kata.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kata.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICalculate _calculate;
        public CheckoutController(ICalculate calculate)
        {
            _calculate = calculate;
        }
        public IActionResult Index()
        {
            ItemsModel model = new ItemsModel();
            CalculationModel cal = new CalculationModel();
            List<ItemModel> items = new List<ItemModel>
            {
                new ItemModel{Id=1,ItemName="A",Price=10,Qty=1},
                new ItemModel{Id=2,ItemName="B",Price=15,Qty=1},
                new ItemModel{Id=3,ItemName="C",Price=40,Qty=1},
                new ItemModel{Id=4,ItemName="D",Price=55,Qty=1}
            };
            model.Items = items.ToList();
            model.calc = new CalculationModel();
            model.calc = _calculate.CalcTotal(items);
            return View(model);
        }
        [HttpPost]
        public IActionResult Calculate(ItemsModel itms)
        {

            ItemsModel model = new ItemsModel();
            model = itms;
            model.calc = _calculate.CalcTotal(itms.Items);
            return View(model);
        }
    }
}
