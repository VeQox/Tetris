namespace Tetris.Block;

public class T : Block
{
    public T() : base(new bool[3, 3]
    {
        { false, false, false },
        { true, true, true },
        { false, true, false }
    }, ConsoleColor.DarkMagenta)
    {
    }
}