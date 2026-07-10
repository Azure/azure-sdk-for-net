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
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DeviceProvisioningServices
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource>.
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class DeviceProvisioningServicesPrivateEndpointConnectionResource
    {
        /// <summary> Delete private endpoint connection with the specified name. </summary>
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
                DeviceProvisioningServicesArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource> operation = new DeviceProvisioningServicesArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource>(new DeviceProvisioningServicesPrivateEndpointConnectionResourceOperationSource(Client), _privateEndpointConnectionsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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

        /// <summary> Delete private endpoint connection with the specified name. </summary>
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
                DeviceProvisioningServicesArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource> operation = new DeviceProvisioningServicesArmOperation<DeviceProvisioningServicesPrivateEndpointConnectionResource>(new DeviceProvisioningServicesPrivateEndpointConnectionResourceOperationSource(Client), _privateEndpointConnectionsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
