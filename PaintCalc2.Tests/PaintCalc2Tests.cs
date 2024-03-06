using Bunit;
using PaintCalc2.Components.Pages;
namespace PaintCalc2.Tests;

public class PaintCalc2Tests
{

    [Theory]
    [InlineData(10)]
    [InlineData(2000)]
    [InlineData(2.0)]
    [InlineData(0.5)]
    [InlineData(5.5)]
    public void WidthInput_ValidInput(double input)
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#roomWidth").Change(input);

        // Assert
        Assert.Equal(input, calculator.RoomWidth);
    }
    
    [Theory]
    [InlineData(10)]
    [InlineData(2000)]
    [InlineData(2.0)]
    [InlineData(0.5)]
    [InlineData(5.5)]
    public void HeightInput_ValidInput(double input)
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#roomHeight").Change(input);

        // Assert
        Assert.Equal(input, calculator.RoomWidth);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(2000)]
    [InlineData(2.0)]
    [InlineData(0.5)]
    [InlineData(5.5)]
    public void LengthInput_ValidInput(double input)
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#LengthWidth").Change(input);

        // Assert
        Assert.Equal(input, calculator.RoomWidth);
    }

    [Fact]
    public void TestSubmitButton()
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;
        var button = cut.Find("submitButton");

        calculator.RoomWidth = 10;
        calculator.RoomLength = 10;

        // Act
        button.Click();

        // Assert
        Assert.Equal(100, calculator.FloorArea);
    }

    [Fact]
    public void TestCelilingCheckbox()
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#CeilingIncluded").Change(true);

        // Assert
        Assert.True(calculator.RoomWidth);
    }
}