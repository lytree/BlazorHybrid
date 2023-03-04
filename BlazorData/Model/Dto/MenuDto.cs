using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlazorConfiguration.Model.Dto
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string? Icon { get; set; }
        public List<MenuDto>? Children { get; set; }
    }
}
