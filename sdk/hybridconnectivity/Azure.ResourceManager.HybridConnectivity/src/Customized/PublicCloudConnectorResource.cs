// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.HybridConnectivity.Models;

namespace Azure.ResourceManager.HybridConnectivity
{
    /// <summary>
    /// A class representing a PublicCloudConnector along with the instance operations that can be performed on it.
    /// </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("TestPermissions", typeof(WaitUntil), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("TestPermissionsAsync", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class PublicCloudConnectorResource
    {
        /// <summary>
        /// A long-running resource action.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridConnectivity/publicCloudConnectors/{publicCloudConnector}/testPermissions. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PublicCloudConnectors_TestPermissions. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-12-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="PublicCloudConnectorResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<HybridConnectivityOperationStatus>> TestPermissionsAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _publicCloudConnectorsClientDiagnostics.CreateScope("PublicCloudConnectorResource.TestPermissions");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicCloudConnectorsRestClient.CreateTestPermissionsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                HybridConnectivityArmOperation<HybridConnectivityOperationStatus> operation = new HybridConnectivityArmOperation<HybridConnectivityOperationStatus>(
                    new HybridConnectivityOperationStatusOperationSource(),
                    _publicCloudConnectorsClientDiagnostics,
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
        /// A long-running resource action.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridConnectivity/publicCloudConnectors/{publicCloudConnector}/testPermissions. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PublicCloudConnectors_TestPermissions. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-12-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="PublicCloudConnectorResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<HybridConnectivityOperationStatus> TestPermissions(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _publicCloudConnectorsClientDiagnostics.CreateScope("PublicCloudConnectorResource.TestPermissions");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicCloudConnectorsRestClient.CreateTestPermissionsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                HybridConnectivityArmOperation<HybridConnectivityOperationStatus> operation = new HybridConnectivityArmOperation<HybridConnectivityOperationStatus>(
                    new HybridConnectivityOperationStatusOperationSource(),
                    _publicCloudConnectorsClientDiagnostics,
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
