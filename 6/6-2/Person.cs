﻿using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.CS7
{
    public partial class Person : System.Object
    {
        public const string Species = "Homo Sapien";

        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;

        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavouriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person> ();

        public Person ()
        {
            Name = "Unkown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName) 
        { 
            Name = initialName; 
            Instantiated = DateTime.Now; 
        }

        public void WriteToConsole ()
        {
            WriteLine ($"{Name} was born on {DateOfBirth:dddd, d MMMM, yyyy}");
        }

        public string GetOrigin ()
        {
            return $"{Name} was born on {HomePlanet}";
        }

        // the old C# 4 and .NET 4.0 System.Tuple type 
        public Tuple<string, int> GetFruitCS4 () 
        { 
            return Tuple.Create ("Apples", 5); 
        } 
    
        // the new C# 7 syntax and new System.ValueTuple type 
        public (string, int) GetFruitCS7 () 
        { 
            return ("Apples", 5); 
        } 

        public (string Name, int Number) GetNamedFruit () 
        { 
            return (Name: "Apples", Number: 5); 
        }

        public string SayHello () 
        { 
            return $"{Name} says 'Hello!'"; 
        } 
    
        public string SayHello (string name) 
        { 
            return $"{Name} says 'Hello {name}!'"; 
        }

        public void OptionalParameters (string command = "Run!", double number = 0.0, bool active = true) 
        { 
            WriteLine($"Command is {command}, number is {number}, active is {active}"); 
        } 

        public void PassingParameters (int x, ref int y, out int z) 
        { 
            // out parameters cannot have a default  
            // AND must be initialized inside the method 
            z = 99; 
        
            // increment each parameter 
            x++; 
            y++; 
            z++; 
        } 
    }
}
