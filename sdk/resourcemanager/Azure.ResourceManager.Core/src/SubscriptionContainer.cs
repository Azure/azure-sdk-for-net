// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Core.Adapters;
using Azure.ResourceManager.Resources;
using System;
using System.Threading;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of Subscription and their operations
    /// </summary>
    public class SubscriptionContainer : ContainerBase<Subscription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionContainer"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        internal SubscriptionContainer(ClientContext clientContext)
            : base(clientContext, null)
        {
        }

        /// <summary>
        /// Gets the valid resource type associated with the container.
        /// </summary>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        /// <summary>
        /// Gets the operations that can be performed on the container.
        /// </summary>
        private SubscriptionsOperations Operations => new ResourcesManagementClient(
            BaseUri,
            Guid.NewGuid().ToString(),
            Credential,
            ClientOptions.Convert<ResourcesManagementClientOptions>()).Subscriptions;

        /// <summary>
        /// Lists all subscriptions in the current container.
        /// </summary>
        /// <param name="cancellationToken">A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<Subscription> List(CancellationToken cancellationToken = default)
        {
            return new PhWrappingPageable<ResourceManager.Resources.Models.Subscription, Subscription>(
                Operations.List(cancellationToken),
                Converter());
        }

        /// <summary>
        /// Lists all subscriptions in the current container.
        /// </summary>
        /// <param name="cancellationToken">A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<Subscription> ListAsync(CancellationToken cancellationToken = default)
        {
            return new PhWrappingAsyncPageable<ResourceManager.Resources.Models.Subscription, Subscription>(
                Operations.ListAsync(cancellationToken),
                Converter());
        }

        /// <summary>
        /// Validate the resource identifier is supported in the current container.
        /// </summary>
        /// <param name="identifier"> The identifier of the resource. </param>
        protected override void Validate(ResourceIdentifier identifier)
        {
            if (!(identifier is null))
                throw new ArgumentException("Invalid parent for subscription container", nameof(identifier));
        }

        /// <summary>
        /// Get an instance of the operations this container holds.
        /// </summary>
        /// <param name="subscriptionGuid"> The guid of the subscription to be found. </param>
        /// <returns> An instance of <see cref="ResourceOperationsBase{Subscription}"/>. </returns>
        protected override ResourceOperationsBase<Subscription> GetOperation(string subscriptionGuid)
        {
            return new SubscriptionOperations(new ClientContext(ClientOptions, Credential, BaseUri), subscriptionGuid);
        }

        //TODO: can make static?
        private Func<ResourceManager.Resources.Models.Subscription, Subscription> Converter()
        {
            return s => new Subscription(new SubscriptionOperations(new ClientContext(ClientOptions, Credential, BaseUri), s.SubscriptionId), new SubscriptionData(s));
        }
    }
}
