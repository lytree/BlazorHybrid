using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorConfiguration.Model.Entity
{
    [Table(Name = "menu")]
    public class Menu
    {
        [Column(IsIdentity = true, IsPrimary = true,Name = "id")]
        public int Id { get; set; }
         [Column(Name = "path")]
        public string Path { get; set; }
         [Column(Name = "name")]
        public string Name { get; set; }
         [Column(Name = "key")]
        public string Key { get; set; }
         [Column(Name = "icon")]
        public string? Icon { get; set; }
         [Column(Name = "parent")]
        public int Parent { get; set; }
    }
}
