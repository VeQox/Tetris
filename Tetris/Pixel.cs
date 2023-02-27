namespace Tetris;

public class Pixel
{
    public bool IsOccupied { get; set; }
    public ConsoleColor Color { get; set; }

    public Pixel(bool isOccupied = false, ConsoleColor color = ConsoleColor.Black)
    {
        IsOccupied = isOccupied;
        Color = color;
    }

    public override string ToString()
    {
        return IsOccupied ? "##" : "--";
        // ⬛
    }

    public void Print()
    {
        if (IsOccupied) Console.BackgroundColor = Color;
        Console.Write(ToString());
        if (IsOccupied) Console.ResetColor();
    }
}