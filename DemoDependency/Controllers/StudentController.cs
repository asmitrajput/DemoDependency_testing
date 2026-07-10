using DemoDependency.Models;
using DemoDependency.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDependency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // here is the dependency injection of service class
        // creating a private readonly field to hold the instance of IStudentRepo
        // IStudentRepo is injected through the constructor.
        // IStudentRepo is the interface that defines the contract for student-related operations.
        private readonly IStudentRepo _studentService;

        // Constructor that accepts an IStudentRepo instance
        // This instance is provided by the dependency injection container.
        // The constructor initializes the _studentService field with the provided instance.
        // This allows the controller to use the methods defined in the IStudentRepo interface.
        public StudentController(IStudentRepo _studentRepo)
        {
            this._studentService = _studentRepo;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDetails()
        {
            var totalstudent = await _studentService.GetAllStudentsDetails();
            return Ok(totalstudent);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetStudentDataById(int id)
        {
            var student = await _studentService.GetStudentById(id);
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudentDetails(Student _std)
        {
            await _studentService.AddStudent(_std);
            return Ok("Student Added Successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatedStdDetails(Student _stdUpdate)
        {
            await _studentService.UpdateStudentDetail(_stdUpdate);
            return Ok("Student Updated Successfully");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStudentDetails(int id)
        {
            await _studentService.DeleteStudent(id);
            return Ok("Student Deleted Successfully");
        }

    }
}
