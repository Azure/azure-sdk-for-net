// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal static class SdkStatsConfigFetcher
    {
        internal static readonly TimeSpan PerAttemptTimeout = TimeSpan.FromSeconds(10);
        internal const int MaxAttempts = 3;
        internal static readonly TimeSpan[] RetryBackoff =
        {
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(4),
        };

        internal static async Task<SdkStatsConfigResult> FetchAsync(
            string configUrl,
            string ingestionEndpoint,
            HttpMessageHandler? httpMessageHandler = null,
            CancellationToken cancellationToken = default)
        {
            using var _ = SuppressInstrumentationScope.Begin();
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
                        return SdkStatsConfigResult.Fallback();
                    }

                    try
                    {
                        using var response = await client.GetAsync(configUrl, cancellationToken).ConfigureAwait(false);
                        if ((int)response.StatusCode >= 500)
                        {
                            AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                                configUrl,
                                $"Attempt {attempt} returned {(int)response.StatusCode}");
                        }
                        else if (!response.IsSuccessStatusCode)
                        {
                            AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                                configUrl,
                                $"HTTP {(int)response.StatusCode}");
                            return SdkStatsConfigResult.Fallback();
                        }
                        else
                        {
                            var payload = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            return ParseAndValidate(configUrl, ingestionEndpoint, payload);
                        }
                    }
                    catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                    {
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
                        AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                            configUrl,
                            $"{ex.GetType().Name}: {ex.Message}");
                        return SdkStatsConfigResult.Fallback();
                    }

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

        internal static Task<SdkStatsConfigResult> FetchAsync(
            string configUrl,
            HttpMessageHandler? httpMessageHandler = null,
            CancellationToken cancellationToken = default) =>
            FetchAsync(
                configUrl,
                "https://westus.in.applicationinsights.azure.com/",
                httpMessageHandler,
                cancellationToken);

        private static SdkStatsConfigResult ParseAndValidate(
            string configUrl,
            string ingestionEndpoint,
            string payload)
        {
            try
            {
                using var document = JsonDocument.Parse(payload);
                if (!document.RootElement.TryGetProperty("settings", out var settingsElement)
                    || settingsElement.ValueKind != JsonValueKind.Object)
                {
                    return ParseLegacyResponse(document.RootElement);
                }

                var settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (var property in settingsElement.EnumerateObject())
                {
                    if (property.Value.ValueKind == JsonValueKind.String)
                    {
                        settings[property.Name] = property.Value.GetString()!;
                    }
                }

                if (IsExplicitlyDisabled(settings))
                {
                    AzureMonitorExporterEventSource.Log.SdkStatsDisabledByConfig(configUrl);
                    return SdkStatsConfigResult.Disabled();
                }

                var connectionString = ResolveConnectionString(settings, ingestionEndpoint);
                return connectionString == null
                    ? SdkStatsConfigResult.Fallback()
                    : SdkStatsConfigResult.UseConnectionString(connectionString);
            }
            catch (JsonException ex)
            {
                AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                    configUrl,
                    $"Malformed JSON: {ex.GetType().Name}");
                return SdkStatsConfigResult.Fallback();
            }
        }

        private static SdkStatsConfigResult ParseLegacyResponse(JsonElement root)
        {
            if (!root.TryGetProperty("ver", out var version)
                || version.GetInt32() != StatsbeatConstants.SdkStatsConfigVersion
                || !root.TryGetProperty("enabled", out var enabled))
            {
                return SdkStatsConfigResult.Fallback();
            }

            if (!enabled.GetBoolean())
            {
                return SdkStatsConfigResult.Disabled();
            }

            if (!root.TryGetProperty("url", out var url)
                || url.ValueKind != JsonValueKind.String
                || string.IsNullOrWhiteSpace(url.GetString()))
            {
                return SdkStatsConfigResult.Fallback();
            }

            var host = url.GetString()!.TrimEnd('/');
            if (!host.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                && !host.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                host = "https://" + host;
            }

            return SdkStatsConfigResult.UseConnectionString(
                "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=" + host + "/");
        }

        private static bool IsExplicitlyDisabled(IReadOnlyDictionary<string, string> settings)
        {
            if (!settings.TryGetValue(StatsbeatConstants.OneSettingsFeatureSdkStats, out var feature))
            {
                return false;
            }

            try
            {
                using var document = JsonDocument.Parse(feature);
                return document.RootElement.TryGetProperty("default", out var defaultValue)
                    && defaultValue.ValueKind == JsonValueKind.String
                    && string.Equals(defaultValue.GetString(), "disabled", StringComparison.OrdinalIgnoreCase);
            }
            catch (JsonException)
            {
                return false;
            }
        }

        private static string? ResolveConnectionString(
            IReadOnlyDictionary<string, string> settings,
            string ingestionEndpoint)
        {
            settings.TryGetValue(
                StatsbeatConstants.OneSettingsDefaultStatsConnectionString,
                out var defaultConnectionString);
            var region = GetRegion(ingestionEndpoint);
            if (region != null
                && settings.TryGetValue(
                    StatsbeatConstants.OneSettingsSupportedDataBoundaries,
                    out var boundariesJson))
            {
                foreach (var boundary in ParseStringArray(boundariesJson))
                {
                    if (string.Equals(boundary, "DEFAULT", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (settings.TryGetValue(boundary + "_REGIONS", out var regionsJson)
                        && ParseStringArray(regionsJson).Contains(region, StringComparer.OrdinalIgnoreCase)
                        && settings.TryGetValue(
                            boundary + "_STATS_CONNECTION_STRING",
                            out var boundaryConnectionString)
                        && IsValidConnectionString(boundaryConnectionString))
                    {
                        return boundaryConnectionString;
                    }
                }
            }

            return IsValidConnectionString(defaultConnectionString) ? defaultConnectionString : null;
        }

        private static string? GetRegion(string ingestionEndpoint)
        {
            if (!Uri.TryCreate(ingestionEndpoint, UriKind.Absolute, out var uri))
            {
                return null;
            }

            return uri.Host.Split('.')[0].Split('-')[0];
        }

        private static IEnumerable<string> ParseStringArray(string value)
        {
            try
            {
                using var document = JsonDocument.Parse(value);
                if (document.RootElement.ValueKind != JsonValueKind.Array)
                {
                    return Array.Empty<string>();
                }

                return document.RootElement.EnumerateArray()
                    .Where(item => item.ValueKind == JsonValueKind.String)
                    .Select(item => item.GetString()!)
                    .ToArray();
            }
            catch (JsonException)
            {
                return Array.Empty<string>();
            }
        }

        private static bool IsValidConnectionString(string? connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return false;
            }

            try
            {
                var values = ConnectionStringParser.GetValues(connectionString!);
                return !string.IsNullOrWhiteSpace(values.InstrumentationKey)
                    && !string.IsNullOrWhiteSpace(values.IngestionEndpoint);
            }
            catch
            {
                return false;
            }
        }

        private static bool IsTransient(Exception ex)
        {
            return ex is HttpRequestException
                || ex is WebException
                || ex is System.IO.IOException;
        }
    }
}
