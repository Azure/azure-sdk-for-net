// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.GenericResource.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class GenericResourcesImpl :
        TopLevelModifiableResources<IGenericResource, GenericResourceImpl, GenericResourceInner, IResourcesOperations, IResourceManager>,
        IGenericResources
    {
        internal GenericResourcesImpl(IResourceManager resourceManager) : base(resourceManager.Inner.Resources, resourceManager)
        {
        }

        public bool CheckExistence(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
        {
            return Extensions.Synchronize (() => CheckExistenceAsync(
                resourceGroupName,
                resourceProviderNamespace,
                parentResourcePath,
                resourceType,
                resourceName,
                apiVersion));
        }

        public async Task<bool> CheckExistenceAsync(
            string resourceGroupName, 
            string resourceProviderNamespace, 
            string parentResourcePath, 
            string resourceType, 
            string resourceName, 
            string apiVersion,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Inner.CheckExistenceAsync(
                resourceGroupName,
                resourceProviderNamespace,
                parentResourcePath,
                resourceType,
                resourceName,
                apiVersion,
                cancellationToken);
        }

        public IBlank Define(string name)
        {
            return new GenericResourceImpl(name, new GenericResourceInner(), Manager);
        }

        public void Delete(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
        {
            Extensions.Synchronize(() => Inner.DeleteAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion));
        }

        public async Task DeleteAsync(
            string resourceGroupName, 
            string resourceProviderNamespace, 
            string parentResourcePath, 
            string resourceType, 
            string resourceName, 
            string apiVersion,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(
                resourceGroupName, 
                resourceProviderNamespace, 
                parentResourcePath, 
                resourceType, 
                resourceName, 
                apiVersion,
                cancellationToken);
        }

        public IGenericResource Get(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
        {
            // Correct for auto-gen'd API's treatment parent path as required even though it makes sense only for child resources
            if (parentResourcePath == null)
            {
                parentResourcePath = "";
            }

            GenericResourceInner inner = Extensions.Synchronize(() => Inner.GetAsync(
                    resourceGroupName,
                    resourceProviderNamespace,
                    parentResourcePath,
                    resourceType,
                    resourceName,
                    apiVersion));
            GenericResourceImpl resource = new GenericResourceImpl(
                    resourceName,
                    inner,
                    Manager)
            {
                resourceProviderNamespace = resourceProviderNamespace,
                parentResourceId = parentResourcePath,
                resourceType = resourceType,
                apiVersion = apiVersion
            };

            return resource;
        }

        protected override Task<GenericResourceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellation)
        {
            throw new NotSupportedException("Get just by resource group and name is not supported. Please use other overloads.");
        }

        public void MoveResources(string sourceResourceGroupName, IResourceGroup targetResourceGroup, IList<string> resources)
        {
            Extensions.Synchronize(() => MoveResourcesAsync(sourceResourceGroupName, targetResourceGroup, resources));
        }

        public async Task MoveResourcesAsync(
            string sourceResourceGroupName, 
            IResourceGroup targetResourceGroup, 
            IList<string> resources,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourcesMoveInfoInner moveInfo = new ResourcesMoveInfoInner()
            {
                TargetResourceGroup = targetResourceGroup.Id,
                Resources = resources,
            };
            await Inner.MoveResourcesAsync(sourceResourceGroupName, moveInfo, cancellationToken);
        }

        protected override IGenericResource WrapModel(GenericResourceInner inner)
        {
            IGenericResource model = (IGenericResource)new GenericResourceImpl(inner.Id, inner, Manager)
            {
                resourceProviderNamespace = ResourceUtils.ResourceProviderFromResourceId(inner.Id),
                parentResourceId = ResourceUtils.ParentResourcePathFromResourceId(inner.Id),
                resourceType = ResourceUtils.ResourceTypeFromResourceId(inner.Id)
            }.WithExistingResourceGroup(ResourceUtils.GroupFromResourceId(inner.Id));
            return model;
        }

        protected override GenericResourceImpl WrapModel(string id)
        {
            GenericResourceImpl model = (GenericResourceImpl)new GenericResourceImpl(id, new GenericResourceInner(), Manager)
            {
                resourceProviderNamespace = ResourceUtils.ResourceProviderFromResourceId(id),
                parentResourceId = ResourceUtils.ParentResourcePathFromResourceId(id),
                resourceType = ResourceUtils.ResourceTypeFromResourceId(id)
            }.WithExistingResourceGroup(ResourceUtils.GroupFromResourceId(id));
            return model;
        }

        protected override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("Delete just by resource group and name is not supported. Please use other overloads.");
        }

        public async Task<IPagedCollection<IGenericResource>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IGenericResource, GenericResourceInner>.LoadPage(
                async (cancellation) => await Manager.Inner.ResourceGroups.ListResourcesAsync(resourceGroupName, cancellationToken: cancellation),
                Manager.Inner.ResourceGroups.ListResourcesNextAsync, WrapModel, loadAllPages, cancellationToken);
        }

        protected async override Task<IPage<GenericResourceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await this.Inner.ListAsync(cancellationToken: cancellationToken);
        }

        protected async override Task<IPage<GenericResourceInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return await this.Inner.ListNextAsync(link, cancellationToken);
        }

        protected async override Task<IPage<GenericResourceInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await Manager.Inner.ResourceGroups.ListResourcesAsync(resourceGroupName, cancellationToken: cancellationToken);
        }

        protected async override Task<IPage<GenericResourceInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Manager.Inner.ResourceGroups.ListResourcesNextAsync(link, cancellationToken);
        }

        public IEnumerable<IGenericResource> ListByTag(string resourceGroupName, string tagName, string tagValue)
        {
            return WrapList(Extensions.Synchronize(() => Manager.Inner.ResourceGroups.ListResourcesAsync(
                    resourceGroupName, ResourceUtils.CreateODataFilterForTags(tagName, tagValue)))
                    .AsContinuousCollection((nextLink) => Extensions.Synchronize(() => Manager.Inner.ResourceGroups.ListResourcesNextAsync(nextLink))));
        }

        public async Task<IPagedCollection<IGenericResource>> ListByTagAsync(string resourceGroupName, string tagName, string tagValue, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IGenericResource, GenericResourceInner>.LoadPage(
                async (cancellation) => await Manager.Inner.ResourceGroups.ListResourcesAsync(
                    resourceGroupName, ResourceUtils.CreateODataFilterForTags(tagName, tagValue), cancellationToken: cancellation),
                Manager.Inner.ResourceGroups.ListResourcesNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}
