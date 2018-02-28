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
        public ICollection<Earning> Earnings { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        
        public Tally()
        {
            Earnings = new Collection<Earning>();
            Expenses = new Collection<Expense>();
        } 
    }
}