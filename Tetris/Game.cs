using System.Diagnostics;
using Tetris.Block;

namespace Tetris;

internal enum State
{
    Idle,
    Running,
    Finished
}

public class Game
{
    private static readonly Random Random = new();
    private State GameState { get; set; }
    private int Y { get; set; }
    private int X { get; set; }
    private Block.Block Block { get; set; }
    private Board Board { get; set; }

    private Thread ControllerThread { get; }
    private Thread RenderThread { get; }

    public Game()
    {
        Board = new Board();
        Block = GetRandomBlock();
        Y = 0;
        X = Random.Next(0, Board.Width - Block.Width - 1);
        GameState = State.Idle;
        ControllerThread = new Thread(() =>
        {
            while (GameState == State.Running) Move(Console.ReadKey(true).Key);
        });
        RenderThread = new Thread(() =>
        {
            var sw = new Stopwatch();
            const float msPerFrame = 1000f / 60f;
            while (GameState == State.Running)
            {
                sw.Restart();
                Console.SetCursorPosition(0, 0);
                Board.Print();
                Block.Print(X, Y);
                if (sw.ElapsedMilliseconds < msPerFrame)
                    Thread.Sleep((int)(msPerFrame - sw.ElapsedMilliseconds));
            }
        });
    }

    public void Start()
    {
        Console.CursorVisible = false;
        GameState = State.Running;
        ControllerThread.Start();
        RenderThread.Start();

        while (GameState == State.Running)
        {
        }
    }

    private void Move(ConsoleKey key)
    {
        if (key == ConsoleKey.RightArrow)
        {
            bool[][] cols = new bool[Block.Width][];
            for (var x = 0; x < Block.Width; x++)
                cols[x] = Block[x];


            var emptyLines = cols.Reverse().TakeWhile(col => col.All(item => item)).Count();

            if (!(X < Board.Width - Block.Width + emptyLines))
                return;
            X++;
        }
        else if (key == ConsoleKey.LeftArrow)
        {
            bool[][] cols = new bool[Block.Width][];
            for (var x = 0; x < Block.Width; x++)
                cols[x] = Block[x];

            var emptyLines = cols.TakeWhile(col => col.All(item => item)).Count();

            if (!(X + emptyLines > 0)) return;
            X--;
        }
        else if (key == ConsoleKey.DownArrow)
        {
            Block.Matrix = Block.Rotate();
        }
    }

    private static Block.Block GetRandomBlock()
    {
        return Random.Next(0, 7) switch
        {
            0 => new I(),
            1 => new J(),
            2 => new L(),
            3 => new O(),
            4 => new S(),
            5 => new T(),
            6 => new Z(),
            _ => throw new Exception()
        };
    }
}