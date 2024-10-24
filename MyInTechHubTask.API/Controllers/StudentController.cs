using DataAccessLayer;
using DataAccessLayer.Migrations;
using Microsoft.AspNetCore.Mvc;
using Student = DataAccessLayer.Student;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyInTechHubTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase 
    {
        public readonly IRepos _refer;
        public StudentController(IRepos repos)
        {
            _refer= repos;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _refer.Show();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
       public Student Get(int id)
        {
             return _refer.Search(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody]Student value)
        {
          _refer.Create(value);       
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Student student)
        {
            _refer.Edit(id,student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _refer.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
