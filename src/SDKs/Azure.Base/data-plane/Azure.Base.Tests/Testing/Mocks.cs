// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading;
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
            _disposed = true;
            base.Dispose();
        }
    }

    public class MockTransport : HttpPipelineTransport
    {
        int[] _statusCodes;
        int _index;

        public MockTransport(params int[] statusCodes)
            => _statusCodes = statusCodes;

        public override HttpMessage CreateMessage(IServiceProvider services, CancellationToken cancellation)
            => new Message(cancellation);

        public override Task ProcessAsync(HttpMessage message)
        {
            var mockMessage = message as Message;
            if (mockMessage == null) throw new InvalidOperationException("the message is not compatible with the transport");

            mockMessage.SetStatus(_statusCodes[_index++]);
            if (_index >= _statusCodes.Length) _index = 0;
            return Task.CompletedTask;
        }

        class Message : HttpMessage
        {
            string _uri;
            int _status;
            HttpVerb _method;

            protected internal override int Status => _status;

            protected internal override Stream ResponseContentStream => throw new NotImplementedException();

            public override HttpVerb Method => throw new NotImplementedException();

            public Message(CancellationToken cancellation)
                : base(cancellation)
            { }

            public void SetStatus(int status) => _status = status;

            public override void SetRequestLine(HttpVerb method, Uri uri)
            {
                _uri = uri.ToString();
                _method = method;
            }

            public override string ToString()
                => $"{_method} {_uri}";

            protected override bool TryGetHeader(string name, out string values)
            {
                values = default;
                return false;
            }

            public override void AddHeader(HttpHeader header)
            {
            }

            public override void SetContent(HttpMessageContent content)
            {
                throw new NotImplementedException();
            }
        }
    }
}
