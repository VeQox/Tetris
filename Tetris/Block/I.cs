namespace Tetris.Block;

public class I : Block
{
    public I() : base(new bool[4, 4]
        {
            { false, true, false, false },
            { false, true, false, false },
            { false, true, false, false },
            { false, true, false, false }
        },
        ConsoleColor.Cyan)
    {
    }

    public override bool[,] Rotate()
    {
        var oldMatrix = (bool[,])Matrix.Clone();
        var rotatedMatrix = new bool[Height, Width];

        rotatedMatrix[0, 1] = oldMatrix[1, 0];
        rotatedMatrix[1, 1] = oldMatrix[1, 1];
        rotatedMatrix[1, 2] = oldMatrix[2, 1];
        rotatedMatrix[1, 3] = oldMatrix[3, 1];
        rotatedMatrix[1, 0] = oldMatrix[0, 1];
        rotatedMatrix[2, 1] = oldMatrix[1, 2];
        rotatedMatrix[3, 1] = oldMatrix[1, 3];

        return rotatedMatrix;
    }
}