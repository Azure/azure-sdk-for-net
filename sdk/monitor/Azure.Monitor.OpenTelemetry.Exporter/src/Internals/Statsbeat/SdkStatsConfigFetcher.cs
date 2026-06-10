// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    /// <summary>
    /// Fetches the SDK statistics configuration JSON from the distro-owned configuration
    /// endpoint. Used at startup by <see cref="AzureMonitorStatsbeat"/> to determine
    /// whether to emit SDK statistics and which ingestion host to send them to.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Runs on a background <see cref="Task"/>; never blocks construction of the
    /// transmitter or customer telemetry pipelines.
    /// </para>
    /// <para>Result semantics:</para>
    /// <list type="bullet">
    /// <item>
    ///   <description>
    ///   <see cref="SdkStatsConfigStatus.UseUrl"/> — config returned <c>enabled: true</c>
    ///   with a non-empty <c>url</c>; SDK statistics should be sent to that url.
    ///   </description>
    /// </item>
    /// <item>
    ///   <description>
    ///   <see cref="SdkStatsConfigStatus.Disabled"/> — config explicitly returned
    ///   <c>enabled: false</c>; the control plane has spoken; do not emit.
    ///   </description>
    /// </item>
    /// <item>
    ///   <description>
    ///   <see cref="SdkStatsConfigStatus.Fallback"/> — config could not be retrieved or
    ///   was malformed; the caller should fall back to the legacy region-derived
    ///   Statsbeat endpoint so SDK statistics keep flowing in the absence of a working
    ///   control plane. This is the "control-plane unavailable → use defaults"
    ///   contract.
    ///   </description>
    /// </item>
    /// </list>
    /// </remarks>
    internal static class SdkStatsConfigFetcher
    {
        /// <summary>Per-attempt HTTP timeout.</summary>
        internal static readonly TimeSpan PerAttemptTimeout = TimeSpan.FromSeconds(10);

        /// <summary>Maximum number of attempts (including the first).</summary>
        internal const int MaxAttempts = 3;

        /// <summary>Backoff delays between retries; index 0 is between attempts 1 and 2.</summary>
        internal static readonly TimeSpan[] RetryBackoff =
        {
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(4),
        };

        /// <summary>
        /// Fetches the SDK statistics configuration from the supplied URL with bounded
        /// retry on transient failures (network exception, timeout, 5xx).
        /// </summary>
        /// <param name="configUrl">The configuration endpoint URL.</param>
        /// <param name="httpMessageHandler">
        /// Optional <see cref="HttpMessageHandler"/> for testing. Production callers pass
        /// <see langword="null"/> to use the default <see cref="HttpClient"/> transport.
        /// </param>
        /// <param name="cancellationToken">Cancellation for the overall operation.</param>
        internal static async Task<SdkStatsConfigResult> FetchAsync(
            string configUrl,
            HttpMessageHandler? httpMessageHandler = null,
            CancellationToken cancellationToken = default)
        {
            // Prevent any HTTP instrumentation in the user's process from picking up the
            // internal fetch as a customer-visible HttpClient activity / metric.
            using var _ = SuppressInstrumentationScope.Begin();

            // Construct HttpClient once per fetch; we expect a single successful call (or a
            // small bounded number of retries), and the overall lifetime is short.
            var ownsHandler = httpMessageHandler == null;
            var handler = httpMessageHandler ?? new HttpClientHandler();
            HttpClient? client = null;
            try
            {
                client = new HttpClient(handler, disposeHandler: false)
                {
                    Timeout = PerAttemptTimeout,
                };

                for (int attempt = 1; attempt <= MaxAttempts; attempt++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(configUrl, "Cancelled");
                        return SdkStatsConfigResult.Fallback();
                    }

                    try
                    {
                        using var response = await client.GetAsync(configUrl, cancellationToken).ConfigureAwait(false);

                        if ((int)response.StatusCode >= 500)
                        {
                            // 5xx is transient; fall through to retry path below.
                            AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                                configUrl,
                                $"Attempt {attempt} returned {(int)response.StatusCode}");
                        }
                        else if (!response.IsSuccessStatusCode)
                        {
                            // 4xx (including 404 / 403) means the server is reachable and
                            // declined the request. Treat as "control plane unavailable"
                            // and fall back to the legacy endpoint; no retry.
                            AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                                configUrl,
                                $"HTTP {(int)response.StatusCode}");
                            return SdkStatsConfigResult.Fallback();
                        }
                        else
                        {
                            var payload = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            return ParseAndValidate(configUrl, payload);
                        }
                    }
                    catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                    {
                        // Per-attempt timeout. Transient; fall through to retry.
                        AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                            configUrl,
                            $"Attempt {attempt} timed out");
                    }
                    catch (Exception ex) when (IsTransient(ex))
                    {
                        AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                            configUrl,
                            $"Attempt {attempt} failed: {ex.GetType().Name}");
                    }
                    catch (Exception ex)
                    {
                        // Non-transient (e.g. argument exception, security exception).
                        // Don't retry; fall back to the legacy endpoint.
                        AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                            configUrl,
                            $"{ex.GetType().Name}: {ex.Message}");
                        return SdkStatsConfigResult.Fallback();
                    }

                    // Sleep between retries; skip after the last attempt.
                    if (attempt < MaxAttempts)
                    {
                        try
                        {
                            await Task.Delay(RetryBackoff[attempt - 1], cancellationToken).ConfigureAwait(false);
                        }
                        catch (OperationCanceledException)
                        {
                            return SdkStatsConfigResult.Fallback();
                        }
                    }
                }

                AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                    configUrl,
                    $"All {MaxAttempts} attempts exhausted");
                return SdkStatsConfigResult.Fallback();
            }
            finally
            {
                client?.Dispose();
                if (ownsHandler)
                {
                    handler.Dispose();
                }
            }
        }

        private static SdkStatsConfigResult ParseAndValidate(string configUrl, string payload)
        {
            SdkStatsConfigResponse? response;
            try
            {
#if NET
                response = JsonSerializer.Deserialize(payload, SourceGenerationContext.Default.SdkStatsConfigResponse);
#else
                response = JsonSerializer.Deserialize<SdkStatsConfigResponse>(payload);
#endif
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                    configUrl,
                    $"Malformed JSON: {ex.GetType().Name}");
                return SdkStatsConfigResult.Fallback();
            }

            if (response == null)
            {
                AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(configUrl, "Empty response");
                return SdkStatsConfigResult.Fallback();
            }

            if (response.ver != StatsbeatConstants.SdkStatsConfigVersion)
            {
                AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                    configUrl,
                    $"Unsupported config version {response.ver}");
                return SdkStatsConfigResult.Fallback();
            }

            // Explicit remote kill switch. Honor it.
            if (!response.enabled)
            {
                AzureMonitorExporterEventSource.Log.SdkStatsDisabledByConfig(configUrl);
                return SdkStatsConfigResult.Disabled();
            }

            // Enabled but no usable url — control plane is incomplete. Fall back so SDK
            // statistics keep flowing rather than silently dropping when the server-side
            // contract drifts.
            if (string.IsNullOrWhiteSpace(response.url))
            {
                AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(configUrl, "Missing url field");
                return SdkStatsConfigResult.Fallback();
            }

            return SdkStatsConfigResult.UseUrl(response.url!);
        }

        private static bool IsTransient(Exception ex)
        {
            // Network-layer failures we want to retry. Anything else is bubbled up to the
            // outer catch (which logs once and gives up without retrying).
            switch (ex)
            {
                case HttpRequestException:
                case WebException:
                case System.IO.IOException:
                    return true;
                default:
                    return false;
            }
        }
    }
}
