using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication1.Entities;

namespace WebApplication1.TagHelpers
{
    [HtmlTargetElement("employee-list")]
    public class EmployeeListTagHelper:TagHelper
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>
        {
             new Employee
                {
                    Id=1,
                     Firstname="Ali",
                      Lastname="Aliyev",
                      CityId=1
                },
                new Employee
                {
                    Id=2,
                     Firstname="Huseyn",
                      Lastname="Huseynov",
                      CityId=10
                },
                new Employee
                {
                    Id=3,
                     Firstname="Ruad",
                      Lastname="Dunyamaliyev",
                      CityId=77
                }
        };

        private const string ListCountAttribute = "count";
        [HtmlAttributeName(ListCountAttribute)]
        public int ListCount { get; set; }

        private const string SortAttribute = "sort";
        [HtmlAttributeName(SortAttribute)]
        public string Sort { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            StringBuilder sb = new StringBuilder();
            var query = Employees.Take(ListCount);

            if (Sort.ToLower() == "a-z")
            {
                query = query.OrderBy(e => e.Firstname);
            }
            else if(Sort.ToLower() == "z-a")
            {
                query = query.OrderByDescending(e => e.Firstname);
            }

            foreach (var employee in query)
            {
                sb.AppendFormat("<h2><a href='/home/GetById/{0}'>{1}</a></h2>",employee.Id,employee.Firstname);
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
