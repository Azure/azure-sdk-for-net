// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    public class SubscriptionOperations : ResourceOperationsBase<SubscriptionResourceIdentifier, Subscription>
    {
        /// <summary>
        /// The resource type for subscription
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/subscriptions";

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class for mocking.
        /// </summary>
        protected SubscriptionOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="subscriptionGuid"> The Guid of the subscription. </param>
        internal SubscriptionOperations(ClientContext clientContext, string subscriptionGuid)
            : base(clientContext, new SubscriptionResourceIdentifier(subscriptionGuid))
        {
            SubscriptionsRestOperations = new SubscriptionsRestOperations(new ClientDiagnostics(this.ClientOptions),
                ManagementPipelineBuilder.Build(Credential, BaseUri, this.ClientOptions),
                BaseUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class.
        /// </summary>
        /// <param name="subscription"> The subscription operations to copy client options from. </param>
        /// <param name="id"> The identifier of the subscription. </param>
        protected SubscriptionOperations(SubscriptionOperations subscription, SubscriptionResourceIdentifier id)
            : base(subscription, id)
        {
            SubscriptionsRestOperations = new SubscriptionsRestOperations(new ClientDiagnostics(this.ClientOptions),
                ManagementPipelineBuilder.Build(Credential, BaseUri, this.ClientOptions),
                BaseUri);
        }

        /// <summary>
        /// ListResources of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public virtual T ListResources<T>(Func<Uri, TokenCredential, ArmClientOptions, T> func)
        {
            return func(BaseUri, Credential, ClientOptions);
        }

        /// <summary>
        /// ListResourcesAsync of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public virtual AsyncPageable<T> ListResourcesAsync<T>(Func<Uri, TokenCredential, ArmClientOptions, AsyncPageable<T>> func)
        {
            return func(BaseUri, Credential, ClientOptions);
        }

        /// <summary>
        /// Gets the valid resource type for this operation class
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        private SubscriptionsRestOperations SubscriptionsRestOperations;

        /// <summary>
        /// Gets the resource group container under this subscription.
        /// </summary>
        /// <returns> The resource group container. </returns>
        public virtual ResourceGroupContainer GetResourceGroups()
        {
            return new ResourceGroupContainer(this);
        }

        /// <summary>
        /// Gets the location group container under this subscription.
        /// </summary>
        /// <returns> The resource group container. </returns>
        public virtual LocationContainer GetLocations()
        {
            return new LocationContainer(this);
        }

        /// <inheritdoc/>
        public override ArmResponse<Subscription> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Subscription, SubscriptionData>(
                SubscriptionsRestOperations.Get(Id.Name, cancellationToken),
                Converter());
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<Subscription>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Subscription, SubscriptionData>(
                await SubscriptionsRestOperations.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false),
                Converter());
        }

        /// <summary> Gets all subscriptions for a tenant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<SubscriptionData> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionsOperations.List");
                scope.Start();
                try
                {
                    var response = await SubscriptionsRestOperations.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionsOperations.List");
                scope.Start();
                try
                {
                    var response = await SubscriptionsRestOperations.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets all subscriptions for a tenant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<SubscriptionData> List(CancellationToken cancellationToken = default)
        {
            Page<SubscriptionData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionsOperations.List");
                scope.Start();
                try
                {
                    var response = SubscriptionsRestOperations.List(cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionsOperations.List");
                scope.Start();
                try
                {
                    var response = SubscriptionsRestOperations.ListNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> This operation provides all the locations that are available for resource providers; however, each resource provider may support a subset of this list. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual AsyncPageable<LocationData> ListLocationsAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }

            async Task<Page<LocationData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionsOperations.ListLocations");
                scope.Start();
                try
                {
                    var response = await SubscriptionsRestOperations.ListLocationsAsync(subscriptionId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> This operation provides all the locations that are available for resource providers; however, each resource provider may support a subset of this list. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual Pageable<LocationData> ListLocations(string subscriptionId, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }

            Page<LocationData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("SubscriptionsOperations.ListLocations");
                scope.Start();
                try
                {
                    var response = SubscriptionsRestOperations.ListLocations(subscriptionId, cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        private Func<SubscriptionData, Subscription> Converter()
        {
            return s => new Subscription(this, s);
        }
    }
}
