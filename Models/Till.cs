using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace caja.Models
{
    public class Till
    {
        public int Id { get; set; }
        public string Store { get; set; }
        public int Number { get; set; }
        public ICollection<Tally> Tallies { get; set; }

        public Till()
        {
            Tallies = new Collection<Tally>();
        }
    }
}