// <copyright file="HttpInListener.cs" company="OpenTelemetry Authors">
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
using System.Reflection;
#if !NETSTANDARD2_0
using System.Runtime.CompilerServices;
#endif
using Microsoft.AspNetCore.Http;
#if NET6_0_OR_GREATER
using Microsoft.AspNetCore.Mvc.Diagnostics;
#endif
using OpenTelemetry.Context.Propagation;
#if !NETSTANDARD2_0
using OpenTelemetry.Instrumentation.GrpcNetClient;
#endif
using OpenTelemetry.Internal;
using OpenTelemetry.Trace;
using static OpenTelemetry.Internal.HttpSemanticConventionHelper;

namespace OpenTelemetry.Instrumentation.AspNetCore.Implementation
{
    internal class HttpInListener : ListenerHandler
    {
        internal const string ActivityOperationName = "Microsoft.AspNetCore.Hosting.HttpRequestIn";
        internal const string OnStartEvent = "Microsoft.AspNetCore.Hosting.HttpRequestIn.Start";
        internal const string OnStopEvent = "Microsoft.AspNetCore.Hosting.HttpRequestIn.Stop";
        internal const string OnMvcBeforeActionEvent = "Microsoft.AspNetCore.Mvc.BeforeAction";
        internal const string OnUnhandledHostingExceptionEvent = "Microsoft.AspNetCore.Hosting.UnhandledException";
        internal const string OnUnHandledDiagnosticsExceptionEvent = "Microsoft.AspNetCore.Diagnostics.UnhandledException";

#if NET7_0_OR_GREATER
        // https://github.com/dotnet/aspnetcore/blob/8d6554e655b64da75b71e0e20d6db54a3ba8d2fb/src/Hosting/Hosting/src/GenericHost/GenericWebHostBuilder.cs#L85
        internal static readonly string AspNetCoreActivitySourceName = "Microsoft.AspNetCore";
#endif

        internal static readonly AssemblyName AssemblyName = typeof(HttpInListener).Assembly.GetName();
        internal static readonly string ActivitySourceName = AssemblyName.Name;
        internal static readonly Version Version = AssemblyName.Version;
        internal static readonly ActivitySource ActivitySource = new(ActivitySourceName, Version.ToString());

        private const string DiagnosticSourceName = "Microsoft.AspNetCore";
        private const string UnknownHostName = "UNKNOWN-HOST";

        private static readonly Func<HttpRequest, string, IEnumerable<string>> HttpRequestHeaderValuesGetter = (request, name) => request.Headers[name];
#if !NET6_0_OR_GREATER
        private readonly PropertyFetcher<object> beforeActionActionDescriptorFetcher = new("actionDescriptor");
        private readonly PropertyFetcher<object> beforeActionAttributeRouteInfoFetcher = new("AttributeRouteInfo");
        private readonly PropertyFetcher<string> beforeActionTemplateFetcher = new("Template");
#endif
        private readonly PropertyFetcher<Exception> stopExceptionFetcher = new("Exception");
        private readonly AspNetCoreInstrumentationOptions options;
        private readonly bool emitOldAttributes;
        private readonly bool emitNewAttributes;

        public HttpInListener(AspNetCoreInstrumentationOptions options)
            : base(DiagnosticSourceName)
        {
            Guard.ThrowIfNull(options);

            this.options = options;

            this.emitOldAttributes = this.options.HttpSemanticConvention.HasFlag(HttpSemanticConvention.Old);

            this.emitNewAttributes = this.options.HttpSemanticConvention.HasFlag(HttpSemanticConvention.New);
        }

        public override void OnEventWritten(string name, object payload)
        {
            switch (name)
            {
                case OnStartEvent:
                    {
                        this.OnStartActivity(Activity.Current, payload);
                    }

                    break;
                case OnStopEvent:
                    {
                        this.OnStopActivity(Activity.Current, payload);
                    }

                    break;
                case OnMvcBeforeActionEvent:
                    {
                        this.OnMvcBeforeAction(Activity.Current, payload);
                    }

                    break;
                case OnUnhandledHostingExceptionEvent:
                case OnUnHandledDiagnosticsExceptionEvent:
                    {
                        this.OnException(Activity.Current, payload);
                    }

                    break;
            }
        }

