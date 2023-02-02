namespace ChalkboardUI.Units
{
    public readonly record struct Point(int X, int Y)
    {
        public Point Offset(Offset offset) =>
            this with
            {
                X = X + offset.Left,
                Y = Y + offset.Top
            };
    }
}