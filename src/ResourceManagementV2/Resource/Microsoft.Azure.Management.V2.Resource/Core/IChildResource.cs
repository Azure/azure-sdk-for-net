namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public interface IChildResource : IIndexable
    {
        string Name { get; }
    }
}
