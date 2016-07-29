using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.V2.Resource.Core;

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

        public PagedList<IResourceGroup> List()
        {
            throw new NotImplementedException();
        }

        public bool CheckExistence(string name)
        {
            throw new NotImplementedException();
        }

        public ResourceGroup.Definition.IBlank Define(string name)
        {
            ResourceManager.Models.ResourceGroupInner inner = new ResourceManager.Models.ResourceGroupInner();
            inner.Name = name;
            return new ResourceGroupImpl(inner, innerCollection);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public IResourceGroup GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IResourceGroup> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
