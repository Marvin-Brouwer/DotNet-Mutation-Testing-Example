using FluentAssertions;

using Moq;

using ShoppingCart.Example.Services;
using ShoppingCart.Models;

namespace ShoppingCart.Tests.Tests.Services;

public sealed class OrderServiceTests
{
	private readonly Mock<ICart> _cartMock;
	private readonly OrderService _sut;

	public OrderServiceTests()
	{
		_cartMock = new();
		_sut = new(_cartMock.Object);
	}

	[Fact]
	public void CanOrder_CartHasNoItems_ReturnsFalse()
	{
		// Arrange
		_cartMock
			.SetupGet(cart => cart.Items)
			.Returns(Array.Empty<CartItem>().ToHashSet());

		// Act
		var result = _sut.CanOrder;

		// Assert
		result.Should().BeFalse();
	}

	[Fact]
	public void CanOrder_CartHasAnItemWithQuantity_ReturnsTrue()
	{
		// Arrange
		_cartMock
			.SetupGet(cart => cart.Items)
			.Returns(new HashSet<CartItem>(new []
			{
				new CartItem { Quantity = 1 }
			}));

		// Act
		var result = _sut.CanOrder;

		// Assert
		result.Should().BeTrue();
	}

	#region Mutant killer

	[Fact(Skip = "Missing mutant killer", DisplayName = "CanOrder_???_???")]
	public void CanOrder_CartHasAnItemWithZeroQuantity_ReturnsFalse()
	{
		// Arrange
		_cartMock
			.SetupGet(cart => cart.Items)
			.Returns(new HashSet<CartItem>(new[]
			{
				new CartItem { Quantity = 0 }
			}));

		// Act
		var result = _sut.CanOrder;

		// Assert
		result.Should().BeFalse();
	}

	#endregion
}
