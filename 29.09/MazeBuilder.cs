public class Maze
{
    public List<(int X, int Y)> Rocks { get; } = new List<(int X, int Y)>();

    public List<(int X, int Y)> Waters { get; } = new List<(int X, int Y)>();
}

public class MazeBuilder<TSelf> where TSelf : MazeBuilder<TSelf>
{
    protected Maze maze = new Maze();

    protected TSelf Self => (TSelf)this;

    public TSelf AddRock(int x, int y)
    {
        // добавляем камень
        return Self;
    }

    public TSelf AddWater(int x, int y)
    {
        // добавляем воду
        return Self;
    }

    // ещё много подобных методов AddXXX для добавления всего в maze.
    // В каждом из них: return Self;

    public Maze Build()
    {
        // ...
        return maze;
    }
}

public class MazeBuilder : MazeBuilder<MazeBuilder>
{
}

