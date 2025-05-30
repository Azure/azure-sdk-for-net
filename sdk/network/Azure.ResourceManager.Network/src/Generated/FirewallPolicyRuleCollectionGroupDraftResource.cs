// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A Class representing a FirewallPolicyRuleCollectionGroupDraft along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="FirewallPolicyRuleCollectionGroupDraftResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetFirewallPolicyRuleCollectionGroupDraftResource method.
    /// Otherwise you can get one from its parent resource <see cref="FirewallPolicyRuleCollectionGroupResource"/> using the GetFirewallPolicyRuleCollectionGroupDraft method.
    /// </summary>
    public partial class FirewallPolicyRuleCollectionGroupDraftResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="FirewallPolicyRuleCollectionGroupDraftResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="firewallPolicyName"> The firewallPolicyName. </param>
        /// <param name="ruleCollectionGroupName"> The ruleCollectionGroupName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string firewallPolicyName, string ruleCollectionGroupName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}/ruleCollectionGroupDrafts/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _firewallPolicyRuleCollectionGroupDraftClientDiagnostics;
        private readonly FirewallPolicyRuleCollectionGroupDraftsRestOperations _firewallPolicyRuleCollectionGroupDraftRestClient;
        private readonly FirewallPolicyRuleCollectionGroupDraftData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/firewallPolicies/ruleCollectionGroups/ruleCollectionGroupDrafts";

        /// <summary> Initializes a new instance of the <see cref="FirewallPolicyRuleCollectionGroupDraftResource"/> class for mocking. </summary>
        protected FirewallPolicyRuleCollectionGroupDraftResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FirewallPolicyRuleCollectionGroupDraftResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal FirewallPolicyRuleCollectionGroupDraftResource(ArmClient client, FirewallPolicyRuleCollectionGroupDraftData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="FirewallPolicyRuleCollectionGroupDraftResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal FirewallPolicyRuleCollectionGroupDraftResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _firewallPolicyRuleCollectionGroupDraftClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string firewallPolicyRuleCollectionGroupDraftApiVersion);
            _firewallPolicyRuleCollectionGroupDraftRestClient = new FirewallPolicyRuleCollectionGroupDraftsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, firewallPolicyRuleCollectionGroupDraftApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual FirewallPolicyRuleCollectionGroupDraftData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Get Rule Collection Group Draft.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}/ruleCollectionGroupDrafts/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicyRuleCollectionGroupDrafts_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirewallPolicyRuleCollectionGroupDraftResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FirewallPolicyRuleCollectionGroupDraftResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _firewallPolicyRuleCollectionGroupDraftClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupDraftResource.Get");
            scope.Start();
            try
            {
                var response = await _firewallPolicyRuleCollectionGroupDraftRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FirewallPolicyRuleCollectionGroupDraftResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get Rule Collection Group Draft.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}/ruleCollectionGroupDrafts/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicyRuleCollectionGroupDrafts_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirewallPolicyRuleCollectionGroupDraftResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FirewallPolicyRuleCollectionGroupDraftResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _firewallPolicyRuleCollectionGroupDraftClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupDraftResource.Get");
            scope.Start();
            try
            {
                var response = _firewallPolicyRuleCollectionGroupDraftRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FirewallPolicyRuleCollectionGroupDraftResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete Rule Collection Group Draft.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}/ruleCollectionGroupDrafts/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicyRuleCollectionGroupDrafts_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirewallPolicyRuleCollectionGroupDraftResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _firewallPolicyRuleCollectionGroupDraftClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupDraftResource.Delete");
            scope.Start();
            try
            {
                var response = await _firewallPolicyRuleCollectionGroupDraftRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                var uri = _firewallPolicyRuleCollectionGroupDraftRestClient.CreateDeleteRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new NetworkArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete Rule Collection Group Draft.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}/ruleCollectionGroupDrafts/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicyRuleCollectionGroupDrafts_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirewallPolicyRuleCollectionGroupDraftResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _firewallPolicyRuleCollectionGroupDraftClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupDraftResource.Delete");
            scope.Start();
            try
            {
                var response = _firewallPolicyRuleCollectionGroupDraftRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken);
                var uri = _firewallPolicyRuleCollectionGroupDraftRestClient.CreateDeleteRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new NetworkArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or Update Rule Collection Group Draft.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}/ruleCollectionGroupDrafts/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicyRuleCollectionGroupDrafts_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirewallPolicyRuleCollectionGroupDraftResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the create or update FirewallPolicyRuleCollectionGroup operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FirewallPolicyRuleCollectionGroupDraftResource>> CreateOrUpdateAsync(WaitUntil waitUntil, FirewallPolicyRuleCollectionGroupDraftData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _firewallPolicyRuleCollectionGroupDraftClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupDraftResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _firewallPolicyRuleCollectionGroupDraftRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, data, cancellationToken).ConfigureAwait(false);
                var uri = _firewallPolicyRuleCollectionGroupDraftRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new NetworkArmOperation<FirewallPolicyRuleCollectionGroupDraftResource>(Response.FromValue(new FirewallPolicyRuleCollectionGroupDraftResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Create or Update Rule Collection Group Draft.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}/ruleCollectionGroupDrafts/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicyRuleCollectionGroupDrafts_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirewallPolicyRuleCollectionGroupDraftResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the create or update FirewallPolicyRuleCollectionGroup operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FirewallPolicyRuleCollectionGroupDraftResource> CreateOrUpdate(WaitUntil waitUntil, FirewallPolicyRuleCollectionGroupDraftData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _firewallPolicyRuleCollectionGroupDraftClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupDraftResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _firewallPolicyRuleCollectionGroupDraftRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, data, cancellationToken);
                var uri = _firewallPolicyRuleCollectionGroupDraftRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new NetworkArmOperation<FirewallPolicyRuleCollectionGroupDraftResource>(Response.FromValue(new FirewallPolicyRuleCollectionGroupDraftResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
    }
}
