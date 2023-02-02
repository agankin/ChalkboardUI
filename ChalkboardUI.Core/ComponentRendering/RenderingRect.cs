using ChalkboardUI.Exceptions;
using ChalkboardUI.Units;

namespace ChalkboardUI.ComponentRendering
{
    public readonly struct RenderingRect
    {
        private readonly Symbol[,] _consoleRect;
        private readonly Point _renderingPoint;
        private readonly Size _size;

        public RenderingRect(Symbol[,] consoleRect, in Point renderingPoint, in Size size)
        {
            _consoleRect = consoleRect;
            _renderingPoint = renderingPoint;
            _size = size;
        }

        public Symbol this[int relativeX, int relativeY]
        {
            get
            {
                var (x, y) = GetPoint(relativeX, relativeY);
                return _consoleRect[x, y];
            }
            set
            {
                var (x, y) = GetPoint(relativeX, relativeY);
                _consoleRect[x, y] = value;
            }
        }

        public RenderingRect Offset(Offset offset)
        {
            var renderingPoint = _renderingPoint.Offset(offset);
            var size = new Size
            {
                Width = _size.Width - offset.Left,
                Height = _size.Height - offset.Top
            };

            return new RenderingRect(_consoleRect, in renderingPoint, in size);
        }

        private Point GetPoint(int relativeX, int relativeY)
        {
            if (relativeX >= _size.Width)
                throw new ChalkboardException("Access to a symbol outside of available rect.");

            if (relativeY >= _size.Height)
                throw new ChalkboardException("Access to a symbol outside of available rect.");

            var (renderingX, renderingY) = _renderingPoint;

            return new Point(renderingX + relativeX, renderingY + relativeY);
        }
    }
}