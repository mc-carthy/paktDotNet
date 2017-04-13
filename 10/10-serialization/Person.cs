using System; 
using System.Collections.Generic; 
using System.Xml.Serialization;

namespace _10_serialization 
{ 
    public class Person 
    { 
        public Person () { }
        public Person(decimal initialSalary) 
        { 
            Salary = initialSalary; 
        } 

        [XmlAttributeAttribute("fname")]
        public string FirstName { get; set; } 
        [XmlAttributeAttribute("lname")]
        public string LastName { get; set; } 
        [XmlAttributeAttribute("dob")]
        public DateTime DateOfBirth { get; set; } 
        public HashSet<Person> Children { get; set; } 
        protected decimal Salary { get; set; } 
    } 
} 