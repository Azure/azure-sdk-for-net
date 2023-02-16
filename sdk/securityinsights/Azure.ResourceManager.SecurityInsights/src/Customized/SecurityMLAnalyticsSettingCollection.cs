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

[assembly: CodeGenSuppressType("SecurityMLAnalyticsSettingCollection")]
namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// A class representing a collection of <see cref="SecurityMLAnalyticsSettingResource" /> and their operations.
    /// Each <see cref="SecurityMLAnalyticsSettingResource" /> in the collection will belong to the same instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
    /// To get a <see cref="SecurityMLAnalyticsSettingCollection" /> instance call the GetSecurityMLAnalyticsSettings method from an instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
    /// </summary>
    public partial class SecurityMLAnalyticsSettingCollection : ArmCollection, IEnumerable<SecurityMLAnalyticsSettingResource>, IAsyncEnumerable<SecurityMLAnalyticsSettingResource>
    {
        private readonly ClientDiagnostics _securityMLAnalyticsSettingClientDiagnostics;
        private readonly SecurityMLAnalyticsSettingsRestOperations _securityMLAnalyticsSettingRestClient;

        /// <summary> Initializes a new instance of the <see cref="SecurityMLAnalyticsSettingCollection"/> class for mocking. </summary>
        protected SecurityMLAnalyticsSettingCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityMLAnalyticsSettingCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SecurityMLAnalyticsSettingCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityMLAnalyticsSettingClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityInsights", SecurityMLAnalyticsSettingResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SecurityMLAnalyticsSettingResource.ResourceType, out string securityMLAnalyticsSettingApiVersion);
            _securityMLAnalyticsSettingRestClient = new SecurityMLAnalyticsSettingsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityMLAnalyticsSettingApiVersion);
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
        /// Creates or updates the Security ML Analytics Settings.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings/{settingsResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityMLAnalyticsSettings_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="settingsResourceName"> Security ML Analytics Settings resource name. </param>
        /// <param name="data"> The security ML Analytics setting. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="settingsResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="settingsResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityMLAnalyticsSettingResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string settingsResourceName, SecurityMLAnalyticsSettingData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(settingsResourceName, nameof(settingsResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _securityMLAnalyticsSettingRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, settingsResourceName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityInsightsArmOperation<SecurityMLAnalyticsSettingResource>(Response.FromValue(new SecurityMLAnalyticsSettingResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates the Security ML Analytics Settings.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings/{settingsResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityMLAnalyticsSettings_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="settingsResourceName"> Security ML Analytics Settings resource name. </param>
        /// <param name="data"> The security ML Analytics setting. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="settingsResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="settingsResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityMLAnalyticsSettingResource> CreateOrUpdate(WaitUntil waitUntil, string settingsResourceName, SecurityMLAnalyticsSettingData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(settingsResourceName, nameof(settingsResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _securityMLAnalyticsSettingRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, settingsResourceName, data, cancellationToken);
                var operation = new SecurityInsightsArmOperation<SecurityMLAnalyticsSettingResource>(Response.FromValue(new SecurityMLAnalyticsSettingResource(Client, response), response.GetRawResponse()));
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
        /// Gets the Security ML Analytics Settings.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings/{settingsResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityMLAnalyticsSettings_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="settingsResourceName"> Security ML Analytics Settings resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="settingsResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="settingsResourceName"/> is null. </exception>
        public virtual async Task<Response<SecurityMLAnalyticsSettingResource>> GetAsync(string settingsResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(settingsResourceName, nameof(settingsResourceName));

            using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.Get");
            scope.Start();
            try
            {
                var response = await _securityMLAnalyticsSettingRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, settingsResourceName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityMLAnalyticsSettingResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the Security ML Analytics Settings.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings/{settingsResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityMLAnalyticsSettings_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="settingsResourceName"> Security ML Analytics Settings resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="settingsResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="settingsResourceName"/> is null. </exception>
        public virtual Response<SecurityMLAnalyticsSettingResource> Get(string settingsResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(settingsResourceName, nameof(settingsResourceName));

            using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.Get");
            scope.Start();
            try
            {
                var response = _securityMLAnalyticsSettingRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, settingsResourceName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityMLAnalyticsSettingResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all Security ML Analytics Settings.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityMLAnalyticsSettings_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityMLAnalyticsSettingResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityMLAnalyticsSettingResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityMLAnalyticsSettingResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityMLAnalyticsSettingRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityMLAnalyticsSettingResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SecurityMLAnalyticsSettingResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityMLAnalyticsSettingRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityMLAnalyticsSettingResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all Security ML Analytics Settings.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityMLAnalyticsSettings_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityMLAnalyticsSettingResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityMLAnalyticsSettingResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SecurityMLAnalyticsSettingResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityMLAnalyticsSettingRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityMLAnalyticsSettingResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SecurityMLAnalyticsSettingResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityMLAnalyticsSettingRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityMLAnalyticsSettingResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings/{settingsResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityMLAnalyticsSettings_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="settingsResourceName"> Security ML Analytics Settings resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="settingsResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="settingsResourceName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string settingsResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(settingsResourceName, nameof(settingsResourceName));

            using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.Exists");
            scope.Start();
            try
            {
                var response = await _securityMLAnalyticsSettingRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, settingsResourceName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings/{settingsResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityMLAnalyticsSettings_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="settingsResourceName"> Security ML Analytics Settings resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="settingsResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="settingsResourceName"/> is null. </exception>
        public virtual Response<bool> Exists(string settingsResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(settingsResourceName, nameof(settingsResourceName));

            using var scope = _securityMLAnalyticsSettingClientDiagnostics.CreateScope("SecurityMLAnalyticsSettingCollection.Exists");
            scope.Start();
            try
            {
                var response = _securityMLAnalyticsSettingRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, settingsResourceName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SecurityMLAnalyticsSettingResource> IEnumerable<SecurityMLAnalyticsSettingResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SecurityMLAnalyticsSettingResource> IAsyncEnumerable<SecurityMLAnalyticsSettingResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
