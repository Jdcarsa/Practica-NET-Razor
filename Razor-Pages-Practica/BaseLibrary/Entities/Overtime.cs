

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Overtime : OtherBaseEntity
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public int NumberDays => (EndTime - StartTime).Days;
        public OvertimeType? OvertimeType { get; set; }
        public int OvertimeTypeId { get; set; }
    }
}
