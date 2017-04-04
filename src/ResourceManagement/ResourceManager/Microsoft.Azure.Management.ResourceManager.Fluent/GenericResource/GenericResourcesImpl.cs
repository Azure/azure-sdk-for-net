﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Microsoft.Azure.Management.Fluent.Resource.Core;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class GenericResourcesImpl :
        GroupableResources<IGenericResource, GenericResourceImpl, GenericResourceInner, IResourcesOperations, IResourceManager>,
        IGenericResources
    {
        internal GenericResourcesImpl(IResourceManager resourceManager) : base(resourceManager.Inner.Resources, resourceManager)
        {
        }

        public bool CheckExistence(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
        {
            return Inner.CheckExistence(
                resourceGroupName,
                resourceProviderNamespace,
                parentResourcePath,
                resourceType,
                resourceName,
                apiVersion);
        }

        public IBlank Define(string name)
        {
            return new GenericResourceImpl(name, new GenericResourceInner(), Manager);
        }

        public void Delete(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
        {
            Inner.Delete(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion);
        }

        public IGenericResource Get(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
        {
            // Correct for auto-gen'd API's treatment parent path as required even though it makes sense only for child resources
            if (parentResourcePath == null)
            {
                parentResourcePath = "";
            }

            GenericResourceInner inner = Inner.Get(
                    resourceGroupName,
                    resourceProviderNamespace,
                    parentResourcePath,
                    resourceType,
                    resourceName,
                    apiVersion);
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

        public IEnumerable<IGenericResource> ListByGroup(string resourceGroupName)
        {
            return WrapList(Inner.List()
                                 .AsContinuousCollection(link => Inner.ListNext(link)));
        }

        public void MoveResources(string sourceResourceGroupName, IResourceGroup targetResourceGroup, IList<string> resources)
        {
            ResourcesMoveInfoInner moveInfo = new ResourcesMoveInfoInner()
            {
                TargetResourceGroup = targetResourceGroup.Id,
                Resources = resources,
            };
            Inner.MoveResources(sourceResourceGroupName, moveInfo);
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

        public async Task<IPagedCollection<IGenericResource>> ListByGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IGenericResource, GenericResourceInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(cancellationToken: cancellation),
                Inner.ListNextAsync, WrapModel, loadAllPages, cancellationToken);
        }
    }
}
