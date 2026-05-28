// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricIPPrefixResource
    {
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkFabricIPPrefixPatchContent, CancellationToken) instead.")]
        public virtual async Task<ArmOperation<NetworkFabricIPPrefixResource>> UpdateAsync(WaitUntil waitUntil, NetworkFabricIPPrefixPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _ipPrefixesClientDiagnostics.CreateScope("NetworkFabricIPPrefixResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _ipPrefixesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkFabricIPPrefixPatch.ToRequestContent(patch), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkFabricIPPrefixResource> operation = new ManagedNetworkFabricArmOperation<NetworkFabricIPPrefixResource>(
                    new NetworkFabricIPPrefixOperationSource(Client),
                    _ipPrefixesClientDiagnostics,
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

        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkFabricIPPrefixPatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkFabricIPPrefixResource> Update(WaitUntil waitUntil, NetworkFabricIPPrefixPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _ipPrefixesClientDiagnostics.CreateScope("NetworkFabricIPPrefixResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _ipPrefixesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkFabricIPPrefixPatch.ToRequestContent(patch), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkFabricIPPrefixResource> operation = new ManagedNetworkFabricArmOperation<NetworkFabricIPPrefixResource>(
                    new NetworkFabricIPPrefixOperationSource(Client),
                    _ipPrefixesClientDiagnostics,
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
