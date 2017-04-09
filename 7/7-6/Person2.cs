using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.CS7
{
    public partial class Person : System.Object, IComparable<Person>
    {
        // property defined using C# 1 - 5 syntax 
        public string Origin 
        { 
            get 
            { 
                return $"{Name} was born on {HomePlanet}"; 
            } 
        } 
    
        // two properties defined using C# 6+ lambda expression syntax 
        public string Greeting => $"{Name} says 'Hello!'";  
    
        public int Age => (int) (System.DateTime.Today.Subtract (DateOfBirth).TotalDays / 365.25); 

        public string FavoriteIceCream { get; set; } // auto-syntax 

        private string favoritePrimaryColor; 
        public string FavoritePrimaryColor 
        { 
            get 
            { 
                return favoritePrimaryColor; 
            } 
            set 
            { 
                switch (value.ToLower()) 
                { 
                    case "red": 
                    case "green": 
                    case "blue": 
                        favoritePrimaryColor = value; 
                        break; 
                    default: 
                        throw new System.ArgumentException($"{value} is not a primary color. Choose from: red, green, blue."); 
                } 
            } 
        }

        // indexers 
        public Person this[int index] 
        { 
            get 
            { 
                return Children[index]; 
            } 
            set 
            { 
                Children[index] = value; 
            } 
        }


        // method to "multiply" 
        public Person Procreate (Person partner) 
        { 
            Person baby = new Person  
            {  
                Name = $"Baby of {this.Name} and {partner.Name}"
            };
            this.Children.Add (baby); 
            partner.Children.Add (baby); 
            return baby; 
        }

        // operator to "multiply" 
        public static Person operator *(Person p1, Person p2) 
        { 
           return p1.Procreate (p2); 
        } 

        // method with a local function 
        public int Factorial (int number) 
        { 
            if (number < 0) 
            { 
                throw new ArgumentException ($"{nameof(number)} cannot be less than zero."); 
            } 
        
            int localFactorial (int localNumber) 
            { 
                if (localNumber < 1) 
                {
                    return 1; 
                }
                return localNumber * localFactorial (localNumber - 1); 
            } 
        
            return localFactorial (number); 
        }

        // event 
        public event EventHandler Shout; 
        // field 
        public int AngerLevel; 
        // method 
        public void Poke() 
        { 
            AngerLevel++; 
            if (AngerLevel >= 3) 
            { 
                // if something is listening... 
                if (Shout != null) 
                { 
                    // ...then raise the event 
                    Shout (this, EventArgs.Empty); 
                } 
            } 
        }

        public int CompareTo (Person other) 
        { 
            return Name.CompareTo (other.Name); 
        }

        public override string ToString ()
        {
            return $"{Name} is a {base.ToString ()}";
        }

        public void TimeTravel (DateTime when) 
        { 
        if (when <= DateOfBirth) 
            { 
                throw new PersonException ("If you travel back in time to a date earlier than your own birth then the universe will explode!"); 
            } 
            else 
            { 
                WriteLine ($"Welcome to {when:yyyy}!"); 
            } 
        } 
    }
}