using System.ComponentModel;

namespace WebApplication1.Models
{
    public class EmployeeDetailViewModel
    {
        public int Id { get; set; }
        [DisplayName("My Name")]
        public string Name { get; set; }
        [DisplayName("My Surname")]
        public string Surname { get; set; }
    }
}