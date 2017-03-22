﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System.Threading;
using System.Threading.Tasks;

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
