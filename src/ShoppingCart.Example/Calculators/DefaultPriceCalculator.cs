using ShoppingCart.Models;

namespace ShoppingCart.Example.Calculators;
public sealed class DefaultPriceCalculator : IPriceCalculator
{
	public bool CanCalculate(Product product) => true;

	public decimal Calculate(Product product, int quantity)
	{
		return product.Price * quantity;
	}
}
