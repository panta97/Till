using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace caja.Models
{
    public class Tally
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal Final { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Till Till { get; set; }
        public int TillId { get; set; }
        public ICollection<TallyEarning> Earnings { get; set; }
        public ICollection<TallyExpense> Expenses { get; set; }
    }
}