using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealTimeWebApp.DataSource
{
	public class DataRepository
	{
		public static List<Product> Products { get; set; }

		static DataRepository()
		{
			Products = new List<Product>
			{
				new Product { id = 1, Name = "LOL", Desc = "Trololol trolololo rlolololrolo rloloo", Price = "12,12", UpVote = 0, DownVote = 0}
			};
		}
	}
}