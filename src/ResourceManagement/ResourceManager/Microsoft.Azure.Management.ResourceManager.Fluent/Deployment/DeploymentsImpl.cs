﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Deployment.Definition;
using Microsoft.Azure.Management.Resource.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.Resource.Fluent
{
    internal class DeploymentsImpl : IDeployments
    {
        private IDeploymentsOperations client;
        private IDeploymentOperationsOperations deploymentOperationsClient;
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
                return client;
            }
        }

        internal DeploymentsImpl(IDeploymentsOperations client, IDeploymentOperationsOperations deploymentOperationsClient, IResourceManager resourceManager)
        {
            this.client = client;
            this.deploymentOperationsClient = deploymentOperationsClient;
            this.resourceManager = resourceManager;
        }

        public bool CheckExistence(string resourceGroupName, string deploymentName)
        {
            return client.CheckExistence(resourceGroupName, deploymentName);
        }

        public IBlank Define(string name)
        {
            return CreateFluentModel(name);
        }

        public void DeleteById(string id)
        {
            DeleteByIdAsync(id).Wait();
        }

        public void DeleteByGroup(string groupName, string name)
        {
            DeleteByGroupAsync(groupName, name).Wait();
        }

        public Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteByGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return client.DeleteAsync(groupName, name, cancellationToken);
        }

        public IDeployment GetByGroup(string resourceGroupName, string name)
        {
            return GetByGroupAsync(resourceGroupName, name).Result;
        }

        public async Task<IDeployment> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var deploymentExtendedInner = await client.GetAsync(resourceGroupName, name, cancellationToken);
            return CreateFluentModel(deploymentExtendedInner);
        }

        public IDeployment GetById(string id)
        {
            return GetByIdAsync(id).Result;
        }

        public Task<IDeployment> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetByGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public IDeployment GetByName(string name)
        {
            var resourceGroups = resourceManager.ResourceGroups.List();
            foreach (var resourceGroup in resourceGroups)
            {
                try
                {
                    var deploymentExtendedInner = client.Get(resourceGroup.Name, name);
                    if (deploymentExtendedInner != null)
                    {
                        return CreateFluentModel(deploymentExtendedInner);
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

        public PagedList<IDeployment> List()
        {
            return new ChildListFlattener<IResourceGroup, IDeployment>(resourceManager.ResourceGroups.List(), (IResourceGroup resourceGroup) =>
            {
                return ListByGroup(resourceGroup.Name);
            }).Flatten();
        }

        public PagedList<IDeployment> ListByGroup(string resourceGroupName)
        {
            IPage<DeploymentExtendedInner> firstPage = client.List(resourceGroupName);
            var innerList = new PagedList<DeploymentExtendedInner>(firstPage, (string nextPageLink) =>
            {
                return client.ListNext(nextPageLink);
            });

            return new PagedList<IDeployment>(new WrappedPage<DeploymentExtendedInner, IDeployment>(innerList.CurrentPage, CreateFluentModel),
            (string nextPageLink) =>
            {
                innerList.LoadNextPage();
                return new WrappedPage<DeploymentExtendedInner, IDeployment>(innerList.CurrentPage, CreateFluentModel);
            });
        }

        public Task<PagedList<IDeployment>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        private DeploymentImpl CreateFluentModel(DeploymentExtendedInner deploymentExtendedInner)
        {
            return new DeploymentImpl(deploymentExtendedInner, client, deploymentOperationsClient, this.resourceManager);
        }

        private DeploymentImpl CreateFluentModel(string name)
        {
            return new DeploymentImpl(
                    new DeploymentExtendedInner
                    {
                        Name = name
                    },
                    client,
                    deploymentOperationsClient,
                    resourceManager
                );
        }
    }
}
