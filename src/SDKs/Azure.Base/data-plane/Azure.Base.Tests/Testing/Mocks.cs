// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Base.Testing
{
    public class TestEventListener : EventListener
    {
        private volatile bool _disposed;
        private ConcurrentQueue<EventWrittenEventArgs> _events = new ConcurrentQueue<EventWrittenEventArgs>();

        public IEnumerable<EventWrittenEventArgs> EventData => _events;

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (!_disposed)
            {
                _events.Enqueue(eventData);
            }
        }

        public override void Dispose()
        {
<<<<<<< HEAD
            _disposed = true;
            base.Dispose();
=======
            if(eventData.EventSource.Name == SOURCE_NAME) {
                Logged.Add(eventData.EventName + " : " + eventData.Payload[0].ToString()); 
            }
>>>>>>> Updated tests to function with the .Net framework
        }
    }

    public class MockTransport : HttpPipelineTransport
    {
        int[] _statusCodes;
        int _index;

        public MockTransport(params int[] statusCodes)
            => _statusCodes = statusCodes;

        public override HttpPipelineRequest CreateRequest(IServiceProvider services)
            => new PipelineRequest();

        public override Task ProcessAsync(HttpPipelineMessage message)
        {
            var request = message.Request as PipelineRequest;
            if (request == null) throw new InvalidOperationException("the request is not compatible with the transport");

            if (_index >= _statusCodes.Length) _index = 0;

            var response = new PipelineResponse(request.Method, request.Uri);

            response.SetStatus(_statusCodes[_index++]);

            message.Response = response;
            return Task.CompletedTask;
        }

        class PipelineRequest : HttpPipelineRequest
        {
            public override void AddHeader(HttpHeader header)
            {
            }

            public override bool TryGetHeader(string name, out string value)
            {
                value = null;
                return false;
            }

            public override IEnumerable<HttpHeader> Headers
            {
                get
                {
                    yield break;
                }
            }

            public override string ToString() => $"{Method} {Uri}";

            public override void Dispose()
            {
            }
        }

        class PipelineResponse : HttpPipelineResponse
        {
            private readonly HttpVerb _method;

            private readonly Uri _uri;

            private int _status;

            public PipelineResponse(HttpVerb method, Uri uri)
            {
                _method = method;
                _uri = uri;
            }

            public override int Status => _status;

            public override Stream ResponseContentStream => throw new NotImplementedException();

            public void SetStatus(int status) => _status = status;

            public override string ToString() => $"{_method} {_uri}";

            public override bool TryGetHeader(string name, out string value)
            {
                value = default;
                return false;
            }

            public override IEnumerable<HttpHeader> Headers
            {
                get
                {
                    yield break;
                }
            }

            public override void Dispose()
            {
            }
        }
    }
}
