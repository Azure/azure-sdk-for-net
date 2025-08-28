// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.MySql.Models;

namespace Azure.ResourceManager.MySql.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableMySqlSubscriptionResource : ArmResource
    {
        private ClientDiagnostics _mySqlServerServersClientDiagnostics;
        private ServersRestOperations _mySqlServerServersRestClient;
        private ClientDiagnostics _locationBasedPerformanceTierClientDiagnostics;
        private LocationBasedPerformanceTierRestOperations _locationBasedPerformanceTierRestClient;
        private ClientDiagnostics _checkNameAvailabilityClientDiagnostics;
        private CheckNameAvailabilityRestOperations _checkNameAvailabilityRestClient;

        /// <summary> Initializes a new instance of the <see cref="MockableMySqlSubscriptionResource"/> class for mocking. </summary>
        protected MockableMySqlSubscriptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMySqlSubscriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMySqlSubscriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics MySqlServerServersClientDiagnostics => _mySqlServerServersClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.MySql", MySqlServerResource.ResourceType.Namespace, Diagnostics);
        private ServersRestOperations MySqlServerServersRestClient => _mySqlServerServersRestClient ??= new ServersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(MySqlServerResource.ResourceType));
        private ClientDiagnostics LocationBasedPerformanceTierClientDiagnostics => _locationBasedPerformanceTierClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.MySql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private LocationBasedPerformanceTierRestOperations LocationBasedPerformanceTierRestClient => _locationBasedPerformanceTierRestClient ??= new LocationBasedPerformanceTierRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics CheckNameAvailabilityClientDiagnostics => _checkNameAvailabilityClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.MySql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private CheckNameAvailabilityRestOperations CheckNameAvailabilityRestClient => _checkNameAvailabilityRestClient ??= new CheckNameAvailabilityRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// List all the servers in a given subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/servers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Servers_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MySqlServerResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MySqlServerResource> GetMySqlServersAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => MySqlServerServersRestClient.CreateListRequest(Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new MySqlServerResource(Client, MySqlServerData.DeserializeMySqlServerData(e)), MySqlServerServersClientDiagnostics, Pipeline, "MockableMySqlSubscriptionResource.GetMySqlServers", "value", null, cancellationToken);
        }

        /// <summary>
        /// List all the servers in a given subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/servers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Servers_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MySqlServerResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MySqlServerResource> GetMySqlServers(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => MySqlServerServersRestClient.CreateListRequest(Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new MySqlServerResource(Client, MySqlServerData.DeserializeMySqlServerData(e)), MySqlServerServersClientDiagnostics, Pipeline, "MockableMySqlSubscriptionResource.GetMySqlServers", "value", null, cancellationToken);
        }

        /// <summary>
        /// List all the performance tiers at specified location in a given subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/locations/{locationName}/performanceTiers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LocationBasedPerformanceTier_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MySqlPerformanceTier"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MySqlPerformanceTier> GetLocationBasedPerformanceTiersAsync(AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => LocationBasedPerformanceTierRestClient.CreateListRequest(Id.SubscriptionId, locationName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => MySqlPerformanceTier.DeserializeMySqlPerformanceTier(e), LocationBasedPerformanceTierClientDiagnostics, Pipeline, "MockableMySqlSubscriptionResource.GetLocationBasedPerformanceTiers", "value", null, cancellationToken);
        }

        /// <summary>
        /// List all the performance tiers at specified location in a given subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/locations/{locationName}/performanceTiers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LocationBasedPerformanceTier_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MySqlPerformanceTier"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MySqlPerformanceTier> GetLocationBasedPerformanceTiers(AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => LocationBasedPerformanceTierRestClient.CreateListRequest(Id.SubscriptionId, locationName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => MySqlPerformanceTier.DeserializeMySqlPerformanceTier(e), LocationBasedPerformanceTierClientDiagnostics, Pipeline, "MockableMySqlSubscriptionResource.GetLocationBasedPerformanceTiers", "value", null, cancellationToken);
        }

        /// <summary>
        /// Check the availability of name for resource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckNameAvailability_Execute</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The required parameters for checking if resource name is available. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<MySqlNameAvailabilityResult>> CheckMySqlNameAvailabilityAsync(MySqlNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = CheckNameAvailabilityClientDiagnostics.CreateScope("MockableMySqlSubscriptionResource.CheckMySqlNameAvailability");
            scope.Start();
            try
            {
                var response = await CheckNameAvailabilityRestClient.ExecuteAsync(Id.SubscriptionId, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Check the availability of name for resource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckNameAvailability_Execute</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The required parameters for checking if resource name is available. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<MySqlNameAvailabilityResult> CheckMySqlNameAvailability(MySqlNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = CheckNameAvailabilityClientDiagnostics.CreateScope("MockableMySqlSubscriptionResource.CheckMySqlNameAvailability");
            scope.Start();
            try
            {
                var response = CheckNameAvailabilityRestClient.Execute(Id.SubscriptionId, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}