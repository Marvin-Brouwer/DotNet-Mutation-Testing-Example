using FluentAssertions;

using ShoppingCart.Example.Calculators;
using ShoppingCart.Example.Services;
using ShoppingCart.Models;

using System.Reflection;

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

	[Fact]
	public void CalculateTotalPrice_ContainsOneProduct2_ReturnsNormalPrice()
	{
		// Arrange
		var cart = new Cart
		{
			Items =
			{
				new CartItem
				{
					Quantity = 2,
					Product = new Product
					{
						Id = new ProductId(2),
						Name = "Product2",
						Price = 20.00M
					}
				},
				new CartItem
				{
					Quantity = 1,
					Product = new Product
					{
						Id = new ProductId(7),
						Name = "Product7",
						Price = 5.00M
					}
				}
			}
		};

		// Act
		var result = Sut.CalculateTotalPrice(cart);

		// Assert
		result.Should().Be(45);
	}

	[Fact]
	public void CalculateTotalPrice_ContainsThreeProduct2_ReturnsPriceWithDiscount()
	{
		// Arrange
		var cart = new Cart
		{
			Items =
			{
				new CartItem
				{
					Quantity = 3,
					Product = new Product
					{
						Id = new ProductId(2),
						Name = "Product2",
						Price = 20.00M
					}
				},
				new CartItem
				{
					Quantity = 1,
					Product = new Product
					{
						Id = new ProductId(7),
						Name = "Product7",
						Price = 5.00M
					}
				}
			}
		};

		// Act
		var result = Sut.CalculateTotalPrice(cart);

		// Assert
		result.Should().Be(55);
	}
}
