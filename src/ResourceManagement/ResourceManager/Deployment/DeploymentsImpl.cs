// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Deployment.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class DeploymentsImpl : IDeployments
    {
        private IResourceManager resourceManager;

        public IResourceManager Manager
        {
            get
            {
                return resourceManager;
            }
        }

        public IDeploymentsOperations Inner
        {
            get
            {
                return Manager.Inner.Deployments;
            }
        }

        internal DeploymentsImpl(IResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        public bool CheckExistence(string resourceGroupName, string deploymentName)
        {
            return Extensions.Synchronize(() => Manager.Inner.Deployments.CheckExistenceAsync(resourceGroupName, deploymentName));
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id, CancellationToken.None));
        }

        public void DeleteByResourceGroup(string groupName, string name)
        {
            Extensions.Synchronize(() =>  DeleteByResourceGroupAsync(groupName, name, CancellationToken.None));
        }

        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteByResourceGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public async Task DeleteByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Deployments.DeleteAsync(groupName, name, cancellationToken);
        }

        public IDeployment GetByResourceGroup(string resourceGroupName, string name)
        {
            return Extensions.Synchronize(() => GetByResourceGroupAsync(resourceGroupName, name, CancellationToken.None));
        }

        public async Task<IDeployment> GetByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var deploymentExtendedInner = await Manager.Inner.Deployments.GetAsync(resourceGroupName, name, cancellationToken);
            return WrapModel(deploymentExtendedInner);
        }

        public IDeployment GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        public async Task<IDeployment> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetByResourceGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public IDeployment GetByName(string name)
        {
            var resourceGroups = resourceManager.ResourceGroups.List();
            foreach (var resourceGroup in resourceGroups)
            {
                try
                {
                    var deploymentExtendedInner = Extensions.Synchronize(() => Manager.Inner.Deployments.GetAsync(resourceGroup.Name, name));
                    if (deploymentExtendedInner != null)
                    {
                        return WrapModel(deploymentExtendedInner);
                    }
                }
                catch (CloudException)
                {
                }
            }
            return null;
        }

        public Task<IDeployment> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public IEnumerable<IDeployment> List()
        {
            return resourceManager.ResourceGroups.List()
                                                 .SelectMany(rg => ListByResourceGroup(rg.Name));
        }

        public IEnumerable<IDeployment> ListByResourceGroup(string resourceGroupName)
        {
            return Extensions.Synchronize(() => Manager.Inner.Deployments.ListAsync(resourceGroupName))
                                            .AsContinuousCollection(link => Extensions.Synchronize(() => Manager.Inner.Deployments.ListNextAsync(link)))
                                            .Select(inner => WrapModel(inner));
        }

        private DeploymentImpl WrapModel(DeploymentExtendedInner deploymentExtendedInner)
        {
            return new DeploymentImpl(deploymentExtendedInner, resourceManager);
        }

        private DeploymentImpl WrapModel(string name)
        {
            return new DeploymentImpl(
                    new DeploymentExtendedInner
                    {
                        Name = name
                    },
                    resourceManager
                );
        }

        public async Task<IPagedCollection<IDeployment>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceGroups = await resourceManager.ResourceGroups.ListAsync(true, cancellationToken);
            var taskResult = await Task.WhenAll(resourceGroups.Select(async (rg) => await ListByResourceGroupAsync(rg.Name, true, cancellationToken)));
            return PagedCollection<IDeployment, DeploymentExtendedInner>.CreateFromEnumerable(taskResult.SelectMany(deployment => deployment));
        }

        public async Task<IPagedCollection<IDeployment>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IDeployment, DeploymentExtendedInner>.LoadPage(
                async (cancellation) => await Manager.Inner.Deployments.ListAsync(resourceGroupName, cancellationToken: cancellationToken),
                Manager.Inner.Deployments.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}
