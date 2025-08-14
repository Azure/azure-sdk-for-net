// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    internal class ConfidentialLedgerFailoverService
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });

        public ConfidentialLedgerFailoverService(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _clientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
        }
        // Overloads for failover-only execution with collectionId gating.
        public Task<T> ExecuteOnFailoversAsync<T>(
            Uri primaryEndpoint,
            Func<Uri, Task<T>> operationAsync,
            string operationName,
            string collectionIdGate,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(collectionIdGate))
            {
                return operationAsync(primaryEndpoint); // collection gating: no failover
            }
            return ExecuteOnFailoversAsync(primaryEndpoint, operationAsync, operationName, cancellationToken);
        }

        public T ExecuteOnFailovers<T>(
            Uri primaryEndpoint,
            Func<Uri, T> operationSync,
            string operationName,
            string collectionIdGate,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(collectionIdGate))
            {
                return operationSync(primaryEndpoint);
            }
            return ExecuteOnFailovers(primaryEndpoint, operationSync, operationName, cancellationToken);
        }

        private async Task<List<Uri>> GetFailoverEndpointsAsync(
            Uri primaryEndpoint,
            CancellationToken cancellationToken = default)
        {
            var failoverEndpoints = new List<Uri>();

            try
            {
                string ledgerId = primaryEndpoint.Host.Substring(0, primaryEndpoint.Host.IndexOf('.'));

                Uri failoverUrl = new Uri($"https://identity.confidential-ledger.core.azure.com/failover/{ledgerId}");

                using HttpMessage message = CreateFailoverRequest(failoverUrl);
                Response response = await _pipeline.ProcessMessageAsync(message, new RequestContext()).ConfigureAwait(false);

                if (response.Status == 200)
                {
                    using JsonDocument jsonDoc = JsonDocument.Parse(response.Content);
                    jsonDoc.RootElement.TryGetProperty("ledgerId", out _); // fire & forget
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
                            catch (Exception)
                            {
                                // ignore element issues
                            }

                            if (!string.IsNullOrEmpty(failoverLedgerId))
                            {
                                Uri endpoint = new UriBuilder(primaryEndpoint) { Host = $"{failoverLedgerId}.confidential-ledger.azure.com" }.Uri;
                                failoverEndpoints.Add(endpoint);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // suppress metadata retrieval exception
            }

            return failoverEndpoints;
        }

        private List<Uri> GetFailoverEndpoints(
            Uri primaryEndpoint,
            CancellationToken cancellationToken = default)
        {
            var failoverEndpoints = new List<Uri>();

            try
            {
                // retrieving sync metadata
                string ledgerId = primaryEndpoint.Host.Substring(0, primaryEndpoint.Host.IndexOf('.'));

                Uri failoverUrl = new Uri($"https://identity.confidential-ledger.core.azure.com/failover/{ledgerId}");

                using HttpMessage message = CreateFailoverRequest(failoverUrl);
                Response response = _pipeline.ProcessMessage(message, new RequestContext());

                if (response.Status == 200)
                {
                    using JsonDocument jsonDoc = JsonDocument.Parse(response.Content);
                    jsonDoc.RootElement.TryGetProperty("ledgerId", out _);
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
                            catch (Exception)
                            {
                                // ignore element issues
                            }

                            if (!string.IsNullOrEmpty(failoverLedgerId))
                            {
                                Uri endpoint = new UriBuilder(primaryEndpoint) { Host = $"{failoverLedgerId}.confidential-ledger.azure.com" }.Uri;
                                failoverEndpoints.Add(endpoint);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // suppress metadata retrieval exception
            }

            return failoverEndpoints;
        }

        private HttpMessage CreateFailoverRequest(Uri failoverUrl)
        {
            HttpMessage message = _pipeline.CreateMessage(new RequestContext(), ResponseClassifier200);
            Request request = message.Request;

            request.Method = RequestMethod.Get;

            var uri = new RawRequestUriBuilder();
            uri.Reset(failoverUrl);
            request.Uri = uri;

            request.Headers.Add("Accept", "application/json");

            return message;
        }

        private static bool IsRetriableFailure(RequestFailedException ex)
        {
            // Include 404 and specific UnknownLedgerEntry error code.
            return ex.Status == 404 ||
                   string.Equals(ex.ErrorCode, "UnknownLedgerEntry", StringComparison.OrdinalIgnoreCase) ||
                   ex.Status >= 500 ||
                   ex.Status == 408 ||
                   ex.Status == 429 ||
                   ex.Status == 503 ||
                   ex.Status == 504;
        }

        // Execute an operation only against discovered failover endpoints (skips primary). Used for specialized fallback flows.
        public async Task<T> ExecuteOnFailoversAsync<T>(
            Uri primaryEndpoint,
            Func<Uri, Task<T>> operationAsync,
            string operationName,
            CancellationToken cancellationToken = default)
        {
            List<Uri> endpoints = await GetFailoverEndpointsAsync(primaryEndpoint, cancellationToken).ConfigureAwait(false);
            Exception last = null;
            foreach (var ep in endpoints)
            {
                // attempt endpoint
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return await operationAsync(ep).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (IsRetriableFailure(ex))
                {
                    // endpoint failed, continue
                    last = ex;
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }
            }
            throw last ?? new RequestFailedException("All failover endpoints failed in failovers mode");
        }

        public T ExecuteOnFailovers<T>(
            Uri primaryEndpoint,
            Func<Uri, T> operationSync,
            string operationName,
            CancellationToken cancellationToken = default)
        {
            List<Uri> endpoints = GetFailoverEndpoints(primaryEndpoint, cancellationToken);
            Exception last = null;
            foreach (var ep in endpoints)
            {
                // attempt endpoint
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return operationSync(ep);
                }
                catch (RequestFailedException ex) when (IsRetriableFailure(ex))
                {
                    // endpoint failed
                    last = ex;
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }
            }
            throw last ?? new RequestFailedException("All failover endpoints failed in failovers mode");
        }
    }
}
