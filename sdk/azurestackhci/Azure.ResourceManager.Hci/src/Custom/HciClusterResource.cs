// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Hci
{
    /// <summary>
    /// A Class representing a HciCluster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="HciClusterResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetHciClusterResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetHciCluster method.
    /// </summary>
    public partial class HciClusterResource : ArmResource
    {
        /// <summary> Gets a collection of PublisherResources in the HciCluster. </summary>
        /// <returns> An object representing collection of PublisherResources and their operations over a PublisherResource. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublishers` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual PublisherCollection GetPublishers()
        {
            return GetCachedClient(client => new PublisherCollection(client, Id));
        }

        /// <summary>
        /// Get Publisher resource details of HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Publishers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PublisherResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publisherName"> The name of the publisher available within HCI cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublisherAsync` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<PublisherResource>> GetPublisherAsync(string publisherName, CancellationToken cancellationToken = default)
        {
            return await GetPublishers().GetAsync(publisherName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Publisher resource details of HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Publishers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PublisherResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publisherName"> The name of the publisher available within HCI cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublisher` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<PublisherResource> GetPublisher(string publisherName, CancellationToken cancellationToken = default)
        {
            return GetPublishers().Get(publisherName, cancellationToken);
        }

        /// <summary>
        /// List Offers available across publishers for the HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/offers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_ListByCluster</description>
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
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterOffersAsync` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<OfferResource> GetOffersAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _hciClusterOfferOffersRestClient.CreateListByClusterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _hciClusterOfferOffersRestClient.CreateListByClusterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new OfferResource(Client, new OfferData(HciClusterOfferData.DeserializeHciClusterOfferData(e))), _hciClusterOfferOffersClientDiagnostics, Pipeline, "HciClusterResource.GetOffers", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List Offers available across publishers for the HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/offers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Offers_ListByCluster</description>
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
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterOffers` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<OfferResource> GetOffers(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _hciClusterOfferOffersRestClient.CreateListByClusterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _hciClusterOfferOffersRestClient.CreateListByClusterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new OfferResource(Client, new OfferData(HciClusterOfferData.DeserializeHciClusterOfferData(e))), _hciClusterOfferOffersClientDiagnostics, Pipeline, "HciClusterResource.GetOffers", "value", "nextLink", cancellationToken);
        }

        /// <summary> Gets an object representing a UpdateSummaryResource along with the instance operations that can be performed on it in the HciCluster. </summary>
        /// <returns> Returns a <see cref="UpdateSummaryResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummary` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual UpdateSummaryResource GetUpdateSummary()
        {
            return new UpdateSummaryResource(Client, Id.AppendChildResource("updateSummaries", "default"));
        }

        /// <summary> Gets a collection of UpdateResources in the HciCluster. </summary>
        /// <returns> An object representing collection of UpdateResources and their operations over a UpdateResource. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdates` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual UpdateCollection GetUpdates()
        {
            return GetCachedClient(client => new UpdateCollection(client, Id));
        }

        /// <summary>
        /// Get specified Update
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/updates/{updateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Updates_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="UpdateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="updateName"> The name of the Update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="updateName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="updateName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateAsync` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<UpdateResource>> GetUpdateAsync(string updateName, CancellationToken cancellationToken = default)
        {
            return await GetUpdates().GetAsync(updateName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get specified Update
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/updates/{updateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Updates_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="UpdateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="updateName"> The name of the Update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="updateName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="updateName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdate` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<UpdateResource> GetUpdate(string updateName, CancellationToken cancellationToken = default)
        {
            return GetUpdates().Get(updateName, cancellationToken);
        }
    }
}
