// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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

        private readonly ConfidentialLedgerFailoverService _failoverService;
        private readonly TimeSpan? _failoverNetworkTimeout;

        internal static void MarkEligible(HttpMessage message) =>
            message.SetProperty(typeof(FailoverEligibleKey), true);

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

            // Only the supported ledger-entry reads are explicitly marked for failover. Other GETs,
            // including governance, receipt, status, and pageable operations, stay on the primary.
            if (message.Request.Method != RequestMethod.Get || !IsEligible(message) ||
                (primaryException == null && !ShouldFailover(message.Response)))
            {
                return;
            }

            // Preserve the primary response so the original error can be restored if every failover fails.
            Response primaryResponse = message.HasResponse ? message.Response : null;

            List<Uri> failoverEndpoints = async
                ? await _failoverService.GetFailoverEndpointsAsync(primaryEndpoint, message.CancellationToken).ConfigureAwait(false)
                : _failoverService.GetFailoverEndpoints(primaryEndpoint, message.CancellationToken);

            foreach (Uri endpoint in failoverEndpoints)
            {
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

                if (!ShouldFailover(message.Response))
                {
                    // This failover endpoint produced a usable response.
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

        // Transient conditions that warrant trying the next endpoint. A 404 means the resource does not
        // exist (its replicas would report the same), so it is intentionally not failed over.
        private static bool ShouldFailover(Response response) =>
            response != null && (response.Status == 408 || response.Status == 429 || response.Status >= 500);

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
