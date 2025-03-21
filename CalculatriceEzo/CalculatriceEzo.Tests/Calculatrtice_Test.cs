using Microsoft.VisualBasic;

namespace CalculatriceEzo.Tests
{
    public class Calculatrice_Test
    {
        [Theory]
        [InlineData("1+1", 2)]
        [InlineData("1 + 2", 3)]
        [InlineData("1 + -1", 0)]
        [InlineData("-1 - -1", 0)]
        [InlineData("5-4", 1)]
        [InlineData("5*2", 10)]
        [InlineData("(2+5)*3", 21)]
        [InlineData("10/2", 5)]
        [InlineData("2+2*5+5", 17)]
        [InlineData("2.8*3-1", 7.4)]
        [InlineData("2^8", 256)]
        [InlineData("2^8*5-1", 1279)]
        [InlineData("sqrt(4)", 2)]
        [InlineData("1/0", null)]
        public void Calculatrice_Calculate(string expression, double result)
        {
            var calc = new Calculatrice();
            Assert.Equal(calc.EvaluerExpression(expression), Math.Round(result, 1));
        }
    }
}