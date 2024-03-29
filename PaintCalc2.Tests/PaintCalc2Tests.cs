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
    [InlineData(-20.0)]
    [InlineData(1000000000.0)]

    public void WidthInput_InvalidNumberInput(double input)
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#roomWidth").Change(input);
        var validationMessage = cut.Find("#roomWidthValidation");
        
        // Assert
        Assert.NotNull(validationMessage);
    }

    [Theory]
    [InlineData("-20.0")]
    [InlineData("e")]
    [InlineData("E")]
    [InlineData("1000000000.0")]
    [InlineData("ten")]
    
    public void WidthInput_InvalidStringInput(string input)
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#roomWidth").Change(input);
        var validationMessage = cut.Find("#roomWidthValidation");
        
        // Assert
        Assert.NotNull(validationMessage);
    }

    [Theory]
    [InlineData(-20.0)]
    [InlineData(1000000000.0)]
    public void HeightInput_InvalidNumberInput(double input)
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#roomHeight").Change(input);
        var validationMessage = cut.Find("#roomHeightValidation");
        
        // Assert
        Assert.NotNull(validationMessage);
    }

    [Theory]
    [InlineData("-20.0")]
    [InlineData("e")]
    [InlineData("E")]
    [InlineData("1000000000.0")]
    [InlineData("ten")]
    
    public void HeightInput_InvalidStringInput(string input)
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#roomHeight").Change(input);
        var validationMessage = cut.Find("#roomHeightValidation");
        
        // Assert
        Assert.NotNull(validationMessage);
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
        Assert.Equal(input, calculator.RoomHeight);
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
        cut.Find("#roomLength").Change(input);

        // Assert
        Assert.Equal(input, calculator.RoomLength);
    }

    [Theory]
    [InlineData(-20.0)]
    [InlineData(1000000000.0)]
    public void LengthInput_InvalidNumberInput(double input)
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#roomLength").Change(input);
        var validationMessage = cut.Find("#roomLengthValidation");
        
        // Assert
        Assert.NotNull(validationMessage);
    }

    [Theory]
    [InlineData("-20.0")]
    [InlineData("e")]
    [InlineData("E")]
    [InlineData("1000000000.0")]
    [InlineData("ten")]
    
    public void LengthInput_InvalidStringInput(string input)
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;

        // Act
        cut.Find("#roomLength").Change(input);
        var validationMessage = cut.Find("#roomLengthValidation");
        
        // Assert
        Assert.NotNull(validationMessage);
    }


    [Fact]
    public void TestSubmitButtonFunctions()
    {
        // Arrange
        TestContext ctx = new();
        IRenderedComponent<Paint> cut = ctx.RenderComponent<Paint>();
        RoomDimensions calculator = cut.Instance.calculator;
        var button = cut.Find("#submitButton");

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
        cut.Find("#ceilingIncluded").Change(true);

        // Assert
        Assert.True(calculator.CeilingIncluded);
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
        calculator.PaintNeeded = 600;

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

        calculator.RoomWidth = 10.0;
        calculator.RoomLength = 18.0;

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
        calculator.RoomHeight = 10.0;

        double expectedRoomVolume = 1800.0;

        //Act
        calculator.CalculateRoomVolume(); 

        //Assert
        Assert.Equal(expectedRoomVolume, calculator.RoomVolume);
    }

    [Fact]
    public void CalculatePaintNeededWithValidInputCeilingIncluded_ReturnExpected() 
    {
        //Assign
        RoomDimensions calculator = new();

        calculator.FloorArea = 300.0;
        calculator.RoomHeight = 40.0;
        calculator.RoomLength = 15.0;
        calculator.RoomWidth = 20.0;
        calculator.CeilingIncluded = true;

        double expectedPaintNeeded = 3100.0;

        //Act
        calculator.CalculatePaintNeeded(); 

        //Assert
        Assert.Equal(expectedPaintNeeded, calculator.PaintNeeded);
    }

    [Fact]
    public void CalculatePaintNeededWithValidInputCeilingNotIncluded_ReturnExpected() 
    {
        //Assign
        RoomDimensions calculator = new();

        calculator.FloorArea = 300.0;
        calculator.RoomHeight = 40.0;
        calculator.RoomLength = 15.0;
        calculator.RoomWidth = 20.0;
        calculator.CeilingIncluded = false;

        double expectedPaintNeeded = 2800.0;

        //Act
        calculator.CalculatePaintNeeded(); 

        //Assert
        Assert.Equal(expectedPaintNeeded, calculator.PaintNeeded);
    }
}