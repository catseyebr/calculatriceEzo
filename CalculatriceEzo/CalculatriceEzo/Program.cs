namespace CalculatriceEzo
{
    public class Program 
    { 
        static void Main(string[] args)
        {
            Calculatrice calc = new Calculatrice();
            double result;
            Console.WriteLine("Entrez une expression mathématique");
            string expression = Console.ReadLine();
            result = calc.Calculate(expression);
            Console.WriteLine(result);
        }
    }
}