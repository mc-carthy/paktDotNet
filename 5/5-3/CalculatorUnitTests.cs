using _5_3;
using Xunit;

namespace _5_3_CalculatorUnitTests
{
    public class CalculatorUnitTests 
    { 
        [Fact] 
        public void TestAdding2And2() 
        { 
            // arrange 
            double a = 2; 
            double b = 2; 
            double expected = 4; 
            var calc = new Calculator(); 
            // act 
            double actual = calc.Add(a, b); 
            // assert 
            Assert.Equal(expected, actual); 
        }

        [Fact] 
        public void TestAdding2And3() 
        { 
            // arrange 
            double a = 2; 
            double b = 3; 
            double expected = 5; 
            var calc = new Calculator(); 
            // act 
            double actual = calc.Add(a, b); 
            // assert 
            Assert.Equal(expected, actual); 
        } 
    }
}