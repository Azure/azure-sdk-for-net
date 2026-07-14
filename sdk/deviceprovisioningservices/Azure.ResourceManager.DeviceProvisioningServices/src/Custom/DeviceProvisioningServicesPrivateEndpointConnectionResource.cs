// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.DeviceProvisioningServices.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DeviceProvisioningServices
{
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]

    public partial class DeviceProvisioningServicesPrivateEndpointConnectionResource
    {
        /// <summary>
        /// Delete private endpoint connection with the specified name
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_DeletePrivateEndpointConnection. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DeviceProvisioningServicesPrivateEndpointConnectionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _privateEndpointConnectionsClientDiagnostics.CreateScope("DeviceProvisioningServicesPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _privateEndpointConnectionsRestClient.CreateDeletePrivateEndpointConnectionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DeviceProvisioningServicesArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource> operation = new DeviceProvisioningServicesArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource>(
                    new DeviceProvisioningServicesPrivateEndpointConnectionResourceOperationSource(Client),
                    _privateEndpointConnectionsClientDiagnostics,
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
        /// Delete private endpoint connection with the specified name
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_DeletePrivateEndpointConnection. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DeviceProvisioningServicesPrivateEndpointConnectionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _privateEndpointConnectionsClientDiagnostics.CreateScope("DeviceProvisioningServicesPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _privateEndpointConnectionsRestClient.CreateDeletePrivateEndpointConnectionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                DeviceProvisioningServicesArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource> operation = new DeviceProvisioningServicesArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource>(
                    new DeviceProvisioningServicesPrivateEndpointConnectionResourceOperationSource(Client),
                    _privateEndpointConnectionsClientDiagnostics,
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
