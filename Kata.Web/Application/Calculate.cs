using Kata.Web.Models;

namespace Kata.Web.Application
{
    public class Calculate : ICalculate
    {
        public CalculationModel CalcTotal(List<ItemModel> items)
        {
            CalculationModel cal = new CalculationModel();
            foreach (ItemModel item in items)
            {
                cal.Total = cal.Total + (item.Qty * item.Price);
                if (item.Id == 2 && item.Qty > 2)
                {
                    var tot = item.Qty * item.Price;
                    cal.Discount = cal.Discount + (tot - (Convert.ToInt32(item.Qty / 3) * 40) - ((item.Qty % 3) * item.Price));
                }
                if (item.Id == 4 && item.Qty > 1)
                {
                    cal.Discount = cal.Discount + ((Convert.ToInt32(item.Qty / 2) * (item.Price * 2)) * 0.25);
                }

            }
            cal.Paying = cal.Total - cal.Discount;
            return cal;
        }
    }
}
