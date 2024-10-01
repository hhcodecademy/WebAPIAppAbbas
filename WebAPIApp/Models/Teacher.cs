using Microsoft.EntityFrameworkCore;

namespace WebAPIApp.Models
{
    public class Teacher:Person
    {
        [Precision(18, 2)]
        public decimal Salary { get; set; }
        public int Grade { get; set; }
    }
}
