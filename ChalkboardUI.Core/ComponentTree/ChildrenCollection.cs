using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ChalkboardUI.Exceptions;
using ChalkboardUI.Utils;

namespace ChalkboardUI.ComponentTree
{
    public class ChildrenCollection : ObservableCollection<Component>
    {
        private readonly Component _parent;

        public ChildrenCollection(Component parent)
        {
            _parent = parent;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            e.OldItems?.Cast<Component>().ForEach(DetachParent);
            e.NewItems?.Cast<Component>().ForEach(AttachParent);
        }

        private void AttachParent(Component element)
        {
            if (element.Parent == _parent)
                throw new ChalkboardException("Element is already child of the parent.");

            if (element.Parent != null)
                throw new ChalkboardException("Element is already child of another element.");

            element.AttachToParent(_parent);
        }

        private void DetachParent(Component element) => element.AttachToParent(null);
    }
}