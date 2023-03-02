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

[assembly: CodeGenSuppressType("SecurityInsightsAutomationRuleCollection")]
namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// A class representing a collection of <see cref="SecurityInsightsAutomationRuleResource" /> and their operations.
    /// Each <see cref="SecurityInsightsAutomationRuleResource" /> in the collection will belong to the same instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
    /// To get a <see cref="SecurityInsightsAutomationRuleCollection" /> instance call the GetSecurityInsightsAutomationRules method from an instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
    /// </summary>
    public partial class SecurityInsightsAutomationRuleCollection : ArmCollection, IEnumerable<SecurityInsightsAutomationRuleResource>, IAsyncEnumerable<SecurityInsightsAutomationRuleResource>
    {
        private readonly ClientDiagnostics _securityInsightsAutomationRuleAutomationRulesClientDiagnostics;
        private readonly AutomationRulesRestOperations _securityInsightsAutomationRuleAutomationRulesRestClient;

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsAutomationRuleCollection"/> class for mocking. </summary>
        protected SecurityInsightsAutomationRuleCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsAutomationRuleCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SecurityInsightsAutomationRuleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityInsightsAutomationRuleAutomationRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityInsights", SecurityInsightsAutomationRuleResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SecurityInsightsAutomationRuleResource.ResourceType, out string securityInsightsAutomationRuleAutomationRulesApiVersion);
            _securityInsightsAutomationRuleAutomationRulesRestClient = new AutomationRulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityInsightsAutomationRuleAutomationRulesApiVersion);
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
        /// Creates or updates the automation rule.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutomationRules_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="automationRuleId"> Automation rule ID. </param>
        /// <param name="data"> The automation rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationRuleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationRuleId"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityInsightsAutomationRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string automationRuleId, SecurityInsightsAutomationRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationRuleId, nameof(automationRuleId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _securityInsightsAutomationRuleAutomationRulesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, automationRuleId, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsAutomationRuleResource>(Response.FromValue(new SecurityInsightsAutomationRuleResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates the automation rule.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutomationRules_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="automationRuleId"> Automation rule ID. </param>
        /// <param name="data"> The automation rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationRuleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationRuleId"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityInsightsAutomationRuleResource> CreateOrUpdate(WaitUntil waitUntil, string automationRuleId, SecurityInsightsAutomationRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationRuleId, nameof(automationRuleId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _securityInsightsAutomationRuleAutomationRulesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, automationRuleId, data, cancellationToken);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsAutomationRuleResource>(Response.FromValue(new SecurityInsightsAutomationRuleResource(Client, response), response.GetRawResponse()));
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
        /// Gets the automation rule.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutomationRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationRuleId"> Automation rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationRuleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationRuleId"/> is null. </exception>
        public virtual async Task<Response<SecurityInsightsAutomationRuleResource>> GetAsync(string automationRuleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationRuleId, nameof(automationRuleId));

            using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.Get");
            scope.Start();
            try
            {
                var response = await _securityInsightsAutomationRuleAutomationRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, automationRuleId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsAutomationRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the automation rule.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutomationRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationRuleId"> Automation rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationRuleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationRuleId"/> is null. </exception>
        public virtual Response<SecurityInsightsAutomationRuleResource> Get(string automationRuleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationRuleId, nameof(automationRuleId));

            using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.Get");
            scope.Start();
            try
            {
                var response = _securityInsightsAutomationRuleAutomationRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, automationRuleId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsAutomationRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all automation rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutomationRules_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityInsightsAutomationRuleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityInsightsAutomationRuleResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityInsightsAutomationRuleResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityInsightsAutomationRuleAutomationRulesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsAutomationRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SecurityInsightsAutomationRuleResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityInsightsAutomationRuleAutomationRulesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsAutomationRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all automation rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutomationRules_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityInsightsAutomationRuleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityInsightsAutomationRuleResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SecurityInsightsAutomationRuleResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityInsightsAutomationRuleAutomationRulesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsAutomationRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SecurityInsightsAutomationRuleResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityInsightsAutomationRuleAutomationRulesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsAutomationRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutomationRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationRuleId"> Automation rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationRuleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationRuleId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string automationRuleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationRuleId, nameof(automationRuleId));

            using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = await _securityInsightsAutomationRuleAutomationRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, automationRuleId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutomationRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationRuleId"> Automation rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationRuleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationRuleId"/> is null. </exception>
        public virtual Response<bool> Exists(string automationRuleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationRuleId, nameof(automationRuleId));

            using var scope = _securityInsightsAutomationRuleAutomationRulesClientDiagnostics.CreateScope("SecurityInsightsAutomationRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = _securityInsightsAutomationRuleAutomationRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, automationRuleId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SecurityInsightsAutomationRuleResource> IEnumerable<SecurityInsightsAutomationRuleResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SecurityInsightsAutomationRuleResource> IAsyncEnumerable<SecurityInsightsAutomationRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
