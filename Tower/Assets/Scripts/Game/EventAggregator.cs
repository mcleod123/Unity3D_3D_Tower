public static class EventAggregator
{
    public static void Subscribe<T>(System.Action<object, T> callback)
    {
        EventHolder<T>.Event += callback;
    }

    public static void Unsubscribe<T>(System.Action<object, T> callback)
    {
        EventHolder<T>.Event -= callback;
    }

    public static void Post<T>(object sender, T evendData)
    {
        EventHolder<T>.Post(sender, evendData);
    }

    private static class EventHolder<T>
    {
        public static event System.Action<object, T> Event;
        public static void Post(object sender, T evendData)
        {
            Event?.Invoke(sender, evendData);
        }
    }
}
