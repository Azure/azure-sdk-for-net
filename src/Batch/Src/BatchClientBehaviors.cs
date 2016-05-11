namespace Microsoft.Azure.Batch
{
    using Common;

    /// <summary>
    /// Derived classes modify operational behaviors of a Azure Batch Service client.  Derived classes can be called out of order and simultaneously by several threads.  Implementations should be threadsafe.
    /// </summary>
    public abstract class BatchClientBehavior
    {
    }
}
