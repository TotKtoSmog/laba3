
using System.Collections.Generic;
using System.Linq;

namespace laba3.Task1
{
    public class DepartmentStatistic
    {
        public string department { get; set; }
        public List<string> post { get; set; }
        public int allCountEmployees { get; set; }
        public int countEmployees { get; set; }
        public DepartmentStatistic() { }
        public DepartmentStatistic(string department, string post) 
        { 
            this.department = department;
            this.post = new List<string>();
            this.post.Add(post);
        }
    }
}
