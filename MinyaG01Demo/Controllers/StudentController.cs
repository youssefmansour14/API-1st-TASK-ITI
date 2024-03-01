using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinyaG01Demo.Entities;
using MinyaG01Demo.Models;

namespace MinyaG01Demo.Controllers
{
    [Route("api/[controller]")]//Domain/Student => URL + Verb
    [ApiController]
    public class StudentController : ControllerBase //Res according Status Code
    {


        CompanyContext db;

        public StudentController(CompanyContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> debtList = db.Student.ToList();
            return Ok(debtList);
        }
        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            // Student debt = db.Student.Find(id);
            Student dept = db.Student.FirstOrDefault(d => d.Id == id);
            if (dept != null)
            {
               //List<Student> debtList = db.Student.ToList();
                return Ok(dept);
            }
            return BadRequest();

        }
        [HttpGet("{name:alpha}")] //Domain/Employee/{name}
        public IActionResult GetByName(string name)
        {
            Student debt = db.Student.FirstOrDefault(d => d.Name == name);
            return Ok(debt);
        }
 
        [HttpPost]
        public IActionResult AddStudent(Student dept)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(dept);
                db.SaveChanges();
                // return Ok(db.Student.ToList());
                string url = Url.Link("GetOne", new { id = dept.Id });
                //return Created("http://localhost:5007/api/Student/" + dept.Id, dept);
                return Created(url, new { department = dept, message = "Student Added Succefully" });
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Update(Student dept, int id)//Primitive DT => Route Data / Query string | Complex => Body
        {
            if (ModelState.IsValid)
            {
                // db.Student.Update(dept);
                Student OldDept = db.Student.Find(id);
                if (OldDept != null)
                {
                    OldDept.Name = dept.Name;
                    db.SaveChanges();
                    return NoContent();
                }



                //return StatusCode(204,
                //    new{Message="Student Updated Successfully",dept=dept.Id});
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            Student dept = db.Student.Find(id);
            if (dept != null)
            {
                db.Student.Remove(dept);
                db.SaveChanges();
                return Ok(new
                {
                    message = $"Student with id  = {dept.Id} deleted !!",
                    dept = dept,
                    depts = db.Student.ToList()
                });

            }
            return NotFound();

        }
        //public IActionResult PostDept()
        //{

        //}
    }
}
