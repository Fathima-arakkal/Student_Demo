namespace Student_Demo.Models
{
    public class Location
    {
        public Guid LocationId { get; set; }
        public required string Name { get; set; }

        public required ICollection<Student> Students { get; set; }
        //public object Departments { get; internal set; }
        public ICollection<Department> Departments { get; set; }
    }
}
