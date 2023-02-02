using ChalkboardUI.Units;

namespace ChalkboardUI.ComponentRendering
{
    public static class ComponentRenderer
    {
        public static Size Render(this Component component, RenderingRect rect)
        {
            var leftMargin = component.Margin.Left;
            var topMargin = component.Margin.Top;

            var contentOffset = new Offset(leftMargin, topMargin);
            var contentRect = rect.Offset(contentOffset);

            var (contentWidth, contentHeight) = component.RenderContent(contentRect);

            var rightMargin = component.Margin.Right;
            var bottomMargin = component.Margin.Bottom;

            var totalWidth = leftMargin + contentWidth + rightMargin;
            var totalHeight = topMargin + contentHeight + bottomMargin;

            return new Size(totalWidth, totalHeight);
        }
    }
}