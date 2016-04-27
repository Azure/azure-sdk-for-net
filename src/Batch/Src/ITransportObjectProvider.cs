namespace Microsoft.Azure.Batch
{
    internal interface ITransportObjectProvider<out T>
    {
        T GetTransportObject();
    }

    internal static class TransportObjectProviderExtensions
    {
        internal static T GetTransportObject<T>(this ITransportObjectProvider<T> objectProvider)
        {
            return objectProvider.GetTransportObject();
        }
    }
}
