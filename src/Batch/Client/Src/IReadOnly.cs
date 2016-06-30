namespace Microsoft.Azure.Batch
{
    internal interface IReadOnly
    {
        bool IsReadOnly { get; set; }
    }

    internal static class ReadOnlyExtensions
    {
        //TODO: It would be nice if semantically this didn't modify the initial object.  Sadly I am
        //TODO: not sure how we can easily accomplish that right now.
        internal static T Freeze<T>(this T o) where T : IReadOnly
        {
            o.IsReadOnly = true;
            return o;
        }
    }
}
