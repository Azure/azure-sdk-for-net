// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    /// <summary>
    /// Pipeline policy that injects W3C trace context headers (traceparent, tracestate)
    /// into outgoing HTTP requests. This enables correlation between client-side and
    /// server-side spans. Optionally includes the W3C baggage header.
    /// </summary>
    internal class TraceContextPropagationPolicy : PipelinePolicy
    {
        private readonly bool _includeBaggage;

        /// <summary>
        /// Initializes a new instance of <see cref="TraceContextPropagationPolicy"/>.
        /// </summary>
        /// <param name="includeBaggage">Whether to propagate the W3C baggage header. Baggage may contain sensitive application data.</param>
        internal TraceContextPropagationPolicy(bool includeBaggage = false)
        {
            _includeBaggage = includeBaggage;
        }

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            InjectTraceContext(message);
            ProcessNext(message, pipeline, currentIndex);
        }

        public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            InjectTraceContext(message);
            return ProcessNextAsync(message, pipeline, currentIndex);
        }

        private void InjectTraceContext(PipelineMessage message)
        {
            Activity activity = Activity.Current;
            if (activity == null || activity.IdFormat != ActivityIdFormat.W3C)
            {
                return;
            }

            // Let the propagator inject all headers it knows about, then filter
            // to the W3C allow-list — same approach as the Python implementation.
            var carrier = new Dictionary<string, string>();
            DistributedContextPropagator.Current.Inject(activity, carrier, static (c, k, v) =>
                ((Dictionary<string, string>)c)[k] = v);

            foreach (KeyValuePair<string, string> entry in carrier)
            {
                string keyLower = entry.Key.ToLowerInvariant();
                if (keyLower == "traceparent" || keyLower == "tracestate")
                {
                    if (!message.Request.Headers.TryGetValue(entry.Key, out _))
                    {
                        message.Request.Headers.Set(entry.Key, entry.Value);
                    }
                }
                else if (keyLower == "baggage" && _includeBaggage)
                {
                    if (!message.Request.Headers.TryGetValue(entry.Key, out _))
                    {
                        message.Request.Headers.Set(entry.Key, entry.Value);
                    }
                }
            }
        }
    }
}
