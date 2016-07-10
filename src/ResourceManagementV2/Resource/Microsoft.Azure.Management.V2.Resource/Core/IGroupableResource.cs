namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public interface IGroupableResource : IResource
    {
        string ResourceGroupName { get; }
    }
}
