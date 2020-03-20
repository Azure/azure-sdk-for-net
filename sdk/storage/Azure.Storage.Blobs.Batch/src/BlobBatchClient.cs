﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// The <see cref="BlobBatchClient"/> allows you to batch multiple Azure
    /// Storage operations in a single request.
    /// </summary>
    public class BlobBatchClient
    {
        /// <summary>
        /// Gets the blob service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri { get; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        internal virtual HttpPipeline Pipeline { get; }

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        internal virtual BlobClientOptions.ServiceVersion Version { get; }

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to prepare
        /// requests for batching without actually sending them.
        /// </summary>
        internal virtual HttpPipeline BatchOperationPipeline { get; }

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBatchClient"/>
        /// class for mocking.
        /// </summary>
        protected BlobBatchClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBatchClient"/>
        /// class for the same account as the <see cref="BlobServiceClient"/>.
        /// The new <see cref="BlobBatchClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobServiceClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobServiceClient"/>.</param>
        public BlobBatchClient(BlobServiceClient client)
        {
            Uri = client.Uri;
            Pipeline = BlobServiceClientInternals.GetHttpPipeline(client);
            BlobClientOptions options = BlobServiceClientInternals.GetClientOptions(client);
            Version = options.Version;
            ClientDiagnostics = new ClientDiagnostics(options);

            // Construct a dummy pipeline for processing batch sub-operations
            // if we don't have one cached on the service
            BatchOperationPipeline = CreateBatchPipeline(
                Pipeline,
                BlobServiceClientInternals.GetAuthenticationPolicy(client),
                Version);
        }

        /// <summary>
        /// Creates a pipeline to use for processing sub-operations before they
        /// are combined into a single multipart request.
        /// </summary>
        /// <param name="pipeline">
        /// The pipeline used to submit the live request.
        /// </param>
        /// <param name="authenticationPolicy">
        /// An optional <see cref="HttpPipelinePolicy"/> used to authenticate
        /// the sub-operations.
        /// </param>
        /// <param name="serviceVersion">
        /// The serviceVersion used when generating sub-requests.
        /// </param>
        /// <returns>A pipeline to use for processing sub-operations.</returns>
        private static HttpPipeline CreateBatchPipeline(
            HttpPipeline pipeline,
            HttpPipelinePolicy authenticationPolicy,
            BlobClientOptions.ServiceVersion serviceVersion)
        {
            // Configure the options to use minimal policies
            var options = new BlobClientOptions(serviceVersion);
            options.Diagnostics.IsLoggingEnabled = false;
            options.Diagnostics.IsTelemetryEnabled = false;
            options.Diagnostics.IsDistributedTracingEnabled = false;
            options.Retry.MaxRetries = 0;

            // Use an empty transport so requests aren't sent
            options.Transport = new BatchPipelineTransport(pipeline);

            // Use the same authentication mechanism
            return HttpPipelineBuilder.Build(
                options,
                RemoveVersionHeaderPolicy.Shared,
                authenticationPolicy);
        }

        /// <summary>
        /// Helper to access protected static members of BlobServiceClient
        /// that should not be exposed directly to customers.
        /// </summary>
        private class BlobServiceClientInternals : BlobServiceClient
        {
            /// <summary>
            /// Prevent instantiation.
            /// </summary>
            private BlobServiceClientInternals() { }

            /// <summary>
            /// Get a <see cref="BlobServiceClient"/>'s <see cref="HttpPipeline"/>
            /// for creating child clients.
            /// </summary>
            /// <param name="client">The BlobServiceClient.</param>
            /// <returns>The BlobServiceClient's HttpPipeline.</returns>
            public static new HttpPipeline GetHttpPipeline(BlobServiceClient client) =>
                BlobServiceClient.GetHttpPipeline(client);

            /// <summary>
            /// Get a <see cref="BlobServiceClient"/>'s authentication
            /// <see cref="HttpPipelinePolicy"/> for creating child clients.
            /// </summary>
            /// <param name="client">The BlobServiceClient.</param>
            /// <returns>The BlobServiceClient's authentication policy.</returns>
            public static new HttpPipelinePolicy GetAuthenticationPolicy(BlobServiceClient client) =>
                BlobServiceClient.GetAuthenticationPolicy(client);

            /// <summary>
            /// Get a <see cref="BlobServiceClient"/>'s <see cref="BlobClientOptions"/>
            /// for creating child clients.
            /// </summary>
            /// <param name="client">The BlobServiceClient.</param>
            /// <returns>The BlobServiceClient's BlobClientOptions.</returns>
            public static new BlobClientOptions GetClientOptions(BlobServiceClient client) =>
                BlobServiceClient.GetClientOptions(client);
        }
        #endregion ctors

        #region Create/SubmitBatch
        /// <summary>
        /// Creates a new <see cref="BlobBatch"/> to collect sub-operations
        /// that can be submitted together via <see cref="SubmitBatch"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobBatch"/>.</returns>
        public virtual BlobBatch CreateBatch() => new BlobBatch(this);

        /// <summary>
        /// Submit a <see cref="BlobBatch"/> of sub-operations.
        /// </summary>
        /// <param name="batch">
        /// A <see cref="BlobBatch"/> of sub-operations.
        /// </param>
        /// <param name="throwOnAnyFailure">
        /// A value indicating whether or not to throw exceptions for
        /// sub-operation failures.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully submitting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure to submit the batch occurs.  Individual sub-operation
        /// failures will only throw if <paramref name="throwOnAnyFailure"/> is
        /// true and be wrapped in an <see cref="AggregateException"/>.
        /// </remarks>
[ForwardsClientCalls] // TODO: Throwing exceptions fails tests
        public virtual Response SubmitBatch(
            BlobBatch batch,
            bool throwOnAnyFailure = false,
            CancellationToken cancellationToken = default) =>
            SubmitBatchInternal(
                batch,
                throwOnAnyFailure,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Submit a <see cref="BlobBatch"/> of sub-operations.
        /// </summary>
        /// <param name="batch">
        /// A <see cref="BlobBatch"/> of sub-operations.
        /// </param>
        /// <param name="throwOnAnyFailure">
        /// A value indicating whether or not to throw exceptions for
        /// sub-operation failures.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully submitting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure to submit the batch occurs.  Individual sub-operation
        /// failures will only throw if <paramref name="throwOnAnyFailure"/> is
        /// true and be wrapped in an <see cref="AggregateException"/>.
        /// </remarks>
[ForwardsClientCalls] // TODO: Throwing exceptions fails tests
        public virtual async Task<Response> SubmitBatchAsync(
            BlobBatch batch,
            bool throwOnAnyFailure = false,
            CancellationToken cancellationToken = default) =>
            await SubmitBatchInternal(
                batch,
                throwOnAnyFailure,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Submit a <see cref="BlobBatch"/> of sub-operations.
        /// </summary>
        /// <param name="batch">
        /// A <see cref="BlobBatch"/> of sub-operations.
        /// </param>
        /// <param name="throwOnAnyFailure">
        /// A value indicating whether or not to throw exceptions for
        /// sub-operation failures.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully submitting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure to submit the batch occurs.  Individual sub-operation
        /// failures will only throw if <paramref name="throwOnAnyFailure"/> is
        /// true and be wrapped in an <see cref="AggregateException"/>.
        /// </remarks>
        private async Task<Response> SubmitBatchInternal(
            BlobBatch batch,
            bool throwOnAnyFailure,
            bool async,
            CancellationToken cancellationToken)
        {
            batch = batch ?? throw new ArgumentNullException(nameof(batch));
            if (batch.Submitted)
            {
                throw BatchErrors.CannotResubmitBatch(nameof(batch));
            }
            else if (!batch.IsAssociatedClient(this))
            {
                throw BatchErrors.BatchClientDoesNotMatch(nameof(batch));
            }

            // Get the sub-operation messages to submit
            IList<HttpMessage> messages = batch.GetMessagesToSubmit();
            if (messages.Count == 0)
            {
                throw BatchErrors.CannotSubmitEmptyBatch(nameof(batch));
            }
            // TODO: Consider validating the upper limit of 256 messages

            // Merge the sub-operations into a single multipart/mixed Stream
            (Stream content, string contentType) =
                await MergeOperationRequests(
                    messages,
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);

            // Send the batch request
            Response<BlobBatchResult> batchResult =
                await BatchRestClient.Service.SubmitBatchAsync(
                    ClientDiagnostics,
                    Pipeline,
                    Uri,
                    body: content,
                    contentLength: content.Length,
                    multipartContentType: contentType,
                    version: Version.ToVersionString(),
                    async: async,
                    operationName: $"{nameof(BlobBatchClient)}.{nameof(SubmitBatch)}",
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

            // Split the responses apart and update the sub-operation responses
            Response raw = batchResult.GetRawResponse();
            await UpdateOperationResponses(
                messages,
                raw,
                batchResult.Value.Content,
                batchResult.Value.ContentType,
                throwOnAnyFailure,
                async,
                cancellationToken)
                .ConfigureAwait(false);

            // Return the batch result
            return raw;
        }

        /// <summary>
        /// Merge the batch sub-operation messages into a single content stream
        /// and content type.
        /// </summary>
        /// <param name="messages">
        /// The batch sub-operation messages to submit together.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A tuple containing the batch sub-operation messages merged into a
        /// single multipart/mixed content stream and content type.
        /// </returns>
        private async Task<(Stream, string)> MergeOperationRequests(
            IList<HttpMessage> messages,
            bool async,
            CancellationToken cancellationToken)
        {
            // Send all of the requests through a batch sub-operation pipeline
            // to prepare the requests with various headers like Authorization
            foreach (HttpMessage message in messages)
            {
                if (async)
                {
                    await BatchOperationPipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    BatchOperationPipeline.Send(message, cancellationToken);
                }
            }

            // Build the multipart/mixed request body
            return await Multipart.CreateAsync(
                messages,
                "batch",
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Split the batch multipart response into individual sub-operation
        /// responses and update the delayed responses already returned when
        /// the sub-operation was added.
        /// </summary>
        /// <param name="messages">
        /// The batch sub-operation messages that were submitted.
        /// </param>
        /// <param name="rawResponse">
        /// The raw batch response.
        /// </param>
        /// <param name="responseContent">
        /// The raw multipart response content.
        /// </param>
        /// <param name="responseContentType">
        /// The raw multipart response content type (containing the boundary).
        /// </param>
        /// <param name="throwOnAnyFailure">
        /// A value indicating whether or not to throw exceptions for
        /// sub-operation failures.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>A Task representing the update operation.</returns>
        private async Task UpdateOperationResponses(
            IList<HttpMessage> messages,
            Response rawResponse,
            Stream responseContent,
            string responseContentType,
            bool throwOnAnyFailure,
            bool async,
            CancellationToken cancellationToken)
        {
            // Parse the response content into individual responses
            Response[] responses;
            try
            {
                responses = await Multipart.ParseAsync(
                    responseContent,
                    responseContentType,
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);

                // Ensure we have the right number of responses
                if (messages.Count != responses.Length)
                {
                    // If we get one response and it's a 400, this is the
                    // service failing the entire batch and sending it back in
                    // a format not currently documented by the spec
                    if (responses.Length == 1 && responses[0].Status == 400)
                    {
                        // We'll re-process this response as a batch result
                        BatchRestClient.Service.SubmitBatchAsync_CreateResponse(ClientDiagnostics, responses[0]);
                    }
                    else
                    {
                        throw BatchErrors.UnexpectedResponseCount(messages.Count, responses.Length);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                // Wrap any parsing errors in a RequestFailedException
                throw BatchErrors.InvalidResponse(ClientDiagnostics, rawResponse, ex);
            }

            // Update the delayed responses
            List<Exception> failures = new List<Exception>();
            for (int i = 0; i < responses.Length; i++)
            {
                try
                {
                    if (messages[i].TryGetProperty(BatchConstants.DelayedResponsePropertyName, out object value) &&
                        value is DelayedResponse response)
                    {
                        response.SetLiveResponse(responses[i], throwOnAnyFailure);
                    }
                }
                catch (Exception ex)
                {
                    failures.Add(ex);
                }
            }

            // Throw any failures
            if (failures.Count > 0)
            {
                throw BatchErrors.ResponseFailures(failures);
            }
        }
        #endregion Create/SubmitBatch

        #region DeleteBlobs
        /// <summary>
        /// The DeleteBlobs operation marks the specified blobs for deletion.
        /// The blobs are later deleted during garbage collection.  All of the
        /// deletions are sent as a single batched request.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <param name="blobUris">URIs of the blobs to delete.</param>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <returns>
        /// The <see cref="Response"/>s for the individual Delete operations.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure to submit the batch occurs.  Individual sub-operation
        /// failures will be wrapped in an <see cref="AggregateException"/>.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response[] DeleteBlobs(
            IEnumerable<Uri> blobUris,
            DeleteSnapshotsOption snapshotsOption = default,
            CancellationToken cancellationToken = default) =>
            DeleteBlobsInteral(
                blobUris,
                snapshotsOption,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The DeleteBlobsAsync operation marks the specified blobs for
        /// deletion.  The blobs are later deleted during garbage collection.
        /// All of the deletions are sent as a single batched request.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <param name="blobUris">URIs of the blobs to delete.</param>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <returns>
        /// The <see cref="Response"/>s for the individual Delete operations.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure to submit the batch occurs.  Individual sub-operation
        /// failures will be wrapped in an <see cref="AggregateException"/>.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response[]> DeleteBlobsAsync(
            IEnumerable<Uri> blobUris,
            DeleteSnapshotsOption snapshotsOption = default,
            CancellationToken cancellationToken = default) =>
            await DeleteBlobsInteral(
                blobUris,
                snapshotsOption,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The DeleteBlobsAsync operation marks the specified blobs for
        /// deletion.  The blobs are later deleted during garbage collection.
        /// All of the deletions are sent as a single batched request.
        /// </summary>
        /// <param name="blobUris">URIs of the blobs to delete.</param>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The <see cref="Response"/>s for the individual Delete operations.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure to submit the batch occurs.  Individual sub-operation
        /// failures will be wrapped in an <see cref="AggregateException"/>.
        /// </remarks>
        internal async Task<Response[]> DeleteBlobsInteral(
            IEnumerable<Uri> blobUris,
            DeleteSnapshotsOption snapshotsOption,
            bool async,
            CancellationToken cancellationToken)
        {
            blobUris = blobUris ?? throw new ArgumentNullException(nameof(blobUris));
            var responses = new List<Response>();

            // Create the batch
            BlobBatch batch = CreateBatch();
            foreach (Uri uri in blobUris)
            {
                responses.Add(batch.DeleteBlob(uri, snapshotsOption));
            }

            // Submit the batch
            await SubmitBatchInternal(
                batch,
                true,
                async,
                cancellationToken)
                .ConfigureAwait(false);

            return responses.ToArray();
        }
        #endregion DeleteBlobs

        #region SetBlobsAccessTier
        /// <summary>
        /// The SetBlobsAccessTier operation sets the tier on blobs.  The
        /// operation is allowed on block blobs in a blob storage or general
        /// purpose v2 account.
        /// </summary>
        /// <param name="blobUris">URIs of the blobs to set the tiers of.</param>
        /// <param name="accessTier">
        /// Indicates the tier to be set on the blobs.
        /// </param>
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The <see cref="Response"/>s for the individual Set Tier operations.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure to submit the batch occurs.  Individual sub-operation
        /// failures will be wrapped in an <see cref="AggregateException"/>.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response[] SetBlobsAccessTier(
            IEnumerable<Uri> blobUris,
            AccessTier accessTier,
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default) =>
            SetBlobsAccessTierInteral(
                blobUris,
                accessTier,
                rehydratePriority,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The SetBlobsAccessTierAsync operation sets the tier on blobs.  The
        /// operation is allowed on block blobs in a blob storage or general
        /// purpose v2 account.
        /// </summary>
        /// <param name="blobUris">URIs of the blobs to set the tiers of.</param>
        /// <param name="accessTier">
        /// Indicates the tier to be set on the blobs.
        /// </param>
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The <see cref="Response"/>s for the individual Set Tier operations.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure to submit the batch occurs.  Individual sub-operation
        /// failures will be wrapped in an <see cref="AggregateException"/>.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response[]> SetBlobsAccessTierAsync(
            IEnumerable<Uri> blobUris,
            AccessTier accessTier,
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default) =>
            await SetBlobsAccessTierInteral(
                blobUris,
                accessTier,
                rehydratePriority,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The SetBlobsAccessTierAsync operation sets the tier on blobs.  The
        /// operation is allowed on block blobs in a blob storage or general
        /// purpose v2 account.
        /// </summary>
        /// <param name="blobUris">
        /// URIs of the blobs to set the tiers of.
        /// </param>
        /// <param name="accessTier">
        /// Indicates the tier to be set on the blobs.
        /// </param>
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The <see cref="Response"/>s for the individual Set Tier operations.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure to submit the batch occurs.  Individual sub-operation
        /// failures will be wrapped in an <see cref="AggregateException"/>.
        /// </remarks>
        internal async Task<Response[]> SetBlobsAccessTierInteral(
            IEnumerable<Uri> blobUris,
            AccessTier accessTier,
            RehydratePriority? rehydratePriority,
            bool async,
            CancellationToken cancellationToken)
        {
            blobUris = blobUris ?? throw new ArgumentNullException(nameof(blobUris));
            var responses = new List<Response>();

            // Create the batch
            BlobBatch batch = CreateBatch();
            foreach (Uri uri in blobUris)
            {
                responses.Add(batch.SetBlobAccessTier(uri, accessTier, rehydratePriority));
            }

            // Submit the batch
            await SubmitBatchInternal(
                batch,
                true,
                async,
                cancellationToken)
                .ConfigureAwait(false);

            return responses.ToArray();
        }
        #endregion SetBlobsAccessTier
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobServiceClient"/> for
    /// creating <see cref="BlobBatchClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="BlobBatchClient"/> object for the same
        /// account as the <see cref="BlobServiceClient"/>.  The new
        /// <see cref="BlobBatchClient"/> uses the same request policy pipeline
        /// as the <see cref="BlobServiceClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobServiceClient"/>.</param>
        /// <returns>A new <see cref="BlobBatchClient"/> instance.</returns>
        public static BlobBatchClient GetBlobBatchClient(this BlobServiceClient client)
            => new BlobBatchClient(client);
    }
}
