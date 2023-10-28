using System.Net.NetworkInformation;
using SkiaSharp;

/// <summary>
/// Базовый класс, абстрактный. Он является родителем для всех остальных фигур. Сердержит базовый функционал.
/// </summary>
public abstract class Shape
{
    public Shape() {}

    public Shape(SKColor color, float x, float y)
    {
        Color = color;
        X = x;
        Y = y;
        
        // Стиль круга
        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke, // Отрисоввывать только обводку круга
            Color = Color,               // Цвет окружности
            StrokeWidth = 2              // Толщина контура круга
        };

        Paint = paint;
    }
    
    /// <summary>
    /// Поле содержит цвет фигуры
    /// </summary>
    public SKColor Color { get; set; }
    /// <summary>
    /// Координата позиции круга X
    /// </summary>
    public float X { get; set; }
    /// <summary>
    /// Координата позиции круга Y
    /// </summary>
    public float Y { get; set; }
    
    protected SKPaint Paint { get; }

    /// <summary>
    /// Мето позволяет отрисовать фигуру
    /// </summary>
    /// <param name="canvas">Холст на котором мы рисуем</param>
    public virtual void Draw(SKCanvas canvas)
    {
        Console.WriteLine(canvas.ToString());
    }
}

/// <summary>
/// Фигура - круг. Наследуется от базового класса Shape.
/// </summary>
public class Circle : Shape
{
    /// <summary>
    /// Радиус круга
    /// </summary>
    public float Radius { get; set; }

    /// <summary>
    /// Конструктор для базовой инициализации
    /// </summary>
    /// <param name="x">Координана x</param>
    /// <param name="y">Координата y</param>
    /// <param name="radius">Радиус</param>
    /// <param name="color">Цвет</param>
    public Circle(float x, float y, float radius, SKColor color): base(color, x, y)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    /// <summary>
    /// Отрисовка круга
    /// </summary>
    /// <param name="canvas">Холст</param>
    public override void Draw(SKCanvas canvas)
    {

        // Отрисовка круга на холсте
        canvas.DrawCircle(X, Y, Radius, Paint);
    }
}

/// <summary>
/// Фигура - прямоугольник. Наследуется от базового класса Shape.
/// </summary>
public class Rectagle : Shape
{
    /// <summary>
    /// Ширина
    /// </summary>
    public float Width { get; set; }
    /// <summary>
    /// Высота
    /// </summary>
    public float Height { get; set; }

    /// <summary>
    /// Конструктор для базовой инициализации
    /// </summary>
    /// <param name="x">Координана x</param>
    /// <param name="y">Координата y</param>
    /// <param name="width">Шарина</param>
    /// <param name="height">Высота</param>
    /// <param name="color">Цвет</param>
    public Rectagle(float x, float y, float width, float height, SKColor color) : base(color, x, y)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
    
    public override void Draw(SKCanvas canvas)
    {
        canvas.DrawRect(X,Y,Width,Height, Paint);
    }
}


public class Point : Shape
{
    /// <summary>
    /// Конструктор для базовой инициализации
    /// </summary>
    /// <param name="x">Координана x</param>
    /// <param name="y">Координата y</param>
    /// <param name="color">Цвет</param>
    public Point(float x, float y, SKColor color) : base(color, x, y)
    {
        X = x;
        Y = y;
    }
    
    public override void Draw(SKCanvas canvas)
    {
        canvas.DrawPoint(X,Y, Color);
    }
}

/// <summary>
/// Типы фигур
/// </summary>
public enum ShapeType
{
    /// <summary>
    /// Точка
    /// </summary>
    Point,
    /// <summary>
    /// Прямоугольник
    /// </summary>
    Rectangle,
    /// <summary>
    /// Круг
    /// </summary>
    Circle
} 