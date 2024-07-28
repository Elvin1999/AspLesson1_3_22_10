using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
        }

        public async Task<List<Student>> GetAllByKeyAsync(string key = "")
        {
            return await _studentRepository.GetAllAsync(key);
        }
    }
}
