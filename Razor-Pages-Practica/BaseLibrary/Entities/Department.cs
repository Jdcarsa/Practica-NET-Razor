

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Department :BaseEntity
    {
        public GeneralDepartment? generalDepartment {  get; set; }
        public int generalDepartmentId { get; set; }
        [JsonIgnore]
        public List<Branch>? branches { get; set; }
    }
}
