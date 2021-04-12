namespace SplittingTheBill.POCOS
{
    public class PersonExpenses
    {
        public int PersonId { get; set; }
        public decimal Amount { get; set; }
        public PersonExpenses(int personId, decimal amount)
        {
            PersonId = personId;
            Amount = amount;
        }
    }
}