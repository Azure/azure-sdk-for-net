// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core.Adapters;
using Azure.ResourceManager.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Represents an Azure geography region where supported resource providers live.
    /// </summary>
    public class LocationContainer : OperationsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationContainer"/> class.
        /// </summary>
        /// <param name="subscriptionOperations"> The subscription that this location container belongs to. </param>
        internal LocationContainer(SubscriptionOperations subscriptionOperations)
            : base(new ClientContext(subscriptionOperations.ClientOptions, subscriptionOperations.Credential, subscriptionOperations.BaseUri), subscriptionOperations.Id)
        {
            Id = subscriptionOperations.Id;
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        /// <summary>
        /// Gets the subscription client.
        /// </summary>
        private SubscriptionsOperations SubscriptionsClient => ResourcesClient.Subscriptions;

        /// <summary>
        /// The resource id
        /// </summary>
        public new SubscriptionResourceIdentifier Id { get; }

        /// <summary>
        /// Gets the Azure subscriptions.
        /// </summary>
        /// <returns> Subscription container. </returns>
        public SubscriptionContainer GetSubscriptions()
        {
            return new SubscriptionContainer(new ClientContext(ClientOptions, Credential, BaseUri));
        }

        /// <summary>
        /// Lists all geo-locations.
        /// </summary>
        /// <returns> A collection of location data that may take multiple service requests to iterate over. </returns>
        public Pageable<LocationData> List()
        {
            return new PhWrappingPageable<Azure.ResourceManager.Resources.Models.Location, LocationData>(SubscriptionsClient.ListLocations(Id.SubscriptionId), s => s.DisplayName);
        }

        /// <summary>
        /// Lists all geo-locations.
        /// </summary>
        /// <param name="token"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of location data that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<LocationData> ListAsync(CancellationToken token = default(CancellationToken))
        {
            return new PhWrappingAsyncPageable<ResourceManager.Resources.Models.Location, LocationData>(SubscriptionsClient.ListLocationsAsync(Id.SubscriptionId, token), s => s.DisplayName);
        }
    }
}
