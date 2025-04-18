// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    internal class CloudEventRequestContent : RequestContent
    {
        private readonly IEnumerable<CloudEvent> _cloudEvents;
        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";
        private readonly bool _isDistributedTracingEnabled;
        private RequestContent _serializedContent;

        public CloudEventRequestContent(IEnumerable<CloudEvent> cloudEvents, bool isDistributedTracingEnabled)
        {
            _cloudEvents = cloudEvents;
            _isDistributedTracingEnabled = isDistributedTracingEnabled;
        }

        public CloudEventRequestContent(CloudEvent cloudEvent, bool isDistributedTracingEnabled)
        {
            _cloudEvents = [ cloudEvent ];
            _isDistributedTracingEnabled = isDistributedTracingEnabled;
        }

        public override void Dispose()
        {
        }

        public override bool TryComputeLength(out long length)
        {
            EnsureSerialized();
            return _serializedContent.TryComputeLength(out length);
        }

        public override void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            EnsureSerialized();
            _serializedContent.WriteTo(stream, cancellationToken);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            EnsureSerialized();
            await _serializedContent.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
        }

        private void EnsureSerialized()
        {
            if (_serializedContent != null)
            {
                return;
            }

            if (_isDistributedTracingEnabled)
            {
                string currentActivityId = null;
                string traceState = null;
                Activity currentActivity = Activity.Current;
                if (currentActivity != null && (currentActivity.IdFormat == ActivityIdFormat.W3C))
                {
                    currentActivityId = currentActivity.Id;
                    traceState = currentActivity.TraceStateString;
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

            _serializedContent = RequestContent.Create(_cloudEvents);
        }
    }
}
