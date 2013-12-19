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
				new Product { Id = 1, Name = "Suszarka", Desc = "Opis suszarki", Price = "999,99 Zł", UpVote = 0, DownVote = 0},
				new Product { Id = 2, Name = "Pralka", Desc = "Opis pralki", Price = "999,99 Zł", UpVote = 0, DownVote = 0},
				new Product { Id = 3, Name = "Widelec", Desc = "Opis widelca", Price = "999,99 Zł", UpVote = 0, DownVote = 0},
				new Product { Id = 4, Name = "Nóż", Desc = "Opis noża", Price = "999,99 Zł", UpVote = 0, DownVote = 0},
				new Product { Id = 5, Name = "A Nuż", Desc = "Opis a nuż", Price = "999,99 Zł", UpVote = 0, DownVote = 0},
				new Product { Id = 6, Name = "Talerzyk", Desc = "Opis talerzyka", Price = "999,99 Zł", UpVote = 0, DownVote = 0},
				new Product { Id = 7, Name = "Miseczka", Desc = "Opis miseczki", Price = "999,99 Zł", UpVote = 0, DownVote = 0}
			};
		}
	}
}