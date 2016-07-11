namespace Microsoft.Azure.Management.V2.Resource
{
    internal class ResourceGroupsImpl : 
        IResourceGroups
    {
        public ResourceGroup.Definition.IBlank Define(string name)
        {
            return new ResourceGroupImpl(null, null);
        }
    }
}