        public void OnStartActivity(Activity activity, object payload)
        {
            // The overall flow of what AspNetCore library does is as below:
            // Activity.Start()
            // DiagnosticSource.WriteEvent("Start", payload)
            // DiagnosticSource.WriteEvent("Stop", payload)
            // Activity.Stop()

            // This method is in the WriteEvent("Start", payload) path.
            // By this time, samplers have already run and
            // activity.IsAllDataRequested populated accordingly.

            if (Sdk.SuppressInstrumentation)
            {
                return;
            }

            HttpContext context = payload as HttpContext;
            if (context == null)
            {
                AspNetCoreInstrumentationEventSource.Log.NullPayload(nameof(HttpInListener), nameof(this.OnStartActivity), activity.OperationName);
                return;
            }

            // Ensure context extraction irrespective of sampling decision
            var request = context.Request;
            var textMapPropagator = Propagators.DefaultTextMapPropagator;
            if (textMapPropagator is not TraceContextPropagator)
            {
                var ctx = textMapPropagator.Extract(default, request, HttpRequestHeaderValuesGetter);

                if (ctx.ActivityContext.IsValid()
                    && ctx.ActivityContext != new ActivityContext(activity.TraceId, activity.ParentSpanId, activity.ActivityTraceFlags, activity.TraceStateString, true))
                {
                    // Create a new activity with its parent set from the extracted context.
                    // This makes the new activity as a "sibling" of the activity created by
                    // Asp.Net Core.
#if NET7_0_OR_GREATER
                    // For NET7.0 onwards activity is created using ActivitySource so,
                    // we will use the source of the activity to create the new one.
                    Activity newOne = activity.Source.CreateActivity(ActivityOperationName, ActivityKind.Server, ctx.ActivityContext);
#else
                    Activity newOne = new Activity(ActivityOperationName);
                    newOne.SetParentId(ctx.ActivityContext.TraceId, ctx.ActivityContext.SpanId, ctx.ActivityContext.TraceFlags);
#endif
                    newOne.TraceStateString = ctx.ActivityContext.TraceState;

                    newOne.SetTag("IsCreatedByInstrumentation", bool.TrueString);

                    // Starting the new activity make it the Activity.Current one.
                    newOne.Start();

                    // Set IsAllDataRequested to false for the activity created by the framework to only export the sibling activity and not the framework activity
                    activity.IsAllDataRequested = false;
                    activity = newOne;
                }

                Baggage.Current = ctx.Baggage;
            }

            // enrich Activity from payload only if sampling decision
            // is favorable.
            if (activity.IsAllDataRequested)
            {
                try
                {
                    if (this.options.Filter?.Invoke(context) == false)
                    {
                        AspNetCoreInstrumentationEventSource.Log.RequestIsFilteredOut(nameof(HttpInListener), nameof(this.OnStartActivity), activity.OperationName);
                        activity.IsAllDataRequested = false;
                        activity.ActivityTraceFlags &= ~ActivityTraceFlags.Recorded;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    AspNetCoreInstrumentationEventSource.Log.RequestFilterException(nameof(HttpInListener), nameof(this.OnStartActivity), activity.OperationName, ex);
                    activity.IsAllDataRequested = false;
                    activity.ActivityTraceFlags &= ~ActivityTraceFlags.Recorded;
                    return;
                }

#if !NET7_0_OR_GREATER
                ActivityInstrumentationHelper.SetActivitySourceProperty(activity, ActivitySource);
                ActivityInstrumentationHelper.SetKindProperty(activity, ActivityKind.Server);
#endif

                var path = (request.PathBase.HasValue || request.Path.HasValue) ? (request.PathBase + request.Path).ToString() : "/";
                activity.DisplayName = path;

                // see the spec https://github.com/open-telemetry/opentelemetry-specification/blob/v1.20.0/specification/trace/semantic_conventions/http.md
                if (this.emitOldAttributes)
                {
                    if (request.Host.HasValue)
                    {
                        activity.SetTag(SemanticConventions.AttributeNetHostName, request.Host.Host);

                        if (request.Host.Port is not null && request.Host.Port != 80 && request.Host.Port != 443)
                        {
                            activity.SetTag(SemanticConventions.AttributeNetHostPort, request.Host.Port);
                        }
                    }

                    activity.SetTag(SemanticConventions.AttributeHttpMethod, request.Method);
                    activity.SetTag(SemanticConventions.AttributeHttpScheme, request.Scheme);
                    activity.SetTag(SemanticConventions.AttributeHttpTarget, path);
                    activity.SetTag(SemanticConventions.AttributeHttpUrl, GetUri(request));
                    activity.SetTag(SemanticConventions.AttributeHttpFlavor, HttpTagHelper.GetFlavorTagValueFromProtocol(request.Protocol));

                    if (request.Headers.TryGetValue("User-Agent", out var values))
                    {
                        var userAgent = values.Count > 0 ? values[0] : null;
                        if (!string.IsNullOrEmpty(userAgent))
                        {
                            activity.SetTag(SemanticConventions.AttributeHttpUserAgent, userAgent);
                        }
                    }
                }

                // see the spec https://github.com/open-telemetry/semantic-conventions/blob/v1.21.0/docs/http/http-spans.md
                if (this.emitNewAttributes)
                {
                    if (request.Host.HasValue)
                    {
                        activity.SetTag(SemanticConventions.AttributeServerAddress, request.Host.Host);

                        if (request.Host.Port is not null && request.Host.Port != 80 && request.Host.Port != 443)
                        {
                            activity.SetTag(SemanticConventions.AttributeServerPort, request.Host.Port);
                        }
                    }

                    if (request.QueryString.HasValue)
                    {
                        // QueryString should be sanitized. see: https://github.com/open-telemetry/opentelemetry-dotnet/issues/4571
                        activity.SetTag(SemanticConventions.AttributeUrlQuery, request.QueryString.Value);
                    }

                    activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, request.Method);
                    activity.SetTag(SemanticConventions.AttributeUrlScheme, request.Scheme);
                    activity.SetTag(SemanticConventions.AttributeUrlPath, path);
                    activity.SetTag(SemanticConventions.AttributeNetworkProtocolVersion, HttpTagHelper.GetFlavorTagValueFromProtocol(request.Protocol));

                    if (request.Headers.TryGetValue("User-Agent", out var values))
                    {
                        var userAgent = values.Count > 0 ? values[0] : null;
                        if (!string.IsNullOrEmpty(userAgent))
                        {
                            activity.SetTag(SemanticConventions.AttributeUserAgentOriginal, userAgent);
                        }
                    }
                }

                try
                {
                    this.options.EnrichWithHttpRequest?.Invoke(activity, request);
                }
                catch (Exception ex)
                {
                    AspNetCoreInstrumentationEventSource.Log.EnrichmentException(nameof(HttpInListener), nameof(this.OnStartActivity), activity.OperationName, ex);
                }
            }
        }

