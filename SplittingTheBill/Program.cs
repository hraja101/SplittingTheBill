using System;
using System.Collections.Generic;
using System.IO;

namespace SplittingTheBill
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Supply the FileName:");
            var fileName = Console.ReadLine();
            
            string newPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../", "InputOutput"));
            string inputFilePath = Path.Combine(newPath, fileName ?? throw new InvalidOperationException());
            string outputFilePath = Path.Combine(newPath, fileName + ".out");

            //TODO-Separation of concerns, Move the file read and write to separate blocks
            //Not an ideal way to deal with reading files, what If the file is huge ?? use databases and stream it.
            List<string> allRows = new List<string>(File.ReadAllLines(inputFilePath));
            var expenseCalculator = new ExpenseCalculator();
            
            var trips = expenseCalculator.Calculate(allRows);

            using (var stream = new StreamWriter(outputFilePath))
            {
                foreach (var trip in trips)
                {
                    for (var person = 1; person <= trip.NumberOfPersons; person++)
                    {
                        var amountPerPerson = trip.AmountPerPerson(person) ;
                        var share = amountPerPerson > 0
                            ? "$" + amountPerPerson
                            : $"(${Math.Abs(amountPerPerson)})";
                        
                        stream.WriteLine(share);
                    }
                    stream.WriteLine("");
                }
            }
        }
    }
}