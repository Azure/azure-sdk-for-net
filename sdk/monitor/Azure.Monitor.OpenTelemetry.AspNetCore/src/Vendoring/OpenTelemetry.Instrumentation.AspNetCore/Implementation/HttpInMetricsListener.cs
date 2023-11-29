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

using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Http;
using OpenTelemetry.Internal;

#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Routing;
#endif
using OpenTelemetry.Trace;
using static OpenTelemetry.Internal.HttpSemanticConventionHelper;

namespace OpenTelemetry.Instrumentation.AspNetCore.Implementation;

internal sealed class HttpInMetricsListener : ListenerHandler
{
    internal const string HttpServerDurationMetricName = "http.server.duration";
    internal const string HttpServerRequestDurationMetricName = "http.server.request.duration";

    internal const string OnUnhandledHostingExceptionEvent = "Microsoft.AspNetCore.Hosting.UnhandledException";
    internal const string OnUnhandledDiagnosticsExceptionEvent = "Microsoft.AspNetCore.Diagnostics.UnhandledException";
    private const string OnStopEvent = "Microsoft.AspNetCore.Hosting.HttpRequestIn.Stop";
    private const string EventName = "OnStopActivity";
    private const string NetworkProtocolName = "http";
    private static readonly PropertyFetcher<Exception> ExceptionPropertyFetcher = new("Exception");
    private static readonly PropertyFetcher<HttpContext> HttpContextPropertyFetcher = new("HttpContext");
    private static readonly object ErrorTypeHttpContextItemsKey = new();

    private readonly Meter meter;
    private readonly AspNetCoreMetricsInstrumentationOptions options;
    private readonly Histogram<double> httpServerDuration;
    private readonly Histogram<double> httpServerRequestDuration;
    private readonly bool emitOldAttributes;
    private readonly bool emitNewAttributes;

    internal HttpInMetricsListener(string name, Meter meter, AspNetCoreMetricsInstrumentationOptions options)
        : base(name)
    {
        this.meter = meter;
        this.options = options;

        this.emitOldAttributes = this.options.HttpSemanticConvention.HasFlag(HttpSemanticConvention.Old);

        this.emitNewAttributes = this.options.HttpSemanticConvention.HasFlag(HttpSemanticConvention.New);

        if (this.emitOldAttributes)
        {
            this.httpServerDuration = meter.CreateHistogram<double>(HttpServerDurationMetricName, "ms", "Measures the duration of inbound HTTP requests.");
        }

        if (this.emitNewAttributes)
        {
            this.httpServerRequestDuration = meter.CreateHistogram<double>(HttpServerRequestDurationMetricName, "s", "Duration of HTTP server requests.");
        }
    }

    public override void OnEventWritten(string name, object payload)
    {
        switch (name)
        {
            case OnUnhandledDiagnosticsExceptionEvent:
            case OnUnhandledHostingExceptionEvent:
                {
                    if (this.emitNewAttributes)
                    {
                        this.OnExceptionEventWritten(name, payload);
                    }
                }

                break;
            case OnStopEvent:
                {
                    if (this.emitOldAttributes)
                    {
                        this.OnEventWritten_Old(name, payload);
                    }

                    if (this.emitNewAttributes)
                    {
                        this.OnEventWritten_New(name, payload);
                    }
                }

                break;
        }
    }

