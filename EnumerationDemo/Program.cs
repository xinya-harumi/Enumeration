using System.Text.Json;

namespace EnumerationDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var standardCard = CreditCard.FromName("Standard");
            var standardCard2 = CreditCard.FromValue(1);
            Console.WriteLine(JsonSerializer.Serialize(standardCard));
            Console.ReadKey();

        }
    }
}