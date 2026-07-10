using DemoDependency.Database;
using DemoDependency.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoDependency.Services
{
    public class StudentService : IStudentRepo
    {
        //step 1: Dependency Injection of DbContext
        // Creating a private readonly field to hold the instance of StudentDbContext
        // This field will be initialized through the constructor.
        private readonly StudentDbContext _studentDbContext;

        public StudentService(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;

        }

        public async Task<List<Student>> GetAllStudentsDetails()
        {
            return await _studentDbContext.Students.ToListAsync();
        }
        public Task<Student> GetStudentById(int stid)
        {
            var studentDataByid = _studentDbContext.Students.FirstOrDefaultAsync(s => s.Id == stid);
            return studentDataByid;
        }
        public async Task AddStudent(Student ob)
        {
            await _studentDbContext.Students.AddAsync(ob);
            await _studentDbContext.SaveChangesAsync();
        }

        public async Task UpdateStudentDetail(Student _objUpdate)
        {
            var existingStudent = _studentDbContext.Students.FirstOrDefault(s => s.Id == _objUpdate.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = _objUpdate.Name;
                existingStudent.Email = _objUpdate.Email;
                // Update other properties as needed

                await _studentDbContext.SaveChangesAsync();
            }

        }

        public async Task DeleteStudent(int id)
        {
            //var product = await _studentDbContext.Students.FindAsync(id);
            //if (product != null)
            //{
            //    _studentDbContext.Students.Remove(product);
            //    await _studentDbContext.SaveChangesAsync();
            //}
            var studentToDelete = await _studentDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (studentToDelete != null)
            {
                _studentDbContext.Students.Remove(studentToDelete);
                await _studentDbContext.SaveChangesAsync();
            }
        }
    }
}
