// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

[assembly: CodeGenSuppressType("SecurityInsightsAlertRuleCollection")]
namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// A class representing a collection of <see cref="SecurityInsightsAlertRuleResource" /> and their operations.
    /// Each <see cref="SecurityInsightsAlertRuleResource" /> in the collection will belong to the same instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
    /// To get a <see cref="SecurityInsightsAlertRuleCollection" /> instance call the GetSecurityInsightsAlertRules method from an instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
    /// </summary>
    public partial class SecurityInsightsAlertRuleCollection : ArmCollection, IEnumerable<SecurityInsightsAlertRuleResource>, IAsyncEnumerable<SecurityInsightsAlertRuleResource>
    {
        private readonly ClientDiagnostics _securityInsightsAlertRuleAlertRulesClientDiagnostics;
        private readonly AlertRulesRestOperations _securityInsightsAlertRuleAlertRulesRestClient;

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsAlertRuleCollection"/> class for mocking. </summary>
        protected SecurityInsightsAlertRuleCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsAlertRuleCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SecurityInsightsAlertRuleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityInsightsAlertRuleAlertRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityInsights", SecurityInsightsAlertRuleResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SecurityInsightsAlertRuleResource.ResourceType, out string securityInsightsAlertRuleAlertRulesApiVersion);
            _securityInsightsAlertRuleAlertRulesRestClient = new AlertRulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityInsightsAlertRuleAlertRulesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != OperationalInsightsWorkspaceSecurityInsightsResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, OperationalInsightsWorkspaceSecurityInsightsResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates the alert rule.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AlertRules_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleId"> Alert rule ID. </param>
        /// <param name="data"> The alert rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityInsightsAlertRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ruleId, SecurityInsightsAlertRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _securityInsightsAlertRuleAlertRulesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleId, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsAlertRuleResource>(Response.FromValue(new SecurityInsightsAlertRuleResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates the alert rule.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AlertRules_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleId"> Alert rule ID. </param>
        /// <param name="data"> The alert rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityInsightsAlertRuleResource> CreateOrUpdate(WaitUntil waitUntil, string ruleId, SecurityInsightsAlertRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _securityInsightsAlertRuleAlertRulesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleId, data, cancellationToken);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsAlertRuleResource>(Response.FromValue(new SecurityInsightsAlertRuleResource(Client, response), response.GetRawResponse()));
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
        /// Gets the alert rule.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AlertRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> Alert rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        public virtual async Task<Response<SecurityInsightsAlertRuleResource>> GetAsync(string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.Get");
            scope.Start();
            try
            {
                var response = await _securityInsightsAlertRuleAlertRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsAlertRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the alert rule.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AlertRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> Alert rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        public virtual Response<SecurityInsightsAlertRuleResource> Get(string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.Get");
            scope.Start();
            try
            {
                var response = _securityInsightsAlertRuleAlertRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsAlertRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all alert rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AlertRules_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityInsightsAlertRuleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityInsightsAlertRuleResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityInsightsAlertRuleResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityInsightsAlertRuleAlertRulesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsAlertRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SecurityInsightsAlertRuleResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityInsightsAlertRuleAlertRulesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsAlertRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all alert rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AlertRules_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityInsightsAlertRuleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityInsightsAlertRuleResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SecurityInsightsAlertRuleResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityInsightsAlertRuleAlertRulesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsAlertRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SecurityInsightsAlertRuleResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityInsightsAlertRuleAlertRulesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsAlertRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AlertRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> Alert rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = await _securityInsightsAlertRuleAlertRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AlertRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> Alert rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        public virtual Response<bool> Exists(string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var scope = _securityInsightsAlertRuleAlertRulesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = _securityInsightsAlertRuleAlertRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SecurityInsightsAlertRuleResource> IEnumerable<SecurityInsightsAlertRuleResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SecurityInsightsAlertRuleResource> IAsyncEnumerable<SecurityInsightsAlertRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
