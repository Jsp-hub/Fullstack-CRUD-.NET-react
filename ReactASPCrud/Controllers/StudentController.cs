using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactASPCrud.Models;

namespace ReactASPCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("getstudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Students.ToListAsync();
        }

        [HttpPost]
        [Route("addstudent")]
        public async Task<Student> AddStudent(Student objStudent)
        {
            _studentDbContext.Students.Add(objStudent);
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpPatch]
        [Route("updatestudent/{id}")]
        public async Task<Student> UpdateStudent(Student objStudent)
        {
            _studentDbContext.Entry(objStudent).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpDelete]
        [Route("deletstudent/{id}")]
        public bool DeleteStudent(int id)
        {
            bool a = false;
            var student = _studentDbContext.Students.Find(id);
            if (student != null)
            {
                a = true;
                _studentDbContext.Entry(student).State = EntityState.Deleted;
                _studentDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;


        }

    }
}