    public void OnExceptionEventWritten(string name, object payload)
    {
        // We need to use reflection here as the payload type is not a defined public type.
        if (!TryFetchException(payload, out Exception exc) || !TryFetchHttpContext(payload, out HttpContext ctx))
        {
            AspNetCoreInstrumentationEventSource.Log.NullPayload(nameof(HttpInMetricsListener), nameof(this.OnExceptionEventWritten), HttpServerDurationMetricName);
            return;
        }

        ctx.Items.Add(ErrorTypeHttpContextItemsKey, exc.GetType().FullName);

        // See https://github.com/dotnet/aspnetcore/blob/690d78279e940d267669f825aa6627b0d731f64c/src/Hosting/Hosting/src/Internal/HostingApplicationDiagnostics.cs#L252
        // and https://github.com/dotnet/aspnetcore/blob/690d78279e940d267669f825aa6627b0d731f64c/src/Middleware/Diagnostics/src/DeveloperExceptionPage/DeveloperExceptionPageMiddlewareImpl.cs#L174
        // this makes sure that top-level properties on the payload object are always preserved.
#if NET6_0_OR_GREATER
        [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "The ASP.NET Core framework guarantees that top level properties are preserved")]
#endif
        static bool TryFetchException(object payload, out Exception exc)
            => ExceptionPropertyFetcher.TryFetch(payload, out exc) && exc != null;
#if NET6_0_OR_GREATER
        [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "The ASP.NET Core framework guarantees that top level properties are preserved")]
#endif
        static bool TryFetchHttpContext(object payload, out HttpContext ctx)
            => HttpContextPropertyFetcher.TryFetch(payload, out ctx) && ctx != null;
    }

    public void OnEventWritten_Old(string name, object payload)
    {
        var context = payload as HttpContext;

        if (context == null)
        {
            AspNetCoreInstrumentationEventSource.Log.NullPayload(nameof(HttpInMetricsListener), EventName, HttpServerDurationMetricName);
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

#if NET6_0_OR_GREATER
        var route = (context.GetEndpoint() as RouteEndpoint)?.RoutePattern.RawText;
        if (!string.IsNullOrEmpty(route))
        {
            tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpRoute, route));
        }
#endif

        // We are relying here on ASP.NET Core to set duration before writing the stop event.
        // https://github.com/dotnet/aspnetcore/blob/d6fa351048617ae1c8b47493ba1abbe94c3a24cf/src/Hosting/Hosting/src/Internal/HostingApplicationDiagnostics.cs#L449
        // TODO: Follow up with .NET team if we can continue to rely on this behavior.
        this.httpServerDuration.Record(Activity.Current.Duration.TotalMilliseconds, tags);
    }

    public void OnEventWritten_New(string name, object payload)
    {
        var context = payload as HttpContext;
        if (context == null)
        {
            AspNetCoreInstrumentationEventSource.Log.NullPayload(nameof(HttpInMetricsListener), EventName, HttpServerRequestDurationMetricName);
            return;
        }

        TagList tags = default;

        // see the spec https://github.com/open-telemetry/semantic-conventions/blob/v1.21.0/docs/http/http-spans.md
        tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeNetworkProtocolVersion, HttpTagHelper.GetFlavorTagValueFromProtocol(context.Request.Protocol)));
        tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeUrlScheme, context.Request.Scheme));
        tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpResponseStatusCode, TelemetryHelper.GetBoxedStatusCode(context.Response.StatusCode)));

        var httpMethod = RequestMethodHelper.GetNormalizedHttpMethod(context.Request.Method);
        tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpRequestMethod, httpMethod));

#if NET6_0_OR_GREATER
        var route = (context.GetEndpoint() as RouteEndpoint)?.RoutePattern.RawText;
        if (!string.IsNullOrEmpty(route))
        {
            tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeHttpRoute, route));
        }
#endif
        if (context.Items.TryGetValue(ErrorTypeHttpContextItemsKey, out var errorType))
        {
            tags.Add(new KeyValuePair<string, object>(SemanticConventions.AttributeErrorType, errorType));
        }

        // We are relying here on ASP.NET Core to set duration before writing the stop event.
        // https://github.com/dotnet/aspnetcore/blob/d6fa351048617ae1c8b47493ba1abbe94c3a24cf/src/Hosting/Hosting/src/Internal/HostingApplicationDiagnostics.cs#L449
        // TODO: Follow up with .NET team if we can continue to rely on this behavior.
        this.httpServerRequestDuration.Record(Activity.Current.Duration.TotalSeconds, tags);
    }
}
