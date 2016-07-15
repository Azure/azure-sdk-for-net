namespace Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions
{
    public interface ISettable<ParentT>
    {
        ParentT Parent();
    }
}
