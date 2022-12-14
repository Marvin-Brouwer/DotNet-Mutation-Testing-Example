using ShoppingCart.Example.Calculators;
using ShoppingCart.Models;

namespace ShoppingCart.Example.Services;

public sealed class PriceService
{
	private readonly IEnumerable<IPriceCalculator> _priceCalculators;
	private DefaultPriceCalculator _defaultPriceCalculator = new DefaultPriceCalculator();

	public PriceService(IEnumerable<IPriceCalculator> priceCalculators)
	{
		_priceCalculators = priceCalculators
			.Reverse();
	}

	public decimal CalculateTotalPrice(ICart cart)
	{
		return cart.Items
			.Select(CalculatePrice)
			.Sum();
	}

	private decimal CalculatePrice(CartItem cartItem)
	{
		var calculator = _priceCalculators
			.FirstOrDefault(c => c.CanCalculate(cartItem.Product))
		    ?? _defaultPriceCalculator;

		return calculator
			.Calculate(cartItem.Product, cartItem.Quantity);
	}
}
