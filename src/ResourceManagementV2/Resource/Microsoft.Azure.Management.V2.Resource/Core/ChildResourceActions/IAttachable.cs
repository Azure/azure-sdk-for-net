namespace Microsoft.Azure.Management.V2.Resource.Core.ChildModel
{
    public interface IAttachable<ParentT>
    {
        ParentT Attach();
    }
}
