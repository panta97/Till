namespace caja.Dtos
{
    public class ExpenseForUpdateDto
    {
        public int TallyId { get; set; }
        public int ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}