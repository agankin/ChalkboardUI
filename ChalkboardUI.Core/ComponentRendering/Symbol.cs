namespace ChalkboardUI.ComponentRendering
{
    public readonly record struct Symbol(
        char Value,
        ConsoleColor Foreground,
        ConsoleColor Background)
    {
    }
}