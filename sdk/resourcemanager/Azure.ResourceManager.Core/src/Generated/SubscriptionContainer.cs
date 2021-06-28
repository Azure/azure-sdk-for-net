// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of Subscription and their operations
    /// </summary>
    public class SubscriptionContainer : ResourceContainerBase<SubscriptionResourceIdentifier, Subscription, SubscriptionData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionContainer"/> class for mocking.
        /// </summary>
        protected SubscriptionContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionContainer"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        internal SubscriptionContainer(ClientContext clientContext)
            : base(clientContext, null)
        {
            RestClient = new SubscriptionsRestOperations(this.Diagnostics, this.Pipeline);
        }

        /// <summary>
        /// Gets the valid resource type associated with the container.
        /// </summary>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        /// <summary>
        /// Gets the operations that can be performed on the container.
        /// </summary>
        private SubscriptionsRestOperations RestClient;

        /// <summary>
        /// Lists all subscriptions in the current container.
        /// </summary>
        /// <param name="cancellationToken">A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<Subscription> List(CancellationToken cancellationToken = default)
        {
            Page<Subscription> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionContainer.List");
                scope.Start();
                try
                {
                    var response = RestClient.List(cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new Subscription(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Subscription> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionContainer.List");
                scope.Start();
                try
                {
                    var response = RestClient.ListNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new Subscription(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all subscriptions in the current container.
        /// </summary>
        /// <param name="cancellationToken">A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<Subscription> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Subscription>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionContainer.List");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new Subscription(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Subscription>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionContainer.List");
                scope.Start();
                try
                {
                    var response = await RestClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new Subscription(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
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
        /// Validate the resource identifier is supported in the current container.
        /// </summary>
        /// <param name="identifier"> The identifier of the resource. </param>
        protected override void Validate(ResourceIdentifier identifier)
        {
            if (!(identifier is null))
                throw new ArgumentException("Invalid parent for subscription container", nameof(identifier));
        }

        /// <summary>
        /// Gets details for this subscription from the service.
        /// </summary>
        /// <param name="subscriptionGuid"> The Id of the subscription to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response{Subscription}"/> operation for this subscription. </returns>
        /// <exception cref="ArgumentException"> subscriptionGuid cannot be null or a whitespace. </exception>
        public Response<Subscription> Get(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            return new SubscriptionOperations(
                    new ClientContext(ClientOptions, Credential, BaseUri, Pipeline),
                    subscriptionGuid).Get(cancellationToken);
        }

        /// <summary>
        /// Gets details for this subscription from the service.
        /// </summary>
        /// <param name="subscriptionGuid"> The Id of the subscription to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{TOperations}"/> operation for this subscription. </returns>
        /// <exception cref="ArgumentException"> subscriptionGuid cannot be null or a whitespace. </exception>
        public virtual Task<Response<Subscription>> GetAsync(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            return new SubscriptionOperations(
                new ClientContext(ClientOptions, Credential, BaseUri, Pipeline),
                subscriptionGuid).GetAsync(cancellationToken);
        }

        /// <summary>
        /// Get an instance of the operations this container holds.
        /// </summary>
        /// <param name="subscriptionGuid"> The guid of the subscription to be found. </param>
        /// <returns> An instance of <see cref="ResourceOperationsBase{TenantResourceIdentifier, Subscription}"/>. </returns>
        protected override ResourceOperationsBase<SubscriptionResourceIdentifier, Subscription> GetOperation(string subscriptionGuid)
        {
            return new SubscriptionOperations(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), subscriptionGuid);
        }

        //TODO: can make static?
        private Func<SubscriptionData, Subscription> Converter()
        {
            return s => new Subscription(new SubscriptionOperations(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), s.Id), s);
        }
    }
}
