// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Proxy.OpenAILike.Mocks
{
    /// <summary>
    /// A tiny self-contained <see cref="PipelineTransport"/> that returns a fixed, "canned" response
    /// body for every request — the equivalent of mocking the service response. Used by both the
    /// end-to-end tests and the runnable console program so a real <see cref="ClientPipeline"/> can be
    /// exercised without a network call. This is test scaffolding, not part of the mock library's API.
    /// </summary>
    public sealed class CannedResponseTransport : PipelineTransport
    {
        private readonly byte[] _body;
        private readonly int _status;

        /// <summary>Creates a transport that answers every request with <paramref name="responseBody"/>.</summary>
        public CannedResponseTransport(string responseBody, int status = 200)
        {
            _body = Encoding.UTF8.GetBytes(responseBody);
            _status = status;
        }

        protected override PipelineMessage CreateMessageCore() => new CannedMessage();

        protected override void ProcessCore(PipelineMessage message)
            => ((CannedMessage)message).SetResponse(new CannedResponse(_status, _body));

        protected override ValueTask ProcessCoreAsync(PipelineMessage message)
        {
            ProcessCore(message);
            return new ValueTask();
        }

        private sealed class CannedMessage : PipelineMessage
        {
            public CannedMessage() : base(new CannedRequest()) { }
            public void SetResponse(PipelineResponse response) => Response = response;
        }

        private sealed class CannedRequest : PipelineRequest
        {
            private readonly PipelineRequestHeaders _headers = new CannedRequestHeaders();
            private string _method = "GET";
            private Uri? _uri;
            private BinaryContent? _content;

            protected override string MethodCore { get => _method; set => _method = value; }
            protected override Uri? UriCore { get => _uri; set => _uri = value; }
            protected override BinaryContent? ContentCore { get => _content; set => _content = value; }
            protected override PipelineRequestHeaders HeadersCore => _headers;
            public override void Dispose() => _content?.Dispose();
        }

        private sealed class CannedResponse : PipelineResponse
        {
            private readonly PipelineResponseHeaders _headers = new CannedResponseHeaders();
            private Stream? _contentStream;
            private readonly BinaryData _content;

            public CannedResponse(int status, byte[] body)
            {
                Status = status;
                _contentStream = new MemoryStream(body, 0, body.Length, writable: false, publiclyVisible: true);
                _content = new BinaryData(body);
            }

            public override int Status { get; }
            public override string ReasonPhrase => "OK";
            public override Stream? ContentStream { get => _contentStream; set => _contentStream = value; }
            public override BinaryData Content => _content;
            protected override PipelineResponseHeaders HeadersCore => _headers;

            public override BinaryData BufferContent(CancellationToken cancellationToken = default) => _content;
            public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
                => new ValueTask<BinaryData>(_content);

            public override void Dispose()
            {
                _contentStream?.Dispose();
                _contentStream = null;
            }
        }

        private sealed class CannedRequestHeaders : PipelineRequestHeaders
        {
            private readonly Dictionary<string, string> _headers = new();
            public override void Add(string name, string value)
                => _headers[name] = _headers.TryGetValue(name, out var v) ? v + "," + value : value;
            public override void Set(string name, string value) => _headers[name] = value;
            public override bool Remove(string name) => _headers.Remove(name);
            public override bool TryGetValue(string name, out string? value) => _headers.TryGetValue(name, out value);
            public override bool TryGetValues(string name, out IEnumerable<string>? values)
            {
                if (_headers.TryGetValue(name, out var v) && !string.IsNullOrEmpty(v)) { values = v.Split(','); return true; }
                values = null; return false;
            }
            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _headers.GetEnumerator();
        }

        private sealed class CannedResponseHeaders : PipelineResponseHeaders
        {
            private readonly Dictionary<string, string> _headers = new();
            public override bool TryGetValue(string name, out string? value) => _headers.TryGetValue(name, out value);
            public override bool TryGetValues(string name, out IEnumerable<string>? values)
            {
                if (_headers.TryGetValue(name, out var v) && !string.IsNullOrEmpty(v)) { values = v.Split(','); return true; }
                values = null; return false;
            }
            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _headers.GetEnumerator();
        }
    }
}
