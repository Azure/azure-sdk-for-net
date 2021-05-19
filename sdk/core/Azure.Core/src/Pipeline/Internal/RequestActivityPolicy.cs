// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class RequestActivityPolicy : HttpPipelinePolicy
    {
        private readonly bool _isDistributedTracingEnabled;
        private readonly string? _resourceProviderNamespace;

        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";
        private const string RequestIdHeaderName = "Request-Id";

        private static readonly DiagnosticListener s_diagnosticSource = new DiagnosticListener("Azure.Core");

        public RequestActivityPolicy(bool isDistributedTracingEnabled, string? resourceProviderNamespace)
        {
            _isDistributedTracingEnabled = isDistributedTracingEnabled;
            _resourceProviderNamespace = resourceProviderNamespace;
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!_isDistributedTracingEnabled ||
                !s_diagnosticSource.IsEnabled())
            {
                return ProcessNextAsync(message, pipeline, true);
            }

            return ProcessAsync(message, pipeline, true);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!_isDistributedTracingEnabled ||
                !s_diagnosticSource.IsEnabled())
            {
                ProcessNextAsync(message, pipeline, false).EnsureCompleted();
                return;
            }

            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            var activity = new Activity("Azure.Core.Http.Request");
            activity.AddTag("http.method", message.Request.Method.Method);
            activity.AddTag("http.url", message.Request.Uri.ToString());
            activity.AddTag("requestId", message.Request.ClientRequestId);
            activity.AddTag("kind", "client");

            if (_resourceProviderNamespace != null)
            {
                activity.AddTag("az.namespace", _resourceProviderNamespace);
            }

            if (message.Request.Headers.TryGetValue("User-Agent", out string? userAgent))
            {
                activity.AddTag("http.user_agent", userAgent);
            }

            var diagnosticSourceActivityEnabled = s_diagnosticSource.IsEnabled(activity.OperationName, message);

            if (diagnosticSourceActivityEnabled)
            {
                s_diagnosticSource.StartActivity(activity, message);
            }
            else
            {
                activity.Start();
            }

            try
            {
                if (async)
                {
                    await ProcessNextAsync(message, pipeline, true).ConfigureAwait(false);
                }
                else
                {
                    ProcessNextAsync(message, pipeline, false).EnsureCompleted();
                }

                activity.AddTag("http.status_code", message.Response.Status.ToString(CultureInfo.InvariantCulture));
                activity.AddTag("serviceRequestId", message.Response.Headers.RequestId);
            }
            finally
            {
                if (diagnosticSourceActivityEnabled)
                {
                    s_diagnosticSource.StopActivity(activity, message);
                }
                else
                {
                    activity.Stop();
                }
            }
        }

        private static ValueTask ProcessNextAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            Activity? currentActivity = Activity.Current;

            if (currentActivity != null)
            {
                var currentActivityId = currentActivity.Id ?? string.Empty;

                if (currentActivity.IsW3CFormat())
                {
                    if (!message.Request.Headers.Contains(TraceParentHeaderName))
                    {
                        message.Request.Headers.Add(TraceParentHeaderName, currentActivityId);
                        if (currentActivity.TryGetTraceState(out string? traceStateString) && traceStateString != null)
                        {
                            message.Request.Headers.Add(TraceStateHeaderName, traceStateString);
                        }
                    }
                }
                else
                {
                    if (!message.Request.Headers.Contains(RequestIdHeaderName))
                    {
                        message.Request.Headers.Add(RequestIdHeaderName, currentActivityId);
                    }
                }
            }

            if (async)
            {
                return ProcessNextAsync(message, pipeline);
            }
            else
            {
                ProcessNext(message, pipeline);
                return default;
            }
        }
    }
}
