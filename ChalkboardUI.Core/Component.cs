using ChalkboardUI.ComponentRendering;
using ChalkboardUI.ComponentTree;
using ChalkboardUI.Units;

namespace ChalkboardUI
{
    public abstract class Component
    {
        private Margin _margin;

        public Component()
        {
            Children = new ChildrenCollection(this);
        }

        public event EventHandler? RenderRequested;

        public Component? Parent { get; private set; }

        internal ChildrenCollection Children { get; }

        public Margin Margin
        {
            get => _margin;
            set => SetRenderableValue(ref _margin, in value);
        }

        public abstract Size MeasureContent(Size availableSize);

        public abstract Size RenderContent(RenderingRect rect);

        internal void AttachToParent(Component? parent) => Parent = parent;

        protected void SetRenderableValue<TValue>(ref TValue field, in TValue value)
            where TValue : struct
        {
            if (EqualityComparer<TValue>.Default.Equals(field, value))
                return;

            field = value;
            RaiseRenderRequest();
        }

        private void RaiseRenderRequest() =>
            RenderRequested?.Invoke(this, EventArgs.Empty);
    }
}