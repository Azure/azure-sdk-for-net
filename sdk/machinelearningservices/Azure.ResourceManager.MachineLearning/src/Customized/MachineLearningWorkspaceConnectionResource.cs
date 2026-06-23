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
using Azure.ResourceManager;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A Class representing a MachineLearningWorkspaceConnection along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="MachineLearningWorkspaceConnectionResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetMachineLearningWorkspaceConnectionResource method.
    /// Otherwise you can get one from its parent resource <see cref="MachineLearningWorkspaceResource" /> using the GetMachineLearningWorkspaceConnection method.
    /// </summary>
    public partial class MachineLearningWorkspaceConnectionResource : ArmResource
    {
        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections/{connectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceConnections_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The object for creating or updating a new workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<MachineLearningWorkspaceConnectionResource>> UpdateAsync(WaitUntil waitUntil, MachineLearningWorkspaceConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            // Customized: preserve the shipped resource-instance WorkspaceConnections_Create method shape.
            // The generator emits the full-resource PUT only on the collection, so this shim reuses the
            // generated PUT RestOperation instead of sending the PATCH-shaped generated Update request.
            using DiagnosticScope scope = _workspaceConnectionsClientDiagnostics.CreateScope("MachineLearningWorkspaceConnectionResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _workspaceConnectionsRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MachineLearningWorkspaceConnectionData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MachineLearningWorkspaceConnectionData> response = Response.FromValue(MachineLearningWorkspaceConnectionData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                MachineLearningArmOperation<MachineLearningWorkspaceConnectionResource> operation = new MachineLearningArmOperation<MachineLearningWorkspaceConnectionResource>(Response.FromValue(new MachineLearningWorkspaceConnectionResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections/{connectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceConnections_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The object for creating or updating a new workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<MachineLearningWorkspaceConnectionResource> Update(WaitUntil waitUntil, MachineLearningWorkspaceConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            // Customized: preserve the shipped resource-instance WorkspaceConnections_Create method shape.
            // The generator emits the full-resource PUT only on the collection, so this shim reuses the
            // generated PUT RestOperation instead of sending the PATCH-shaped generated Update request.
            using DiagnosticScope scope = _workspaceConnectionsClientDiagnostics.CreateScope("MachineLearningWorkspaceConnectionResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _workspaceConnectionsRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, MachineLearningWorkspaceConnectionData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MachineLearningWorkspaceConnectionData> response = Response.FromValue(MachineLearningWorkspaceConnectionData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                MachineLearningArmOperation<MachineLearningWorkspaceConnectionResource> operation = new MachineLearningArmOperation<MachineLearningWorkspaceConnectionResource>(Response.FromValue(new MachineLearningWorkspaceConnectionResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
