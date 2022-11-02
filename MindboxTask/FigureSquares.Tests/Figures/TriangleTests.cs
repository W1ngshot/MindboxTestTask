using System;
using System.Linq;
using FigureSquares.Figures;
using Xunit;

namespace FigureSquares.Tests.Figures;

public class TriangleTests
{
    [Theory]
    [InlineData(-2, -3, -4)]
    [InlineData(-2, -1, 1)]
    [InlineData(-1, 2, 3)]
    [InlineData(0, 0, 0)]
    [InlineData(1, 2, 0)]
    [InlineData(1, 2, 3)]
    [InlineData(2, 5, 2)]
    [InlineData(10, 3, 4)]
    public void NewTriangle_WrongTriangleSides_ShouldThrowArgumentException(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(12, 5, 13)]
    [InlineData(25, 20, 15)]
    public void GetSquare_RightTriangle_ShouldCalculateSquareRight(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        var sortedArray = new[] {a, b, c}.OrderByDescending(value => value).ToArray();
        var expectedSquare = sortedArray[1] * sortedArray[2] / 2;

        var actualSquare = triangle.GetSquare();

        Assert.Equal(expectedSquare, actualSquare);
    }

    [Theory]
    [InlineData(3, 4, 6)]
    [InlineData(5, 7, 6)]
    [InlineData(7, 6, 9)]
    public void GetSquare_SuccessPath_ShouldCalculateSquareRight(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        var p = (a + b + c) / 2;
        var expectedSquare = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        var actualSquare = triangle.GetSquare();
        
        Assert.True(Math.Abs(actualSquare - expectedSquare) < double.Epsilon);
    }
}