namespace ShoppingCart.Example.Models;

public sealed class Cart
{
    public CartId Id { get; init; }
}

[StronglyTypedId]
public readonly partial struct CartId { } 