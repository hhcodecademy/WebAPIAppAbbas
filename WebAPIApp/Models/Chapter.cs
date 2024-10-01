using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace WebAPIApp.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public int Hour { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
