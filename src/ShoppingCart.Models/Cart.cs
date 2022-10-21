namespace ShoppingCart.Models;

public sealed class Cart : ICart
{
	public CartId Id { get; init; }

    public HashSet<CartItem> Items { get; } = new();
}

[StronglyTypedId(generateJsonConverter: false)]
public readonly partial struct CartId { } 