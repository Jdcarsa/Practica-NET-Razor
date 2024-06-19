using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Vacation : OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required, Display(Name = "Number of days")]
        public int NumberOfDays { get; set; }
        [Required]
        public DateTime EndDate => StartDate.AddDays(NumberOfDays);

        [Required]
        public VacationType? VacationType { get; set; }

        [Required]
        public int VacationTypeId { get; set; }

    }

}