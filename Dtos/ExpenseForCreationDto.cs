namespace caja.Dtos
{
    public class ExpenseForCreationDto
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int TallyId { get; set; }
    }
}