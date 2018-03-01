using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace caja.Models
{
    public class Earning
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Denomination { get; set; }
        public decimal Amount { get; set; }
        public ICollection<TallyEarning> Tally { get; set; }
        public int TallyId { get; set; }
    }
}