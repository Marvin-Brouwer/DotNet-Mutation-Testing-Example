namespace ShoppingCart.Example.Models;

public sealed class ProductCategory
{
    public ProductCategoryId Id { get; init; }

    public ProductId ProductId { get; init; }
    public Product Product { get; init; }

    public CategoryId CategoryId { get; init; }
    public Category Category { get; init; }
}



[StronglyTypedId]
public readonly partial struct ProductCategoryId { }