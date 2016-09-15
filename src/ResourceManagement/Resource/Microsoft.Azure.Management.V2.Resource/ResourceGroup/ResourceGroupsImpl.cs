using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class ResourceGroupsImpl : 
        CreatableWrappers<IResourceGroup, ResourceGroupImpl, ResourceGroupInner>,
        IResourceGroups
    {
        private IResourceGroupsOperations InnerCollection { get; set; }

        internal ResourceGroupsImpl(IResourceGroupsOperations innerCollection)
        {
            InnerCollection = innerCollection;
        }

        public PagedList<IResourceGroup> List()
        {
            IPage<ResourceGroupInner> firstPage = InnerCollection.List();
            var pagedList = new PagedList<ResourceGroupInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });
           return WrapList(pagedList);
        }

        public bool CheckExistence(string name)
        {
            return InnerCollection.CheckExistence(name);
        }

        public ResourceGroup.Definition.IBlank Define(string name)
        {
            ResourceGroupInner inner = new ResourceGroupInner();
            inner.Name = name;
            return new ResourceGroupImpl(inner, InnerCollection);
        }

        public void Delete(string name)
        {
            DeleteAsync(name).Wait();
        }

        public Task DeleteAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(name, cancellationToken);
        }

        public IResourceGroup GetByName(string name)
        {
            return GetByNameAsync(name).Result;
        }

        public async Task<IResourceGroup> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceGroupInner = await InnerCollection.GetAsync(name, cancellationToken);
            return WrapModel(resourceGroupInner);
        }

        #region Implementation of CreatableWrappers abstract methods

        protected override ResourceGroupImpl WrapModel(string name)
        {
            return new ResourceGroupImpl(new ResourceGroupInner
            {
                Name = name
            }, InnerCollection);
        }

        protected override IResourceGroup WrapModel(ResourceGroupInner inner)
        {
            return new ResourceGroupImpl(inner, InnerCollection);
        }

        #endregion
    }
}
