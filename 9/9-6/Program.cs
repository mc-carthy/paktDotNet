using System;
using System.Linq;
using static System.Console;

namespace _9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] {
                "Michael",
                "Pam",
                "Jim",
                "Dwight",
                "Angela",
                "Kevin",
                "Toby",
                "Creed"
            };

            var query = names
                .ProcessSequence()
                .Where (name => name.Length > 4)
                .OrderBy (name => name.Length)
                .ThenBy (name => name);

            foreach (var item in query)
            {
                WriteLine(item);
            }
        }

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }
    }
}
