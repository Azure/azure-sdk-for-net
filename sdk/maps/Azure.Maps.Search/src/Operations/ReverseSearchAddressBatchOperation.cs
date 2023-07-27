// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Maps.Search.Models;

namespace Azure.Maps.Search
{
    /// <summary>
    /// Reverse search address batch long-running operation class.
    /// Use this operation to get the reverse search address batch results from server.
    /// </summary>
    public partial class ReverseSearchAddressBatchOperation : Operation<ReverseSearchAddressBatchResult>
    {
        /// <summary> Initializes a new instance of ReverseSearchAddressBatchOperation for mocking. </summary>
        protected ReverseSearchAddressBatchOperation()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ReverseSearchAddressBatchOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// <param name="followUpUrl">Follow up URL of the request.</param>
        /// The client used to check for completion.
        /// </param>
        internal ReverseSearchAddressBatchOperation(MapsSearchClient client, Uri followUpUrl)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(followUpUrl, nameof(followUpUrl));

            try
            {
                var paths = followUpUrl.AbsolutePath.Split('/');
                _id = paths[paths.Length - 1];
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is UriFormatException)
                {
                    throw new FormatException("Invalid ID", ex);
                }
            }

            _value = null;
            _rawResponse = null;
            _client = client;
            _cancellationToken = default;
        }

        /// <summary>
        /// Initializes a new <see cref="ReverseSearchAddressBatchOperation"/> instance
        /// <param name="client"> The client used to check for completion. </param>
        /// <param name="id"> An ID representing a specific operation.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="id"/> is null. </exception>
        /// <exception cref="FormatException"> <paramref name="id"/> format error. </exception>
        /// </summary>
        public ReverseSearchAddressBatchOperation(MapsSearchClient client, string id) :
            this(client, id, null)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ReverseSearchAddressBatchOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="id"> An ID representing a specific operation.</param>
        /// <param name="initialResponse">
        /// Either the response from initiating the operation or getting the
        /// status if we're creating an operation from an existing ID.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        internal ReverseSearchAddressBatchOperation(
            MapsSearchClient client,
            string id,
            Response initialResponse,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(id, nameof(id));

            _id = id;
            _value = null;
            _rawResponse = initialResponse;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        private readonly MapsSearchClient _client;

        private readonly CancellationToken _cancellationToken;

        private bool _hasCompleted;

        private ReverseSearchAddressBatchResult _value;

        private Response _rawResponse;

        private string _id;

        /// <inheritdoc />
        public override ReverseSearchAddressBatchResult Value => _value;

        /// <inheritdoc />
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _value != null;

        /// <inheritdoc />
        public override string Id => _id;

        /// <inheritdoc />
        public override Response GetRawResponse() => _rawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc />
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check for the latest status of the route matrix calculation operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="async" />
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        private async Task<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            // Short-circuit when already completed (which improves mocking
            // scenarios that won't have a client).
            if (HasCompleted)
            {
                return GetRawResponse();
            }

            // Use our original CancellationToken if the user didn't provide one
            if (cancellationToken == default)
            {
                cancellationToken = _cancellationToken;
            }

            // Get the latest status
            ResponseWithHeaders<SearchGetReverseSearchAddressBatchHeaders> update = async
                ? await _client.RestClient.GetReverseSearchAddressBatchAsync(_id, cancellationToken).ConfigureAwait(false)
                : _client.RestClient.GetReverseSearchAddressBatch(_id, cancellationToken);

            // Check if the operation is no longer running
            if (update.Headers.Location == null)
            {
                _hasCompleted = true;
            }
            else
            {
                var uri = new Uri(update.Headers.Location);
                var paths = uri.AbsolutePath.Split('/');
                _id = paths[paths.Length - 1];
            }

            // Save this update as the latest raw response indicating the state
            // of the route matrix calculation operation
            Response response = update.GetRawResponse();
            _rawResponse = response;
            return response;
        }

        /// <inheritdoc />
        public override async ValueTask<Response<ReverseSearchAddressBatchResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            await WaitForCompletionAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override async ValueTask<Response<ReverseSearchAddressBatchResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            await this.WaitForCompletionAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override Response<ReverseSearchAddressBatchResult> WaitForCompletion(CancellationToken cancellationToken = default) =>
            this.WaitForCompletionAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc />
        public override Response<ReverseSearchAddressBatchResult> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.WaitForCompletionAsync(false, cancellationToken).EnsureCompleted();

        private async ValueTask<Response<ReverseSearchAddressBatchResult>> WaitForCompletionAsync(bool async, CancellationToken cancellationToken)
        {
            ResponseWithHeaders<SearchGetReverseSearchAddressBatchHeaders> update = async
                ? await _client.RestClient.GetReverseSearchAddressBatchAsync(_id, cancellationToken).ConfigureAwait(false)
                : _client.RestClient.GetReverseSearchAddressBatch(_id, cancellationToken);

            Response response = update.GetRawResponse();

            // Check if the operation is no longer running
            if (update.Headers.Location == null)
            {
                _hasCompleted = true;

                using var document = JsonDocument.Parse(response.ContentStream);
                _value = ReverseSearchAddressBatchResult.DeserializeReverseSearchAddressBatchResult(document.RootElement);
                return Response.FromValue(_value, response);
            }
            else
            {
                var uri = new Uri(update.Headers.Location);
                var paths = uri.AbsolutePath.Split('/');
                _id = paths[paths.Length - 1];
            }

            ReverseSearchAddressBatchResult result = null;
            return Response.FromValue(result, response);
        }
    }
}
