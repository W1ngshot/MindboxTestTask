namespace FigureSquares.Figures;

public class Circle : IFigure
{
    public Circle(double radius)
    {
        if (!IsArgValid(radius))
        {
            throw new ArgumentException("Radius must be positive");
        }
        
        Radius = radius;
    }
    
    private Circle() {}
    
    private double Radius { get; }

    public double GetSquare() =>
        Math.PI * Radius * Radius;

    private static bool IsArgValid(double radius) => radius > 0;
}