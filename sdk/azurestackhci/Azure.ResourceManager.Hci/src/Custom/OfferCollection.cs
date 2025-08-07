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

namespace Azure.ResourceManager.Hci
{
    /// <summary>
    /// A class representing a collection of <see cref="OfferResource"/> and their operations.
    /// Each <see cref="OfferResource"/> in the collection will belong to the same instance of <see cref="PublisherResource"/>.
    /// To get an <see cref="OfferCollection"/> instance call the GetOffers method from an instance of <see cref="PublisherResource"/>.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterOfferCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class OfferCollection : ArmCollection, IEnumerable<OfferResource>, IAsyncEnumerable<OfferResource>
    {
        private readonly ClientDiagnostics _offerClientDiagnostics;
        private readonly OffersRestOperations _offerRestClient;

        /// <summary> Initializes a new instance of the <see cref="OfferCollection"/> class for mocking. </summary>
        protected OfferCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="OfferCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal OfferCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _offerClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Hci", OfferResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(OfferResource.ResourceType, out string offerApiVersion);
            _offerRestClient = new OffersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, offerApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != PublisherResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, PublisherResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get Offer resource details within a publisher of HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers/{offerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OfferResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="offerName"> The name of the offer available within HCI cluster. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="offerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerName"/> is null. </exception>
        public virtual async Task<Response<OfferResource>> GetAsync(string offerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(offerName, nameof(offerName));

            using var scope = _offerClientDiagnostics.CreateScope("OfferCollection.Get");
            scope.Start();
            try
            {
                var response = await _offerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, offerName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OfferResource(Client, new OfferData(response.Value)), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get Offer resource details within a publisher of HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers/{offerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OfferResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="offerName"> The name of the offer available within HCI cluster. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="offerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerName"/> is null. </exception>
        public virtual Response<OfferResource> Get(string offerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(offerName, nameof(offerName));

            using var scope = _offerClientDiagnostics.CreateScope("OfferCollection.Get");
            scope.Start();
            try
            {
                var response = _offerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, offerName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OfferResource(Client, new OfferData(response.Value)), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List Offers available for a publisher within the HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_ListByPublisher</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OfferResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OfferResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OfferResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _offerRestClient.CreateListByPublisherRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _offerRestClient.CreateListByPublisherNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new OfferResource(Client, new OfferData(HciClusterOfferData.DeserializeHciClusterOfferData(e))), _offerClientDiagnostics, Pipeline, "OfferCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List Offers available for a publisher within the HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_ListByPublisher</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OfferResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OfferResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OfferResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _offerRestClient.CreateListByPublisherRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _offerRestClient.CreateListByPublisherNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new OfferResource(Client, new OfferData(HciClusterOfferData.DeserializeHciClusterOfferData(e))), _offerClientDiagnostics, Pipeline, "OfferCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers/{offerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OfferResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="offerName"> The name of the offer available within HCI cluster. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="offerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string offerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(offerName, nameof(offerName));

            using var scope = _offerClientDiagnostics.CreateScope("OfferCollection.Exists");
            scope.Start();
            try
            {
                var response = await _offerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, offerName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers/{offerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OfferResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="offerName"> The name of the offer available within HCI cluster. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="offerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerName"/> is null. </exception>
        public virtual Response<bool> Exists(string offerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(offerName, nameof(offerName));

            using var scope = _offerClientDiagnostics.CreateScope("OfferCollection.Exists");
            scope.Start();
            try
            {
                var response = _offerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, offerName, expand, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers/{offerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OfferResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="offerName"> The name of the offer available within HCI cluster. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="offerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerName"/> is null. </exception>
        public virtual async Task<NullableResponse<OfferResource>> GetIfExistsAsync(string offerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(offerName, nameof(offerName));

            using var scope = _offerClientDiagnostics.CreateScope("OfferCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _offerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, offerName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<OfferResource>(response.GetRawResponse());
                return Response.FromValue(new OfferResource(Client, new OfferData(response.Value)), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers/{offerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OfferResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="offerName"> The name of the offer available within HCI cluster. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="offerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerName"/> is null. </exception>
        public virtual NullableResponse<OfferResource> GetIfExists(string offerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(offerName, nameof(offerName));

            using var scope = _offerClientDiagnostics.CreateScope("OfferCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _offerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, offerName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<OfferResource>(response.GetRawResponse());
                return Response.FromValue(new OfferResource(Client, new OfferData(response.Value)), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<OfferResource> IEnumerable<OfferResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<OfferResource> IAsyncEnumerable<OfferResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
