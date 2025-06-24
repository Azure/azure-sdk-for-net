// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Benchmarks.Local
{
    /// <summary>
    /// This benchmark tests the performance of the Azure.Core.Diagnostics.EventSource.
    /// </summary>
    public class EventSourceScenario
    {
        private AzureEventSourceListener _sourceListener;
        private CustomEventSource _eventSource;
        private string _sanitizedUri;
        private byte[] _headersBytes;
        private int _iteration;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSourceScenario"/> class.
        /// </summary>
        /// <param name="sanitizedUri">The sanitized URI to be used in the benchmark.</param>
        /// <param name="headersBytes">The headers in byte array format.</param>
        public EventSourceScenario(string sanitizedUri, byte[] headersBytes)
        {
            _sourceListener = new AzureEventSourceListener(_ => { }, EventLevel.LogAlways);
            _eventSource = new CustomEventSource();
            _sourceListener.EnableEvents(_eventSource, EventLevel.LogAlways);
            _sanitizedUri = sanitizedUri;
            _headersBytes = headersBytes;
        }

        /// <summary>
        /// Runs the old version of the event source request.
        /// </summary>
        /// <param name="uri">The URI for the request.</param>
        /// <param name="headers">The headers in byte array format.</param>
        public void RunOld(string uri, byte[] headers)
        {
            _eventSource.RequestOld(uri, _iteration++, _iteration, headers);
        }

        /// <summary>
        /// Runs the new version of the event source request.
        /// </summary>
        /// <param name="uri">The URI for the request.</param>
        /// <param name="headers">The headers in byte array format.</param>
        public void RunNew(string uri, byte[] headers)
        {
            _eventSource.RequestNew(uri, _iteration++, _iteration, headers);
        }

        /// <summary>
        /// Runs the new version of the event source request with preformatted data.
        /// </summary>
        public void RunNewPreformatted()
        {
            _eventSource.RequestNew(_sanitizedUri, _iteration++, _iteration, _headersBytes);
        }

        /// <summary>
        /// Disposes the resources used by the <see cref="EventSourceScenario"/> instance.
        /// </summary>
        public void Dispose()
        {
            _sourceListener.Dispose();
            _eventSource.Dispose();
        }
    }
}
