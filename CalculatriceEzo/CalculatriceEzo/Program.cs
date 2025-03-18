namespace CalculatriceEzo
{
    public class Program 
    { 
        static void Main(string[] args)
        {
            
            Calculatrice calc = new Calculatrice();
            double result;
            string expression = "0";

            while (expression != "sortie")
            {
                Console.WriteLine("Entrez une expression mathématique");
                expression = Console.ReadLine();
                result = calc.Calculate(expression);
                Console.WriteLine(result);
            }
        }
    }
}