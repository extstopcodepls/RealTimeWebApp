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
				new Product { Id = 1, Name = "Szusarka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0},
				new Product { Id = 2, Name = "Szusareczka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0},
				new Product { Id = 3, Name = "Szusarka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0},
				new Product { Id = 4, Name = "Szusarka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0},
				new Product { Id = 5, Name = "Szusarka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0},
				new Product { Id = 6, Name = "Szusarka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0},
				new Product { Id = 7, Name = "Szusarka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0},
				new Product { Id = 8, Name = "Szusarka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0},
				new Product { Id = 9, Name = "Szusarka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0},
				new Product { Id = 10, Name = "Szusarka", Desc = "Przepiękny opis tej Szusarki, jako, że najlepszy produkt na wigilijnym stole", Price = "999,99 Zł, bo Mango", UpVote = 0, DownVote = 0}
			};
		}
	}
}