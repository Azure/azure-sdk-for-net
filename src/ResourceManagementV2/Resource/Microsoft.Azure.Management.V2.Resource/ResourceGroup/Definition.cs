using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Resource.ResourceGroup.Definition
{
    public interface IDefinition : 
        IBlank,
        IWithCreate {
    }

    public interface IBlank : 
        Resource.Definition.IWithRegion<IWithCreate>
    {}

    public interface IWithCreate : 
        ICreatable<IResourceGroup>,
        Resource.Definition.IWithTags<IWithCreate>
    {}
}
