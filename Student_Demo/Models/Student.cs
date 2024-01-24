namespace Student_Demo.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Division Division { get; set; }


        public Guid DepartmentId { get; set; } = Guid.Empty;
      
        public virtual required Department Department { get; set; }
       
    }
}
