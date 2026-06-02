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
    public partial class NetworkFabricIPCommunityResource
    {
        // 1. The TypeSpec patch models now keep the Swagger-compatible TagsUpdate base and the generated
        //    C# update operations accept renamed *PatchContent types.
        // 2. We keep obsolete overloads that accept the shipped *Patch types and serialize those legacy
        //    patch instances into the generated content shape before invoking the same REST operation.
        // 3. Without this custom code, only Update overloads accepting *PatchContent would be generated,
        //    removing the public Update overloads that existing callers use with the shipped patch types.
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkFabricIPCommunityPatchContent, CancellationToken) instead.")]
        public virtual async Task<ArmOperation<NetworkFabricIPCommunityResource>> UpdateAsync(WaitUntil waitUntil, NetworkFabricIPCommunityPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _ipCommunitiesClientDiagnostics.CreateScope("NetworkFabricIPCommunityResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _ipCommunitiesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkFabricIPCommunityPatch.ToRequestContent(patch), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkFabricIPCommunityResource> operation = new ManagedNetworkFabricArmOperation<NetworkFabricIPCommunityResource>(
                    new CompatibilityOperationSource<NetworkFabricIPCommunityResource, NetworkFabricIPCommunityData>(Client, NetworkFabricIPCommunityData.DeserializeNetworkFabricIPCommunityData, (client, data) => new NetworkFabricIPCommunityResource(client, data)),
                    _ipCommunitiesClientDiagnostics,
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

        // 1. The TypeSpec patch models now keep the Swagger-compatible TagsUpdate base and the generated
        //    C# update operations accept renamed *PatchContent types.
        // 2. We keep obsolete overloads that accept the shipped *Patch types and serialize those legacy
        //    patch instances into the generated content shape before invoking the same REST operation.
        // 3. Without this custom code, only Update overloads accepting *PatchContent would be generated,
        //    removing the public Update overloads that existing callers use with the shipped patch types.
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkFabricIPCommunityPatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkFabricIPCommunityResource> Update(WaitUntil waitUntil, NetworkFabricIPCommunityPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _ipCommunitiesClientDiagnostics.CreateScope("NetworkFabricIPCommunityResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _ipCommunitiesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkFabricIPCommunityPatch.ToRequestContent(patch), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkFabricIPCommunityResource> operation = new ManagedNetworkFabricArmOperation<NetworkFabricIPCommunityResource>(
                    new CompatibilityOperationSource<NetworkFabricIPCommunityResource, NetworkFabricIPCommunityData>(Client, NetworkFabricIPCommunityData.DeserializeNetworkFabricIPCommunityData, (client, data) => new NetworkFabricIPCommunityResource(client, data)),
                    _ipCommunitiesClientDiagnostics,
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
