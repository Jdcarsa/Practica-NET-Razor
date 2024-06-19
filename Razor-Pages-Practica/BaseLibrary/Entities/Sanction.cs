using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Sanction : OtherBaseEntity
    {
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string Punishment {  get; set; } = string.Empty;
        [Required]
        public DateTime PunishmentDate { get; set; }

        public SactionType? SactionType { get; set; }
    }
}