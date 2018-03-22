using System;

namespace caja.Dtos
{
    public class TallyForCreationDto
    {
        public DateTime Created { get; set; }
        public decimal Final { get; set; }
        public int UserId { get; set; }
        public int TillId { get; set; }
        public TallyForCreationDto()
        {
            this.Created = DateTime.Now;
        }
    }
}