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
    /// A class representing collection of Tags and their operations.
    /// </summary>
    public class TagsContainer : ResourceContainerBase<SubscriptionResourceIdentifier, Tags, TagsData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagsContainer"/> class for mocking.
        /// </summary>
        protected TagsContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TagsContainer"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="subscriptionId"></param>
        internal TagsContainer(ClientContext clientContext, string subscriptionId)
            : base(clientContext, null)
        {
            RestClient = new TagsRestOperations(Diagnostics, Pipeline, subscriptionId, BaseUri);
        }

        /// <summary>
        /// Gets the valid resource type associated with the container.
        /// </summary>
        protected override ResourceType ValidResourceType => TagsOperations.ResourceType;

        /// <summary>
        /// Gets the operations that can be performed on the container.
        /// </summary>
        private TagsRestOperations RestClient;

        /// <summary>
        /// Lists all Tags in the current container.
        /// </summary>
        /// <param name="cancellationToken">A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<TagDetails> List(CancellationToken cancellationToken = default)
        {
            Page<TagDetails> FirstPageFunc(int? pageSizeHint)
            {
                using var scope0 = Diagnostics.CreateScope("TagsOperations.List");
                scope0.Start();
                try
                {
                    var response = RestClient.List(cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            Page<TagDetails> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope0 = Diagnostics.CreateScope("TagsOperations.List");
                scope0.Start();
                try
                {
                    var response = RestClient.ListNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
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
        public virtual AsyncPageable<TagDetails> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TagDetails>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope0 = Diagnostics.CreateScope("TagsOperations.List");
                scope0.Start();
                try
                {
                    var response = await RestClient.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            async Task<Page<TagDetails>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope0 = Diagnostics.CreateScope("TagsOperations.List");
                scope0.Start();
                try
                {
                    var response = await RestClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
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

        /// <inheritdoc />
        public override Response<Tags> Get(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            return new TagsOperations(
                    new ClientContext(ClientOptions, Credential, BaseUri, Pipeline),
                    subscriptionGuid).Get(cancellationToken);
        }

        /// <inheritdoc />
        public override Task<Response<Tags>> GetAsync(string subscriptionGuid, CancellationToken cancellationToken = default)
        {
            return new TagsOperations(
                new ClientContext(ClientOptions, Credential, BaseUri, Pipeline),
                subscriptionGuid).GetAsync(cancellationToken);
        }

        /// <summary>
        /// Get an instance of the operations this container holds.
        /// </summary>
        /// <param name="subscriptionGuid"> The guid of the subscription to be found. </param>
        /// <returns> An instance of <see cref="ResourceOperationsBase{TenantResourceIdentifier, Tags}"/>. </returns>
        protected override ResourceOperationsBase<SubscriptionResourceIdentifier, Tags> GetOperation(string subscriptionGuid)
        {
            return new TagsOperations(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), subscriptionGuid);
        }
    }
}
