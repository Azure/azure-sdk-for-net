// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

namespace Azure.Messaging.EventGrid
{
    internal class CloudEventRequestContent : RequestContent
    {
        private IEnumerable<CloudEvent> _cloudEvents;
        private static readonly JsonObjectSerializer s_jsonSerializer = new JsonObjectSerializer();
        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";
        private byte[] _data;

        public CloudEventRequestContent(IEnumerable<CloudEvent> cloudEvents)
        {
            _cloudEvents = cloudEvents;
        }

        public override void Dispose()
        {
        }

        public override bool TryComputeLength(out long length)
        {
            EnsureSerializedAsync(false, CancellationToken.None).EnsureCompleted();
            length = _data.Length;
            return true;
        }

        public override void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            EnsureSerializedAsync(false, cancellationToken).EnsureCompleted();
            stream.Write(_data, 0, _data.Length);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            await EnsureSerializedAsync(true, cancellationToken).ConfigureAwait(false);
            await stream.WriteAsync(_data, 0, _data.Length, cancellationToken).ConfigureAwait(false);
        }

        private async Task EnsureSerializedAsync(bool async, CancellationToken cancellationToken)
        {
            if (_data != null)
            {
                return;
            }

            string activityId = null;
            string traceState = null;
            Activity currentActivity = Activity.Current;
            if (currentActivity != null && currentActivity.IsW3CFormat())
            {
                activityId = currentActivity.Id;
                currentActivity.TryGetTraceState(out traceState);
            }

            foreach (CloudEvent cloudEvent in _cloudEvents)
            {
                // Individual events cannot be null
                Argument.AssertNotNull(cloudEvent, nameof(cloudEvent));

                if (activityId != null &&
                    !cloudEvent.ExtensionAttributes.ContainsKey(TraceParentHeaderName) &&
                    !cloudEvent.ExtensionAttributes.ContainsKey(TraceStateHeaderName))
                {
                    cloudEvent.ExtensionAttributes.Add(TraceParentHeaderName, activityId);
                    if (traceState != null)
                    {
                        cloudEvent.ExtensionAttributes.Add(TraceStateHeaderName, traceState);
                    }
                }
            }
            if (async)
            {
                _data = (await s_jsonSerializer.SerializeAsync(_cloudEvents, typeof(List<CloudEvent>), cancellationToken).ConfigureAwait(false)).ToArray();
            }
            else
            {
                _data = s_jsonSerializer.Serialize(_cloudEvents, typeof(List<CloudEvent>), cancellationToken).ToArray();
            }
        }
    }
}
