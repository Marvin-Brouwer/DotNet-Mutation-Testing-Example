namespace ShoppingCart.Models;

public sealed class CartItem
{
    public CartItemId Id { get; init; }

    public int Quantity { get; set; }

	public DateTime Created { get; init; }

	public ProductId ProductId => Product.Id;
	public Product Product { get; init; } = default!;
}

[StronglyTypedId(generateJsonConverter: false)]
public readonly partial struct CartItemId { } 