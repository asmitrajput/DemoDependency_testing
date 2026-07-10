using DemoDependency.Models;

namespace DemoDependency.Services
{
    
    public interface IStudentRepo 
    {
        Task<List<Student>> GetAllStudentsDetails();
        Task<Student> GetStudentById(int id);
        Task AddStudent(Student ob);
        Task UpdateStudentDetail(Student _objUpdate);
        Task DeleteStudent(int id);

    }
}
