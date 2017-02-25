﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resource.Fluent.GenericResource.Definition;
using System.Threading;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.Resource.Fluent
{
    internal class GenericResourcesImpl : 
        GroupableResources<IGenericResource, GenericResourceImpl, GenericResourceInner, IResourcesOperations, IResourceManager>,
        IGenericResources
    {
        private IResourceManagementClient client;

        internal GenericResourcesImpl(IResourceManagementClient client, IResourceManager resourceManager) : base(client.Resources, resourceManager)
        {
            this.client = client;
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
            return new GenericResourceImpl(name, new GenericResourceInner(), this.client.Resources, Manager);
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
                    client.Resources,
                    Manager)
            {
                resourceProviderNamespace = resourceProviderNamespace,
                parentResourceId = parentResourcePath,
                resourceType = resourceType,
                apiVersion = apiVersion
            };

            return resource;
        }

        public override Task<IGenericResource> GetByGroupAsync(string groupName, string name, CancellationToken cancellation = default(CancellationToken))
        {
            throw new NotSupportedException("Get just by resource group and name is not supported. Please use other overloads.");
        }

        public PagedList<IGenericResource> ListByGroup(string resourceGroupName)
        {
            IPage<GenericResourceInner> firstPage = Inner.List();
            var pagedList = new PagedList<GenericResourceInner>(firstPage, (string nextPageLink) =>
            {
                return Inner.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        public Task<PagedList<IGenericResource>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
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
            IGenericResource model = (IGenericResource)new GenericResourceImpl(inner.Id, inner, this.client.Resources, Manager)
            {
                resourceProviderNamespace = ResourceUtils.ResourceProviderFromResourceId(inner.Id),
                parentResourceId = ResourceUtils.ParentResourcePathFromResourceId(inner.Id),
                resourceType = ResourceUtils.ResourceTypeFromResourceId(inner.Id)
            }.WithExistingResourceGroup(ResourceUtils.GroupFromResourceId(inner.Id));
            return model;
        }

        protected override GenericResourceImpl WrapModel(string id)
        {
            GenericResourceImpl model = (GenericResourceImpl)new GenericResourceImpl(id, new GenericResourceInner(), this.client.Resources, Manager)
            {
                resourceProviderNamespace = ResourceUtils.ResourceProviderFromResourceId(id),
                parentResourceId = ResourceUtils.ParentResourcePathFromResourceId(id),
                resourceType = ResourceUtils.ResourceTypeFromResourceId(id)
            }.WithExistingResourceGroup(ResourceUtils.GroupFromResourceId(id));
            return model;
        }

        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException("Delete just by resource group and name is not supported. Please use other overloads.");
        }
    }
}
