#pragma warning disable SA1636
// <copyright file="HttpHandlerMetricsDiagnosticListener.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics;
#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif
using System.Diagnostics.Metrics;
using System.Net.Http;
#if NETFRAMEWORK
using System.Net.Http;
#endif
using OpenTelemetry.Trace;
using static OpenTelemetry.Internal.HttpSemanticConventionHelper;

namespace OpenTelemetry.Instrumentation.Http.Implementation;

internal sealed class HttpHandlerMetricsDiagnosticListener : ListenerHandler
{
    internal const string OnStopEvent = "System.Net.Http.HttpRequestOut.Stop";

    private static readonly PropertyFetcher<HttpRequestMessage> StopRequestFetcher = new("Request");
    private static readonly PropertyFetcher<HttpResponseMessage> StopResponseFetcher = new("Response");
    private readonly Histogram<double> httpClientDuration;
    private readonly HttpClientMetricInstrumentationOptions options;
    private readonly bool emitOldAttributes;
    private readonly bool emitNewAttributes;

    public HttpHandlerMetricsDiagnosticListener(string name, Meter meter, HttpClientMetricInstrumentationOptions options)
        : base(name)
    {
        this.httpClientDuration = meter.CreateHistogram<double>("http.client.duration", "ms", "Measures the duration of outbound HTTP requests.");
        this.options = options;

        this.emitOldAttributes = this.options.HttpSemanticConvention.HasFlag(HttpSemanticConvention.Old);

        this.emitNewAttributes = this.options.HttpSemanticConvention.HasFlag(HttpSemanticConvention.New);
    }

    public override void OnEventWritten(string name, object? payload)
    {
        if (name == OnStopEvent)
        {
            if (Sdk.SuppressInstrumentation)
            {
                return;
            }

            var activity = Activity.Current!;
            if (payload != null && TryFetchRequest(payload!, out HttpRequestMessage? request))
            {
                TagList tags = default;

                // see the spec https://github.com/open-telemetry/opentelemetry-specification/blob/v1.20.0/specification/trace/semantic_conventions/http.md
                if (this.emitOldAttributes)
                {
                    tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpMethod, HttpTagHelper.GetNameForHttpMethod(request!.Method)));
                    tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, request.RequestUri.Scheme));
                    tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpFlavor, HttpTagHelper.GetFlavorTagValueFromProtocolVersion(request.Version)));
                    tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, request.RequestUri.Host));

                    if (!request.RequestUri.IsDefaultPort)
                    {
                        tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, request.RequestUri.Port));
                    }

                    if (payload != null && TryFetchResponse(payload, out HttpResponseMessage? response))
                    {
                        tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpStatusCode, TelemetryHelper.GetBoxedStatusCode(response!.StatusCode)));
                    }
                }

                // see the spec https://github.com/open-telemetry/semantic-conventions/blob/v1.21.0/docs/http/http-spans.md
                if (this.emitNewAttributes)
                {
                    tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, HttpTagHelper.GetNameForHttpMethod(request!.Method)));
                    tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeNetworkProtocolVersion, HttpTagHelper.GetFlavorTagValueFromProtocolVersion(request!.Version)));
                    tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, request.RequestUri.Host));

                    if (!request.RequestUri.IsDefaultPort)
                    {
                        tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeServerPort, request.RequestUri.Port));
                    }

                    if (payload != null && TryFetchResponse(payload, out HttpResponseMessage? response))
                    {
                        tags.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpResponseStatusCode, TelemetryHelper.GetBoxedStatusCode(response!.StatusCode)));
                    }
                }

                // We are relying here on HttpClient library to set duration before writing the stop event.
                // https://github.com/dotnet/runtime/blob/90603686d314147017c8bbe1fa8965776ce607d0/src/libraries/System.Net.Http/src/System/Net/Http/DiagnosticsHandler.cs#L178
                // TODO: Follow up with .NET team if we can continue to rely on this behavior.
                this.httpClientDuration.Record(activity.Duration.TotalMilliseconds, tags);
            }
        }

        // The AOT-annotation DynamicallyAccessedMembers in System.Net.Http library ensures that top-level properties on the payload object are always preserved.
        // see https://github.com/dotnet/runtime/blob/f9246538e3d49b90b0e9128d7b1defef57cd6911/src/libraries/System.Net.Http/src/System/Net/Http/DiagnosticsHandler.cs#L325
#if NET6_0_OR_GREATER
        [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "The event source guarantees that top-level properties are preserved")]
#endif
        static bool TryFetchRequest(object payload, out HttpRequestMessage? request) =>
            StopRequestFetcher.TryFetch(payload, out request) && request != null;

        // The AOT-annotation DynamicallyAccessedMembers in System.Net.Http library ensures that top-level properties on the payload object are always preserved.
        // see https://github.com/dotnet/runtime/blob/f9246538e3d49b90b0e9128d7b1defef57cd6911/src/libraries/System.Net.Http/src/System/Net/Http/DiagnosticsHandler.cs#L325
#if NET6_0_OR_GREATER
        [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "The event source guarantees that top-level properties are preserved")]
#endif
        static bool TryFetchResponse(object payload, out HttpResponseMessage? response) =>
            StopResponseFetcher.TryFetch(payload, out response) && response != null;
    }
}
#pragma warning restore SA1636
