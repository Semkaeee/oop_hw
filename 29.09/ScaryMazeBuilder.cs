public class ScaryMazeBuilder : MazeBuilder<ScaryMazeBuilder>
{
    public ScaryMazeBuilder AddGhost(int x, int y)
    {
        //...
        return this;
    }

    // ещё много методов добавления страшилок в лабиринт.
    // В каждом из них: return this;
}