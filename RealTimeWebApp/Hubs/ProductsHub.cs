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

		public void UpdateVotes(int id, bool doUpvote)
		{
			if (doUpvote)
			{
				DataRepository.Products.ElementAt(id).UpVote++;
			}
			else
			{
				DataRepository.Products.ElementAt(id).DownVote++;		
			}

			Clients.All.updateProducts(DataRepository.Products);
		}
	}
}