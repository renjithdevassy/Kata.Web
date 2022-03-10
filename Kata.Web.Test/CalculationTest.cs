using Kata.Web.Application;
using Kata.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kata.Web.Test
{
    public class CalculationTest : IClassFixture<Calculate>
    {
        
        readonly List<ItemModel> _items;
        readonly List<ItemModel> _items1;
        readonly List<ItemModel> _items2;
        private readonly Calculate _calculate;
        public CalculationTest(Calculate calculate)
        {
            _items = new List<ItemModel>
            {
                new ItemModel{Id=1,ItemName="A",Price=10,Qty=1},
                new ItemModel{Id=2,ItemName="B",Price=15,Qty=1},
                new ItemModel{Id=3,ItemName="C",Price=40,Qty=1},
                new ItemModel{Id=4,ItemName="D",Price=55,Qty=1}
            };
            _items1 = new List<ItemModel>
            {
                new ItemModel{Id=1,ItemName="A",Price=10,Qty=1},
                new ItemModel{Id=2,ItemName="B",Price=15,Qty=4},
                new ItemModel{Id=3,ItemName="C",Price=40,Qty=1},
                new ItemModel{Id=4,ItemName="D",Price=55,Qty=1}
            };
            _items2 = new List<ItemModel>
            {
                new ItemModel{Id=1,ItemName="A",Price=10,Qty=1},
                new ItemModel{Id=2,ItemName="B",Price=15,Qty=1},
                new ItemModel{Id=3,ItemName="C",Price=40,Qty=1},
                new ItemModel{Id=4,ItemName="D",Price=55,Qty=2}
            };
            _calculate = calculate;
        }
        [Fact]
        public void CalcTotalWithoutPromotion_Test()
        {
            //Arrange
            CalculationModel expected = new CalculationModel()
            {
                Discount = 0,
                Paying = 120,
                Total = 120
            };

            //Act
            CalculationModel actual = _calculate.CalcTotal(_items);
            //Assert
            AssertValueEquality(expected, actual);

        }
        [Fact]
        public void CalcTotalWith3for40Promotion_Test()
        {
            //Arrange
            CalculationModel expected = new CalculationModel()
            {
                Discount = 5,
                Paying = 160,
                Total = 165
            };

            //Act
            CalculationModel actual = _calculate.CalcTotal(_items1);
            //Assert
            AssertValueEquality(expected, actual);

        }
        [Fact]
        public void CalcTotalWith25percentPromotion_Test()
        {
            //Arrange
            CalculationModel expected = new CalculationModel()
            {
                Discount = 27.5,
                Paying = 147.5,
                Total = 175
            };

            //Act
            CalculationModel actual = _calculate.CalcTotal(_items2);
            //Assert
            AssertValueEquality(expected, actual);

        }
        private void AssertValueEquality(CalculationModel expected, CalculationModel actual)
        {
            Assert.Equal(
                new double[] { expected.Total, expected.Discount, expected.Paying },
                new double[] { actual.Total, actual.Discount, actual.Paying }
            );
        }

    }

}
