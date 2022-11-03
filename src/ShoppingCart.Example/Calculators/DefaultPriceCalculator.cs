using ShoppingCart.Models;

using System.Diagnostics.CodeAnalysis;

namespace ShoppingCart.Example.Calculators;
public sealed class DefaultPriceCalculator : IPriceCalculator
{
	[ExcludeFromCodeCoverage]
	public bool CanCalculate(Product product) => throw new NotSupportedException();

	public decimal Calculate(Product product, int quantity)
	{
		return product.Price * quantity;
	}
}
