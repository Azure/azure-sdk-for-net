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
    // TypeSpec generation emits CreateOrUpdate returning ArmOperation<DscNodeConfigurationResource>.
    // Keep the GA surface that returns a non-generic ArmOperation by customizing these methods so the
    // generator skips emitting its own versions.
    [CodeGenSuppress("CreateOrUpdate", typeof(WaitUntil), typeof(string), typeof(DscNodeConfigurationCreateOrUpdateContent), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdateAsync", typeof(WaitUntil), typeof(string), typeof(DscNodeConfigurationCreateOrUpdateContent), typeof(CancellationToken))]
    public partial class DscNodeConfigurationCollection
    {
        /// <summary>
        /// Create the node configuration identified by node configuration name.
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
        /// <param name="nodeConfigurationName"> The Dsc node configuration name. </param>
        /// <param name="content"> The create or update parameters for configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nodeConfigurationName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="nodeConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> CreateOrUpdateAsync(WaitUntil waitUntil, string nodeConfigurationName, DscNodeConfigurationCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nodeConfigurationName, nameof(nodeConfigurationName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _dscNodeConfigurationRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, nodeConfigurationName, DscNodeConfigurationCreateOrUpdateContent.ToRequestContent(content), context);
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
        /// Create the node configuration identified by node configuration name.
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
        /// <param name="nodeConfigurationName"> The Dsc node configuration name. </param>
        /// <param name="content"> The create or update parameters for configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nodeConfigurationName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="nodeConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation CreateOrUpdate(WaitUntil waitUntil, string nodeConfigurationName, DscNodeConfigurationCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nodeConfigurationName, nameof(nodeConfigurationName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _dscNodeConfigurationRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, nodeConfigurationName, DscNodeConfigurationCreateOrUpdateContent.ToRequestContent(content), context);
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
        /// Create the node configuration identified by node configuration name.
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
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-23. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="nodeConfigurationName"> The Dsc node configuration name. </param>
        /// <param name="content"> The create or update parameters for configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nodeConfigurationName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="nodeConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<DscNodeConfigurationResource>> CreateOrUpdateNodeConfigurationAsync(WaitUntil waitUntil, string nodeConfigurationName, DscNodeConfigurationCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nodeConfigurationName, nameof(nodeConfigurationName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _dscNodeConfigurationRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, nodeConfigurationName, DscNodeConfigurationCreateOrUpdateContent.ToRequestContent(content), context);
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
        /// Create the node configuration identified by node configuration name.
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
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-23. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="nodeConfigurationName"> The Dsc node configuration name. </param>
        /// <param name="content"> The create or update parameters for configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nodeConfigurationName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="nodeConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<DscNodeConfigurationResource> CreateOrUpdateNodeConfiguration(WaitUntil waitUntil, string nodeConfigurationName, DscNodeConfigurationCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nodeConfigurationName, nameof(nodeConfigurationName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _dscNodeConfigurationRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, nodeConfigurationName, DscNodeConfigurationCreateOrUpdateContent.ToRequestContent(content), context);
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
