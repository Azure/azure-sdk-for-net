// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline.Policies
{
    internal class RequestActivityPolicy : HttpPipelinePolicy
    {
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
                if (isAsync)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
            }

            var activity = new Activity("Azure.Core.Http.Request");
            activity.AddTag("method", message.Request.Method.Method);
            activity.AddTag("uri", message.Request.UriBuilder.ToString());

            var diagnosticSourceActivityEnabled = s_diagnosticSource.IsEnabled(activity.OperationName);

            if (diagnosticSourceActivityEnabled)
            {
                s_diagnosticSource.StartActivity(activity, null);
            }
            else
            {
                activity.Start();
            }

            if (isAsync)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            activity.AddTag("status", message.Response.Status.ToString(CultureInfo.InvariantCulture));

            if (diagnosticSourceActivityEnabled)
            {
                s_diagnosticSource.StopActivity(activity, null);
            }
            else
            {
                activity.Stop();
            }
        }
    }
}
