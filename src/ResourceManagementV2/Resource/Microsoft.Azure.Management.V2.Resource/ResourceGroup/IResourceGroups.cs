using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;

namespace Microsoft.Azure.Management.V2.Resource
{
    public interface IResourceGroups :
        ISupportsCreating<ResourceGroup.Definition.IBlank>
    {
    }
}
