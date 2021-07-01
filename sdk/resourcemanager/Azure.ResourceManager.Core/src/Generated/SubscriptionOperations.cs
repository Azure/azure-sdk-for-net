// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
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
        /// <param name="operations"> The resource operations to copy the options from. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionOperations(OperationsBase operations, TenantResourceIdentifier id)
            : base(operations, id)
        {
        }

        /// <summary>
        /// Provides a way to reuse the protected client context.
        /// </summary>
        /// <typeparam name="T"> The actual type returned by the delegate. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns> Whatever the delegate returns. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual T UseClientContext<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, T> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }

        /// <summary>
        /// Gets the valid resource type for this operation class
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        private SubscriptionsRestOperations RestClient => new SubscriptionsRestOperations(Diagnostics, Pipeline, BaseUri);

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

        /// <summary>
        /// Gets the provider container under this subscription.
        /// </summary>
        /// <returns> The provider container. </returns>
        public virtual ProviderContainer GetProviders()
        {
            return new ProviderContainer(this);
        }

        /// <inheritdoc/>
        public override Response<Subscription> Get(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("SubscriptionOperations.Get");
            scope.Start();
            try
            {
                var response = RestClient.Get(Id.Name, cancellationToken);
                return Response.FromValue(new Subscription(this, response.Value), response.GetRawResponse());
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
                var response = await RestClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Subscription(this, response.Value), response.GetRawResponse());
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
                    var response = await RestClient.ListLocationsAsync(subscriptionId, cancellationToken).ConfigureAwait(false);
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
                    var response = RestClient.ListLocations(subscriptionId, cancellationToken);
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

        /// <summary>
        /// Gets a container representing all resources as generic objects in the current tenant.
        /// </summary>
        /// <returns> GenericResource container. </returns>
        public virtual GenericResourceContainer GetGenericResources()
        {
            return new GenericResourceContainer(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), Id);
        }
    }
}
