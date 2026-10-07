// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ContainerInstance.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerInstance
{
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class ContainerGroupResource
    {
        /// <summary>
        /// Delete the specified container group in the specified subscription and resource group. The operation does not delete other resources provided by the user, such as volumes.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ContainerGroupResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _containerGroupsClientDiagnostics.CreateScope("ContainerGroupResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _containerGroupsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ContainerInstanceArmOperation<ContainerGroupResource> operation = new ContainerInstanceArmOperation<ContainerGroupResource>(
                    new ContainerGroupResourceOperationSource(Client),
                    _containerGroupsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete the specified container group in the specified subscription and resource group. The operation does not delete other resources provided by the user, such as volumes.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerGroupResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _containerGroupsClientDiagnostics.CreateScope("ContainerGroupResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _containerGroupsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                ContainerInstanceArmOperation<ContainerGroupResource> operation = new ContainerInstanceArmOperation<ContainerGroupResource>(
                    new ContainerGroupResourceOperationSource(Client),
                    _containerGroupsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
