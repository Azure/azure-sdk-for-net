// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Maps.Common;

namespace Azure.Maps.Routing.Models
{
    /// <summary>
    /// An <see cref="Operation{RouteMatrixResult}"/> for tracking the status of a
    /// <see cref="MapsRoutingClient.GetRouteMatrix(WaitUntil, RouteMatrixOptions, CancellationToken)"/>
    /// request.  Its <see cref="Operation{RouteMatrixResult}.Value"/> upon successful
    /// completion will be the route matrix result.
    /// </summary>
    public class GetRouteMatrixOperation : Operation<RouteMatrixResult>
    {
        /// <summary>
        /// The client used to check for completion.
        /// </summary>
        private readonly MapsRoutingClient _client;

        /// <summary>
        /// The CancellationToken to use for all status checking.
        /// </summary>
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        /// Whether the operation has completed.
        /// </summary>
        private bool _hasCompleted;

        /// <summary>
        /// Gets the route matrix batch result.
        /// </summary>
        private RouteMatrixResult _value;

        private Response _rawResponse;

        /// <summary>
        /// The request ID used in route matrix request
        /// </summary>
        private string _id;

        /// <summary>
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <summary>
        /// Indicating whether the operation completed and
        /// successfully produced a value.  The <see cref="Operation{RouteMatrixResult}.Value"/>
        /// property is the route matrix result.
        /// </summary>
        public override bool HasValue => _value != null;

        /// <inheritdoc />
        public override string Id => _id;

        /// <summary>
        /// Gets the will be the route matrix result.
        /// </summary>
        public override RouteMatrixResult Value => _value;

        /// <inheritdoc />
        public override Response GetRawResponse() => _rawResponse;

        /// <inheritdoc />
        public override async ValueTask<Response<RouteMatrixResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            await WaitForCompletionAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override async ValueTask<Response<RouteMatrixResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            await WaitForCompletionAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override Response<RouteMatrixResult> WaitForCompletion(CancellationToken cancellationToken = default) =>
            WaitForCompletionAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc />
        public override Response<RouteMatrixResult> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            WaitForCompletionAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc />
        private async ValueTask<Response<RouteMatrixResult>> WaitForCompletionAsync(bool async, CancellationToken cancellationToken = default)
        {
            ResponseWithHeaders<RouteGetRouteMatrixHeaders> update = async
                ? await _client.RestClient.GetRouteMatrixAsync(_id, cancellationToken).ConfigureAwait(false)
                : _client.RestClient.GetRouteMatrix(_id, cancellationToken);

            Response response = update.GetRawResponse();

            // Check if the operation is no longer running
            if (update.Headers.Location == null)
            {
                _hasCompleted = true;

                using var document = JsonDocument.Parse(response.ContentStream);
                _value = RouteMatrixResult.DeserializeRouteMatrixResult(document.RootElement);
                return Response.FromValue(_value, response);
            }
            else
            {
                var uri = new Uri(update.Headers.Location);
                var paths = uri.AbsolutePath.Split('/');
                _id = paths[paths.Length - 1];
            }

            return await WaitForCompletionAsync(async, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Initializes a new <see cref="GetRouteMatrixOperation"/> instance for
        /// mocking.
        /// </summary>
        protected GetRouteMatrixOperation()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="GetRouteMatrixOperation"/> instance
        /// </summary>
        /// <param name="client"> The client used to check for completion. </param>
        /// <param name="followUpUrl"> Follow up URL for route matrix operation. </param>
        internal GetRouteMatrixOperation(MapsRoutingClient client, Uri followUpUrl)
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
        /// Initializes a new <see cref="GetRouteMatrixOperation"/> instance
        /// </summary>
        /// <param name="client"> The client used to check for completion. </param>
        /// <param name="id"> An ID representing a specific operation.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="id"/> is null. </exception>
        /// <exception cref="FormatException"> <paramref name="id"/> format error. </exception>
        public GetRouteMatrixOperation(MapsRoutingClient client, string id) :
            this(client, id, null)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="GetRouteMatrixOperation"/> instance
        /// </summary>
        /// <param name="client"> The client used to check for completion. </param>
        /// <param name="id"> An ID representing a specific operation.</param>
        /// <param name="initialResponse">
        /// Either the response from initiating the operation or getting the
        /// status if we're creating an operation from an existing ID.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="id"/> is null. </exception>
        internal GetRouteMatrixOperation(
            MapsRoutingClient client,
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

        /// <summary>
        /// Check for the latest status of the route matrix calculation operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override Response UpdateStatus(
            CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Check for the latest status of the route matrix calculation operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override async ValueTask<Response> UpdateStatusAsync(
            CancellationToken cancellationToken = default) =>
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
            ResponseWithHeaders<RouteGetRouteMatrixHeaders> update = async
                ? await _client.RestClient.GetRouteMatrixAsync(_id, cancellationToken).ConfigureAwait(false)
                : _client.RestClient.GetRouteMatrix(_id, cancellationToken);

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
    }
}
