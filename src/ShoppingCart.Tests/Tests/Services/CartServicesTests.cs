using FluentAssertions;

using ShoppingCart.Example.Services;
using ShoppingCart.Models;

namespace ShoppingCart.Tests.Tests.Services;

public class CartServicesTests
{
	private readonly ICartService _sut = new CartService();

	private static ICart Cart => new Cart
	{
		Items =
		{
			new CartItem
			{
				Created = new DateTime(1991, 11, 28, 1, 0, 0),
				Quantity = 1,
				Product = new Product
				{
					Id = new ProductId(1),
					Name = "TestProduct1",
					Description = "Just a test product",
					Price = 10.00M
				}
			},

			new CartItem
			{
				Created = new DateTime(1991, 11, 28, 2, 0, 0),
				Quantity = 1,
				Product = new Product
				{
					Id = new ProductId(2),
					Name = "TestProduct2",
					Description = "Just a test product",
					Price = 11.00M
				}
			}
		}
	};

	[Fact]
	public void AddToCart_NewProduct_ProductAdded()
	{
		// Arrange
		var product = new Product
		{
			Id = new ProductId(9),
			Name = "TestProduct9",
			Description = "Just a test product",
			Price = 18.00M
		};

		// Act
		var result = _sut.AddToCart(Cart, product);

		// Assert
		result.Items.Should().HaveCount(3);
	}

	[Fact]
	public void AddToCart_AddedProduct_QuantityIncreased()
	{
		// Arrange
		var product = new Product
		{
			Id = new ProductId(2),
			Name = "TestProduct2",
			Description = "Just a test product",
			Price = 11.00M
		};

		// Act
		var result = _sut.AddToCart(Cart, product);

		// Assert
		result.Items.Should().HaveCount(2);
		result.Items.Skip(1).First().ProductId.Should().Be(product.Id);
		result.Items.Skip(1).First().Quantity.Should().Be(2);
	}

	[Fact]
	public void SetQuantity_NewProduct_QuantityPositive_ProductAddedWithQuantity()
	{
		// Arrange
		var product = new Product
		{
			Id = new ProductId(9),
			Name = "TestProduct9",
			Description = "Just a test product",
			Price = 18.00M
		};

		// Act
		var result = _sut.SetQuantity(Cart, product, 80);

		// Assert
		result.Items.Should().HaveCount(3);
		result.Items.Skip(2).First().ProductId.Should().Be(product.Id);
		result.Items.Skip(2).First().Quantity.Should().Be(80);
	}

	[Fact]
	public void SetQuantity_AddedProduct_QuantityPositive_QuantitySet()
	{
		// Arrange
		var product = new Product
		{
			Id = new ProductId(2),
			Name = "TestProduct2",
			Description = "Just a test product",
			Price = 11.00M
		};

		// Act
		var result = _sut.SetQuantity(Cart, product, 80);

		// Assert
		result.Items.Should().HaveCount(2);
		result.Items.Skip(1).First().ProductId.Should().Be(product.Id);
		result.Items.Skip(1).First().Quantity.Should().Be(80);
	}

	[Fact]
	public void SetQuantity_NewProduct_QuantityZero_NothingHappens()
	{
		// Arrange
		var product = new Product
		{
			Id = new ProductId(9),
			Name = "TestProduct9",
			Description = "Just a test product",
			Price = 18.00M
		};

		// Act
		var result = _sut.SetQuantity(Cart, product, 0);

		// Assert
		result.Items.Should().HaveCount(2);
	}

	[Fact]
	public void SetQuantity_AddedProduct_QuantityZero_ProductRemoved()
	{
		// Arrange
		var product = new Product
		{
			Id = new ProductId(2),
			Name = "TestProduct2",
			Description = "Just a test product",
			Price = 11.00M
		};

		// Act
		var result = _sut.SetQuantity(Cart, product, 0);

		// Assert
		result.Items.Should().HaveCount(1);
	}

	[Fact]
	public void SetQuantity_QuantityNegative_Throws()
	{
		// Arrange
		var product = new Product
		{
			Id = new ProductId(2),
			Name = "TestProduct2",
			Description = "Just a test product",
			Price = 11.00M
		};

		// Act
		var result = () =>  _sut.SetQuantity(Cart, product, -9);

		// Assert
		result.Should().ThrowExactly<ArgumentException>();
	}

	[Fact]
	public void RemoveFromCart_NewProduct_NothingHappens()
	{
		// Arrange
		var product = new Product
		{
			Id = new ProductId(9),
			Name = "TestProduct9",
			Description = "Just a test product",
			Price = 18.00M
		};

		// Act
		var result = _sut.RemoveFromCart(Cart, product);

		// Assert
		result.Items.Should().HaveCount(2);
	}

	[Fact]
	public void RemoveFromCart_AddedProduct_ProductRemoved()
	{
		// Arrange
		var product = new Product
		{
			Id = new ProductId(2),
			Name = "TestProduct2",
			Description = "Just a test product",
			Price = 11.00M
		};

		// Act
		var result = _sut.RemoveFromCart(Cart, product);

		// Assert
		result.Items.Should().HaveCount(1);
	}
}