using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace caja.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Tally Tally { get; set; }
        public int TallyId { get; set; }
    }
}