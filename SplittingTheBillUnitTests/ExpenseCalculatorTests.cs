using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using SplittingTheBill;
using SplittingTheBill.POCOS;

namespace SplittingTheBillUnitTests
{
    [TestFixture]
    public class ExpenseCalculatorTests
    {
        [Test]
        public void Expenses_Not_Null()
        {
            //Better way, if read and write operations from input/output file were separated from Program.cs (separation of concerns)
            //Mock the file reading and writing test cases 
            var allRows = new List<string> { "2", "2", "10.00", "20.00", "1", "15.00", "0" };
            var expenseCalculator = new ExpenseCalculator();
            var trips = expenseCalculator.Calculate(allRows);

            foreach (var trip in trips)
            {
                Assert.NotNull(trip.Expenses);
            }
        }
        
        [Test]
        public void Calculate_Total_Expenses()
        {

            var currentTrip = new CampingExpenses(3);
            currentTrip.Expenses.Add(new PersonExpenses(1, 10.12m));
            currentTrip.Expenses.Add(new PersonExpenses(1, 32.00m));
            currentTrip.Expenses.Add(new PersonExpenses(2, 43.72m));
            currentTrip.Expenses.Add(new PersonExpenses(2, 17.12m));
            currentTrip.Expenses.Add(new PersonExpenses(3, 22.25m));
            currentTrip.Expenses.Add(new PersonExpenses(3, 35.75m));
            currentTrip.Expenses.Add(new PersonExpenses(3, 14.91m));
            
            Assert.AreEqual(currentTrip.NumberOfPersons , 3);
            Assert.AreEqual(currentTrip.TotalExpenses(),175.87m);
        }
        
        [Test]
        public void Calculate_Expenses_PaidByPerson()
        {

            var currentTrip = new CampingExpenses(3);
            currentTrip.Expenses.Add(new PersonExpenses(1, 10.18m));
            currentTrip.Expenses.Add(new PersonExpenses(1, 17.00m));
            currentTrip.Expenses.Add(new PersonExpenses(2, 19.48m));
            currentTrip.Expenses.Add(new PersonExpenses(2, 34.33m));
            currentTrip.Expenses.Add(new PersonExpenses(2, 16.25m));
            currentTrip.Expenses.Add(new PersonExpenses(3, 28.42m));
            currentTrip.Expenses.Add(new PersonExpenses(3, 12.19m));
            currentTrip.Expenses.Add(new PersonExpenses(3, 14.91m));
            
            Assert.AreEqual(currentTrip.ExpensesPaidByPerson(1) , 27.18m);
            Assert.AreEqual(currentTrip.ExpensesPaidByPerson(2) , 70.06);
            Assert.AreEqual(currentTrip.ExpensesPaidByPerson(3) , 55.52);
        }
        
        [Test]
        public void Calculate_PerPerson_Expenses()
        {

            var currentTrip = new CampingExpenses(2);
            currentTrip.Expenses.Add(new PersonExpenses(1, 12.32m));
            currentTrip.Expenses.Add(new PersonExpenses(1, 14.64m));
            currentTrip.Expenses.Add(new PersonExpenses(1, 23.72m));
            currentTrip.Expenses.Add(new PersonExpenses(2, 18.42m));
            currentTrip.Expenses.Add(new PersonExpenses(2, 26.52m));

            var firstPersonAmount = currentTrip.AmountPerPerson(1);
            var secondPersonAmount = currentTrip.AmountPerPerson(2);
            
            Assert.AreEqual(firstPersonAmount, -2.87m);
            Assert.AreEqual(secondPersonAmount, 2.87m);

        }
    }
}