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
    /// A Class representing an Offer along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="OfferResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetOfferResource method.
    /// Otherwise you can get one from its parent resource <see cref="PublisherResource"/> using the GetOffer method.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterOfferResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class OfferResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="OfferResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="clusterName"> The clusterName. </param>
        /// <param name="publisherName"> The publisherName. </param>
        /// <param name="offerName"> The offerName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers/{offerName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _offerClientDiagnostics;
        private readonly OffersRestOperations _offerRestClient;
        private readonly OfferData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.AzureStackHCI/clusters/publishers/offers";

        /// <summary> Initializes a new instance of the <see cref="OfferResource"/> class for mocking. </summary>
        protected OfferResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="OfferResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal OfferResource(ArmClient client, OfferData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="OfferResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal OfferResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _offerClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Hci", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string offerApiVersion);
            _offerRestClient = new OffersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, offerApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual OfferData Data
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

        /// <summary> Gets a collection of HciSkuResources in the Offer. </summary>
        /// <returns> An object representing collection of HciSkuResources and their operations over a HciSkuResource. </returns>
        public virtual HciSkuCollection GetHciSkus()
        {
            return GetCachedClient(client => new HciSkuCollection(client, Id));
        }

        /// <summary>
        /// Get SKU resource details within a offer of HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers/{offerName}/skus/{skuName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Skus_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="HciSkuResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skuName"> The name of the SKU available within HCI cluster. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="skuName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="skuName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<HciSkuResource>> GetHciSkuAsync(string skuName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await GetHciSkus().GetAsync(skuName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get SKU resource details within a offer of HCI Cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/clusters/{clusterName}/publishers/{publisherName}/offers/{offerName}/skus/{skuName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Skus_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="HciSkuResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skuName"> The name of the SKU available within HCI cluster. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="skuName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="skuName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<HciSkuResource> GetHciSku(string skuName, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetHciSkus().Get(skuName, expand, cancellationToken);
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
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<OfferResource>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _offerClientDiagnostics.CreateScope("OfferResource.Get");
            scope.Start();
            try
            {
                var response = await _offerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, expand, cancellationToken).ConfigureAwait(false);
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
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<OfferResource> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _offerClientDiagnostics.CreateScope("OfferResource.Get");
            scope.Start();
            try
            {
                var response = _offerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, expand, cancellationToken);
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
    }
}
