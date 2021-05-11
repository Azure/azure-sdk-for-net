// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class.
        /// </summary>
        /// <param name="subscription"> The subscription operations to copy client options from. </param>
        /// <param name="id"> The identifier of the subscription. </param>
        protected SubscriptionOperations(SubscriptionOperations subscription, SubscriptionResourceIdentifier id)
            : base(subscription, id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class.
        /// </summary>
        /// <param name="operations"> The resource operations to copy the options from. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionOperations(OperationsBase operations, TenantResourceIdentifier id)
            : base(operations, id)
        {
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

        private SubscriptionsRestOperations SubscriptionsRestOperations => new SubscriptionsRestOperations(this.Diagnostics, this.Pipeline, BaseUri);

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
        public override Response<Subscription> Get(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("SubscriptionOperations.Get");
            scope.Start();
            try
            {
                return new PhArmResponse<Subscription, SubscriptionData>(
                SubscriptionsRestOperations.Get(Id.Name, cancellationToken),
                Converter());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override async Task<Response<Subscription>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("SubscriptionOperations.Get");
            scope.Start();
            try
            {
                return new PhArmResponse<Subscription, SubscriptionData>(
                await SubscriptionsRestOperations.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false),
                Converter());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
                using var scope = Diagnostics.CreateScope("SubscriptionOperations.ListLocations");
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
                using var scope = Diagnostics.CreateScope("SubscriptionOperations.ListLocations");
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

        /// <summary>
        /// Gets a container representing all resources as generic objects in the current tenant.
        /// </summary>
        /// <returns> GenericResource container. </returns>
        public GenericResourceContainer GetGenericResources()
        {
            return new GenericResourceContainer(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), Id);
        }
    }
}
