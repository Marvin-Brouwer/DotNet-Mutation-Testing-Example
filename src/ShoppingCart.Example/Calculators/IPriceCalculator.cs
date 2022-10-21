using ShoppingCart.Models;

namespace ShoppingCart.Example.Calculators;

public interface IPriceCalculator
{
	public bool CanCalculate(Product product);
	public decimal Calculate(Product product, int quantity);
}
