// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        /// <summary>
        /// [Protocol Method] Gets the status of a queued ledger entry by Web Frontend Gateway operation id.
        /// Returned when a prior call to <see cref="PostLedgerEntry(WaitUntil, RequestContent, string, string, RequestContext)"/>
        /// or its async counterpart received a <c>202 Accepted</c> response.
        /// </summary>
        /// <remarks>
        /// Below is the JSON schema for the response body.
        ///
        /// Schema for the response:
        /// <code>{
        ///   operationId:   string,                # The Web Frontend operation id (UUID).
        ///   status:        "queued" | "committed" | "failed",
        ///   collectionId:  string,                # Present when status == "committed".
        ///   transactionId: string,                # Present when status == "committed".
        ///   error: {                              # Present when status == "failed".
        ///     code:    string,                    # e.g. "MaxRetriesExceeded".
        ///     message: string
        ///   }
        /// }
        /// </code>
        ///
        /// A <c>404</c> response with <c>error.code == "OperationNotFound"</c> indicates the operation
        /// status has been evicted after its 24-hour TTL elapsed. The underlying write may or may not have
        /// committed and the caller must reconcile out of band (for example via
        /// <see cref="GetLedgerEntries(string, string, string, string, RequestContext)"/>).
        /// </remarks>
        /// <param name="operationId"> The Web Frontend Gateway operation id returned on the <c>202 Accepted</c> response. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetOperationStatusAsync(string operationId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetOperationStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetOperationStatusRequest(operationId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of a queued ledger entry by Web Frontend Gateway operation id.
        /// Returned when a prior call to <see cref="PostLedgerEntry(WaitUntil, RequestContent, string, string, RequestContext)"/>
        /// or its async counterpart received a <c>202 Accepted</c> response.
        /// </summary>
        /// <remarks>
        /// See <see cref="GetOperationStatusAsync(string, RequestContext)"/> for the response body schema and
        /// the semantics of a <c>404 OperationNotFound</c> response.
        /// </remarks>
        /// <param name="operationId"> The Web Frontend Gateway operation id returned on the <c>202 Accepted</c> response. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetOperationStatus(string operationId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetOperationStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetOperationStatusRequest(operationId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reconstructs a <see cref="Operation"/> that represents a queued ledger entry previously
        /// initiated against the Confidential Ledger Web Frontend Gateway. Use this to resume polling
        /// for an operation whose id was persisted by the caller (typically after the original process
        /// has been restarted or when delegating completion to a different worker).
        /// </summary>
        /// <remarks>
        /// This call is local and performs no network I/O. The first invocation of
        /// <see cref="Operation.UpdateStatus(System.Threading.CancellationToken)"/> (or
        /// <see cref="Operation.WaitForCompletionResponse(System.Threading.CancellationToken)"/>)
        /// on the returned operation issues
        /// <c>GET /app/operations/{operationId}</c> against the gateway. While the operation is still
        /// queued, <see cref="Operation.Id"/> returns <paramref name="operationId"/>; once the gateway
        /// reports the operation as committed, <see cref="Operation.Id"/> flips to the CCF transaction id.
        /// <para>
        /// A queued operation may take a long time (up to 24 hours during an outage) to reach a terminal
        /// state. Callers are strongly encouraged to use a bounded
        /// <see cref="System.Threading.CancellationToken"/> when waiting for completion. A
        /// <c>404 OperationNotFound</c> response indicates the operation status has been evicted; the
        /// underlying write may or may not have committed and the caller must reconcile out of band.
        /// </para>
        /// </remarks>
        /// <param name="operationId"> The Web Frontend Gateway operation id previously returned on a <c>202 Accepted</c> response. </param>
        /// <param name="cancellationToken"> Reserved for future use; this call performs no I/O. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation RehydratePostLedgerEntryOperation(string operationId, System.Threading.CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));
            _ = cancellationToken; // Reserved; no network I/O is performed here.

            return new PostLedgerEntryOperation(this, operationId, PostLedgerEntryOperation.PollingMode.WebFrontend);
        }

        /// <summary>
        /// [Protocol Method] Gets the current depth of the Web Frontend Gateway write queue.
        /// Diagnostic endpoint; not intended for general application use.
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<Response> GetWriteQueueStatusAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetWriteQueueStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetWriteQueueStatusRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the current depth of the Web Frontend Gateway write queue.
        /// Diagnostic endpoint; not intended for general application use.
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response GetWriteQueueStatus(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetWriteQueueStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetWriteQueueStatusRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetOperationStatusRequest(string operationId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_ledgerEndpoint);
            uri.AppendPath("/app/operations/", false);
            uri.AppendPath(operationId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetWriteQueueStatusRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_ledgerEndpoint);
            uri.AppendPath("/app/queue/status", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200202;
        internal static ResponseClassifier ResponseClassifier200202 => _responseClassifier200202 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 202 });
    }
}
