using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIApp.Data;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly CustomDbContext _dbContext;


        public TeachersController(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public Teacher Create(Teacher item)
        {

            _dbContext.Teachers.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        [HttpGet]
        public List<Teacher> GetTeachers()
        {
            var teachers = _dbContext.Teachers.ToList();
            return teachers;

        }

        [HttpGet("{id}")]
        public Teacher GetTeacher(int id)
        {
            var teacher = _dbContext.Teachers.Where(x=>x.Id==id).FirstOrDefault();
            return teacher;

        }

        [HttpDelete("{id}")]
        public Teacher DeleteTeacher(int id)
        {
            var teacher = _dbContext.Teachers.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Remove(teacher);
            _dbContext.SaveChanges();
            return teacher;

        }

        [HttpPut("{id}")]
        public Teacher UpdateTeacher(int id,Teacher item)
        {
            var teacher = _dbContext.Teachers.Where(x => x.Id == id).FirstOrDefault();
            teacher.Name = item.Name;
            teacher.Surname = item.Surname;
            teacher.Fathername = item.Fathername;

            _dbContext.Update(teacher);
            _dbContext.SaveChanges();
            return teacher;

        }
    }
}
