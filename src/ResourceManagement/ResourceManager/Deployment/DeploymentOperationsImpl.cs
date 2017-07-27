// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

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
            return WrapModel(Extensions.Synchronize(() => client.GetAsync(deployment.ResourceGroupName, deployment.Name, operationId)));
        }

        public async Task<IDeploymentOperation> GetByIdAsync(string operationId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await client.GetAsync(deployment.ResourceGroupName, deployment.Name, operationId, cancellationToken);
            return WrapModel(inner);
        }

        public IEnumerable<IDeploymentOperation> List()
        {
            return Extensions.Synchronize(() => client.ListAsync(deployment.ResourceGroupName, deployment.Name))
                         .AsContinuousCollection(link => Extensions.Synchronize(() => client.ListNextAsync(link)))
                         .Select(inner => WrapModel(inner));
        }

        public async Task<IPagedCollection<IDeploymentOperation>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IDeploymentOperation, DeploymentOperationInner>.LoadPage(
                async (cancellation) => await client.ListAsync(deployment.ResourceGroupName, deployment.Name, cancellationToken: cancellation),
                client.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        #endregion

        private DeploymentOperationImpl WrapModel(DeploymentOperationInner deploymentOperationInner)
        {
            return new DeploymentOperationImpl(deploymentOperationInner, client);
        }
    }
}
