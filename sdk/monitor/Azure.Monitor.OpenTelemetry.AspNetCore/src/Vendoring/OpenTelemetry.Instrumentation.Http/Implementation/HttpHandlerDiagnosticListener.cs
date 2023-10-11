// <copyright file="HttpHandlerDiagnosticListener.cs" company="OpenTelemetry Authors">
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
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
#if NETFRAMEWORK
using System.Net.Http;
#endif
using System.Reflection;
using System.Threading.Tasks;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Trace;
using static OpenTelemetry.Internal.HttpSemanticConventionHelper;

namespace OpenTelemetry.Instrumentation.Http.Implementation
{
    internal sealed class HttpHandlerDiagnosticListener : ListenerHandler
    {
        internal static readonly AssemblyName AssemblyName = typeof(HttpHandlerDiagnosticListener).Assembly.GetName();
        internal static readonly bool IsNet7OrGreater;

        // https://github.com/dotnet/runtime/blob/7d034ddbbbe1f2f40c264b323b3ed3d6b3d45e9a/src/libraries/System.Net.Http/src/System/Net/Http/DiagnosticsHandler.cs#L19
        internal static readonly string HttpClientActivitySourceName = "System.Net.Http";
        internal static readonly string ActivitySourceName = AssemblyName.Name + ".HttpClient";
        internal static readonly Version Version = AssemblyName.Version;
        internal static readonly ActivitySource ActivitySource = new(ActivitySourceName, Version.ToString());

        private const string OnStartEvent = "System.Net.Http.HttpRequestOut.Start";
        private const string OnStopEvent = "System.Net.Http.HttpRequestOut.Stop";
        private const string OnUnhandledExceptionEvent = "System.Net.Http.Exception";

        private readonly PropertyFetcher<HttpRequestMessage> startRequestFetcher = new("Request");
        private readonly PropertyFetcher<HttpResponseMessage> stopResponseFetcher = new("Response");
        private readonly PropertyFetcher<Exception> stopExceptionFetcher = new("Exception");
        private readonly PropertyFetcher<TaskStatus> stopRequestStatusFetcher = new("RequestTaskStatus");
        private readonly HttpClientInstrumentationOptions options;
        private readonly bool emitOldAttributes;
        private readonly bool emitNewAttributes;

        static HttpHandlerDiagnosticListener()
        {
            try
            {
                IsNet7OrGreater = typeof(HttpClient).Assembly.GetName().Version.Major >= 7;
            }
            catch (Exception)
            {
                IsNet7OrGreater = false;
            }
        }

        public HttpHandlerDiagnosticListener(HttpClientInstrumentationOptions options)
            : base("HttpHandlerDiagnosticListener")
        {
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
                case OnUnhandledExceptionEvent:
                    {
                        this.OnException(Activity.Current, payload);
                    }

                    break;
            }
        }

