namespace Tetris.Block;

public class Z : Block
{
    public Z() : base(new bool[3, 3]
    {
        { false, false, false },
        { true, true, false },
        { false, true, true }
    }, ConsoleColor.Red)
    {
    }
}