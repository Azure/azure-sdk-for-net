namespace Microsoft.Azure.Management.V2.Resource.Core
{
    interface IChildResource : IIndexable
    {
        string Name { get; }
    }
}
