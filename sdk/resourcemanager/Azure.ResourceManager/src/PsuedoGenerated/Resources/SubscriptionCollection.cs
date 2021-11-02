// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing collection of Subscription and their operations
    /// </summary>
    public class SubscriptionCollection : ArmCollection, IEnumerable<Subscription>, IAsyncEnumerable<Subscription>
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionCollection"/> class for mocking.
        /// </summary>
        protected SubscriptionCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionCollection"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SubscriptionCollection(Tenant parent)
            : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            RestClient = new SubscriptionsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected new Tenant Parent { get { return base.Parent as Tenant; } }

        /// <summary>
        /// Gets the valid resource type associated with the collection.
        /// </summary>
        protected override ResourceType ValidResourceType => Tenant.ResourceType;

        /// <summary>
        /// Gets the operations that can be performed on the collection.
        /// </summary>
        private SubscriptionsRestOperations RestClient;

        /// <summary>
        /// Lists all subscriptions in the current collection.
        /// </summary>
        /// <param name="cancellationToken">A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<Subscription> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Subscription> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.GetAll");
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
                using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.GetAll");
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
        /// Lists all subscriptions in the current collection.
        /// </summary>
        /// <param name="cancellationToken">A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<Subscription> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Subscription>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.GetAll");
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
                using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.GetAll");
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
        /// Gets details for this subscription from the service.
        /// </summary>
        /// <param name="subscriptionGuid"> The Id of the subscription to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response{Subscription}"/> operation for this subscription. </returns>
        /// <exception cref="ArgumentException"> subscriptionGuid cannot be null or a whitespace. </exception>
        public Response<Subscription> Get(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.Get");
            scope.Start();
            try
            {
                var response = RestClient.Get(subscriptionGuid, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());

                return Response.FromValue(new Subscription(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets details for this subscription from the service.
        /// </summary>
        /// <param name="subscriptionGuid"> The Id of the subscription to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{TOperations}"/> operation for this subscription. </returns>
        /// <exception cref="ArgumentException"> subscriptionGuid cannot be null or a whitespace. </exception>
        public virtual async Task<Response<Subscription>> GetAsync(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.Get");
            scope.Start();
            try
            {
                var response = await RestClient.GetAsync(subscriptionGuid, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

                return Response.FromValue(new Subscription(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="subscriptionGuid"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual Response<Subscription> GetIfExists(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.GetIfExists");
            scope.Start();

            try
            {
                var response = RestClient.Get(subscriptionGuid, cancellationToken);
                return response.Value == null
                    ? Response.FromValue<Subscription>(null, response.GetRawResponse())
                    : Response.FromValue(new Subscription(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="subscriptionGuid"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<Response<Subscription>> GetIfExistsAsync(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.GetIfExists");
            scope.Start();

            try
            {
                var response = await RestClient.GetAsync(subscriptionGuid, cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<Subscription>(null, response.GetRawResponse())
                    : Response.FromValue(new Subscription(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this collection.
        /// </summary>
        /// <param name="subscriptionGuid"> The name of the resource you want to check. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual Response<bool> CheckIfExists(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.CheckIfExists");
            scope.Start();

            try
            {
                var response = GetIfExists(subscriptionGuid, cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this collection.
        /// </summary>
        /// <param name="subscriptionGuid"> The name of the resource you want to check. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<Response<bool>> CheckIfExistsAsync(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionCollection.CheckIfExists");
            scope.Start();

            try
            {
                var response = await GetIfExistsAsync(subscriptionGuid, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Subscription> IEnumerable<Subscription>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Subscription> IAsyncEnumerable<Subscription>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
