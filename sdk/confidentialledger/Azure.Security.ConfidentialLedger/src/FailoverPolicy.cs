// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// Pipeline policy that transparently retries a failed read against the ledger's failover endpoints.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The policy sits in the per-call position, so each endpoint attempt runs underneath the normal
    /// retry pipeline. When the primary attempt completes with a transient failure (408/429/5xx), the
    /// policy discovers the configured failover ledgers from the identity service and re-issues the same
    /// request against each one in turn until a non-transient response is obtained or the candidates are
    /// exhausted. If every failover also fails transiently, the original primary response is restored so
    /// the caller observes the primary error.
    /// </para>
    /// <para>
    /// With an explicit nonempty collection id, a 404 also permits failover and traversal. A primary
    /// historical-read 404 uses the legacy collection-based current-entry lookup on failovers, returning
    /// that entry with state Ready and preserving its actual transaction id rather than the requested id.
    /// </para>
    /// <para>
    /// Only the explicitly marked <c>GetLedgerEntry</c> and <c>GetCurrentLedgerEntry</c> requests are
    /// failed over; every other request stays on the primary ledger.
    /// Each failover ledger is a distinct CCF network with its own identity TLS certificate, so before a
    /// request is sent the failover ledger's certificate is registered with the shared certificate trust
    /// store (see <see cref="ConfidentialLedgerCertificateTrustStore"/>); endpoints whose certificate
    /// cannot be established are skipped.
    /// </para>
    /// </remarks>
    internal sealed class FailoverPolicy : HttpPipelinePolicy
    {
        private sealed class FailoverEligibleKey
        {
        }

        private sealed class CollectionFallbackKey
        {
        }

        private readonly ConfidentialLedgerFailoverService _failoverService;
        private readonly TimeSpan? _failoverNetworkTimeout;

        internal static void MarkEligible(HttpMessage message, string collectionId)
        {
            message.SetProperty(typeof(FailoverEligibleKey), true);
            message.SetProperty(typeof(CollectionFallbackKey), !string.IsNullOrEmpty(collectionId));
        }

        private static bool IsEligible(HttpMessage message) =>
            message.TryGetProperty(typeof(FailoverEligibleKey), out object value) &&
            value is bool eligible && eligible;

        public FailoverPolicy(ConfidentialLedgerFailoverService failoverService, TimeSpan? failoverNetworkTimeout)
        {
            _failoverService = failoverService ?? throw new ArgumentNullException(nameof(failoverService));
            _failoverNetworkTimeout = failoverNetworkTimeout;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline) =>
            ProcessAsync(message, pipeline, async: false).EnsureCompleted();

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline) =>
            ProcessAsync(message, pipeline, async: true);

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            // Only explicitly marked ledger-entry reads may fail over. For all other requests,
            // preserve the normal pipeline response or exception without intercepting transport failures.
            if (message.Request.Method != RequestMethod.Get || !IsEligible(message))
            {
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }

                return;
            }

            // Capture the primary endpoint before the request is mutated.
            Uri primaryEndpoint = message.Request.Uri.ToUri();

            ExceptionDispatchInfo primaryException = null;
            try
            {
                // Primary attempt (the rest of the pipeline, including the retry policy, runs below this point).
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
            }
            catch (Exception exception) when (IsRetryableTransportException(message, exception))
            {
                primaryException = ExceptionDispatchInfo.Capture(exception);
            }

            bool collectionFallback = message.TryGetProperty(typeof(CollectionFallbackKey), out object value) && value is true;
            if (primaryException == null && !ShouldFailover(message.Response, collectionFallback))
            {
                return;
            }

            // Preserve the primary response so the original error can be restored if every failover fails.
            Response primaryResponse = message.HasResponse ? message.Response : null;
            // Transaction ids are local to a CCF network. Restore the legacy collection-based lookup
            // only after a primary 404, not for transient failures of an otherwise historical read.
            bool useCurrentEntry = primaryException == null && primaryResponse?.Status == 404 &&
                !primaryEndpoint.AbsolutePath.EndsWith("/current", StringComparison.Ordinal);

            message.CancellationToken.ThrowIfCancellationRequested();
            List<Uri> failoverEndpoints = async
                ? await _failoverService.GetFailoverEndpointsAsync(primaryEndpoint, message.CancellationToken).ConfigureAwait(false)
                : _failoverService.GetFailoverEndpoints(primaryEndpoint, message.CancellationToken);
            message.CancellationToken.ThrowIfCancellationRequested();

            foreach (Uri endpoint in failoverEndpoints)
            {
                message.CancellationToken.ThrowIfCancellationRequested();
                HttpPipeline endpointPipeline;
                try
                {
                    endpointPipeline = _failoverService.GetEndpointPipeline(endpoint);
                }
                catch (Exception) when (!message.CancellationToken.IsCancellationRequested)
                {
                    // Could not establish trust for this endpoint (e.g. identity lookup failed); skip it.
                    continue;
                }

                RewriteRequestEndpoint(message.Request, endpoint);
                if (useCurrentEntry)
                {
                    var current = new UriBuilder(message.Request.Uri.ToUri());
                    current.Path = current.Path.Substring(0, current.Path.LastIndexOf('/') + 1) + "current";
                    message.Request.Uri.Reset(current.Uri);
                }
                message.Response = null;
                MessageProcessingContext processingContext = message.ProcessingContext;
                processingContext.RetryNumber = 0;

                // Give each failover attempt its own network timeout when one is configured, so that time
                // spent on the (already failed) primary does not eat into the failover budget.
                if (_failoverNetworkTimeout.HasValue)
                {
                    message.NetworkTimeout = _failoverNetworkTimeout;
                }

                try
                {
                    if (async)
                    {
                        await endpointPipeline.SendAsync(message, message.CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        endpointPipeline.Send(message, message.CancellationToken);
                    }
                }
                catch (Exception exception) when (IsRetryableTransportException(message, exception))
                {
                    continue;
                }

                message.CancellationToken.ThrowIfCancellationRequested();
                if (!ShouldFailover(message.Response, collectionFallback))
                {
                    // This failover endpoint produced a usable response.
                    if (useCurrentEntry && message.Response.Status == 200)
                    {
                        message.Response = new CurrentEntryResponse(message.Response);
                    }
                    primaryResponse?.Dispose();
                    return;
                }

                // Transient failure on this endpoint too; discard its response and try the next one.
                message.Response?.Dispose();
            }

            // No failover endpoint produced a usable response: surface the original primary error.
            message.Response = primaryResponse;
            primaryException?.Throw();
        }

        private static bool IsRetryableTransportException(HttpMessage message, Exception exception)
        {
            if (message.CancellationToken.IsCancellationRequested)
            {
                return false;
            }
            if (exception is AggregateException aggregate)
            {
                return aggregate.InnerExceptions.Count > 0 &&
                    aggregate.InnerExceptions.All(inner => IsRetryableTransportException(message, inner));
            }
            return message.ResponseClassifier.IsRetriable(message, exception);
        }

        // A collection can exist on a different CCF network even when this ledger returns 404.
        private static bool ShouldFailover(Response response, bool collectionFallback) =>
            response != null && (response.Status == 408 || response.Status == 429 || response.Status >= 500 ||
                (collectionFallback && response.Status == 404));

        // Preserve the whole entry (including tags and its actual transaction id), plus response
        // metadata. Only the body and its length change to match the historical-read response shape.
        private sealed class CurrentEntryResponse : Response
        {
            private readonly Response _original;
            private Stream _content;
            private readonly string _contentLength;

            public CurrentEntryResponse(Response original)
            {
                _original = original;
                using JsonDocument document = JsonDocument.Parse(original.Content);
                var stream = new MemoryStream();
                using (var writer = new Utf8JsonWriter(stream))
                {
                    writer.WriteStartObject();
                    writer.WriteString("state", "Ready");
                    writer.WritePropertyName("entry");
                    document.RootElement.WriteTo(writer);
                    writer.WriteEndObject();
                }
                stream.Position = 0;
                _content = stream;
                _contentLength = stream.Length.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }

            public override int Status => _original.Status;
            public override string ReasonPhrase => _original.ReasonPhrase;
            public override string ClientRequestId { get => _original.ClientRequestId; set => _original.ClientRequestId = value; }
            public override Stream ContentStream { get => _content; set => _content = value; }
            public override void Dispose()
            {
                _content?.Dispose();
                _original.Dispose();
            }
            protected override bool ContainsHeader(string name) =>
                string.Equals(name, "Content-Length", StringComparison.OrdinalIgnoreCase) || _original.Headers.Contains(name);
            protected override bool TryGetHeader(string name, out string value)
            {
                if (string.Equals(name, "Content-Length", StringComparison.OrdinalIgnoreCase))
                {
                    value = _contentLength;
                    return true;
                }
                return _original.Headers.TryGetValue(name, out value);
            }
            protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            {
                if (string.Equals(name, "Content-Length", StringComparison.OrdinalIgnoreCase))
                {
                    values = new[] { _contentLength };
                    return true;
                }
                return _original.Headers.TryGetValues(name, out values);
            }
            protected override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                foreach (HttpHeader header in _original.Headers)
                {
                    if (!string.Equals(header.Name, "Content-Length", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return header;
                    }
                }
                yield return new HttpHeader("Content-Length", _contentLength);
            }
        }

        private static void RewriteRequestEndpoint(Request request, Uri endpoint)
        {
            Uri current = request.Uri.ToUri();
            var rebuilt = new UriBuilder(current)
            {
                Scheme = endpoint.Scheme,
                Host = endpoint.Host,
                Port = endpoint.IsDefaultPort ? -1 : endpoint.Port,
            };
            request.Uri.Reset(rebuilt.Uri);
        }
    }
}
