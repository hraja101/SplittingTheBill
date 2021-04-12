using System.Collections.Generic;

namespace SplittingTheBill.POCOS
{
    public class CampingExpenses
    {
        public int NumberOfPersons { get; set; }
        public List<PersonExpenses> Expenses { get; set; }

        public CampingExpenses(int numberOfPersons)
        {
            NumberOfPersons = numberOfPersons;
            Expenses = new List<PersonExpenses>();
        }
    }
}