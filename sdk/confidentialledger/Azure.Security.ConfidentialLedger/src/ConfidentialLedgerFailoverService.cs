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

        public async Task<T> ExecuteWithFailoverAsync<T>(
            Uri primaryEndpoint,
            Func<Uri, Task<T>> operationAsync,
            string operationName,
            CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"ConfidentialLedgerClient.{operationName}");
            scope.Start();

            Exception lastException = null;

            try
            {
                Console.WriteLine($"[Failover] Primary attempt for {operationName} at {primaryEndpoint}");
                cancellationToken.ThrowIfCancellationRequested();
                return await operationAsync(primaryEndpoint).ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (IsRetriableFailure(ex))
            {
                Console.WriteLine($"[Failover] Primary failed (Status {ex.Status}, ErrorCode '{ex.ErrorCode}'). Will attempt failover.");
                lastException = ex;
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                Console.WriteLine("[Failover] Primary attempt timeout. Will attempt failover.");
                lastException = ex;
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                throw;
            }

            Console.WriteLine("[Failover] Discovering failover endpoints (async)...");
            List<Uri> failoverEndpoints = await GetFailoverEndpointsAsync(primaryEndpoint, cancellationToken).ConfigureAwait(false);
            Console.WriteLine($"[Failover] Found {failoverEndpoints.Count} failover endpoint(s).");

            foreach (Uri endpoint in failoverEndpoints)
            {
                Console.WriteLine($"[Failover] Attempting {operationName} on {endpoint}");
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return await operationAsync(endpoint).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (IsRetriableFailure(ex))
                {
                    Console.WriteLine($"[Failover] Endpoint {endpoint} failed (Status {ex.Status}, ErrorCode '{ex.ErrorCode}'). Trying next.");
                    lastException = ex;
                }
                catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
                {
                    Console.WriteLine($"[Failover] Endpoint {endpoint} timeout. Trying next.");
                    lastException = ex;
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }
            }

            scope.Failed(lastException);
            throw lastException ?? new RequestFailedException("All endpoints failed");
        }

        public T ExecuteWithFailover<T>(
            Uri primaryEndpoint,
            Func<Uri, T> operationSync,
            string operationName,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Executing operation {operationName} on primary endpoint: {primaryEndpoint}");
            using var scope = _clientDiagnostics.CreateScope($"ConfidentialLedgerClient.{operationName}");
            scope.Start();

            Exception lastException = null;

            try
            {
                Console.WriteLine($"[Failover] Primary attempt for {operationName} at {primaryEndpoint}");
                cancellationToken.ThrowIfCancellationRequested();
                return operationSync(primaryEndpoint);
            }
            catch (RequestFailedException ex) when (IsRetriableFailure(ex))
            {
                Console.WriteLine($"[Failover] Primary failed (Status {ex.Status}, ErrorCode '{ex.ErrorCode}'). Will attempt failover.");
                lastException = ex;
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                throw;
            }

            Console.WriteLine("[Failover] Discovering failover endpoints (sync)...");
            List<Uri> failoverEndpoints = GetFailoverEndpoints(primaryEndpoint, cancellationToken);
            Console.WriteLine($"[Failover] Found {failoverEndpoints.Count} failover endpoint(s).");

            foreach (Uri endpoint in failoverEndpoints)
            {
                try
                {
                    Console.WriteLine($"[Failover] Attempting {operationName} on {endpoint}");
                    cancellationToken.ThrowIfCancellationRequested();
                    return operationSync(endpoint);
                }
                catch (RequestFailedException ex) when (IsRetriableFailure(ex))
                {
                    Console.WriteLine($"[Failover] Endpoint {endpoint} failed (Status {ex.Status}, ErrorCode '{ex.ErrorCode}'). Trying next.");
                    lastException = ex;
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }
            }

            scope.Failed(lastException);
            throw lastException ?? new RequestFailedException("All endpoints failed");
        }

        // Overloads with collectionId gating: if collectionId is null/empty, skip failover entirely.
        public Task<T> ExecuteWithFailoverAsync<T>(
            Uri primaryEndpoint,
            Func<Uri, Task<T>> operationAsync,
            string operationName,
            string collectionIdGate,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(collectionIdGate))
            {
                Console.WriteLine($"[Failover] collectionId not provided; skipping failover for {operationName} and using primary endpoint {primaryEndpoint}");
                return operationAsync(primaryEndpoint);
            }
            return ExecuteWithFailoverAsync(primaryEndpoint, operationAsync, operationName, cancellationToken);
        }

        public T ExecuteWithFailover<T>(
            Uri primaryEndpoint,
            Func<Uri, T> operationSync,
            string operationName,
            string collectionIdGate,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(collectionIdGate))
            {
                Console.WriteLine($"[Failover] collectionId not provided; skipping failover for {operationName} and using primary endpoint {primaryEndpoint}");
                return operationSync(primaryEndpoint);
            }
            return ExecuteWithFailover(primaryEndpoint, operationSync, operationName, cancellationToken);
        }

        private async Task<List<Uri>> GetFailoverEndpointsAsync(
            Uri primaryEndpoint,
            CancellationToken cancellationToken = default)
        {
            var failoverEndpoints = new List<Uri>();

            try
            {
                string ledgerId = primaryEndpoint.Host.Substring(0, primaryEndpoint.Host.IndexOf('.'));

                Uri failoverUrl = new UriBuilder(primaryEndpoint)
                {
                    Host = "localhost",
                    Path = $"/failover/{ledgerId}"
                }.Uri;

                using HttpMessage message = CreateFailoverRequest(failoverUrl);
                Response response = await _pipeline.ProcessMessageAsync(message, new RequestContext()).ConfigureAwait(false);

                if (response.Status == 200)
                {
                    Console.WriteLine("[Failover] Metadata request succeeded.");
                    using JsonDocument jsonDoc = JsonDocument.Parse(response.Content);
                    if (jsonDoc.RootElement.TryGetProperty("ledgerId", out JsonElement primaryLedgerIdElem) && primaryLedgerIdElem.ValueKind == JsonValueKind.String)
                    {
                        Console.WriteLine($"[Failover] Metadata primary ledgerId: {primaryLedgerIdElem.GetString()}");
                    }

                    if (jsonDoc.RootElement.TryGetProperty("failoverLedgers", out JsonElement failoverArray))
                    {
                        int count = 0;
                        foreach (JsonElement failoverLedger in failoverArray.EnumerateArray())
                        {
                            string failoverLedgerId = null;
                            string access = null;
                            try
                            {
                                switch (failoverLedger.ValueKind)
                                {
                                    case JsonValueKind.String:
                                        failoverLedgerId = failoverLedger.GetString();
                                        break;
                                    case JsonValueKind.Object:
                                        // Expected shape: { "name": "ledgerName", ... }
                                        if (failoverLedger.TryGetProperty("name", out JsonElement nameProp) && nameProp.ValueKind == JsonValueKind.String)
                                        {
                                            failoverLedgerId = nameProp.GetString();
                                        }
                                        else
                                        {
                                            // Fall back: look for any string property that could represent the id
                                            foreach (JsonProperty prop in failoverLedger.EnumerateObject())
                                            {
                                                if (prop.Value.ValueKind == JsonValueKind.String &&
                                                    string.Equals(prop.Name, "id", StringComparison.OrdinalIgnoreCase))
                                                {
                                                    failoverLedgerId = prop.Value.GetString();
                                                    break;
                                                }
                                            }
                                        }
                                        if (failoverLedger.TryGetProperty("access", out JsonElement accessProp) && accessProp.ValueKind == JsonValueKind.String)
                                        {
                                            access = accessProp.GetString();
                                        }
                                        break;
                                    default:
                                        Console.WriteLine($"[Failover] Unexpected element kind {failoverLedger.ValueKind} in failoverLedgers array; skipping.");
                                        break;
                                }
                            }
                            catch (Exception exElem)
                            {
                                Console.WriteLine($"[Failover] Suppressed exception parsing failover ledger element: {exElem.Message}");
                            }

                            if (!string.IsNullOrEmpty(failoverLedgerId))
                            {
                                Uri endpoint = new UriBuilder(primaryEndpoint)
                                {
                                    Host = $"{failoverLedgerId}.confidential-ledger.azure.com"
                                }.Uri;
                                failoverEndpoints.Add(endpoint);
                                Console.WriteLine($"[Failover] Added failover endpoint {endpoint} (access={access ?? "unknown"})");
                                count++;
                            }
                            else
                            {
                                Console.WriteLine("[Failover] Could not extract ledger id from element; skipping.");
                            }
                        }
                        Console.WriteLine($"[Failover] Parsed {count} failover ledger id(s).");
                    }
                    else
                    {
                        Console.WriteLine("[Failover] No 'failoverLedgers' property in metadata response.");
                    }
                }
                else
                {
                    Console.WriteLine($"[Failover] Metadata request returned status {response.Status}. No endpoints extracted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Failover] Suppressed exception during metadata retrieval: {ex.Message}");
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
                Console.WriteLine($"Retrieving failover endpoints for primary endpoint: {primaryEndpoint}");
                string ledgerId = primaryEndpoint.Host.Substring(0, primaryEndpoint.Host.IndexOf('.'));

                Uri failoverUrl = new UriBuilder(primaryEndpoint)
                {
                    Host = "localhost",
                    Path = $"/failover/{ledgerId}"
                }.Uri;

                using HttpMessage message = CreateFailoverRequest(failoverUrl);
                Response response = _pipeline.ProcessMessage(message, new RequestContext());

                if (response.Status == 200)
                {
                    Console.WriteLine("[Failover] Metadata request succeeded.");
                    using JsonDocument jsonDoc = JsonDocument.Parse(response.Content);
                    if (jsonDoc.RootElement.TryGetProperty("ledgerId", out JsonElement primaryLedgerIdElem) && primaryLedgerIdElem.ValueKind == JsonValueKind.String)
                    {
                        Console.WriteLine($"[Failover] Metadata primary ledgerId: {primaryLedgerIdElem.GetString()}");
                    }

                    if (jsonDoc.RootElement.TryGetProperty("failoverLedgers", out JsonElement failoverArray))
                    {
                        int count = 0;
                        foreach (JsonElement failoverLedger in failoverArray.EnumerateArray())
                        {
                            string failoverLedgerId = null;
                            string access = null;
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
                                                if (prop.Value.ValueKind == JsonValueKind.String &&
                                                    string.Equals(prop.Name, "id", StringComparison.OrdinalIgnoreCase))
                                                {
                                                    failoverLedgerId = prop.Value.GetString();
                                                    break;
                                                }
                                            }
                                        }
                                        if (failoverLedger.TryGetProperty("access", out JsonElement accessProp) && accessProp.ValueKind == JsonValueKind.String)
                                        {
                                            access = accessProp.GetString();
                                        }
                                        break;
                                    default:
                                        Console.WriteLine($"[Failover] Unexpected element kind {failoverLedger.ValueKind} in failoverLedgers array; skipping.");
                                        break;
                                }
                            }
                            catch (Exception exElem)
                            {
                                Console.WriteLine($"[Failover] Suppressed exception parsing failover ledger element: {exElem.Message}");
                            }

                            if (!string.IsNullOrEmpty(failoverLedgerId))
                            {
                                Uri endpoint = new UriBuilder(primaryEndpoint)
                                {
                                    Host = $"{failoverLedgerId}.confidential-ledger.azure.com"
                                }.Uri;
                                failoverEndpoints.Add(endpoint);
                                Console.WriteLine($"[Failover] Added failover endpoint {endpoint} (access={access ?? "unknown"})");
                                count++;
                            }
                            else
                            {
                                Console.WriteLine("[Failover] Could not extract ledger id from element; skipping.");
                            }
                        }
                        Console.WriteLine($"[Failover] Parsed {count} failover ledger id(s).");
                    }
                    else
                    {
                        Console.WriteLine("[Failover] No 'failoverLedgers' property in metadata response.");
                    }
                }
                else
                {
                    Console.WriteLine($"[Failover] Metadata request returned status {response.Status}. No endpoints extracted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Failover] Suppressed exception during metadata retrieval: {ex.Message}");
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
        public async Task<T> ExecuteOnFailoversOnlyAsync<T>(
            Uri primaryEndpoint,
            Func<Uri, Task<T>> operationAsync,
            string operationName,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"[Failover] Discovering failover endpoints for {operationName} (failovers-only mode)...");
            List<Uri> endpoints = await GetFailoverEndpointsAsync(primaryEndpoint, cancellationToken).ConfigureAwait(false);
            Console.WriteLine($"[Failover] Found {endpoints.Count} failover endpoint(s) for {operationName}.");
            Exception last = null;
            foreach (var ep in endpoints)
            {
                Console.WriteLine($"[Failover] (FailoversOnly) Attempting {operationName} on {ep}");
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return await operationAsync(ep).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (IsRetriableFailure(ex))
                {
                    Console.WriteLine($"[Failover] (FailoversOnly) Endpoint {ep} failed (Status {ex.Status}, Code {ex.ErrorCode}). Trying next.");
                    last = ex;
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }
            }
            throw last ?? new RequestFailedException("All failover endpoints failed in failovers-only mode");
        }

        public T ExecuteOnFailoversOnly<T>(
            Uri primaryEndpoint,
            Func<Uri, T> operationSync,
            string operationName,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"[Failover] Discovering failover endpoints for {operationName} (failovers-only mode)...");
            List<Uri> endpoints = GetFailoverEndpoints(primaryEndpoint, cancellationToken);
            Console.WriteLine($"[Failover] Found {endpoints.Count} failover endpoint(s) for {operationName}.");
            Exception last = null;
            foreach (var ep in endpoints)
            {
                Console.WriteLine($"[Failover] (FailoversOnly) Attempting {operationName} on {ep}");
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return operationSync(ep);
                }
                catch (RequestFailedException ex) when (IsRetriableFailure(ex))
                {
                    Console.WriteLine($"[Failover] (FailoversOnly) Endpoint {ep} failed (Status {ex.Status}, Code {ex.ErrorCode}). Trying next.");
                    last = ex;
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }
            }
            throw last ?? new RequestFailedException("All failover endpoints failed in failovers-only mode");
        }
    }
}
