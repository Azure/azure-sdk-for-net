// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Collections.Generic;
using System;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
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

        public IEnumerable<IResourceGroup> List()
        {
           return WrapList(Extensions.Synchronize(() => Inner.ListAsync())
                                .AsContinuousCollection(link => Extensions.Synchronize(() => Inner.ListNextAsync(link))));
        }

        public bool CheckExistence(string name)
        {
            return Extensions.Synchronize(() => CheckExistenceAsync(name));
        }
        public async Task<bool> CheckExistenceAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Inner.CheckExistenceAsync(name, cancellationToken);
        }

        public ResourceGroup.Definition.IBlank Define(string name)
        {
            ResourceGroupInner inner = new ResourceGroupInner();
            inner.Name = name;
            return new ResourceGroupImpl(inner, Inner);
        }

        public void DeleteByName(string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(name));
        }

        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(name, cancellationToken);
        }

        public override void DeleteById(string id)
        {
            DeleteByName(ResourceUtils.NameFromResourceId(id));
        }

        public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteByNameAsync(ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public IResourceGroup GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        public async Task<IResourceGroup> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceGroupInner = await Inner.GetAsync(name, cancellationToken);
            return WrapModel(resourceGroupInner);
        }
        
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

        public async Task<IPagedCollection<IResourceGroup>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IResourceGroup, ResourceGroupInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(cancellationToken: cancellationToken),
                Inner.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        public IEnumerable<IResourceGroup> ListByTag(string tagName, string tagValue)
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAsync(ResourceUtils.CreateODataFilterForTags(tagName, tagValue)))
                    .AsContinuousCollection((nextLink) => Extensions.Synchronize(() => Inner.ListNextAsync(nextLink))));
        }

        public async Task<IPagedCollection<IResourceGroup>> ListByTagAsync(string tagName, string tagValue, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IResourceGroup, ResourceGroupInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(
                    ResourceUtils.CreateODataFilterForTags(tagName, tagValue), cancellationToken: cancellation),
                Inner.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        public void BeginDeleteByName(string name)
        {
            Extensions.Synchronize(() => BeginDeleteByNameAsync(name));
        }

        public async Task BeginDeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.BeginDeleteAsync(name, cancellationToken);
        }
    }
}
