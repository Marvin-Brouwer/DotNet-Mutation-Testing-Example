using ShoppingCart.Models;

namespace ShoppingCart.Example.Services;

public sealed class OrderService
{
	private readonly ICart _cart;

	public OrderService(ICart cart)
	{
		_cart = cart;
	}

	public bool CanOrder => _cart.Items.Any((item) => item.Quantity > 0);

	// public void SubmitOrder() => throw new NotImplementedException("This is out of scope for the example");
}
