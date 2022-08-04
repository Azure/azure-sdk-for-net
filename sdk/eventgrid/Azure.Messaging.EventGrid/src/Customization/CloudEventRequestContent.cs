// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.EventGrid
{
    internal class CloudEventRequestContent : RequestContent
    {
        private readonly IEnumerable<CloudEvent> _cloudEvents;
        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";
        private readonly bool _isDistributedTracingEnabled;
        private byte[] _data;

        public CloudEventRequestContent(IEnumerable<CloudEvent> cloudEvents, bool isDistributedTracingEnabled)
        {
            _cloudEvents = cloudEvents;
            _isDistributedTracingEnabled = isDistributedTracingEnabled;
        }

        public override void Dispose()
        {
        }

        public override bool TryComputeLength(out long length)
        {
            EnsureSerialized();
            length = _data.Length;
            return true;
        }

        public override void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            EnsureSerialized();
            stream.Write(_data, 0, _data.Length);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            EnsureSerialized();
            await stream.WriteAsync(_data, 0, _data.Length, cancellationToken).ConfigureAwait(false);
        }

        private void EnsureSerialized()
        {
            if (_data != null)
            {
                return;
            }

            if (_isDistributedTracingEnabled)
            {
                string currentActivityId = null;
                string traceState = null;
                Activity currentActivity = Activity.Current;
                if (currentActivity != null && currentActivity.IsW3CFormat())
                {
                    currentActivityId = currentActivity.Id;
                    traceState = currentActivity.GetTraceState();
                }

                foreach (CloudEvent cloudEvent in _cloudEvents)
                {
                    if (currentActivityId != null &&
                        !cloudEvent.ExtensionAttributes.ContainsKey(TraceParentHeaderName) &&
                        !cloudEvent.ExtensionAttributes.ContainsKey(TraceStateHeaderName))
                    {
                        cloudEvent.ExtensionAttributes.Add(TraceParentHeaderName, currentActivityId);
                        if (traceState != null)
                        {
                            cloudEvent.ExtensionAttributes.Add(TraceStateHeaderName, traceState);
                        }
                    }
                }
            }
            _data = JsonSerializer.SerializeToUtf8Bytes(_cloudEvents, typeof(IEnumerable<CloudEvent>));
        }
    }
}
