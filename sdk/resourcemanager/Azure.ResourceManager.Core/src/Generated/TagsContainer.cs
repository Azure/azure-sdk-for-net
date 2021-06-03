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
    public class TagsContainer : ContainerBase
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
            : base(clientContext, new SubscriptionResourceIdentifier(subscriptionId))
        {
            RestClient = new TagsRestOperations(Diagnostics, Pipeline, subscriptionId, BaseUri);
        }

        /// <summary>
        /// Gets the valid resource type associated with the container.
        /// </summary>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        /// <summary>
        /// Gets the operations that can be performed on the container.
        /// </summary>
        private TagsRestOperations RestClient;

        /// <summary> This operation allows adding a name to the list of predefined tag names for the given subscription. A tag name can have a maximum of 512 characters and is case-insensitive. Tag names cannot have the following prefixes which are reserved for Azure use: &apos;microsoft&apos;, &apos;azure&apos;, &apos;windows&apos;. </summary>
        /// <param name="tagName"> The name of the tag to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TagDetails>> CreateOrUpdateAsync(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.CreateOrUpdate");
            scope.Start();
            try
            {
                return await RestClient.CreateOrUpdateAsync(tagName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation allows adding a name to the list of predefined tag names for the given subscription. A tag name can have a maximum of 512 characters and is case-insensitive. Tag names cannot have the following prefixes which are reserved for Azure use: &apos;microsoft&apos;, &apos;azure&apos;, &apos;windows&apos;. </summary>
        /// <param name="tagName"> The name of the tag to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TagDetails> CreateOrUpdate(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.CreateOrUpdate");
            scope.Start();
            try
            {
                return RestClient.CreateOrUpdate(tagName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation performs a union of predefined tags, resource tags, resource group tags and subscription tags, and returns a summary of usage for each tag name and value under the given subscription. In case of a large number of tags, this operation may return a previously cached result. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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

        /// <summary> This operation performs a union of predefined tags, resource tags, resource group tags and subscription tags, and returns a summary of usage for each tag name and value under the given subscription. In case of a large number of tags, this operation may return a previously cached result. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
    }
}
