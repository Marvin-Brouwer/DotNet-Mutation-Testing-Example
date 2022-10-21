namespace ShoppingCart.Models;

public interface ICart
{
	CartId Id { get; init; }
	HashSet<CartItem> Items { get; }
}