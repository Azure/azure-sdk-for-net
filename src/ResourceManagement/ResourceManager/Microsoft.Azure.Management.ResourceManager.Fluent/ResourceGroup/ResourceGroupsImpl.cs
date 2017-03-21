// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Microsoft.Azure.Management.Resource.Fluent
{
    internal class ResourceGroupsImpl : 
        CreatableResources<IResourceGroup, ResourceGroupImpl, ResourceGroupInner>,
        IResourceGroups
    {
        private IResourceGroupsOperations Inner { get; set; }

        internal ResourceGroupsImpl(IResourceGroupsOperations innerCollection)
        {
            Inner = innerCollection;
        }

        public PagedList<IResourceGroup> List()
        {
            IPage<ResourceGroupInner> firstPage = Inner.List();
            var pagedList = new PagedList<ResourceGroupInner>(firstPage, (string nextPageLink) =>
            {
                return Inner.ListNext(nextPageLink);
            });
           return WrapList(pagedList);
        }

        public bool CheckExistence(string name)
        {
            return Inner.CheckExistence(name);
        }

        public ResourceGroup.Definition.IBlank Define(string name)
        {
            ResourceGroupInner inner = new ResourceGroupInner();
            inner.Name = name;
            return new ResourceGroupImpl(inner, Inner);
        }

        public void DeleteByName(string name)
        {
            DeleteByNameAsync(name).Wait();
        }

        public Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Inner.DeleteAsync(name, cancellationToken);
        }

        public override void DeleteById(string id)
        {
            DeleteByName(ResourceUtils.NameFromResourceId(id));
        }

        public override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteByNameAsync(ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public IResourceGroup GetByName(string name)
        {
            return GetByNameAsync(name).Result;
        }

        public async Task<IResourceGroup> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceGroupInner = await Inner.GetAsync(name, cancellationToken);
            return WrapModel(resourceGroupInner);
        }

        #region Implementation of CreatableWrappers abstract methods

        protected override ResourceGroupImpl WrapModel(string name)
        {
            return new ResourceGroupImpl(new ResourceGroupInner
            {
                Name = name
            }, Inner);
        }

        protected override IResourceGroup WrapModel(ResourceGroupInner inner)
        {
            return new ResourceGroupImpl(inner, Inner);
        }

        #endregion
    }
}