        public void OnStartActivity(Activity activity, object payload)
        {
            // The overall flow of what HttpClient library does is as below:
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

            if (!this.startRequestFetcher.TryFetch(payload, out HttpRequestMessage request) || request == null)
            {
                HttpInstrumentationEventSource.Log.NullPayload(nameof(HttpHandlerDiagnosticListener), nameof(this.OnStartActivity));
                return;
            }

            // Propagate context irrespective of sampling decision
            var textMapPropagator = Propagators.DefaultTextMapPropagator;
            if (textMapPropagator is not TraceContextPropagator)
            {
                textMapPropagator.Inject(new PropagationContext(activity.Context, Baggage.Current), request, HttpRequestMessageContextPropagation.HeaderValueSetter);
            }

            // For .NET7.0 or higher versions, activity is created using activity source.
            // However the framework will fallback to creating activity if the sampler's decision is to drop and there is a active diagnostic listener.
            // To prevent processing such activities we first check the source name to confirm if it was created using
            // activity source or not.
            if (IsNet7OrGreater && string.IsNullOrEmpty(activity.Source.Name))
            {
                activity.IsAllDataRequested = false;
            }

            // enrich Activity from payload only if sampling decision
            // is favorable.
            if (activity.IsAllDataRequested)
            {
                try
                {
                    if (this.options.EventFilterHttpRequestMessage(activity.OperationName, request) == false)
                    {
                        HttpInstrumentationEventSource.Log.RequestIsFilteredOut(activity.OperationName);
                        activity.IsAllDataRequested = false;
                        activity.ActivityTraceFlags &= ~ActivityTraceFlags.Recorded;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    HttpInstrumentationEventSource.Log.RequestFilterException(ex);
                    activity.IsAllDataRequested = false;
                    activity.ActivityTraceFlags &= ~ActivityTraceFlags.Recorded;
                    return;
                }

                activity.DisplayName = HttpTagHelper.GetOperationNameForHttpMethod(request.Method);

                if (!IsNet7OrGreater)
                {
                    ActivityInstrumentationHelper.SetActivitySourceProperty(activity, ActivitySource);
                    ActivityInstrumentationHelper.SetKindProperty(activity, ActivityKind.Client);
                }

                // see the spec https://github.com/open-telemetry/opentelemetry-specification/blob/v1.20.0/specification/trace/semantic_conventions/http.md
                if (this.emitOldAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeHttpScheme, request.RequestUri.Scheme);
                    activity.SetTag(SemanticConventions.AttributeHttpMethod, HttpTagHelper.GetNameForHttpMethod(request.Method));
                    activity.SetTag(SemanticConventions.AttributeNetPeerName, request.RequestUri.Host);
                    if (!request.RequestUri.IsDefaultPort)
                    {
                        activity.SetTag(SemanticConventions.AttributeNetPeerPort, request.RequestUri.Port);
                    }

                    activity.SetTag(SemanticConventions.AttributeHttpUrl, HttpTagHelper.GetUriTagValueFromRequestUri(request.RequestUri));
                    activity.SetTag(SemanticConventions.AttributeHttpFlavor, HttpTagHelper.GetFlavorTagValueFromProtocolVersion(request.Version));
                }

                // see the spec https://github.com/open-telemetry/semantic-conventions/blob/v1.21.0/docs/http/http-spans.md
                if (this.emitNewAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, HttpTagHelper.GetNameForHttpMethod(request.Method));
                    activity.SetTag(SemanticConventions.AttributeServerAddress, request.RequestUri.Host);
                    if (!request.RequestUri.IsDefaultPort)
                    {
                        activity.SetTag(SemanticConventions.AttributeServerPort, request.RequestUri.Port);
                    }

                    activity.SetTag(SemanticConventions.AttributeUrlFull, HttpTagHelper.GetUriTagValueFromRequestUri(request.RequestUri));
                    activity.SetTag(SemanticConventions.AttributeNetworkProtocolVersion, HttpTagHelper.GetFlavorTagValueFromProtocolVersion(request.Version));

                    if (request.Headers.TryGetValues("User-Agent", out var userAgentValues))
                    {
                        var userAgent = userAgentValues.FirstOrDefault();
                        if (!string.IsNullOrEmpty(userAgent))
                        {
                            activity.SetTag(SemanticConventions.AttributeHttpUserAgent, userAgent);
                        }
                    }
                }

                try
                {
                    this.options.EnrichWithHttpRequestMessage?.Invoke(activity, request);
                }
                catch (Exception ex)
                {
                    HttpInstrumentationEventSource.Log.EnrichmentException(ex);
                }
            }
        }

        public void OnStopActivity(Activity activity, object payload)
        {
            if (activity.IsAllDataRequested)
            {
                // https://github.com/dotnet/runtime/blob/master/src/libraries/System.Net.Http/src/System/Net/Http/DiagnosticsHandler.cs
                // requestTaskStatus is not null
                _ = this.stopRequestStatusFetcher.TryFetch(payload, out var requestTaskStatus);

                ActivityStatusCode currentStatusCode = activity.Status;
                if (requestTaskStatus != TaskStatus.RanToCompletion)
                {
                    if (requestTaskStatus == TaskStatus.Canceled)
                    {
                        if (currentStatusCode == ActivityStatusCode.Unset)
                        {
                            activity.SetStatus(ActivityStatusCode.Error);
                        }
                    }
                    else if (requestTaskStatus != TaskStatus.Faulted)
                    {
                        if (currentStatusCode == ActivityStatusCode.Unset)
                        {
                            // Faults are handled in OnException and should already have a span.Status of Error w/ Description.
                            activity.SetStatus(ActivityStatusCode.Error);
                        }
                    }
                }

                if (this.stopResponseFetcher.TryFetch(payload, out HttpResponseMessage response) && response != null)
                {
                    if (this.emitOldAttributes)
                    {
                        activity.SetTag(SemanticConventions.AttributeHttpStatusCode, TelemetryHelper.GetBoxedStatusCode(response.StatusCode));
                    }

                    if (this.emitNewAttributes)
                    {
                        activity.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, TelemetryHelper.GetBoxedStatusCode(response.StatusCode));
                    }

                    if (currentStatusCode == ActivityStatusCode.Unset)
                    {
                        activity.SetStatus(SpanHelper.ResolveSpanStatusForHttpStatusCode(activity.Kind, (int)response.StatusCode));
                    }

                    try
                    {
                        this.options.EnrichWithHttpResponseMessage?.Invoke(activity, response);
                    }
                    catch (Exception ex)
                    {
                        HttpInstrumentationEventSource.Log.EnrichmentException(ex);
                    }
                }
            }
        }

        public void OnException(Activity activity, object payload)
        {
            if (activity.IsAllDataRequested)
            {
                if (!this.stopExceptionFetcher.TryFetch(payload, out Exception exc) || exc == null)
                {
                    HttpInstrumentationEventSource.Log.NullPayload(nameof(HttpHandlerDiagnosticListener), nameof(this.OnException));
                    return;
                }

                if (this.options.RecordException)
                {
                    activity.RecordException(exc);
                }

                if (exc is HttpRequestException)
                {
                    activity.SetStatus(ActivityStatusCode.Error, exc.Message);
                }

                try
                {
                    this.options.EnrichWithException?.Invoke(activity, exc);
                }
                catch (Exception ex)
                {
                    HttpInstrumentationEventSource.Log.EnrichmentException(ex);
                }
            }
        }
    }
}
