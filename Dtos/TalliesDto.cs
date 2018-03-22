using System;

namespace caja.Dtos
{
    public class TalliesDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal Final { get; set; }
        public int UserId { get; set; }
        public int TillId { get; set; }
    }
}
