using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest.Azure;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class DeploymentOperationsImpl :
        IDeploymentOperations
    {
        private IDeploymentOperationsOperations client;
        private IDeployment deployment;

        internal DeploymentOperationsImpl(IDeploymentOperationsOperations client, IDeployment deployment)
        {
            this.client = client;
            this.deployment = deployment;
        }

        #region Actions

        public IDeploymentOperation GetById(string operationId)
        {
            return CreateFluentModel(client.Get(deployment.ResourceGroupName, deployment.Name, operationId));
        }

        public async Task<IDeploymentOperation> GetByIdAsync(string operationId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await client.GetAsync(deployment.ResourceGroupName, deployment.Name, operationId);
            return CreateFluentModel(inner);
        }

        public PagedList<IDeploymentOperation> List()
        {
            IPage<DeploymentOperationInner> firstPage = client.List(deployment.ResourceGroupName, deployment.Name);
            var innerList = new PagedList<DeploymentOperationInner>(firstPage, (string nextPageLink) =>
            {
                return client.ListNext(nextPageLink);
            });

            return new PagedList<IDeploymentOperation>(new WrappedPage<DeploymentOperationInner, IDeploymentOperation>(innerList.CurrentPage, CreateFluentModel),
            (string nextPageLink) =>
            {
                innerList.LoadNextPage();
                return new WrappedPage<DeploymentOperationInner, IDeploymentOperation>(innerList.CurrentPage, CreateFluentModel);
            });
        }

        #endregion

        private DeploymentOperationImpl CreateFluentModel(DeploymentOperationInner deploymentOperationInner)
        {
            return new DeploymentOperationImpl(deploymentOperationInner, client);
        }
    }
}
