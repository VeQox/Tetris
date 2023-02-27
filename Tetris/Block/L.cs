namespace Tetris.Block;

public class L : Block
{
    public L() : base(new bool[3, 3]
    {
        { false, true, false },
        { false, true, false },
        { false, true, true }
    }, ConsoleColor.DarkYellow)
    {
    }
}