        public void OnStopActivity(Activity activity, object payload)
        {
            if (activity.IsAllDataRequested)
            {
                HttpContext context = payload as HttpContext;
                if (context == null)
                {
                    AspNetCoreInstrumentationEventSource.Log.NullPayload(nameof(HttpInListener), nameof(this.OnStopActivity), activity.OperationName);
                    return;
                }

                var response = context.Response;

                if (this.emitOldAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeHttpStatusCode, TelemetryHelper.GetBoxedStatusCode(response.StatusCode));
                }

                if (this.emitNewAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, TelemetryHelper.GetBoxedStatusCode(response.StatusCode));
                }

#if !NETSTANDARD2_0
                if (this.options.EnableGrpcAspNetCoreSupport && TryGetGrpcMethod(activity, out var grpcMethod))
                {
                    this.AddGrpcAttributes(activity, grpcMethod, context);
                }
                else if (activity.Status == ActivityStatusCode.Unset)
                {
                    activity.SetStatus(SpanHelper.ResolveSpanStatusForHttpStatusCode(activity.Kind, response.StatusCode));
                }
#else
                if (activity.Status == ActivityStatusCode.Unset)
                {
                    activity.SetStatus(SpanHelper.ResolveSpanStatusForHttpStatusCode(activity.Kind, response.StatusCode));
                }
#endif

