// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Base.Testing
{
    public class TestEventListener : EventListener
    {
        const string SOURCE_NAME = "AzureSDK";

        public readonly List<string> Logged = new List<string>();
        EventLevel _enabled;
        EventSource _source;

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);
            if(eventSource.Name == SOURCE_NAME) {
                _source = eventSource;
                if(_enabled != default) {
                    EnableEvents(_source, _enabled);
                }
            }
        }

        public void EnableEvents(EventLevel level)
        {
            _enabled = level;
            if(_source != null) {
                EnableEvents(_source, _enabled);
            }

        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            base.OnEventWritten(eventData);
            if(eventData.EventSource.Name == SOURCE_NAME) {
                Logged.Add(eventData.EventName + " : " + eventData.Payload[0].ToString());
            }
        }

        public override string ToString()
            =>string.Join(" # ", Logged);
    }

    public class MockTransport : HttpPipelineTransport
    {
        int[] _statusCodes;
        int _index;

        public MockTransport(params int[] statusCodes)
            => _statusCodes = statusCodes;

        public override HttpPipelineRequest CreateRequest(IServiceProvider services)
            => new PipelineRequest();

        public override Task ProcessAsync(HttpPipelineContext pipelineContext)
        {
            var mockMessage = pipelineContext.Request as PipelineRequest;
            if (mockMessage == null) throw new InvalidOperationException("the message is not compatible with the transport");

            if (_index >= _statusCodes.Length) _index = 0;

            var response = new PipelineResponse(mockMessage.Method, mockMessage.Uri);

            response.SetStatus(_statusCodes[_index++]);

            pipelineContext.Response = response;
            return Task.CompletedTask;
        }

        class PipelineRequest : HttpPipelineRequest
        {
            private HttpVerb _method;

            public override HttpVerb Method => _method;
            public Uri Uri { get; private set; }


            public override void SetRequestLine(HttpVerb method, Uri uri)
            {
                Uri = uri;
                _method = method;
            }

            public override string ToString() => $"{_method} {Uri}";


            public override void AddHeader(HttpHeader header)
            {
            }

            public override void SetContent(HttpMessageContent content)
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

            public override bool TryGetHeader(ReadOnlySpan<byte> name, out ReadOnlySpan<byte> value)
            {
                value = default;
                return false;
            }

            public override void Dispose()
            {
            }
        }
    }
}
