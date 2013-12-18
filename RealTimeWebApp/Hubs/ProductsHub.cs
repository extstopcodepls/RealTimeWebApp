using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using RealTimeWebApp.DataSource;

namespace RealTimeWebApp.Hubs
{
	public class ProductsHub : Hub
	{
		public IEnumerable<Product> GetAllProducts()
		{
			return DataRepository.Products;
		}

		public void UpdateVotes(int id)
		{
			Clients.All.updateProducts(DataRepository.Products);
		}
	}
}