using Bunit;
using PaintCalc2.Components.Pages;
namespace PaintCalc2.Tests;

public class PaintCalc2Tests
{
    [Fact]
    public void WidthInput_ValidInput()
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#roomWidth").Change("10");

        // Assert
        Assert.Equal(10, calculator.RoomWidth);
    }
    
}