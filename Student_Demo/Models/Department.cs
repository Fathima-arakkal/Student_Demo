namespace Student_Demo.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public required string Name { get; set; }

        public required ICollection<Student> Students { get; set; }

        public Guid LocationId { get; set; }
        public virtual required Location Location { get; set; }
    }
}
