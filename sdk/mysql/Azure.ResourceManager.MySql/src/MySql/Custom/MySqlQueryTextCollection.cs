// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.MySql
{
    /// <summary>
    /// A class representing a collection of <see cref="MySqlQueryTextResource"/> and their operations.
    /// Each <see cref="MySqlQueryTextResource"/> in the collection will belong to the same instance of <see cref="MySqlServerResource"/>.
    /// To get a <see cref="MySqlQueryTextCollection"/> instance call the GetMySqlQueryTexts method from an instance of <see cref="MySqlServerResource"/>.
    /// </summary>
    public partial class MySqlQueryTextCollection : ArmCollection
    {
        private readonly ClientDiagnostics _mySqlQueryTextQueryTextsClientDiagnostics;
        private readonly QueryTextsRestOperations _mySqlQueryTextQueryTextsRestClient;

        /// <summary> Initializes a new instance of the <see cref="MySqlQueryTextCollection"/> class for mocking. </summary>
        protected MySqlQueryTextCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MySqlQueryTextCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MySqlQueryTextCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mySqlQueryTextQueryTextsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.MySql", MySqlQueryTextResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MySqlQueryTextResource.ResourceType, out string mySqlQueryTextQueryTextsApiVersion);
            _mySqlQueryTextQueryTextsRestClient = new QueryTextsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, mySqlQueryTextQueryTextsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != MySqlServerResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, MySqlServerResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Retrieve the Query-Store query texts for the queryId.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/queryTexts/{queryId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QueryTexts_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlQueryTextResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryId"> The Query-Store query identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="queryId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queryId"/> is null. </exception>
        public virtual async Task<Response<MySqlQueryTextResource>> GetAsync(string queryId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(queryId, nameof(queryId));

            using var scope = _mySqlQueryTextQueryTextsClientDiagnostics.CreateScope("MySqlQueryTextCollection.Get");
            scope.Start();
            try
            {
                var response = await _mySqlQueryTextQueryTextsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MySqlQueryTextResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve the Query-Store query texts for the queryId.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/queryTexts/{queryId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QueryTexts_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlQueryTextResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryId"> The Query-Store query identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="queryId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queryId"/> is null. </exception>
        public virtual Response<MySqlQueryTextResource> Get(string queryId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(queryId, nameof(queryId));

            using var scope = _mySqlQueryTextQueryTextsClientDiagnostics.CreateScope("MySqlQueryTextCollection.Get");
            scope.Start();
            try
            {
                var response = _mySqlQueryTextQueryTextsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MySqlQueryTextResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve the Query-Store query texts for specified queryIds.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/queryTexts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QueryTexts_ListByServer</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlQueryTextResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryIds"> The query identifiers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queryIds"/> is null. </exception>
        /// <returns> An async collection of <see cref="MySqlQueryTextResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MySqlQueryTextResource> GetAllAsync(IEnumerable<string> queryIds, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(queryIds, nameof(queryIds));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _mySqlQueryTextQueryTextsRestClient.CreateListByServerRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryIds);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _mySqlQueryTextQueryTextsRestClient.CreateListByServerNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryIds);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new MySqlQueryTextResource(Client, MySqlQueryTextData.DeserializeMySqlQueryTextData(e)), _mySqlQueryTextQueryTextsClientDiagnostics, Pipeline, "MySqlQueryTextCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Retrieve the Query-Store query texts for specified queryIds.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/queryTexts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QueryTexts_ListByServer</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlQueryTextResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryIds"> The query identifiers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queryIds"/> is null. </exception>
        /// <returns> A collection of <see cref="MySqlQueryTextResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MySqlQueryTextResource> GetAll(IEnumerable<string> queryIds, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(queryIds, nameof(queryIds));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _mySqlQueryTextQueryTextsRestClient.CreateListByServerRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryIds);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _mySqlQueryTextQueryTextsRestClient.CreateListByServerNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryIds);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new MySqlQueryTextResource(Client, MySqlQueryTextData.DeserializeMySqlQueryTextData(e)), _mySqlQueryTextQueryTextsClientDiagnostics, Pipeline, "MySqlQueryTextCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/queryTexts/{queryId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QueryTexts_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlQueryTextResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryId"> The Query-Store query identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="queryId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queryId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string queryId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(queryId, nameof(queryId));

            using var scope = _mySqlQueryTextQueryTextsClientDiagnostics.CreateScope("MySqlQueryTextCollection.Exists");
            scope.Start();
            try
            {
                var response = await _mySqlQueryTextQueryTextsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/queryTexts/{queryId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QueryTexts_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlQueryTextResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryId"> The Query-Store query identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="queryId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queryId"/> is null. </exception>
        public virtual Response<bool> Exists(string queryId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(queryId, nameof(queryId));

            using var scope = _mySqlQueryTextQueryTextsClientDiagnostics.CreateScope("MySqlQueryTextCollection.Exists");
            scope.Start();
            try
            {
                var response = _mySqlQueryTextQueryTextsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/queryTexts/{queryId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QueryTexts_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlQueryTextResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryId"> The Query-Store query identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="queryId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queryId"/> is null. </exception>
        public virtual async Task<NullableResponse<MySqlQueryTextResource>> GetIfExistsAsync(string queryId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(queryId, nameof(queryId));

            using var scope = _mySqlQueryTextQueryTextsClientDiagnostics.CreateScope("MySqlQueryTextCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _mySqlQueryTextQueryTextsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryId, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<MySqlQueryTextResource>(response.GetRawResponse());
                return Response.FromValue(new MySqlQueryTextResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/queryTexts/{queryId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QueryTexts_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlQueryTextResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queryId"> The Query-Store query identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="queryId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queryId"/> is null. </exception>
        public virtual NullableResponse<MySqlQueryTextResource> GetIfExists(string queryId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(queryId, nameof(queryId));

            using var scope = _mySqlQueryTextQueryTextsClientDiagnostics.CreateScope("MySqlQueryTextCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _mySqlQueryTextQueryTextsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, queryId, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<MySqlQueryTextResource>(response.GetRawResponse());
                return Response.FromValue(new MySqlQueryTextResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}