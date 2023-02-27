namespace Tetris.Block;

public class O : Block
{
    public O() : base(new bool[2, 2]
    {
        { true, true },
        { true, true }
    }, ConsoleColor.Yellow)
    {
    }

    public override bool[,] Rotate()
    {
        return Matrix;
    }
}