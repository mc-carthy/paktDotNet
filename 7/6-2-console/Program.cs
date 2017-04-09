using System;
using Packt.CS7;
using static System.Console;

namespace _6_2_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person ();
            p1.Name = "Bob Smith";
            p1.DateOfBirth = new DateTime (1965, 12, 22);
            p1.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            p1.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            // p1.BucketList = (WondersOfTheAncientWorld)18; 
            p1.Children.Add(new Person()); 
            p1.Children.Add(new Person()); 

            WriteLine ($"{p1.Name} was born on {p1.DateOfBirth:dddd, d MMMM yyyy}");
            WriteLine ($"{p1.Name}'s favourite wonder is {p1.FavouriteAncientWonder}"); 
            WriteLine ($"{p1.Name}'s bucket list is {p1.BucketList}"); 
            WriteLine ($"{p1.Name} has {p1.Children.Count} children."); 
            WriteLine ($"{p1.Name} is a {Person.Species}"); 
            WriteLine ($"{p1.Name} was born on {p1.HomePlanet}"); 
            p1.WriteToConsole ();
            WriteLine (p1.GetOrigin ());


            Person p2 = new Person { Name = "Alice Jones", DateOfBirth = new DateTime (1998, 3, 17) }; 
            WriteLine ($"{p2.Name} was born on {p2.DateOfBirth:d MMM yy}"); 

            Person p3 = new Person(); 
            WriteLine ($"{p3.Name} was instantiated at {p3.Instantiated:hh:mm:ss} on {p3.Instantiated:dddd, d MMMM yyyy}"); 
    
            Person p4 = new Person("Aziz"); 
            WriteLine ($"{p4.Name} was instantiated at {p4.Instantiated:hh:mm:ss} on {p4.Instantiated:dddd, d MMMM yyyy}"); 



            BankAccount.InterestRate = 0.012M; 
            BankAccount ba1 = new BankAccount(); 
            ba1.AccountName = "Mrs. Jones"; 
            ba1.Balance = 2400; 
            WriteLine ($"{ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate:C} interest."); 
            BankAccount ba2 = new BankAccount(); 
            ba2.AccountName = "Ms. Gerrier"; 
            ba2.Balance = 98; 
            WriteLine ($"{ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate:C} interest."); 



            Tuple<string, int> fruit4 = p1.GetFruitCS4 (); 
            WriteLine ($"There are {fruit4.Item2} {fruit4.Item1}."); 
        
            (string, int) fruit7 = p1.GetFruitCS7 (); 
            WriteLine ($"{fruit7.Item1}, {fruit7.Item2} there are."); 

            var fruitNamed = p1.GetNamedFruit (); 
            WriteLine ($"Are there {fruitNamed.Number} {fruitNamed.Name}?"); 

            (string fruitName, int fruitNumber) = p1.GetFruitCS7 (); 
            WriteLine ($"Deconstructed: {fruitName}, {fruitNumber}"); 

            WriteLine (p1.SayHello ()); 
            WriteLine (p1.SayHello ("Emily")); 

            p1.OptionalParameters ();
            p1.OptionalParameters ("Jump!", 98.5); 
            p1.OptionalParameters (number: 52.7, command: "Hide!"); 
            p1.OptionalParameters ("Poke!", active: false); 

            int a = 10; 
            int b = 20; 
            int c = 30; 
            WriteLine ($"Before: a = {a}, b = {b}, c = {c}"); 
            p1.PassingParameters (a, ref b, out c); 
            WriteLine ($"After: a = {a}, b = {b}, c = {c}"); 

            // simplified C# 7 syntax for out parameters 
            int d = 10; 
            int e = 20; 
            WriteLine ($"Before: d = {d}, e = {e}, f doesn't exist yet!"); 
            p1.PassingParameters (d, ref e, out int f); 
            WriteLine ($"After: d = {d}, e = {e}, f = {f}"); 

            Person max = new Person 
            { 
                Name = "Max",  
                DateOfBirth = new DateTime (1972, 1, 27) 
            }; 

            WriteLine (max.Origin); 
            WriteLine (max.Greeting); 
            WriteLine (max.Age); 

            max.FavoriteIceCream = "Chocolate Fudge"; 
            WriteLine ($"Max's favorite ice-cream flavor is  {max.FavoriteIceCream}."); 
            max.FavoritePrimaryColor = "Red"; 
            WriteLine ($"Max's favorite primary color is  {max.FavoritePrimaryColor}."); 

            max.Children.Add(new Person { Name = "Charlie" }); 
            max.Children.Add(new Person { Name = "Ella" }); 
            WriteLine($"Max's first child is {max.Children[0].Name}"); 
            WriteLine($"Max's second child is {max.Children[1].Name}"); 
            WriteLine($"Max's first child is {max[0].Name}"); 
            WriteLine($"Max's second child is {max[1].Name}"); 


            Person harry = new Person { Name = "Harry" }; 
            Person mary = new Person { Name = "Mary" }; 
            Person baby1 = harry.Procreate (mary); 
            Person baby2 = harry * mary; 
            WriteLine ($"{harry.Name} has {mary.Children.Count} children."); 
            WriteLine ($"{mary.Name} has {mary.Children.Count} children."); 
            WriteLine ($"{harry.Name}'s first child is name \"{harry.Children[0].Name}\"."); 

            
            WriteLine($"5! is {harry.Factorial(5)}"); 


            harry.Shout += Harry_Shout;
            harry.Poke ();
            harry.Poke ();
            harry.Poke ();
            harry.Poke ();



            Person[] people =  
            { 
                new Person { Name = "Simon" }, 
                new Person { Name = "Jenny" }, 
                new Person { Name = "Adam" }, 
                new Person { Name = "Richard" } 
            }; 
        
            WriteLine ("Initial list of people:"); 
            foreach (Person person in people) 
            { 
                WriteLine ($"{person.Name}"); 
            } 
        
            WriteLine ("Use Person's sort implementation:"); 
            Array.Sort (people); 
            foreach (Person person in people) 
            { 
                WriteLine ($"{person.Name}"); 
            }

            WriteLine ("Use PersonComparer's sort implementation:"); 
            Array.Sort (people, new PersonComparer ()); 
            foreach (var Person in people) 
            { 
                WriteLine ($"{person.Name}"); 
            } 
        }

        private static void Harry_Shout (object sender, EventArgs e)
        {
            Person p = (Person) sender;
            WriteLine ($"{p.Name} is this angry: {p.AngerLevel}.");
        }
    }
}
