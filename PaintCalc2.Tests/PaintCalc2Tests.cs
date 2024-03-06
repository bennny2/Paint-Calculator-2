using Bunit;
using PaintCalc2.Components.Pages;
namespace PaintCalc2.Tests;

public class PaintCalc2Tests
{

    [Theory]
    [InlineData(10)]
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
    
}