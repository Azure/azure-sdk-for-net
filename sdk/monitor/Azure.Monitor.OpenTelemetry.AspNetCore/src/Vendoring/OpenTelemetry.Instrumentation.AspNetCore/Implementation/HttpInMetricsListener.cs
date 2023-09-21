// <copyright file="HttpInMetricsListener.cs" company="OpenTelemetry Authors">
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Http;
#if NET6_0_OR_GREATER
using Microsoft.AspNetCore.Routing;
#endif
using OpenTelemetry.Trace;
using static OpenTelemetry.Internal.HttpSemanticConventionHelper;

namespace OpenTelemetry.Instrumentation.AspNetCore.Implementation
{
    internal sealed class HttpInMetricsListener : ListenerHandler
    {
        private const string HttpServerDurationMetricName = "http.server.duration";
        private const string OnStopEvent = "Microsoft.AspNetCore.Hosting.HttpRequestIn.Stop";
        private const string EventName = "OnStopActivity";

        private readonly Meter meter;
        private readonly AspNetCoreMetricsInstrumentationOptions options;
        private readonly Histogram<double> httpServerDuration;
        private readonly bool emitOldAttributes;
        private readonly bool emitNewAttributes;

        internal HttpInMetricsListener(string name, Meter meter, AspNetCoreMetricsInstrumentationOptions options)
            : base(name)
        {
            this.meter = meter;
            this.options = options;
            this.httpServerDuration = meter.CreateHistogram<double>(HttpServerDurationMetricName, "ms", "Measures the duration of inbound HTTP requests.");

            this.emitOldAttributes = this.options.HttpSemanticConvention.HasFlag(HttpSemanticConvention.Old);

            this.emitNewAttributes = this.options.HttpSemanticConvention.HasFlag(HttpSemanticConvention.New);
        }

        public override void OnEventWritten(string name, object payload)
        {
            if (name == OnStopEvent)
            {
                var context = payload as HttpContext;
                if (context == null)
                {
                    AspNetCoreInstrumentationEventSource.Log.NullPayload(nameof(HttpInMetricsListener), EventName, HttpServerDurationMetricName);
                    return;
                }

                try
                {
                    if (this.options.Filter?.Invoke(HttpServerDurationMetricName, context) == false)
                    {
                        AspNetCoreInstrumentationEventSource.Log.RequestIsFilteredOut(nameof(HttpInMetricsListener), EventName, HttpServerDurationMetricName);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    AspNetCoreInstrumentationEventSource.Log.RequestFilterException(nameof(HttpInMetricsListener), EventName, HttpServerDurationMetricName, ex);
                    return;
                }

                // TODO: Prometheus pulls metrics by invoking the /metrics endpoint. Decide if it makes sense to suppress this.
                // Below is just a temporary way of achieving this suppression for metrics (we should consider suppressing traces too).
                // If we want to suppress activity from Prometheus then we should use SuppressInstrumentationScope.
                if (context.Request.Path.HasValue && context.Request.Path.Value.Contains("metrics"))
                {
                    return;
                }

                TagList tags = default;

                // see the spec https://github.com/open-telemetry/opentelemetry-specification/blob/v1.20.0/specification/trace/semantic_conventions/http.md
                if (this.emitOldAttributes)
                {
                    tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpFlavor, HttpTagHelper.GetFlavorTagValueFromProtocol(context.Request.Protocol)));
                    tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, context.Request.Scheme));
                    tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpMethod, context.Request.Method));
                    tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpStatusCode, TelemetryHelper.GetBoxedStatusCode(context.Response.StatusCode)));

                    if (context.Request.Host.HasValue)
                    {
                        tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostName, context.Request.Host.Host));

                        if (context.Request.Host.Port is not null && context.Request.Host.Port != 80 && context.Request.Host.Port != 443)
                        {
                            tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostPort, context.Request.Host.Port));
                        }
                    }
                }

                // see the spec https://github.com/open-telemetry/semantic-conventions/blob/v1.21.0/docs/http/http-spans.md
                if (this.emitNewAttributes)
                {
                    tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeNetworkProtocolVersion, HttpTagHelper.GetFlavorTagValueFromProtocol(context.Request.Protocol)));
                    tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeUrlScheme, context.Request.Scheme));
                    tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpRequestMethod, context.Request.Method));
                    tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpResponseStatusCode, TelemetryHelper.GetBoxedStatusCode(context.Response.StatusCode)));

                    if (context.Request.Host.HasValue)
                    {
                        tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeServerAddress, context.Request.Host.Host));

                        if (context.Request.Host.Port is not null && context.Request.Host.Port != 80 && context.Request.Host.Port != 443)
                        {
                            tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeServerPort, context.Request.Host.Port));
                        }
                    }
                }

#if NET6_0_OR_GREATER
                var route = (context.GetEndpoint() as RouteEndpoint)?.RoutePattern.RawText;
                if (!string.IsNullOrEmpty(route))
                {
                    tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpRoute, route));
                }
#endif
                if (this.options.Enrich != null)
                {
                    try
                    {
                        this.options.Enrich(HttpServerDurationMetricName, context, ref tags);
                    }
                    catch (Exception ex)
                    {
                        AspNetCoreInstrumentationEventSource.Log.EnrichmentException(nameof(HttpInMetricsListener), EventName, HttpServerDurationMetricName, ex);
                    }
                }

                // We are relying here on ASP.NET Core to set duration before writing the stop event.
                // https://github.com/dotnet/aspnetcore/blob/d6fa351048617ae1c8b47493ba1abbe94c3a24cf/src/Hosting/Hosting/src/Internal/HostingApplicationDiagnostics.cs#L449
                // TODO: Follow up with .NET team if we can continue to rely on this behavior.
                this.httpServerDuration.Record(Activity.Current.Duration.TotalMilliseconds, tags);
            }
        }
    }
}
