namespace WebAPIApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
        public ICollection<Student> Students { get; set; }


    }
}
