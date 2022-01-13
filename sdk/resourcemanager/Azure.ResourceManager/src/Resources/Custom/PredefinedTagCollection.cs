// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
    /// A class representing collection of Tag and its operations.
    /// </summary>
    public class PredefinedTagCollection : ArmCollection, IEnumerable<PredefinedTag>, IAsyncEnumerable<PredefinedTag>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TagRestOperations _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PredefinedTagCollection"/> class for mocking.
        /// </summary>
        protected PredefinedTagCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PredefinedTagCollection"/> class.
        /// </summary>
        /// <param name="clientContext">Current client context. </param>
        /// <param name="parentId"> The parent subscription id. </param>
        internal PredefinedTagCollection(ClientContext clientContext, ResourceIdentifier parentId)
            : base(clientContext, parentId)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            if (ClientOptions.ResourceApiVersionOverrides.TryGetValue(TagResource.ResourceType, out var version))
            {
                _restClient = new TagRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri, version);
            }
            else
            {
                _restClient = new TagRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
            }
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// <summary> This operation allows adding a name to the list of predefined tag names for the given subscription. A tag name can have a maximum of 512 characters and is case-insensitive. Tag names cannot have the following prefixes which are reserved for Azure use: &apos;microsoft&apos;, &apos;azure&apos;, &apos;windows&apos;. </summary>
        /// <param name="tagName"> The name of the tag to create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<PredefinedTagCreateOrUpdateOperation> CreateOrUpdateAsync(string tagName, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PredefinedTagCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = await _restClient.CreateOrUpdateAsync(tagName, cancellationToken).ConfigureAwait(false);
                var operation = new PredefinedTagCreateOrUpdateOperation(this, originalResponse);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation allows adding a name to the list of predefined tag names for the given subscription. A tag name can have a maximum of 512 characters and is case-insensitive. Tag names cannot have the following prefixes which are reserved for Azure use: &apos;microsoft&apos;, &apos;azure&apos;, &apos;windows&apos;. </summary>
        /// <param name="tagName"> The name of the tag to create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual PredefinedTagCreateOrUpdateOperation CreateOrUpdate(string tagName, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PredefinedTagCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = _restClient.CreateOrUpdate(tagName, cancellationToken);
                var operation = new PredefinedTagCreateOrUpdateOperation(this, originalResponse);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation performs a union of predefined tags, resource tags, resource group tags and subscription tags, and returns a summary of usage for each tag name and value under the given subscription. In case of a large number of tags, this operation may return a previously cached result. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PredefinedTag> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PredefinedTag>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope0 = _clientDiagnostics.CreateScope("PredefinedTagCollection.GetAll");
                scope0.Start();
                try
                {
                    var response = await _restClient.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new PredefinedTag(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            async Task<Page<PredefinedTag>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope0 = _clientDiagnostics.CreateScope("PredefinedTagCollection.GetAll");
                scope0.Start();
                try
                {
                    var response = await _restClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new PredefinedTag(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
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
        public virtual Pageable<PredefinedTag> GetAll(CancellationToken cancellationToken = default)
        {
            Page<PredefinedTag> FirstPageFunc(int? pageSizeHint)
            {
                using var scope0 = _clientDiagnostics.CreateScope("PredefinedTagCollection.GetAll");
                scope0.Start();
                try
                {
                    var response = _restClient.List(cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new PredefinedTag(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            Page<PredefinedTag> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope0 = _clientDiagnostics.CreateScope("PredefinedTagCollection.GetAll");
                scope0.Start();
                try
                {
                    var response = _restClient.ListNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new PredefinedTag(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<PredefinedTag> IEnumerable<PredefinedTag>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PredefinedTag> IAsyncEnumerable<PredefinedTag>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
