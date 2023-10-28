using SkiaSharp;

const int BITMAP_WIDTH = 800;
const int BITMAP_HEIGHT = 600;

using SKBitmap bitmap = new SKBitmap(BITMAP_WIDTH, BITMAP_HEIGHT);
using SKCanvas canvas = new SKCanvas(bitmap);

canvas.Clear();
canvas.DrawColor(SKColors.White);
canvas.Flush();
canvas.Save();

List<ShapeType> shapeTypes = new List<ShapeType> { ShapeType.Point, ShapeType.Rectangle, ShapeType.Circle };
List<SKColor> colors = new List<SKColor>()
{
    SKColors.Aqua, SKColors.Blue, SKColors.SkyBlue, SKColors.Chartreuse,
    SKColors.Crimson, SKColors.Black, SKColors.Gold, SKColors.Fuchsia, SKColors.Yellow
};

const int shapesCount = 100;
List<Shape> shapes = new List<Shape>();

for (int i = 0; i < shapesCount; i++)
{
    int shapeTypeIndex = Random.Shared.Next(0, shapeTypes.Count);
    int colorIndex = Random.Shared.Next(0, colors.Count);
    
    ShapeType shapeType = shapeTypes[shapeTypeIndex];
    SKColor color = colors[colorIndex];

    float x = Random.Shared.Next(0, BITMAP_WIDTH);
    float y = Random.Shared.Next(0, BITMAP_HEIGHT);

    Shape shape = null;
    switch (shapeType)
    {
        case ShapeType.Point:
            shape = new Point(x, y, color);
            break;
        case ShapeType.Rectangle:
            float width = Random.Shared.Next(50, 200);
            float hegit = Random.Shared.Next(10, 100);
            shape = new Rectagle(x, y, width, hegit, color);
            break;
        case ShapeType.Circle:
            float radius = Random.Shared.Next(10, 250);
            shape = new Circle(x, y, radius, color);
            break;
    }

    if (shape is not null)
    {
        shapes.Add(shape);
    }
}

foreach (Shape shape in shapes)
{
    shape.Draw(canvas);
}

SKData data = bitmap.Encode(SKEncodedImageFormat.Png, 100);
File.WriteAllBytes("picture.png", data.ToArray());