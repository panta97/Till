namespace caja.Models
{
    public class TallyExpense
    {
        public int TallyId { get; set; }
        public int ExpenseId { get; set; }
        public Tally Tally { get; set; }
        public Expense Expense { get; set; }
    }
}