using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square(4, "pink");
        //Console.WriteLine($"The area of the {square.GetColor()} square is {square.GetArea()}");

        Rectangle rectangle = new Rectangle(8, 4, "red");
        //Console.WriteLine($"The area of the {rectangle.GetColor()} rectangle is {rectangle.GetArea()}");

        Circle circle = new Circle(5, "yellow");
        //Console.WriteLine($"The area of the {circle.GetColor()} circle is {circle.GetArea()}");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The color is {shape.GetColor()} and his area is {shape.GetArea()}");
        }
    }
}