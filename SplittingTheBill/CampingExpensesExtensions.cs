using System;
using System.Linq;
using SplittingTheBill.POCOS;

namespace SplittingTheBill
{

    public static class CampingExpensesExtensions
    {
        public static decimal TotalExpenses(this CampingExpenses campingExpenses)
        {
            return campingExpenses.Expenses.Sum(p => p.Amount);
        }

        private static decimal AverageExpenses(this CampingExpenses campingExpenses)
        {
            return TotalExpenses(campingExpenses) / campingExpenses.NumberOfPersons;
        }

        public static decimal ExpensesPaidByPerson(this CampingExpenses campingExpenses, int personId)
        {
            return campingExpenses.Expenses.Where(p => p.PersonId == personId).Sum(x => x.Amount);
        }

        public static decimal AmountPerPerson(this CampingExpenses campingExpenses, int personId)
        {
            return decimal.Round(AverageExpenses(campingExpenses) - ExpensesPaidByPerson(campingExpenses, personId), 2,
                MidpointRounding.ToEven);
        }
    }
}