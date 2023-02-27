namespace Tetris.Block;

public abstract class Block
{
    protected Block(bool[,] matrix, ConsoleColor color)
    {
        Matrix = matrix;
        Color = color;
    }

    public int Height => Matrix.GetLength(0);

    public int Width => Matrix.GetLength(1);

    public bool[,] Matrix { get; set; }

    public ConsoleColor Color { get; set; }

    public virtual bool[,] Rotate()
    {
        var oldMatrix = (bool[,])Matrix.Clone();
        var rotatedMatrix = new bool[Height, Width];

        rotatedMatrix[0, 0] = oldMatrix[2, 0];
        rotatedMatrix[0, 1] = oldMatrix[1, 0];
        rotatedMatrix[0, 2] = oldMatrix[0, 0];
        rotatedMatrix[1, 0] = oldMatrix[2, 1];
        rotatedMatrix[1, 1] = oldMatrix[1, 1];
        rotatedMatrix[1, 2] = oldMatrix[0, 1];
        rotatedMatrix[2, 0] = oldMatrix[2, 2];
        rotatedMatrix[2, 1] = oldMatrix[1, 2];
        rotatedMatrix[2, 2] = oldMatrix[0, 2];

        return rotatedMatrix;
    }

    public void Print(int x, int y)
    {
        Console.BackgroundColor = Color;
        Console.ForegroundColor = Color;
        for (var i = 0; i < Matrix.GetLength(0); i++)
        for (var j = 0; j < Matrix.GetLength(1); j++)
            if (Matrix[i, j])
            {
                Console.SetCursorPosition((x + j) * 2, y + i);
                Console.Write("  ");
            }

        Console.ResetColor();
    }

    public bool[] this[int x]
    {
        get
        {
            var col = new bool[Height];
            for (var y = 0; y < Height; y++) col[x] = Matrix[y, x];
            return col;
        }
    }
}