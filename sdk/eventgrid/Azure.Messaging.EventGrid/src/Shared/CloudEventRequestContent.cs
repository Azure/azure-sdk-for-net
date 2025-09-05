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
        private readonly CloudEvent _cloudEvent;
        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";
        private readonly bool _isDistributedTracingEnabled;
        private RequestContent _data;

        public CloudEventRequestContent(CloudEvent cloudEvent, bool isDistributedTracingEnabled)
        {
            _cloudEvent = cloudEvent;
            _isDistributedTracingEnabled = isDistributedTracingEnabled;
        }

        public override void Dispose()
        {
        }

        public override bool TryComputeLength(out long length)
        {
            EnsureSerialized();
            return _data.TryComputeLength(out length);
        }

        public override void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            EnsureSerialized();
            _data.WriteTo(stream, cancellationToken);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            EnsureSerialized();
            await _data.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
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
                if (currentActivity != null && (currentActivity.IdFormat == ActivityIdFormat.W3C))
                {
                    currentActivityId = currentActivity.Id;
                    traceState = currentActivity.TraceStateString;
                }

                if (currentActivityId != null &&
                            !_cloudEvent.ExtensionAttributes.ContainsKey(TraceParentHeaderName) &&
                            !_cloudEvent.ExtensionAttributes.ContainsKey(TraceStateHeaderName))
                {
                    _cloudEvent.ExtensionAttributes.Add(TraceParentHeaderName, currentActivityId);
                    if (traceState != null)
                    {
                        _cloudEvent.ExtensionAttributes.Add(TraceStateHeaderName, traceState);
                    }
                }
            }

            _data = RequestContent.Create(_cloudEvent);
        }
    }
}
