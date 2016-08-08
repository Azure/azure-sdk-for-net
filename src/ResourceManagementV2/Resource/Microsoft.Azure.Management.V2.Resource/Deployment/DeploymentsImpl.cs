using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Deployment.Definition;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class DeploymentsImpl : IDeployments
    {
        private IDeploymentsOperations client;
        private IDeploymentOperationsOperations deploymentOperationsClient;
        private IResourceManager resourceManager;

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

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public void Delete(string groupName, string name)
        {
            DeleteAsync(groupName, name).Wait();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
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
