using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SplittingTheBill.POCOS;

namespace SplittingTheBill
{
    public class ExpenseCalculator
    {
        private List<CampingExpenses> CampingExpensesList { get; set; }
        private int _rowNumber = 0;

        public ExpenseCalculator()
        {
            CampingExpensesList = new List<CampingExpenses>();
        }

        public List<CampingExpenses> Calculate(List<string> allRows)
        {
            try
            {
                if (allRows.Any())
                {
                    while (true)
                    {
                        if (Convert.ToInt32(allRows[_rowNumber]) == 0)
                        {
                            break;
                        }

                        CampingExpenses currentTrip = new CampingExpenses(Convert.ToInt32(allRows[_rowNumber]));
                        ProcessCurrentTrip(currentTrip, allRows);
                        CampingExpensesList.Add(currentTrip);
                        _rowNumber++;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("processing error: {0}", ex.ToString());
            }

            return CampingExpensesList;
        }
        
        private void ProcessCurrentTrip(CampingExpenses currentTrip, List<string> lines)
        {
            for (var personIndex = 1; personIndex <= currentTrip.NumberOfPersons; personIndex++)
            {
               _rowNumber++;
                int personWithExpenseCount = Convert.ToInt32(lines[_rowNumber]);
                for (var personWithExpenseIndex = 1; personWithExpenseIndex <= personWithExpenseCount; personWithExpenseIndex++)
                {
                    _rowNumber++;
                    currentTrip.Expenses.Add( new PersonExpenses(personIndex, Convert.ToDecimal(lines[_rowNumber])));
                }
            }
        }
    }
}
