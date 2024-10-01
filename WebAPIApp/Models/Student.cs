namespace WebAPIApp.Models
{
    public class Student:Person
    {
        public string StudentNumber { get; set; }
        public int Point { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
