using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Resource.GroupableResource.Definition
{
    public interface IWithGroup<T> :
        IWithNewResourceGroup<T>,
        IWithExistingResourceGroup<T>
    {}

    public interface IWithNewResourceGroup<T>
    {
        T WithNewResourceGroup(string name);

        T WithNewResourceGroup();

        T WithNewResourceGroup(ICreatable<IResourceGroup> creatable);
    }

    public interface IWithExistingResourceGroup<T>
    {
        T WithExistingResourceGroup(string groupName);

        T WithExistingResourceGroup(IResourceGroup resourceGroup);
    }
}
