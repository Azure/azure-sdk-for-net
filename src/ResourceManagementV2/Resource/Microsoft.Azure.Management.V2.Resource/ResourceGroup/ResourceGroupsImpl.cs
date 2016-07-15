using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class ResourceGroupsImpl : 
        IResourceGroups
    {
        IResourceGroupsOperations innerCollection;

        internal ResourceGroupsImpl(IResourceGroupsOperations innerCollection)
        {
            this.innerCollection = innerCollection;
        }

        public ResourceGroup.Definition.IBlank Define(string name)
        {
            ResourceManager.Models.ResourceGroup inner = new ResourceManager.Models.ResourceGroup();
            inner.Name = name;
            return new ResourceGroupImpl(inner, innerCollection);
        }
    }
}
