using System;
using FigureSquares.Figures;
using Xunit;

namespace FigureSquares.Tests.Figures;

public class CircleTests
{
    [Theory]
    [InlineData(-10)]
    [InlineData(-2.2)]
    [InlineData(0)]
    public void NewCircle_WrongRadius_ShouldThrowArgumentException(double radius)
    {
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    [Theory]
    [InlineData(10)]
    [InlineData(3.3)]
    [InlineData(1)]
    public void GetSquare_SuccessPath_ShouldCalculateSquareRight(double radius)
    {
        var circle = new Circle(radius);
        var expectedValue = Math.PI * radius * radius;

        var square = circle.GetSquare();
        
        Assert.True(Math.Abs(square - expectedValue) < double.Epsilon);
    }
}