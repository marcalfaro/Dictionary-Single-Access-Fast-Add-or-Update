using System.Text.Json;

namespace DictionaryFastFix2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var values = new Dictionary<int, string>
            {
                {69420,"69420"}
            };

            var val = values.GetOrAdd(1337, "1337");

            Console.WriteLine(val);
            Console.WriteLine(JsonSerializer.Serialize(values));

            Console.ReadLine();
        }
    }
}
