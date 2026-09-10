// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Automation.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation
{
    // TypeSpec generation emits Update returning ArmOperation<DscNodeConfigurationResource>.
    // Keep the GA surface that returns a non-generic ArmOperation by customizing these methods so the
    // generator skips emitting its own versions.
    [CodeGenSuppress("Update", typeof(WaitUntil), typeof(DscNodeConfigurationCreateOrUpdateContent), typeof(CancellationToken))]
    [CodeGenSuppress("UpdateAsync", typeof(WaitUntil), typeof(DscNodeConfigurationCreateOrUpdateContent), typeof(CancellationToken))]
    public partial class DscNodeConfigurationResource
    {
        /// <summary>
        /// Update a DscNodeConfiguration.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodeConfigurations/{nodeConfigurationName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DscNodeConfigurations_CreateOrUpdate. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The create or update parameters for configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> UpdateAsync(WaitUntil waitUntil, DscNodeConfigurationCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _dscNodeConfigurationRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, DscNodeConfigurationCreateOrUpdateContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                AutomationArmOperation operation = new AutomationArmOperation(_dscNodeConfigurationClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
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
        /// Update a DscNodeConfiguration.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodeConfigurations/{nodeConfigurationName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DscNodeConfigurations_CreateOrUpdate. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The create or update parameters for configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Update(WaitUntil waitUntil, DscNodeConfigurationCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _dscNodeConfigurationRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, DscNodeConfigurationCreateOrUpdateContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                AutomationArmOperation operation = new AutomationArmOperation(_dscNodeConfigurationClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // This customization is represented the resource creation operation defined in the TypeSpec.
        /// <summary>
        /// Update a DscNodeConfiguration.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodeConfigurations/{nodeConfigurationName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DscNodeConfigurations_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DscNodeConfigurationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The create or update parameters for configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<DscNodeConfigurationResource>> UpdateNodeConfigurationAsync(WaitUntil waitUntil, DscNodeConfigurationCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _dscNodeConfigurationRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, DscNodeConfigurationCreateOrUpdateContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                AutomationArmOperation<DscNodeConfigurationResource> operation = new AutomationArmOperation<DscNodeConfigurationResource>(
                    new DscNodeConfigurationResourceOperationSource(Client),
                    _dscNodeConfigurationClientDiagnostics,
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

        // This customization is represented the resource creation operation defined in the TypeSpec.
        /// <summary>
        /// Update a DscNodeConfiguration.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodeConfigurations/{nodeConfigurationName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DscNodeConfigurations_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DscNodeConfigurationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The create or update parameters for configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<DscNodeConfigurationResource> UpdateNodeConfiguration(WaitUntil waitUntil, DscNodeConfigurationCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _dscNodeConfigurationRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, DscNodeConfigurationCreateOrUpdateContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                AutomationArmOperation<DscNodeConfigurationResource> operation = new AutomationArmOperation<DscNodeConfigurationResource>(
                    new DscNodeConfigurationResourceOperationSource(Client),
                    _dscNodeConfigurationClientDiagnostics,
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
