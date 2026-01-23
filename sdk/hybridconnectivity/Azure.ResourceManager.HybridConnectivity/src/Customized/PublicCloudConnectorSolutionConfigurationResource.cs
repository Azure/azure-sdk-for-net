// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.HybridConnectivity.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridConnectivity
{
    /// <summary>
    /// A class representing a PublicCloudConnectorSolutionConfiguration along with the instance operations that can be performed on it.
    /// </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SyncNow", typeof(WaitUntil), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SyncNowAsync", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class PublicCloudConnectorSolutionConfigurationResource
    {
        /// <summary>
        /// Trigger immediate sync with source cloud
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceUri}/providers/Microsoft.HybridConnectivity/solutionConfigurations/{solutionConfiguration}/syncNow. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SolutionConfigurations_SyncNow. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-12-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="PublicCloudConnectorSolutionConfigurationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<HybridConnectivityOperationStatus>> SyncNowAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _solutionConfigurationsClientDiagnostics.CreateScope("PublicCloudConnectorSolutionConfigurationResource.SyncNow");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _solutionConfigurationsRestClient.CreateSyncNowRequest(Id.Parent, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                HybridConnectivityArmOperation<HybridConnectivityOperationStatus> operation = new HybridConnectivityArmOperation<HybridConnectivityOperationStatus>(
                    new HybridConnectivityOperationStatusOperationSource(),
                    _solutionConfigurationsClientDiagnostics,
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
        /// Trigger immediate sync with source cloud
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceUri}/providers/Microsoft.HybridConnectivity/solutionConfigurations/{solutionConfiguration}/syncNow. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SolutionConfigurations_SyncNow. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-12-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="PublicCloudConnectorSolutionConfigurationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<HybridConnectivityOperationStatus> SyncNow(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _solutionConfigurationsClientDiagnostics.CreateScope("PublicCloudConnectorSolutionConfigurationResource.SyncNow");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _solutionConfigurationsRestClient.CreateSyncNowRequest(Id.Parent, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                HybridConnectivityArmOperation<HybridConnectivityOperationStatus> operation = new HybridConnectivityArmOperation<HybridConnectivityOperationStatus>(
                    new HybridConnectivityOperationStatusOperationSource(),
                    _solutionConfigurationsClientDiagnostics,
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
