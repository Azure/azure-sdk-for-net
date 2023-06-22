// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary>
    /// A class representing a collection of <see cref="SubscriptionGovernanceRuleResource" /> and their operations.
    /// Each <see cref="SubscriptionGovernanceRuleResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="SubscriptionGovernanceRuleCollection" /> instance call the GetSubscriptionGovernanceRules method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This class is obsolete and will be removed in a future release. Please use GovernanceRuleCollection.", false)]
    public partial class SubscriptionGovernanceRuleCollection : ArmCollection, IEnumerable<SubscriptionGovernanceRuleResource>, IAsyncEnumerable<SubscriptionGovernanceRuleResource>
    {
        private readonly ClientDiagnostics _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics;
        private readonly SubscriptionGovernanceRulesRestOperations _subscriptionGovernanceRuleGovernanceRulesRestClient;
        private readonly ClientDiagnostics _subscriptionGovernanceRuleGovernanceRuleClientDiagnostics;
        private readonly SubscriptionGovernanceRuleRestOperations _subscriptionGovernanceRuleGovernanceRuleRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionGovernanceRuleCollection"/> class for mocking. </summary>
        protected SubscriptionGovernanceRuleCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionGovernanceRuleCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SubscriptionGovernanceRuleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", SubscriptionGovernanceRuleResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SubscriptionGovernanceRuleResource.ResourceType, out string subscriptionGovernanceRuleGovernanceRulesApiVersion);
            _subscriptionGovernanceRuleGovernanceRulesRestClient = new SubscriptionGovernanceRulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, subscriptionGovernanceRuleGovernanceRulesApiVersion);
            _subscriptionGovernanceRuleGovernanceRuleClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", SubscriptionGovernanceRuleResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SubscriptionGovernanceRuleResource.ResourceType, out string subscriptionGovernanceRuleGovernanceRuleApiVersion);
            _subscriptionGovernanceRuleGovernanceRuleRestClient = new SubscriptionGovernanceRuleRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, subscriptionGovernanceRuleGovernanceRuleApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubscriptionResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubscriptionResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or update a security GovernanceRule on the given subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="data"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SubscriptionGovernanceRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ruleId, GovernanceRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics.CreateScope("SubscriptionGovernanceRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _subscriptionGovernanceRuleGovernanceRulesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, ruleId, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityCenterArmOperation<SubscriptionGovernanceRuleResource>(Response.FromValue(new SubscriptionGovernanceRuleResource(Client, response), response.GetRawResponse()));
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
        /// Creates or update a security GovernanceRule on the given subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="data"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SubscriptionGovernanceRuleResource> CreateOrUpdate(WaitUntil waitUntil, string ruleId, GovernanceRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics.CreateScope("SubscriptionGovernanceRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _subscriptionGovernanceRuleGovernanceRulesRestClient.CreateOrUpdate(Id.SubscriptionId, ruleId, data, cancellationToken);
                var operation = new SecurityCenterArmOperation<SubscriptionGovernanceRuleResource>(Response.FromValue(new SubscriptionGovernanceRuleResource(Client, response), response.GetRawResponse()));
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
        /// Get a specific governanceRule for the requested scope by ruleId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        public virtual async Task<Response<SubscriptionGovernanceRuleResource>> GetAsync(string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var scope = _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics.CreateScope("SubscriptionGovernanceRuleCollection.Get");
            scope.Start();
            try
            {
                var response = await _subscriptionGovernanceRuleGovernanceRulesRestClient.GetAsync(Id.SubscriptionId, ruleId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubscriptionGovernanceRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a specific governanceRule for the requested scope by ruleId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        public virtual Response<SubscriptionGovernanceRuleResource> Get(string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var scope = _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics.CreateScope("SubscriptionGovernanceRuleCollection.Get");
            scope.Start();
            try
            {
                var response = _subscriptionGovernanceRuleGovernanceRulesRestClient.Get(Id.SubscriptionId, ruleId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubscriptionGovernanceRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a list of all relevant governanceRules over a subscription level scope
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRule_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionGovernanceRuleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubscriptionGovernanceRuleResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _subscriptionGovernanceRuleGovernanceRuleRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _subscriptionGovernanceRuleGovernanceRuleRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionGovernanceRuleResource(Client, GovernanceRuleData.DeserializeGovernanceRuleData(e)), _subscriptionGovernanceRuleGovernanceRuleClientDiagnostics, Pipeline, "SubscriptionGovernanceRuleCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get a list of all relevant governanceRules over a subscription level scope
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRule_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionGovernanceRuleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubscriptionGovernanceRuleResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _subscriptionGovernanceRuleGovernanceRuleRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _subscriptionGovernanceRuleGovernanceRuleRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionGovernanceRuleResource(Client, GovernanceRuleData.DeserializeGovernanceRuleData(e)), _subscriptionGovernanceRuleGovernanceRuleClientDiagnostics, Pipeline, "SubscriptionGovernanceRuleCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var scope = _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics.CreateScope("SubscriptionGovernanceRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = await _subscriptionGovernanceRuleGovernanceRulesRestClient.GetAsync(Id.SubscriptionId, ruleId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        public virtual Response<bool> Exists(string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var scope = _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics.CreateScope("SubscriptionGovernanceRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = _subscriptionGovernanceRuleGovernanceRulesRestClient.Get(Id.SubscriptionId, ruleId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SubscriptionGovernanceRuleResource> IEnumerable<SubscriptionGovernanceRuleResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SubscriptionGovernanceRuleResource> IAsyncEnumerable<SubscriptionGovernanceRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
