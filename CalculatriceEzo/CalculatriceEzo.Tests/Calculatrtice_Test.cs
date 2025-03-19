namespace CalculatriceEzo.Tests
{
    public class Calculatrice_Test
    {
        [Theory]
        [InlineData("1+1",2)]
        [InlineData("1 + 2", 3)]
        [InlineData("1 + -1", 0)]
        [InlineData("-1 - -1", 0)]
        [InlineData("5-4", 1)]
        [InlineData("5*2", 10)]
        [InlineData("(2+5)*3", 21)]
        [InlineData("10/2", 5)]
        public void Calculatrice_Calculate(string expression, double result)
        {
            var calc = new Calculatrice();
            Assert.Equal(calc.EvaluerExpression(expression), result);
        }        
    }
}