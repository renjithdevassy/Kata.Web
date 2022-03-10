using Kata.Web.Models;

namespace Kata.Web.Application
{
    public interface ICalculate
    {
        CalculationModel CalcTotal(List<ItemModel> items);
    }
}
