using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection.Metadata.Ecma335;

namespace WebAPIApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
