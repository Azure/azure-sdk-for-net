// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.LiveMetrics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal sealed class LiveMetricsRedirectPolicy : HttpPipelinePolicy
    {
        private string? _redirectHostValue;

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            // Check if we've already processed the redirection
            if (message.TryGetProperty("redirectionComplete", out object? objValue)
                && objValue is bool isComplete
                && isComplete)
            {
                return;
            }

            Request request = message.Request;

            // If we have a cached redirect, apply it
            if (_redirectHostValue is not null)
            {
                request.Uri.Host = _redirectHostValue;
            }

            // Process the request
            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            // Check for redirection and retry
            if (IsRedirection(message.Response, out string? redirectionValue))
            {
                Debug.WriteLine($"OnPing: Received Redirection: {redirectionValue}");
                AzureMonitorLiveMetricsEventSource.Log.LiveMetricsRedirectReceived(redirectionValue);

                message.Response.Dispose();

                // ORIGINAL VALUE (default endpoint):
                // https://rt.services.visualstudio.com/QuickPulseService.svc/ping?api-version=2024-04-01-preview&ikey=00000000-0000-0000-0000-000000000000

                // REDIRECT VALUE (regional endpoint):
                // https://westus.livediagnostics.monitor.azure.com/QuickPulseService.svc

                // FINAL VALUE:
                // https://westus.livediagnostics.monitor.azure.com/QuickPulseService.svc/ping?api-version=2024-04-01-preview&ikey=00000000-0000-0000-0000-000000000000

                // Extract the host value from the redirection URI
                _redirectHostValue = new Uri(redirectionValue).Host;

                // Apply redirect
                request.Uri.Host = _redirectHostValue;

                // Issue the redirected request.
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
            }

            message.SetProperty("redirectionComplete", true);
            return;
        }

        private static bool IsRedirection(Response response, [NotNullWhen(true)] out string? redirectValue)
        {
            // example: https://westus.livediagnostics.monitor.azure.com/QuickPulseService.svc
            return response.Headers.TryGetValue("x-ms-qps-service-endpoint-redirect-v2", out redirectValue);
        }
    }
}
