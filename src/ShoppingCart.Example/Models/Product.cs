namespace ShoppingCart.Example.Models;

public sealed class Product
{
    public ProductId Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;

    public decimal Price { get; init; }

    private IReadOnlyCollection<ProductCategory> Categories { get; init; } = Array.Empty<ProductCategory>();
}

[StronglyTypedId]
public readonly partial struct ProductId { }