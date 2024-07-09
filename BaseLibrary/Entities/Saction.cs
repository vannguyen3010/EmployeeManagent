using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Saction : OtherBaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Punishment { get; set; } = string.Empty;
        [Required]
        public DateTime PunishmentDate { get; set; }

        //Many to one relationship with Vacation Type
        public SactionType? SactionType { get; set; }
        [Required]
        public int SactionTypeId { get; set; }
    }
}
