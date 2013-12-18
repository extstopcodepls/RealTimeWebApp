using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealTimeWebApp.DataSource
{
	public class Product
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public String Desc { get; set; }
		public String Price { get; set; }
		public int UpVote { get; set; }
		public int DownVote { get; set; }
	}
}
