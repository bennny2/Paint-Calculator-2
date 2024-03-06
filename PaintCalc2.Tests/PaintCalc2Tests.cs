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
    public void TestSubmitButtonFunctions()
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
    public void TestCelilingCheckboxFunctions()
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

    [Fact]
    public void TestOutputsAreCorrectAndRender()
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        calculator.FloorArea = 200;
        calculator.RoomVolume = 3000;
        calculator.PainNeeded = 600;

        // Act
        var floorAreaElement = cut.Find("#floorArea");
        var roomVolumeElement = cut.Find("#roomVolume");
        var paintNeededElement = cut.Find("#paintNeeded");

        // Assert
        Assert.Equal(calculator.FloorArea.ToString(), floorAreaElement.TextContent);
        Assert.Equal(calculator.RoomVolume.ToString(), roomVolumeElement.TextContent);
        Assert.Equal(calculator.PaintNeeded.ToString(), paintNeededElement.TextContent);
    }

    [Fact]
    public void CalculateFloorAreaWithValidInput_ReturnExpected() 
    {
        //Assign
        RoomDimensions calculator = new();

        calculator.Width = 10.0;
        calculator.Length = 18.0;
        double expectedFloorArea = 180.0;

        //Act
        calculator.CalculateFloorArea(); 

        //Assert
        Assert.Equal(expectedFloorArea, calculator.FloorArea);
    }

    [Fact]
    public void CalculateRoomVolumeWithValidInput_ReturnExpected() 
    {
        //Assign
        RoomDimensions calculator = new();

        calculator.FloorArea = 180.0;
        calculator.Height = 10.0;
        double expectedRoomVolume = 18000.0;

        //Act
        calculator.CalculateFloorArea(); 

        //Assert
        Assert.Equal(expectedRoomVolume, calculator.RoomVolume);
    }
}