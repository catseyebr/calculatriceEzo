namespace CalculatriceEzo.Tests
{
    public class Calculatrice_Test
    {
        [Theory]
        [InlineData("1+1",2)]
        [InlineData("1 + 2", 3)]
        public void Calculatrice_Calculate(string expression, double result)
        {
            var calc = new Calculatrice();
            Assert.Equal(calc.EvaluerExpression(expression), result);
        }        
    }
}