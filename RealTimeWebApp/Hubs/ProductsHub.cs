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

		public void ResetUpvotes(int id)
		{
			var product = DataRepository.Products.SingleOrDefault(p => p.Id == id);
			product.DownVote = 0;
			product.UpVote = 0;

			Clients.All.updateProducts(DataRepository.Products);
		}

		public void RemoveProduct(int id)
		{
			var productToRemove = DataRepository.Products.SingleOrDefault(p => p.Id == id);
			DataRepository.Products.Remove(productToRemove);
			Clients.All.updateProducts(DataRepository.Products);
		}

		public void AddProduct(string name, string description, string price)
		{
			var newLastId = DataRepository.Products.Last().Id + 1;
			DataRepository.Products.Add(new Product { Id = newLastId, Name = name, Desc = description, Price = price, DownVote = 0, UpVote = 0 });

			Clients.All.updateProducts(DataRepository.Products);
			Clients.All.addedProduct();
		}

	}
}