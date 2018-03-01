namespace caja.Models
{
    public class TallyEarning
    {
        public int TallyId { get; set; }
        public int EarningId { get; set; }
        public Tally Tally { get; set; }
        public Earning Earning { get; set; }
    }
}