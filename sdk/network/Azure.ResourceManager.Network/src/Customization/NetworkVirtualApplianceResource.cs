// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVirtualApplianceResource : ArmResource
    {
        private ClientDiagnostics _inboundSecurityRuleClientDiagnostics;
        private InboundSecurityRuleRestOperations _inboundSecurityRuleRestClient;

        private ClientDiagnostics InboundSecurityRuleClientDiagnostics
        {
            get => _inboundSecurityRuleClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Network", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        }
        private InboundSecurityRuleRestOperations InboundSecurityRuleRestClient
        {
            get => _inboundSecurityRuleRestClient ??= new InboundSecurityRuleRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        }

        /// <summary>
        /// Restarts one or more VMs belonging to the specified Network Virtual Appliance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}/restart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetworkVirtualAppliances_Restart</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkVirtualApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkVirtualApplianceInstanceIds"> Specifies a list of virtual machine instance IDs from the Network Virtual Appliance VM instances. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Restart(NetworkVirtualApplianceInstanceIds networkVirtualApplianceInstanceIds = null, CancellationToken cancellationToken = default)
            => Restart(WaitUntil.Completed, networkVirtualApplianceInstanceIds, cancellationToken).GetRawResponse();

        /// <summary>
        /// Restarts one or more VMs belonging to the specified Network Virtual Appliance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}/restart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetworkVirtualAppliances_Restart</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkVirtualApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkVirtualApplianceInstanceIds"> Specifies a list of virtual machine instance IDs from the Network Virtual Appliance VM instances. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> RestartAsync(NetworkVirtualApplianceInstanceIds networkVirtualApplianceInstanceIds = null, CancellationToken cancellationToken = default)
            => (await RestartAsync(WaitUntil.Completed, networkVirtualApplianceInstanceIds, cancellationToken).ConfigureAwait(false)).GetRawResponse();

        /// <summary>
        /// Creates or updates the specified Network Virtual Appliance Inbound Security Rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}/inboundSecurityRules/{ruleCollectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>InboundSecurityRule_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleCollectionName"> The name of security rule collection. </param>
        /// <param name="inboundSecurityRule"> Parameters supplied to the create or update Network Virtual Appliance Inbound Security Rules operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionName"/> or <paramref name="inboundSecurityRule"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<InboundSecurityRule>> CreateOrUpdateInboundSecurityRuleAsync(WaitUntil waitUntil, string ruleCollectionName, InboundSecurityRule inboundSecurityRule, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionName, nameof(ruleCollectionName));
            Argument.AssertNotNull(inboundSecurityRule, nameof(inboundSecurityRule));

            using var scope = InboundSecurityRuleClientDiagnostics.CreateScope("NetworkVirtualApplianceResource.CreateOrUpdateInboundSecurityRule");
            scope.Start();
            try
            {
                var response = await InboundSecurityRuleRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionName, inboundSecurityRule, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<InboundSecurityRule>(new ObsoleteInboundSecurityRuleOperationSource(), InboundSecurityRuleClientDiagnostics, Pipeline, InboundSecurityRuleRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionName, inboundSecurityRule).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates the specified Network Virtual Appliance Inbound Security Rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}/inboundSecurityRules/{ruleCollectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>InboundSecurityRule_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleCollectionName"> The name of security rule collection. </param>
        /// <param name="inboundSecurityRule"> Parameters supplied to the create or update Network Virtual Appliance Inbound Security Rules operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionName"/> or <paramref name="inboundSecurityRule"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<InboundSecurityRule> CreateOrUpdateInboundSecurityRule(WaitUntil waitUntil, string ruleCollectionName, InboundSecurityRule inboundSecurityRule, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionName, nameof(ruleCollectionName));
            Argument.AssertNotNull(inboundSecurityRule, nameof(inboundSecurityRule));

            using var scope = InboundSecurityRuleClientDiagnostics.CreateScope("NetworkVirtualApplianceResource.CreateOrUpdateInboundSecurityRule");
            scope.Start();
            try
            {
                var response = InboundSecurityRuleRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionName, inboundSecurityRule, cancellationToken);
                var operation = new NetworkArmOperation<InboundSecurityRule>(new ObsoleteInboundSecurityRuleOperationSource(), InboundSecurityRuleClientDiagnostics, Pipeline, InboundSecurityRuleRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionName, inboundSecurityRule).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This is a copy of old InboundSecurityRuleOperationSource class.
        /// </summary>
        private class ObsoleteInboundSecurityRuleOperationSource : IOperationSource<InboundSecurityRule>
        {
            InboundSecurityRule IOperationSource<InboundSecurityRule>.CreateResult(Response response, CancellationToken cancellationToken)
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                return InboundSecurityRule.DeserializeInboundSecurityRule(document.RootElement);
            }

            async ValueTask<InboundSecurityRule> IOperationSource<InboundSecurityRule>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                return InboundSecurityRule.DeserializeInboundSecurityRule(document.RootElement);
            }
        }
    }
}
