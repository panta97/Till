using System.Collections.Generic;
using System.Collections.ObjectModel;
using caja.Models;

namespace caja.Models
{
    public class Till
    {
        public int Id { get; set; }
        public Store Store { get; set; }
        public int StoreId { get; set; }
        public int Number { get; set; }
        public ICollection<Tally> Tallies { get; set; }

        public Till()
        {
            Tallies = new Collection<Tally>();
        }
    }
}