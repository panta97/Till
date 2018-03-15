using System.Collections.Generic;
using System.Collections.ObjectModel;
using caja.Models;

namespace caja.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Till> Tills { get; set; }
        public Store()
        {
            Tills = new Collection<Till>();
        }
    }
}