namespace ShoppingCart.Example.Models;

public sealed class Category
{
    public CategoryId Id { get; init; }
    public string Name { get; init; } = default!; 
    
    private IReadOnlyCollection<Product> Product { get; init; } = Array.Empty<Product>();
}

[StronglyTypedId]
public readonly partial struct CategoryId { }