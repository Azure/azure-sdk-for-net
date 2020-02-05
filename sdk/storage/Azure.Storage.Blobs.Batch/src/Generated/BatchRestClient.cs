// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file was automatically generated.  Do not edit.

#pragma warning disable IDE0016 // Null check can be simplified
#pragma warning disable IDE0017 // Variable declaration can be inlined
#pragma warning disable IDE0018 // Object initialization can be simplified
#pragma warning disable SA1402  // File may only contain a single type

#region Service
namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Azure Blob Storage
    /// </summary>
    internal static partial class BatchRestClient
    {
        #region Service operations
        /// <summary>
        /// Service operations for Azure Blob Storage
        /// </summary>
        public static partial class Service
        {
            #region Service.SubmitBatchAsync
            /// <summary>
            /// The Batch operation allows multiple API calls to be embedded into a single HTTP request.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="multipartContentType">Required. The value of this header must be multipart/mixed with a batch boundary. Example header value: multipart/mixed; boundary=batch_{GUID}</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobBatchResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Blobs.Models.BlobBatchResult>> SubmitBatchAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                long contentLength,
                string multipartContentType,
                string version,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "ServiceClient.SubmitBatch",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SubmitBatchAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        body,
                        contentLength,
                        multipartContentType,
                        version,
                        timeout,
                        requestId))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return SubmitBatchAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Service.SubmitBatchAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="multipartContentType">Required. The value of this header must be multipart/mixed with a batch boundary. Example header value: multipart/mixed; boundary=batch_{GUID}</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.SubmitBatchAsync Message.</returns>
            internal static Azure.Core.HttpMessage SubmitBatchAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                long contentLength,
                string multipartContentType,
                string version,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (body == null)
                {
                    throw new System.ArgumentNullException(nameof(body));
                }
                if (multipartContentType == null)
                {
                    throw new System.ArgumentNullException(nameof(multipartContentType));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Post;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("comp", "batch", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("Content-Type", multipartContentType);
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                _request.Content = Azure.Core.RequestContent.Create(body);

                return _message;
            }

            /// <summary>
            /// Create the Service.SubmitBatchAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.SubmitBatchAsync Azure.Response{Azure.Storage.Blobs.Models.BlobBatchResult}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobBatchResult> SubmitBatchAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobBatchResult _value = new Azure.Storage.Blobs.Models.BlobBatchResult();
                        _value.Content = response.ContentStream; // You should manually wrap with RetriableStream!

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Service.SubmitBatchAsync
        }
        #endregion Service operations

        #region Blob operations
        /// <summary>
        /// Blob operations for Azure Blob Storage
        /// </summary>
        public static partial class Blob
        {
            #region Blob.SetAccessTierAsync
            /// <summary>
            /// The Set Tier operation sets the tier on a blob. The operation is allowed on a page blob in a premium storage account and on a block blob in a blob storage account (locally redundant storage only). A premium page blob's tier determines the allowed size, IOPS, and bandwidth of the blob. A block blob's tier determines Hot/Cool/Archive storage type. This operation does not update the blob's ETag.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="tier">Indicates the tier to be set on the blob.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="rehydratePriority">Optional: Indicates the priority with which to rehydrate an archived blob.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> SetAccessTierAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.AccessTier tier,
                string version,
                int? timeout = default,
                Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default,
                string requestId = default,
                string leaseId = default,
                bool async = true,
                string operationName = "BlobClient.SetAccessTier",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SetAccessTierAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        tier,
                        version,
                        timeout,
                        rehydratePriority,
                        requestId,
                        leaseId))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetAccessTierAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.SetAccessTierAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="tier">Indicates the tier to be set on the blob.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="rehydratePriority">Optional: Indicates the priority with which to rehydrate an archived blob.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Blob.SetAccessTierAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetAccessTierAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.AccessTier tier,
                string version,
                int? timeout = default,
                Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default,
                string requestId = default,
                string leaseId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("comp", "tier", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-access-tier", tier.ToString());
                _request.Headers.SetValue("x-ms-version", version);
                if (rehydratePriority != null) { _request.Headers.SetValue("x-ms-rehydrate-priority", rehydratePriority.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the Blob.SetAccessTierAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.SetAccessTierAsync Azure.Response.</returns>
            internal static Azure.Response SetAccessTierAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Blob.SetAccessTierAsync

            #region Blob.DeleteAsync
            /// <summary>
            /// If the storage account's soft delete feature is disabled then, when a blob is deleted, it is permanently removed from the storage account. If the storage account's soft delete feature is enabled, then, when a blob is deleted, it is marked for deletion and becomes inaccessible immediately. However, the blob service retains the blob or snapshot for the number of days specified by the DeleteRetentionPolicy section of [Storage service properties] (Set-Blob-Service-Properties.md). After the specified number of days has passed, the blob's data is permanently removed from the storage account. Note that you continue to be charged for the soft-deleted blob's storage until it is permanently removed. Use the List Blobs API and specify the "include=deleted" query parameter to discover which blobs and snapshots have been soft deleted. You can then use the Undelete Blob API to restore a soft-deleted blob. All other operations on a soft-deleted blob or snapshot causes the service to return an HTTP status code of 404 (ResourceNotFound).
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="deleteSnapshots">Required if the blob has associated snapshots. Specify one of the following two options: include: Delete the base blob and all of its snapshots. only: Delete only the blob's snapshots and not the blob itself</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                Azure.Storage.Blobs.Models.DeleteSnapshotsOption? deleteSnapshots = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "BlobClient.Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = DeleteAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        snapshot,
                        timeout,
                        leaseId,
                        deleteSnapshots,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return DeleteAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="deleteSnapshots">Required if the blob has associated snapshots. Specify one of the following two options: include: Delete the base blob and all of its snapshots. only: Delete only the blob's snapshots and not the blob itself</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.DeleteAsync Message.</returns>
            internal static Azure.Core.HttpMessage DeleteAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                Azure.Storage.Blobs.Models.DeleteSnapshotsOption? deleteSnapshots = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Delete;
                _request.Uri.Reset(resourceUri);
                if (snapshot != null) { _request.Uri.AppendQuery("snapshot", snapshot); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (deleteSnapshots != null) { _request.Headers.SetValue("x-ms-delete-snapshots", Azure.Storage.Blobs.BatchRestClient.Serialization.ToString(deleteSnapshots.Value)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Blob.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Blob.DeleteAsync
        }
        #endregion Blob operations
    }
}
#endregion Service

#region Models

#region class BlobBatchResult
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobBatchResult
    /// </summary>
    internal partial class BlobBatchResult
    {
        /// <summary>
        /// The media type of the body of the response. For batch requests, this is multipart/mixed; boundary=batchresponse_GUID
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// Content
        /// </summary>
        public System.IO.Stream Content { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of BlobBatchResult instances.
        /// You can use BlobsModelFactory.BlobBatchResult instead.
        /// </summary>
        internal BlobBatchResult() { }
    }
}
#endregion class BlobBatchResult

#region enum DeleteSnapshotsOption

namespace Azure.Storage.Blobs
{
    internal static partial class BatchRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.DeleteSnapshotsOption value)
            {
                return value switch
                {
                    Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None => null,
                    Azure.Storage.Blobs.Models.DeleteSnapshotsOption.IncludeSnapshots => "include",
                    Azure.Storage.Blobs.Models.DeleteSnapshotsOption.OnlySnapshots => "only",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.DeleteSnapshotsOption value.")
                };
            }

            public static Azure.Storage.Blobs.Models.DeleteSnapshotsOption ParseDeleteSnapshotsOption(string value)
            {
                return value switch
                {
                    null => Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None,
                    "include" => Azure.Storage.Blobs.Models.DeleteSnapshotsOption.IncludeSnapshots,
                    "only" => Azure.Storage.Blobs.Models.DeleteSnapshotsOption.OnlySnapshots,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.DeleteSnapshotsOption value.")
                };
            }
        }
    }
}
#endregion enum DeleteSnapshotsOption

#region enum RehydratePriority
#endregion enum RehydratePriority

#region class StorageError
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// StorageError
    /// </summary>
    internal partial class StorageError
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of StorageError instances.
        /// You can use BlobsModelFactory.StorageError instead.
        /// </summary>
        internal StorageError() { }

        /// <summary>
        /// Deserializes XML into a new StorageError instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized StorageError instance.</returns>
        internal static Azure.Storage.Blobs.Models.StorageError FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.StorageError _value = new Azure.Storage.Blobs.Models.StorageError();
            _child = element.Element(System.Xml.Linq.XName.Get("Message", ""));
            if (_child != null)
            {
                _value.Message = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Code", ""));
            if (_child != null)
            {
                _value.Code = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.StorageError value);
    }
}
#endregion class StorageError
#endregion Models

