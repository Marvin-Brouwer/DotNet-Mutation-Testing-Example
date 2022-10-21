using ShoppingCart.Models;

namespace ShoppingCart.Example.Services;

public interface ICartService
{
	ICart AddToCart(ICart cart, Product product);
	ICart SetQuantity(ICart cart, Product product, int quantity);
	ICart RemoveFromCart(ICart cart, Product product);
}