// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Avs.Models;

namespace Azure.ResourceManager.Avs
{
    /// <summary>
    /// A class representing a collection of <see cref="WorkloadNetworkResource"/> and their operations.
    /// Each <see cref="WorkloadNetworkResource"/> in the collection will belong to the same instance of <see cref="AvsPrivateCloudResource"/>.
    /// To get a <see cref="WorkloadNetworkCollection"/> instance call the GetWorkloadNetworks method from an instance of <see cref="AvsPrivateCloudResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This class is obsolete and will be removed in a future release.", false)]
    public partial class WorkloadNetworkCollection : ArmCollection, IEnumerable<WorkloadNetworkResource>, IAsyncEnumerable<WorkloadNetworkResource>
    {
        private readonly ClientDiagnostics _workloadNetworkClientDiagnostics;
        private readonly WorkloadNetworksRestOperations _workloadNetworkRestClient;

        /// <summary> Initializes a new instance of the <see cref="WorkloadNetworkCollection"/> class for mocking. </summary>
        protected WorkloadNetworkCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="WorkloadNetworkCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal WorkloadNetworkCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _workloadNetworkClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Avs", WorkloadNetworkResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(WorkloadNetworkResource.ResourceType, out string workloadNetworkApiVersion);
            _workloadNetworkRestClient = new WorkloadNetworksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, workloadNetworkApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AvsPrivateCloudResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AvsPrivateCloudResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<WorkloadNetworkResource>> GetAsync(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            using var scope = _workloadNetworkClientDiagnostics.CreateScope("WorkloadNetworkCollection.Get");
            scope.Start();
            try
            {
                var response = await _workloadNetworkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, workloadNetworkName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new WorkloadNetworkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<WorkloadNetworkResource> Get(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            using var scope = _workloadNetworkClientDiagnostics.CreateScope("WorkloadNetworkCollection.Get");
            scope.Start();
            try
            {
                var response = _workloadNetworkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, workloadNetworkName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new WorkloadNetworkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List of workload networks in a private cloud.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WorkloadNetworkResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WorkloadNetworkResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _workloadNetworkRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _workloadNetworkRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new WorkloadNetworkResource(Client, WorkloadNetworkData.DeserializeWorkloadNetworkData(e)), _workloadNetworkClientDiagnostics, Pipeline, "WorkloadNetworkCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List of workload networks in a private cloud.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WorkloadNetworkResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WorkloadNetworkResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _workloadNetworkRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _workloadNetworkRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new WorkloadNetworkResource(Client, WorkloadNetworkData.DeserializeWorkloadNetworkData(e)), _workloadNetworkClientDiagnostics, Pipeline, "WorkloadNetworkCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            using var scope = _workloadNetworkClientDiagnostics.CreateScope("WorkloadNetworkCollection.Exists");
            scope.Start();
            try
            {
                var response = await _workloadNetworkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, workloadNetworkName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            using var scope = _workloadNetworkClientDiagnostics.CreateScope("WorkloadNetworkCollection.Exists");
            scope.Start();
            try
            {
                var response = _workloadNetworkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, workloadNetworkName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<WorkloadNetworkResource>> GetIfExistsAsync(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            using var scope = _workloadNetworkClientDiagnostics.CreateScope("WorkloadNetworkCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _workloadNetworkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, workloadNetworkName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<WorkloadNetworkResource>(response.GetRawResponse());
                return Response.FromValue(new WorkloadNetworkResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<WorkloadNetworkResource> GetIfExists(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            using var scope = _workloadNetworkClientDiagnostics.CreateScope("WorkloadNetworkCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _workloadNetworkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, workloadNetworkName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<WorkloadNetworkResource>(response.GetRawResponse());
                return Response.FromValue(new WorkloadNetworkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<WorkloadNetworkResource> IEnumerable<WorkloadNetworkResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<WorkloadNetworkResource> IAsyncEnumerable<WorkloadNetworkResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
