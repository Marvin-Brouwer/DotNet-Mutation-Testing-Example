using ShoppingCart.Example.Calculators;
using ShoppingCart.Example.Services;

namespace ShoppingCart.Tests.Tests.Services;

/// <summary>
/// TODO discount if 3 of x product Assert result contains discount, don't assert if doesn't on other cases
/// </summary>
public sealed class PriceServiceTests
{
	private readonly PriceService Sut = new (new List<IPriceCalculator>
	{
		new DefaultPriceCalculator(),
		new Product2DiscountCalculator()
	});
}
