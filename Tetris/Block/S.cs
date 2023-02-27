namespace Tetris.Block;

public class S : Block
{
    public S() : base(new bool[3, 3]
    {
        { false, false, false },
        { false, true, true },
        { true, true, false }
    }, ConsoleColor.Green)
    {
    }
}