                try
                {
                    this.options.EnrichWithHttpResponse?.Invoke(activity, response);
                }
                catch (Exception ex)
                {
                    AspNetCoreInstrumentationEventSource.Log.EnrichmentException(nameof(HttpInListener), nameof(this.OnStopActivity), activity.OperationName, ex);
                }
            }

#if NET7_0_OR_GREATER
            var tagValue = activity.GetTagValue("IsCreatedByInstrumentation");
            if (ReferenceEquals(tagValue, bool.TrueString))
#else
            if (activity.TryCheckFirstTag("IsCreatedByInstrumentation", out var tagValue) && ReferenceEquals(tagValue, bool.TrueString))
#endif
            {
                // If instrumentation started a new Activity, it must
                // be stopped here.
                activity.SetTag("IsCreatedByInstrumentation", null);
                activity.Stop();

                // After the activity.Stop() code, Activity.Current becomes null.
                // If Asp.Net Core uses Activity.Current?.Stop() - it'll not stop the activity
                // it created.
                // Currently Asp.Net core does not use Activity.Current, instead it stores a
                // reference to its activity, and calls .Stop on it.

                // TODO: Should we still restore Activity.Current here?
                // If yes, then we need to store the asp.net core activity inside
                // the one created by the instrumentation.
                // And retrieve it here, and set it to Current.
            }
        }

        public void OnMvcBeforeAction(Activity activity, object payload)
        {
            // We cannot rely on Activity.Current here
            // There could be activities started by middleware
            // after activity started by framework resulting in different Activity.Current.
            // so, we need to first find the activity started by Asp.Net Core.
            // For .net6.0 onwards we could use IHttpActivityFeature to get the activity created by framework
            // var httpActivityFeature = context.Features.Get<IHttpActivityFeature>();
            // activity = httpActivityFeature.Activity;
            // However, this will not work as in case of custom propagator
            // we start a new activity during onStart event which is a sibling to the activity created by framework
            // So, in that case we need to get the activity created by us here.
            // we can do so only by looping through activity.Parent chain.
            while (activity != null)
            {
                if (string.Equals(activity.OperationName, ActivityOperationName, StringComparison.Ordinal))
                {
                    break;
                }

                activity = activity.Parent;
            }

            if (activity == null)
            {
                return;
            }

            if (activity.IsAllDataRequested)
            {
#if !NET6_0_OR_GREATER
                _ = this.beforeActionActionDescriptorFetcher.TryFetch(payload, out var actionDescriptor);
                _ = this.beforeActionAttributeRouteInfoFetcher.TryFetch(actionDescriptor, out var attributeRouteInfo);
                _ = this.beforeActionTemplateFetcher.TryFetch(attributeRouteInfo, out var template);
#else
                var beforeActionEventData = payload as BeforeActionEventData;
                var template = beforeActionEventData.ActionDescriptor?.AttributeRouteInfo?.Template;
#endif
                if (!string.IsNullOrEmpty(template))
                {
                    // override the span name that was previously set to the path part of URL.
                    activity.DisplayName = template;
                    activity.SetTag(SemanticConventions.AttributeHttpRoute, template);
                }

                // TODO: Should we get values from RouteData?
                // private readonly PropertyFetcher beforeActionRouteDataFetcher = new PropertyFetcher("routeData");
                // var routeData = this.beforeActionRouteDataFetcher.Fetch(payload) as RouteData;
            }
        }

        public void OnException(Activity activity, object payload)
        {
            if (activity.IsAllDataRequested)
            {
                // We need to use reflection here as the payload type is not a defined public type.
                if (!this.stopExceptionFetcher.TryFetch(payload, out Exception exc) || exc == null)
                {
                    AspNetCoreInstrumentationEventSource.Log.NullPayload(nameof(HttpInListener), nameof(this.OnException), activity.OperationName);
                    return;
                }

                if (this.options.RecordException)
                {
                    activity.RecordException(exc);
                }

                activity.SetStatus(ActivityStatusCode.Error, exc.Message);

                try
                {
                    this.options.EnrichWithException?.Invoke(activity, exc);
                }
                catch (Exception ex)
                {
                    AspNetCoreInstrumentationEventSource.Log.EnrichmentException(nameof(HttpInListener), nameof(this.OnException), activity.OperationName, ex);
                }
            }
        }

        private static string GetUri(HttpRequest request)
        {
            // this follows the suggestions from https://github.com/dotnet/aspnetcore/issues/28906
            var scheme = request.Scheme ?? string.Empty;

            // HTTP 1.0 request with NO host header would result in empty Host.
            // Use placeholder to avoid incorrect URL like "http:///"
            var host = request.Host.Value ?? UnknownHostName;
            var pathBase = request.PathBase.Value ?? string.Empty;
            var path = request.Path.Value ?? string.Empty;
            var queryString = request.QueryString.Value ?? string.Empty;
            var length = scheme.Length + Uri.SchemeDelimiter.Length + host.Length + pathBase.Length
                         + path.Length + queryString.Length;

#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            return string.Create(length, (scheme, host, pathBase, path, queryString), (span, parts) =>
            {
                CopyTo(ref span, parts.scheme);
                CopyTo(ref span, Uri.SchemeDelimiter);
                CopyTo(ref span, parts.host);
                CopyTo(ref span, parts.pathBase);
                CopyTo(ref span, parts.path);
                CopyTo(ref span, parts.queryString);

                static void CopyTo(ref Span<char> buffer, ReadOnlySpan<char> text)
                {
                    if (!text.IsEmpty)
                    {
                        text.CopyTo(buffer);
                        buffer = buffer.Slice(text.Length);
                    }
                }
            });
