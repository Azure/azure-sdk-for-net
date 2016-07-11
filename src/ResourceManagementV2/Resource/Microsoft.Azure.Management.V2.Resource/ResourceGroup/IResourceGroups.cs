using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;

namespace Microsoft.Azure.Management.V2.Resource.ResourceGroup
{
    public interface IResourceGroups :
        ISupportsCreating<Definition.IBlank>
    {
    }
}
