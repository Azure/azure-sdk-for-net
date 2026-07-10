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

namespace Azure.ResourceManager.KeyVault
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<ManagedHsmPrivateEndpointConnectionResource>.
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class ManagedHsmPrivateEndpointConnectionResource
    {
        /// <summary> Deletes private endpoint connection. </summary>
        public virtual async Task<ArmOperation<ManagedHsmPrivateEndpointConnectionResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _mhsmPrivateEndpointConnectionsClientDiagnostics.CreateScope("ManagedHsmPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _mhsmPrivateEndpointConnectionsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                KeyVaultArmOperation<ManagedHsmPrivateEndpointConnectionResource> operation = new KeyVaultArmOperation<ManagedHsmPrivateEndpointConnectionResource>(new DeleteOperationSource(Client, Id), _mhsmPrivateEndpointConnectionsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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

        /// <summary> Deletes private endpoint connection. </summary>
        public virtual ArmOperation<ManagedHsmPrivateEndpointConnectionResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _mhsmPrivateEndpointConnectionsClientDiagnostics.CreateScope("ManagedHsmPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _mhsmPrivateEndpointConnectionsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                KeyVaultArmOperation<ManagedHsmPrivateEndpointConnectionResource> operation = new KeyVaultArmOperation<ManagedHsmPrivateEndpointConnectionResource>(new DeleteOperationSource(Client, Id), _mhsmPrivateEndpointConnectionsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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

        private sealed class DeleteOperationSource : IOperationSource<ManagedHsmPrivateEndpointConnectionResource>
        {
            private readonly ArmClient _client;
            private readonly ResourceIdentifier _id;

            internal DeleteOperationSource(ArmClient client, ResourceIdentifier id)
            {
                _client = client;
                _id = id;
            }

            ManagedHsmPrivateEndpointConnectionResource IOperationSource<ManagedHsmPrivateEndpointConnectionResource>.CreateResult(Response response, CancellationToken cancellationToken)
                => new ManagedHsmPrivateEndpointConnectionResource(_client, _id);

            ValueTask<ManagedHsmPrivateEndpointConnectionResource> IOperationSource<ManagedHsmPrivateEndpointConnectionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
                => new ValueTask<ManagedHsmPrivateEndpointConnectionResource>(new ManagedHsmPrivateEndpointConnectionResource(_client, _id));
        }
    }
}
