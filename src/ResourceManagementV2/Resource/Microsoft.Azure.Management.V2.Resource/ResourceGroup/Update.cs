using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Resource.ResourceGroup.Update
{
    public interface IUpdate :
        IApplicable<IResourceGroup>,
        Resource.Update.IWithTags<IUpdate>
    {}
}