#else
            return new System.Text.StringBuilder(length)
                .Append(scheme)
                .Append(Uri.SchemeDelimiter)
                .Append(host)
                .Append(pathBase)
                .Append(path)
                .Append(queryString)
                .ToString();
#endif
        }

#if !NETSTANDARD2_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetGrpcMethod(Activity activity, out string grpcMethod)
        {
            grpcMethod = GrpcTagHelper.GetGrpcMethodFromActivity(activity);
            return !string.IsNullOrEmpty(grpcMethod);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddGrpcAttributes(Activity activity, string grpcMethod, HttpContext context)
        {
            // The RPC semantic conventions indicate the span name
            // should not have a leading forward slash.
            // https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/rpc.md#span-name
            activity.DisplayName = grpcMethod.TrimStart('/');

            activity.SetTag(SemanticConventions.AttributeRpcSystem, GrpcTagHelper.RpcSystemGrpc);

            if (this.emitOldAttributes)
            {
                if (context.Connection.RemoteIpAddress != null)
                {
                    // TODO: This attribute was changed in v1.13.0 https://github.com/open-telemetry/opentelemetry-specification/pull/2614
                    activity.SetTag(SemanticConventions.AttributeNetPeerIp, context.Connection.RemoteIpAddress.ToString());
                }

                activity.SetTag(SemanticConventions.AttributeNetPeerPort, context.Connection.RemotePort);
            }

            // see the spec https://github.com/open-telemetry/semantic-conventions/blob/v1.21.0/docs/rpc/rpc-spans.md
            if (this.emitNewAttributes)
            {
                if (context.Connection.RemoteIpAddress != null)
                {
                    activity.SetTag(SemanticConventions.AttributeClientAddress, context.Connection.RemoteIpAddress.ToString());
                }

                activity.SetTag(SemanticConventions.AttributeClientPort, context.Connection.RemotePort);
            }

            bool validConversion = GrpcTagHelper.TryGetGrpcStatusCodeFromActivity(activity, out int status);
            if (validConversion)
            {
                activity.SetStatus(GrpcTagHelper.ResolveSpanStatusForGrpcStatusCode(status));
            }

            if (GrpcTagHelper.TryParseRpcServiceAndRpcMethod(grpcMethod, out var rpcService, out var rpcMethod))
            {
                activity.SetTag(SemanticConventions.AttributeRpcService, rpcService);
                activity.SetTag(SemanticConventions.AttributeRpcMethod, rpcMethod);

                // Remove the grpc.method tag added by the gRPC .NET library
                activity.SetTag(GrpcTagHelper.GrpcMethodTagName, null);

                // Remove the grpc.status_code tag added by the gRPC .NET library
                activity.SetTag(GrpcTagHelper.GrpcStatusCodeTagName, null);

                if (validConversion)
                {
                    // setting rpc.grpc.status_code
                    activity.SetTag(SemanticConventions.AttributeRpcGrpcStatusCode, status);
                }
            }
        }
#endif
    }
}
