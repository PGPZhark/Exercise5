using System.Runtime.CompilerServices;

namespace Exercise_5
{
    internal class Program
    {
        static void Main()
        {
            IUI UI = new UI();
            UI.Menu();
            Console.Read();
        }
    }
}
