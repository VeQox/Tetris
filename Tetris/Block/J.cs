namespace Tetris.Block;

public class J : Block
{
    public J() : base(new bool[3, 3]
    {
        {
            false, true, false
        },
        {
            false, true, false
        },
        {
            true, true, false
        }
    }, ConsoleColor.Blue)
    {
    }
}