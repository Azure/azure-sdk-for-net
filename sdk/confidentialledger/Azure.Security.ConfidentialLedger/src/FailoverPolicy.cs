// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
    /// Only idempotent read requests (HTTP GET) are failed over; writes always stay on the primary ledger.
    /// Each failover ledger is a distinct CCF network with its own identity TLS certificate, so before a
    /// request is sent the failover ledger's certificate is registered with the shared certificate trust
    /// store (see <see cref="ConfidentialLedgerCertificateTrustStore"/>); endpoints whose certificate
    /// cannot be established are skipped.
    /// </para>
    /// </remarks>
    internal sealed class FailoverPolicy : HttpPipelinePolicy
    {
        private readonly ConfidentialLedgerFailoverService _failoverService;
        private readonly TimeSpan? _failoverNetworkTimeout;

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

            // Primary attempt (the rest of the pipeline, including the retry policy, runs below this point).
            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            // Only fail over idempotent reads; writes must remain on the primary ledger.
            if (message.Request.Method != RequestMethod.Get || !ShouldFailover(message.Response))
            {
                return;
            }

            // Preserve the primary response so the original error can be restored if every failover fails.
            Response primaryResponse = message.Response;

            List<Uri> failoverEndpoints = async
                ? await _failoverService.GetFailoverEndpointsAsync(primaryEndpoint).ConfigureAwait(false)
                : _failoverService.GetFailoverEndpoints(primaryEndpoint);

            foreach (Uri endpoint in failoverEndpoints)
            {
                // A failover ledger has its own identity TLS certificate; make sure the transport trusts it.
                try
                {
                    _failoverService.EnsureEndpointTrusted(endpoint);
                }
                catch
                {
                    // Could not establish trust for this endpoint (e.g. identity lookup failed); skip it.
                    continue;
                }

                RewriteRequestEndpoint(message.Request, endpoint);

                // Give each failover attempt its own network timeout when one is configured, so that time
                // spent on the (already failed) primary does not eat into the failover budget.
                if (_failoverNetworkTimeout.HasValue)
                {
                    message.NetworkTimeout = _failoverNetworkTimeout;
                }

                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
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
