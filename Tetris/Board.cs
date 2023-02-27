using Tetris;
using Tetris.Block;

public class Board
{
    public Pixel[,] Matrix { get; set; }

    public int Width => Matrix.GetLength(1);
    public int Height => Matrix.GetLength(0);

    public Board()
    {
        Matrix = new Pixel[20, 10];

        for (var y = 0; y < Matrix.GetLength(0); y++)
        for (var x = 0; x < Matrix.GetLength(1); x++)
            Matrix[y, x] = new Pixel();
    }

    public void Print()
    {
        for (var y = 0; y < Matrix.GetLength(0); y++)
        for (var x = 0; x < Matrix.GetLength(1); x++)
        {
            Console.SetCursorPosition(x * Matrix[y, x].ToString().Length, y);
            Matrix[y, x].Print();
        }
    }

    public Pixel[,] this[int y, int x, int h, int l]
    {
        get
        {
            var pixels = new Pixel[h, l];
            for (var i = 0; i < h; i++)
            for (var j = 0; j < l; j++)
                pixels[i, j] = Matrix[y + i, j + i];
            return pixels;
        }
    }

    public void InsertAt(int posX, int posY, Block block)
    {
        Console.Title =
            $"x:{posX}, y:{posY}, {Matrix.GetLength(0)} {Matrix.GetLength(1)} {block.Height - 1 + posY} {block.Width - 1 + posX}";
        for (var y = 0; y < block.Height; y++)
        for (var x = 0; x < block.Width; x++)
            if (block.Matrix[y, x])
                Matrix[posY + y, posX + x] = new Pixel(block.Matrix[y, x], block.Color);
    }

    public override string ToString()
    {
        var board = "";

        for (var y = 0; y < Matrix.GetLength(0); y++)
        {
            for (var x = 0; x < Matrix.GetLength(1); x++)
                board += Matrix[y, x].ToString();
            board += "\n";
        }

        return board;
    }
}