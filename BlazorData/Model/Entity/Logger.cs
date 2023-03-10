using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorConfiguration.Model.Entity
{
	[Table(Name = "logger")]
	public class Logger
	{
		[Column(IsIdentity = true, IsPrimary = true, Name = "id")]
		public int Id { get; set; }
		[Column(Name = "name")]
		public string Name { get; set; }
		[Column(Name = "status")]
		public int Status { get; set; }
		[Column(Name = "context")]
		public string? Context { get; set; }
		[Column(Name = "create_time")]
		public DateTime CreateTime { get; set; }
		[Column(Name = "dev_message")]
		public string? DevMessage { get; set; }
	}
}
