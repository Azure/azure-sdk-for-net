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

[assembly: CodeGenSuppressType("SecurityInsightsDataConnectorCollection")]
namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// A class representing a collection of <see cref="SecurityInsightsDataConnectorResource" /> and their operations.
    /// Each <see cref="SecurityInsightsDataConnectorResource" /> in the collection will belong to the same instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
    /// To get a <see cref="SecurityInsightsDataConnectorCollection" /> instance call the GetSecurityInsightsDataConnectors method from an instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
    /// </summary>
    public partial class SecurityInsightsDataConnectorCollection : ArmCollection, IEnumerable<SecurityInsightsDataConnectorResource>, IAsyncEnumerable<SecurityInsightsDataConnectorResource>
    {
        private readonly ClientDiagnostics _securityInsightsDataConnectorDataConnectorsClientDiagnostics;
        private readonly DataConnectorsRestOperations _securityInsightsDataConnectorDataConnectorsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsDataConnectorCollection"/> class for mocking. </summary>
        protected SecurityInsightsDataConnectorCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsDataConnectorCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SecurityInsightsDataConnectorCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityInsightsDataConnectorDataConnectorsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityInsights", SecurityInsightsDataConnectorResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SecurityInsightsDataConnectorResource.ResourceType, out string securityInsightsDataConnectorDataConnectorsApiVersion);
            _securityInsightsDataConnectorDataConnectorsRestClient = new DataConnectorsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityInsightsDataConnectorDataConnectorsApiVersion);
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
        /// Creates or updates the data connector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors/{dataConnectorId}
        /// Operation Id: DataConnectors_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="dataConnectorId"> Connector ID. </param>
        /// <param name="data"> The data connector. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataConnectorId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataConnectorId"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityInsightsDataConnectorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string dataConnectorId, SecurityInsightsDataConnectorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataConnectorId, nameof(dataConnectorId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _securityInsightsDataConnectorDataConnectorsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataConnectorId, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsDataConnectorResource>(Response.FromValue(new SecurityInsightsDataConnectorResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates the data connector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors/{dataConnectorId}
        /// Operation Id: DataConnectors_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="dataConnectorId"> Connector ID. </param>
        /// <param name="data"> The data connector. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataConnectorId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataConnectorId"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityInsightsDataConnectorResource> CreateOrUpdate(WaitUntil waitUntil, string dataConnectorId, SecurityInsightsDataConnectorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataConnectorId, nameof(dataConnectorId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _securityInsightsDataConnectorDataConnectorsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataConnectorId, data, cancellationToken);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsDataConnectorResource>(Response.FromValue(new SecurityInsightsDataConnectorResource(Client, response), response.GetRawResponse()));
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
        /// Gets a data connector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors/{dataConnectorId}
        /// Operation Id: DataConnectors_Get
        /// </summary>
        /// <param name="dataConnectorId"> Connector ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataConnectorId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataConnectorId"/> is null. </exception>
        public virtual async Task<Response<SecurityInsightsDataConnectorResource>> GetAsync(string dataConnectorId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataConnectorId, nameof(dataConnectorId));

            using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.Get");
            scope.Start();
            try
            {
                var response = await _securityInsightsDataConnectorDataConnectorsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataConnectorId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsDataConnectorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a data connector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors/{dataConnectorId}
        /// Operation Id: DataConnectors_Get
        /// </summary>
        /// <param name="dataConnectorId"> Connector ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataConnectorId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataConnectorId"/> is null. </exception>
        public virtual Response<SecurityInsightsDataConnectorResource> Get(string dataConnectorId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataConnectorId, nameof(dataConnectorId));

            using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.Get");
            scope.Start();
            try
            {
                var response = _securityInsightsDataConnectorDataConnectorsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataConnectorId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsDataConnectorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all data connectors.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors
        /// Operation Id: DataConnectors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityInsightsDataConnectorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityInsightsDataConnectorResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityInsightsDataConnectorResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityInsightsDataConnectorDataConnectorsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsDataConnectorResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SecurityInsightsDataConnectorResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityInsightsDataConnectorDataConnectorsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsDataConnectorResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all data connectors.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors
        /// Operation Id: DataConnectors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityInsightsDataConnectorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityInsightsDataConnectorResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SecurityInsightsDataConnectorResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityInsightsDataConnectorDataConnectorsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsDataConnectorResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SecurityInsightsDataConnectorResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityInsightsDataConnectorDataConnectorsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsDataConnectorResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors/{dataConnectorId}
        /// Operation Id: DataConnectors_Get
        /// </summary>
        /// <param name="dataConnectorId"> Connector ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataConnectorId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataConnectorId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string dataConnectorId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataConnectorId, nameof(dataConnectorId));

            using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.Exists");
            scope.Start();
            try
            {
                var response = await _securityInsightsDataConnectorDataConnectorsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataConnectorId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors/{dataConnectorId}
        /// Operation Id: DataConnectors_Get
        /// </summary>
        /// <param name="dataConnectorId"> Connector ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataConnectorId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataConnectorId"/> is null. </exception>
        public virtual Response<bool> Exists(string dataConnectorId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataConnectorId, nameof(dataConnectorId));

            using var scope = _securityInsightsDataConnectorDataConnectorsClientDiagnostics.CreateScope("SecurityInsightsDataConnectorCollection.Exists");
            scope.Start();
            try
            {
                var response = _securityInsightsDataConnectorDataConnectorsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataConnectorId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SecurityInsightsDataConnectorResource> IEnumerable<SecurityInsightsDataConnectorResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SecurityInsightsDataConnectorResource> IAsyncEnumerable<SecurityInsightsDataConnectorResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
