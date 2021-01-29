﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private static readonly object? s_activitySource = ActivityExtensions.CreateActivitySource("Azure.Core.Http");

        public RequestActivityPolicy(bool isDistributedTracingEnabled, string? resourceProviderNamespace)
        {
            _isDistributedTracingEnabled = isDistributedTracingEnabled;
            _resourceProviderNamespace = resourceProviderNamespace;
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!ShouldCreateActivity)
            {
                return ProcessNextAsync(message, pipeline, true);
            }

            return ProcessAsync(message, pipeline, true);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!ShouldCreateActivity)
            {
                ProcessNextAsync(message, pipeline, false).EnsureCompleted();
                return;
            }

            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            using var scope = new DiagnosticScope("Azure.Core.Http.Request", "Request", s_diagnosticSource, message, s_activitySource, DiagnosticScope.ActivityKind.Client);
            scope.AddAttribute("http.method", message.Request.Method.Method);
            scope.AddAttribute("http.url", message.Request.Uri.ToString());
            scope.AddAttribute("requestId", message.Request.ClientRequestId);

            if (_resourceProviderNamespace != null)
            {
                scope.AddAttribute("az.namespace", _resourceProviderNamespace);
            }

            if (message.Request.Headers.TryGetValue("User-Agent", out string? userAgent))
            {
                scope.AddAttribute("http.user_agent", userAgent);
            }

            scope.Start();

            if (async)
            {
                await ProcessNextAsync(message, pipeline, true).ConfigureAwait(false);
            }
            else
            {
                ProcessNextAsync(message, pipeline, false).EnsureCompleted();
            }

            scope.AddAttribute("http.status_code", message.Response.Status, static i => i.ToString(CultureInfo.InvariantCulture));
            if (message.Response.Headers.RequestId is string serviceRequestId)
            {
                scope.AddAttribute("serviceRequestId", serviceRequestId);
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
                        if (currentActivity.GetTraceState() is string traceStateString)
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

        private bool ShouldCreateActivity =>
            _isDistributedTracingEnabled &&
            (s_diagnosticSource.IsEnabled() || ActivityExtensions.ActivitySourceHasListeners(s_activitySource));
    }
}
