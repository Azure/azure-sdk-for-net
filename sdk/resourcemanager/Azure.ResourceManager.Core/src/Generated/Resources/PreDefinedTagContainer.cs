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
    /// A class representing collection of Tag and its operations.
    /// </summary>
    public class PreDefinedTagContainer : ContainerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTagContainer"/> class for mocking.
        /// </summary>
        protected PreDefinedTagContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTagContainer"/> class.
        /// </summary>
        /// <param name="clientContext">Current client context. </param>
        /// <param name="subscription">The parent subscription. </param>
        internal PreDefinedTagContainer(ClientContext clientContext, SubscriptionResourceIdentifier subscription)
            : base(clientContext, new SubscriptionResourceIdentifier(subscription))
        {
            RestClient = new TagRestOperations(Diagnostics, Pipeline, subscription.SubscriptionId, BaseUri);
        }

        /// <summary>
        /// Gets the valid resource type associated with the container.
        /// </summary>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        /// <summary>
        /// Gets the operations that can be performed on the container.
        /// </summary>
        private TagRestOperations RestClient;

        /// <summary> This operation allows adding a name to the list of predefined tag names for the given subscription. A tag name can have a maximum of 512 characters and is case-insensitive. Tag names cannot have the following prefixes which are reserved for Azure use: &apos;microsoft&apos;, &apos;azure&apos;, &apos;windows&apos;. </summary>
        /// <param name="tagName"> The name of the tag to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PreDefinedTag>> CreateOrUpdateAsync(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("PreDefinedTagContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response =  await StartCreateOrUpdateAsync(tagName, cancellationToken).ConfigureAwait(false);
                return await response.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
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
        public virtual Response<PreDefinedTag> CreateOrUpdate(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("PreDefinedTagContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = StartCreateOrUpdate(tagName, cancellationToken);
                return response.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>This operation allows adding a name to the list of predefined tag names for the given subscription. A tag name can have a maximum of 512 characters and is case-insensitive. Tag names cannot have the following prefixes which are reserved for Azure use: &apos;microsoft&apos;, &apos;azure&apos;, &apos;windows&apos;. </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="Operation{ResourceGroup}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the resource group cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public PreDefinedTagCreateOrUpdateOperation StartCreateOrUpdate(string tagName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(tagName))
                throw new ArgumentException("tagName cannot be null or a whitespace.", nameof(tagName));

            using var scope = Diagnostics.CreateScope("PreDefinedTagContainer.StartCreateOrUpdate");
            scope.Start();

            try
            {
                var originalResponse = RestClient.CreateOrUpdate(tagName, cancellationToken);
                return new PreDefinedTagCreateOrUpdateOperation(this, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation allows adding a name to the list of predefined tag names for the given subscription. A tag name can have a maximum of 512 characters and is case-insensitive. Tag names cannot have the following prefixes which are reserved for Azure use: &apos;microsoft&apos;, &apos;azure&apos;, &apos;windows&apos;.
        /// </summary>
        /// <param name="tagName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="Operation{ResourceGroup}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the resource group cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public virtual async Task<PreDefinedTagCreateOrUpdateOperation> StartCreateOrUpdateAsync(string tagName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(tagName))
                throw new ArgumentException("name cannot be null or a whitespace.", nameof(tagName));

            using var scope = Diagnostics.CreateScope("PreDefinedTagContainer.StartCreateOrUpdate");
            scope.Start();

            try
            {
                var originalResponse = await RestClient.CreateOrUpdateAsync(tagName, cancellationToken).ConfigureAwait(false);
                return new PreDefinedTagCreateOrUpdateOperation(this, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation performs a union of predefined tags, resource tags, resource group tags and subscription tags, and returns a summary of usage for each tag name and value under the given subscription. In case of a large number of tags, this operation may return a previously cached result. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PreDefinedTag> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PreDefinedTag>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope0 = Diagnostics.CreateScope("PreDefinedTagContainer.List");
                scope0.Start();
                try
                {
                    var response = await RestClient.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new PreDefinedTag(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            async Task<Page<PreDefinedTag>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope0 = Diagnostics.CreateScope("PreDefinedTagContainer.List");
                scope0.Start();
                try
                {
                    var response = await RestClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new PreDefinedTag(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
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
        public virtual Pageable<PreDefinedTag> List(CancellationToken cancellationToken = default)
        {
            Page<PreDefinedTag> FirstPageFunc(int? pageSizeHint)
            {
                using var scope0 = Diagnostics.CreateScope("PreDefinedTagContainer.List");
                scope0.Start();
                try
                {
                    var response = RestClient.List(cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new PreDefinedTag(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            Page<PreDefinedTag> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope0 = Diagnostics.CreateScope("PreDefinedTagContainer.List");
                scope0.Start();
                try
                {
                    var response = RestClient.ListNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new PreDefinedTag(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
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
