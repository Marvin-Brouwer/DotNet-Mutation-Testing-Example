namespace ShoppingCart.Models;

public sealed class Product
{
    public ProductId Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;

    public decimal Price { get; init; }
}

// This is just int to make the tests easier
[StronglyTypedId(generateJsonConverter: false, backingType: StronglyTypedIdBackingType.Int)]
public readonly partial struct ProductId { }