using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllByKeyAsync(string key = "");
        Task AddAsync(Student student);
    }
}
