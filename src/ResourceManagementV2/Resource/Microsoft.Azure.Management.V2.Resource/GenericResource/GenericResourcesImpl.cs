using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.GenericResource.Definition;
using System.Threading;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class GenericResourcesImpl : 
        GroupableResources<IGenericResource, GenericResourceImpl, GenericResourceInner, IResourcesOperations, IResourceManager>,
        IGenericResources
    {
        private ResourceManagementClient client;

        internal GenericResourcesImpl(ResourceManagementClient client, IResourceManager resourceManager) : base(client.Resources, resourceManager)
        {
            this.client = client;
        }

        public bool CheckExistence(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
        {
            return InnerCollection.CheckExistence(
                resourceGroupName,
                resourceProviderNamespace,
                parentResourcePath,
                resourceType,
                resourceName,
                apiVersion);
        }

        public IBlank Define(string name)
        {
            return new GenericResourceImpl(name, new GenericResourceInner(), this.client.Resources, MyManager);
        }

        public void Delete(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
        {
            this.InnerCollection.Delete(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion);
        }

        public IGenericResource Get(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
        {
            // Correct for auto-gen'd API's treatment parent path as required even though it makes sense only for child resources
            if (parentResourcePath == null)
            {
                parentResourcePath = "";
            }

            GenericResourceInner inner = InnerCollection.Get(
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
                    MyManager)
            {
                resourceProviderNamespace = resourceProviderNamespace,
                parentResourceId = parentResourcePath,
                resourceType = resourceType,
                apiVersion = apiVersion
            };

            return resource;
        }

        public override Task<IGenericResource> GetByGroupAsync(string groupName, string name)
        {
            // Not needed, can't be supported, provided only to satisfy GroupableResourceImpl's requirements
            return null;
        }

        public PagedList<IGenericResource> ListByGroup(string resourceGroupName)
        {
            IPage<GenericResourceInner> firstPage = InnerCollection.List();
            var pagedList = new PagedList<GenericResourceInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
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
            InnerCollection.MoveResources(sourceResourceGroupName, moveInfo);
        }

        protected override IGenericResource WrapModel(GenericResourceInner inner)
        {
            IGenericResource model = (IGenericResource)new GenericResourceImpl(inner.Id, inner, this.client.Resources, MyManager)
            {
                resourceProviderNamespace = ResourceUtils.ResourceProviderFromResourceId(inner.Id),
                parentResourceId = ResourceUtils.ParentResourcePathFromResourceId(inner.Id),
                resourceType = ResourceUtils.ResourceTypeFromResourceId(inner.Id)
            }.WithExistingResourceGroup(ResourceUtils.GroupFromResourceId(inner.Id));
            return model;
        }

        protected override GenericResourceImpl WrapModel(string id)
        {
            GenericResourceImpl model = (GenericResourceImpl)new GenericResourceImpl(id, new GenericResourceInner(), this.client.Resources, MyManager)
            {
                resourceProviderNamespace = ResourceUtils.ResourceProviderFromResourceId(id),
                parentResourceId = ResourceUtils.ParentResourcePathFromResourceId(id),
                resourceType = ResourceUtils.ResourceTypeFromResourceId(id)
            }.WithExistingResourceGroup(ResourceUtils.GroupFromResourceId(id));
            return model;
        }
    }
}
