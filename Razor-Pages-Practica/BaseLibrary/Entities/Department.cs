

namespace BaseLibrary.Entities
{
    public class Department :BaseEntity
    {
        public GeneralDepartment? generalDepartment {  get; set; }
        public int generalDepartmentId { get; set; }

        public List<Branch>? branches { get; set; }
    }
}
