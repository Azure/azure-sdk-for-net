// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// Discovers a ledger's failover endpoints from the identity service and ensures their identity TLS
    /// certificates are trusted by the client transport. The actual failover requests are issued by
    /// <see cref="FailoverPolicy"/>; this service only provides endpoint discovery and certificate trust.
    /// </summary>
    internal class ConfidentialLedgerFailoverService
    {
        // Discovery uses a dedicated pipeline with normal TLS validation rather than the ledger pipeline:
        // the identity service presents a publicly-trusted certificate (not a ledger identity certificate),
        // and routing discovery through the (failover-enabled) ledger pipeline would also be re-entrant.
        private readonly HttpPipeline _discoveryPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        // The identity service used to discover failover ledgers. Honors a custom
        // ConfidentialLedgerClientOptions.CertificateEndpoint when one is configured, falling back to
        // the default identity service endpoint otherwise.
        private readonly Uri _identityServiceEndpoint;

        private readonly ConfidentialLedgerCertificateTrustStore _trustStore;
        private readonly Func<Uri, X509Certificate2> _identityCertResolver;
        private readonly ConfidentialLedgerClientOptions.FailoverSelection _selection;
        private readonly Random _random = new Random();

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });

        public ConfidentialLedgerFailoverService(
            HttpPipeline discoveryPipeline,
            ClientDiagnostics clientDiagnostics,
            Uri identityServiceEndpoint,
            ConfidentialLedgerCertificateTrustStore trustStore,
            Func<Uri, X509Certificate2> identityCertResolver,
            ConfidentialLedgerClientOptions.FailoverSelection selection)
        {
            _discoveryPipeline = discoveryPipeline ?? throw new ArgumentNullException(nameof(discoveryPipeline));
            _clientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _identityServiceEndpoint = identityServiceEndpoint ?? new Uri(ConfidentialLedgerClient.Default_Certificate_Endpoint);
            _trustStore = trustStore ?? throw new ArgumentNullException(nameof(trustStore));
            _identityCertResolver = identityCertResolver ?? throw new ArgumentNullException(nameof(identityCertResolver));
            _selection = selection;
        }

        /// <summary>
        /// Registers the failover ledger's identity TLS certificate with the shared trust store so that
        /// the transport will accept its TLS connection. No-op when the certificate is already trusted.
        /// </summary>
        public void EnsureEndpointTrusted(Uri endpoint)
        {
            string ledgerId = GetLedgerId(endpoint);
            if (string.IsNullOrEmpty(ledgerId) || _trustStore.IsTrusted(ledgerId))
            {
                return;
            }

            X509Certificate2 cert = _identityCertResolver(endpoint);
            _trustStore.Trust(ledgerId, cert);
        }

        public async Task<List<Uri>> GetFailoverEndpointsAsync(Uri primaryEndpoint)
        {
            try
            {
                using HttpMessage message = CreateFailoverRequest(BuildFailoverUrl(primaryEndpoint));
                Response response = await _discoveryPipeline.ProcessMessageAsync(message, new RequestContext()).ConfigureAwait(false);
                return OrderEndpoints(ParseFailoverEndpoints(primaryEndpoint, response));
            }
            catch (Exception)
            {
                // suppress metadata retrieval exception
            }
            return new List<Uri>();
        }

        public List<Uri> GetFailoverEndpoints(Uri primaryEndpoint)
        {
            try
            {
                using HttpMessage message = CreateFailoverRequest(BuildFailoverUrl(primaryEndpoint));
                Response response = _discoveryPipeline.ProcessMessage(message, new RequestContext());
                return OrderEndpoints(ParseFailoverEndpoints(primaryEndpoint, response));
            }
            catch (Exception)
            {
                // suppress metadata retrieval exception
            }
            return new List<Uri>();
        }

        private Uri BuildFailoverUrl(Uri primaryEndpoint)
        {
            string ledgerId = GetLedgerId(primaryEndpoint);
            return new Uri(_identityServiceEndpoint, $"/failover/{ledgerId}");
        }

        private static string GetLedgerId(Uri endpoint)
        {
            string host = endpoint.Host;
            int dotIndex = host.IndexOf('.');
            return dotIndex > 0 ? host.Substring(0, dotIndex) : host;
        }

        // Returns the candidate endpoints either in the order reported by the identity service (priority
        // ordered) or randomly shuffled to spread load across failover ledgers, per client configuration.
        private List<Uri> OrderEndpoints(List<Uri> endpoints)
        {
            if (_selection != ConfidentialLedgerClientOptions.FailoverSelection.Random || endpoints.Count < 2)
            {
                return endpoints;
            }

            // Fisher-Yates shuffle.
            for (int i = endpoints.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                Uri tmp = endpoints[i];
                endpoints[i] = endpoints[j];
                endpoints[j] = tmp;
            }
            return endpoints;
        }

        private static List<Uri> ParseFailoverEndpoints(Uri primaryEndpoint, Response response)
        {
            var endpoints = new List<Uri>();
            if (response?.Status != 200)
            {
                return endpoints;
            }
            try
            {
                using JsonDocument jsonDoc = JsonDocument.Parse(response.Content);
                jsonDoc.RootElement.TryGetProperty("ledgerId", out _); // optional
                if (jsonDoc.RootElement.TryGetProperty("failoverLedgers", out JsonElement failoverArray))
                {
                    foreach (JsonElement failoverLedger in failoverArray.EnumerateArray())
                    {
                        string failoverLedgerId = null;
                        try
                        {
                            switch (failoverLedger.ValueKind)
                            {
                                case JsonValueKind.String:
                                    failoverLedgerId = failoverLedger.GetString();
                                    break;
                                case JsonValueKind.Object:
                                    if (failoverLedger.TryGetProperty("name", out JsonElement nameProp) && nameProp.ValueKind == JsonValueKind.String)
                                    {
                                        failoverLedgerId = nameProp.GetString();
                                    }
                                    else
                                    {
                                        foreach (JsonProperty prop in failoverLedger.EnumerateObject())
                                        {
                                            if (prop.Value.ValueKind == JsonValueKind.String && string.Equals(prop.Name, "id", StringComparison.OrdinalIgnoreCase))
                                            {
                                                failoverLedgerId = prop.Value.GetString();
                                                break;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        catch (JsonException)
                        {
                            // Ignore a malformed individual failover ledger element and continue.
                        }
                        catch (InvalidOperationException)
                        {
                            // Ignore an unexpected JSON value-kind for an element and continue.
                        }

                        if (!string.IsNullOrEmpty(failoverLedgerId))
                        {
                            string primaryHost = primaryEndpoint.Host;
                            int dotIndex = primaryHost.IndexOf('.');
                            if (dotIndex > 0)
                            {
                                string hostSuffix = primaryHost.Substring(dotIndex);
                                Uri endpoint = new UriBuilder(primaryEndpoint) { Host = $"{failoverLedgerId}{hostSuffix}" }.Uri;
                                endpoints.Add(endpoint);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // ignore entire parse failure
            }
            return endpoints;
        }

        private HttpMessage CreateFailoverRequest(Uri failoverUrl)
        {
            HttpMessage message = _discoveryPipeline.CreateMessage(new RequestContext(), ResponseClassifier200);
            Request request = message.Request;

            request.Method = RequestMethod.Get;

            var uri = new RawRequestUriBuilder();
            uri.Reset(failoverUrl);
            request.Uri = uri;

            request.Headers.Add("Accept", "application/json");

            return message;
        }
    }
}
