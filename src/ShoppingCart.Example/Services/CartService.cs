using Ardalis.GuardClauses;

using ShoppingCart.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Example.Services;

public sealed class CartService : ICartService
{
	public ICart AddToCart(ICart cart, Product product)
	{
		var item = cart.Items.AsQueryable()
			.FirstOrDefault(existingItem => existingItem.ProductId == product.Id);

		if (item is null)
		{
			cart.Items.Add(new CartItem
			{
				Created = DateTime.UtcNow,
				Product = product,
				Quantity = 1
			});
		}
		else
		{
			item.Quantity++;
		}

		return cart;
	}

	public ICart SetQuantity(ICart cart, Product product, int quantity)
	{
		Guard.Against.Negative(quantity);
		if (quantity == 0) return RemoveFromCart(cart, product);

		var item = cart.Items.AsQueryable()
			.FirstOrDefault(existingItem => existingItem.ProductId == product.Id);

		if (item is null)
		{
			cart.Items.Add(new CartItem
			{
				Created = DateTime.UtcNow,
				Product = product,
				Quantity = quantity
			});
		}
		else
		{
			item.Quantity = quantity;
		}

		return cart;
	}

	public ICart RemoveFromCart(ICart cart, Product product)
	{
		var item = cart.Items.AsQueryable()
			.FirstOrDefault(existingItem => existingItem.ProductId == product.Id);

		if (item is not null)
		{
			cart.Items.Remove(item);
		}

		return cart;
	}
}
