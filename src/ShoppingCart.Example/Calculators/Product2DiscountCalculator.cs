using ShoppingCart.Models;

using System.Diagnostics.CodeAnalysis;

namespace ShoppingCart.Example.Calculators;
public sealed class Product2DiscountCalculator : IPriceCalculator
{
	public bool CanCalculate(Product product) => product.Id == new ProductId(2);

	public decimal Calculate(Product product, int quantity)
	{
		var normalPrice = product.Price * quantity;

		if (quantity % 3 == 0)
			return normalPrice - (product.Price / 2);

		return normalPrice;
	}
}
