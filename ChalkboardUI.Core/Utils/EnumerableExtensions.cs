namespace ChalkboardUI.Utils
{
    public static class EnumerableExtensions
    {
        public static void ForEach<TItem>(this IEnumerable<TItem>? items, Action<TItem> handle)
        {
            if (items == null)
                return;

            foreach (var item in items)
            {
                handle(item);
            }
        }

        public static void ForEach<TItem>(this IEnumerable<TItem>? items, Action<TItem, int> handle)
        {
            if (items == null)
                return;

            var idx = 0;
            foreach (var item in items)
            {
                handle(item, idx++);
            }
        }
    }
}