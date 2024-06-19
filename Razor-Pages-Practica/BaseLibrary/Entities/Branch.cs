

namespace BaseLibrary.Entities
{
    public class Branch : BaseEntity
    {
        public Department? Department { get; set; }
        public int departmentId {  get; set; }

        public List<Employee>? Employees { get; set; }
    }
}
