// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Hci
{
    /// <summary>
    /// A Class representing a Publisher along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="PublisherResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetPublisherResource method.
    /// Otherwise you can get one from its parent resource <see cref="HciClusterResource"/> using the GetPublisher method.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterPublisherResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PublisherResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="PublisherResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="clusterName"> The clusterName. </param>
        /// <param name="publisherName"> The publisherName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _publisherClientDiagnostics;
        private readonly PublishersRestOperations _publisherRestClient;
        private readonly PublisherData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.AzureStackHCI/clusters/publishers";

        /// <summary> Initializes a new instance of the <see cref="PublisherResource"/> class for mocking. </summary>
        protected PublisherResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PublisherResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal PublisherResource(ArmClient client, PublisherData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="PublisherResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PublisherResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _publisherClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Hci", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string publisherApiVersion);
            _publisherRestClient = new PublishersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, publisherApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PublisherData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of OfferResources in the Publisher. </summary>
        /// <returns> An object representing collection of OfferResources and their operations over a OfferResource. </returns>
        public virtual OfferCollection GetOffers()
        {
            return GetCachedClient(client => new OfferCollection(client, Id));
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
        /// <exception cref="ArgumentNullException"> <paramref name="offerName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="offerName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<OfferResource>> GetOfferAsync(string offerName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await GetOffers().GetAsync(offerName, expand, cancellationToken).ConfigureAwait(false);
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
        /// <exception cref="ArgumentNullException"> <paramref name="offerName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="offerName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<OfferResource> GetOffer(string offerName, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetOffers().Get(offerName, expand, cancellationToken);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PublisherResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _publisherClientDiagnostics.CreateScope("PublisherResource.Get");
            scope.Start();
            try
            {
                var response = await _publisherRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PublisherResource(Client, new PublisherData(response.Value)), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PublisherResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _publisherClientDiagnostics.CreateScope("PublisherResource.Get");
            scope.Start();
            try
            {
                var response = _publisherRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PublisherResource(Client, new PublisherData(response.Value)), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
