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
        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";
        private const string RequestIdHeaderName = "Request-Id";

        public static RequestActivityPolicy Shared { get; } = new RequestActivityPolicy();

        private static readonly DiagnosticListener s_diagnosticSource = new DiagnosticListener("Azure.Pipeline");

        public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private static async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool isAsync)
        {
            if (!s_diagnosticSource.IsEnabled())
            {
                await ProcessNextAsync(message, pipeline, isAsync).ConfigureAwait(false);

                return;
            }

            var activity = new Activity("Azure.Core.Http.Request");
            activity.AddTag("http.method", message.Request.Method.Method);
            activity.AddTag("http.url", message.Request.UriBuilder.ToString());
            if (message.Request.Headers.TryGetValue("User-Agent", out string userAgent))
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


            if (isAsync)
            {
                await ProcessNextAsync(message, pipeline, true).ConfigureAwait(false);
            }
            else
            {
                ProcessNextAsync(message, pipeline, false).EnsureCompleted();
            }

            activity.AddTag("http.status_code", message.Response.Status.ToString(CultureInfo.InvariantCulture));

            if (diagnosticSourceActivityEnabled)
            {
                s_diagnosticSource.StopActivity(activity, message);
            }
            else
            {
                activity.Stop();
            }
        }

        private static async Task ProcessNextAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool isAsync)
        {
            var currentActivity = Activity.Current;

            if (currentActivity != null)
            {
                if (currentActivity.IdFormat == ActivityIdFormat.W3C)
                {
                    if (!message.Request.Headers.Contains(TraceParentHeaderName))
                    {
                        message.Request.Headers.Add(TraceParentHeaderName, currentActivity.Id);
                        if (currentActivity.TraceStateString != null)
                        {
                            message.Request.Headers.Add(TraceStateHeaderName, currentActivity.TraceStateString);
                        }
                    }
                }
                else
                {
                    if (!message.Request.Headers.Contains(RequestIdHeaderName))
                    {
                        message.Request.Headers.Add(RequestIdHeaderName, currentActivity.Id);
                    }
                }
            }

            if (isAsync)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }
        }
    }
}
