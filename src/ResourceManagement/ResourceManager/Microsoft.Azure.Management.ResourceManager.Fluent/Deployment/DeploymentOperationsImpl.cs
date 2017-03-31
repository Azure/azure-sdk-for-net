// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class DeploymentOperationsImpl :
        IDeploymentOperationsFluent
    {
        private Management.ResourceManager.Fluent.IDeploymentOperations client;
        private IDeployment deployment;

        internal DeploymentOperationsImpl(Management.ResourceManager.Fluent.IDeploymentOperations client, IDeployment deployment)
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
            var inner = await client.GetAsync(deployment.ResourceGroupName, deployment.Name, operationId, cancellationToken);
            return CreateFluentModel(inner);
        }

        public IEnumerable<IDeploymentOperation> List()
        {
            return client.List(deployment.ResourceGroupName, deployment.Name)
                         .AsContinuousCollection(link => client.ListNext(link))
                         .Select(inner => CreateFluentModel(inner));
        }

        #endregion

        private DeploymentOperationImpl CreateFluentModel(DeploymentOperationInner deploymentOperationInner)
        {
            return new DeploymentOperationImpl(deploymentOperationInner, client);
        }
    }
}
