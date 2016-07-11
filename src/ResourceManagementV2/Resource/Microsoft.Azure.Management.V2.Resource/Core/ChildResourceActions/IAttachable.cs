namespace Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions
{
    public interface IAttachable<ParentT>
    {
        ParentT Attach();
    }
}
