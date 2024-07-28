using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public class EFStudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public EFStudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync(string key)
        {
            var keyCode=key.ToLower();
            return await _context.Students.Where(i=>i.Firstname.ToLower().Contains(keyCode)).ToListAsync();
        }
    }
}
