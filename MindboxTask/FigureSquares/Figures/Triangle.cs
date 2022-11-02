namespace FigureSquares.Figures;

public class Triangle : IFigure
{
    public Triangle(double a, double b, double c)
    {
        if (!IsArgsValid(a, b, c))
        {
            throw new ArgumentException("Sum of two triangle sides always must be bigger than third one");
        }

        var sortedSides = new[] {a, b, c}.OrderByDescending(value => value).ToArray();
        A = sortedSides[0];
        B = sortedSides[1];
        C = sortedSides[2];
    }
    
    private Triangle() {}
    
    private double A { get; }
    private double B { get; }
    private double C { get; }

    public double GetSquare() 
        => IsTriangleRightAngled() ? (B * C) / 2 : UseHeronFormula();

    private double UseHeronFormula()
    {
        var p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    private bool IsTriangleRightAngled() =>
        Math.Abs(A * A - (B * B + C * C)) < double.Epsilon;

    private static bool IsArgsValid(double a, double b, double c) =>
        a + b > c && a + c > b && b + c > a;
}