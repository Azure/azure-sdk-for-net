// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Buffers;
using Azure.Core.Http.Pipeline;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Buffers.Text.Encodings;

namespace Azure.Core.Http
{
    public class SocketClientTransport : PipelineTransport
    {
        public override HttpMessage CreateMessage(PipelineOptions options, CancellationToken cancellation)
            => new SocketClientMessage(ref options, cancellation);

        public override async Task ProcessAsync(HttpMessage message)
        {
            var socketTransportMessage = message as SocketClientMessage;
            if (socketTransportMessage == null) throw new InvalidOperationException("the message is not compatible with the transport");
            await socketTransportMessage.ProcessAsync().ConfigureAwait(false);
        }

        protected class SocketClientMessage : HttpMessage
        {
            // TODO (pri 3): refactor connection cache and GC it.
            static readonly Dictionary<string, (Socket Client, SslStream Stream)> s_cache = new Dictionary<string, (Socket client, SslStream stream)>();

            Socket _socket;
            SslStream _sslStream;

            string _host;
            PipelineMethod _method;
            Sequence<byte> _requestBuffer;
            Sequence<byte> _responseBuffer;
            PipelineContent _requestContent;

            int _statusCode;
            int _headersStart;
            int _contentStart;
            bool _endOfHeadersWritten = false;

            public SocketClientMessage(ref PipelineOptions options, CancellationToken cancellation)
                : base(cancellation)
            {
                _responseBuffer = new Sequence<byte>(options.Pool);
                _requestBuffer = new Sequence<byte>(options.Pool);
            }

            public override void SetRequestLine(PipelineMethod method, Uri uri)
            {
                _method = method;
                _host = uri.Host;
                var path = uri.PathAndQuery;

                Http.WriteRequestLine(ref _requestBuffer, "https", method, Encoding.ASCII.GetBytes(path));
                AddHeader("Host", _host);
            }

            public override PipelineMethod Method => _method;

            internal virtual async Task<Sequence<byte>> ReceiveAsync(Sequence<byte> buffer)
                => await _sslStream.ReadAsync(buffer, Cancellation).ConfigureAwait(false);

            public async Task ProcessAsync()
            {
                if (_requestContent.TryComputeLength(out long len))
                {
                    AddHeader(HttpHeader.Common.CreateContentLength(len));
                }

                // this is needed so the retry does not add this again
                if (!_endOfHeadersWritten) AddEndOfHeaders();
                               
                await SendAsync(_requestBuffer.AsReadOnly()).ConfigureAwait(false);
     
                while (true)
                {
                    _responseBuffer = await ReceiveAsync(_responseBuffer).ConfigureAwait(false);
                    OperationStatus result = Http.ParseResponse(_responseBuffer, out _statusCode, out _headersStart, out _contentStart);
                    if (result == OperationStatus.Done) break;
                    if (result == OperationStatus.NeedMoreData) continue;
                    throw new Exception("invalid response");
                }
            }

            protected virtual async Task SendAsync(ReadOnlySequence<byte> buffer)
            {
                if (_socket == null) // i.e. this is not a retry  
                {
                    if (s_cache.TryGetValue(_host, out var connection))
                    {
                        // TODO (pri 1): this needs to use a real pool and take the connection out, as of now it's very not thread safe
                        _socket = connection.Client;
                        _sslStream = connection.Stream;
                    }
                    else
                    {
                        _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                        await _socket.ConnectAsync(_host, 443).ConfigureAwait(false);
                        var ns = new NetworkStream(_socket);
                        _sslStream = new SslStream(ns, false, new RemoteCertificateValidationCallback(
                            (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => sslPolicyErrors == SslPolicyErrors.None
                        ));
                        await _sslStream.AuthenticateAsClientAsync(_host).ConfigureAwait(false);
                        s_cache.Add(_host, (_socket, _sslStream));
                    }
                }
                await _sslStream.WriteAsync(buffer, Cancellation).ConfigureAwait(false);
                await _requestContent.WriteTo(_sslStream, Cancellation);
                await _sslStream.FlushAsync().ConfigureAwait(false);
            }

            public sealed override void AddHeader(HttpHeader header)
            {
                if (_endOfHeadersWritten) throw new NotImplementedException("need to shift EOH");

                Span<byte> span = _requestBuffer.GetSpan();
                while (true)
                {
                    if (header.TryWrite(span, out var written))
                    {
                        _requestBuffer.Advance(written);
                        return;
                    }
                    span = _requestBuffer.GetSpan(span.Length * 2);
                }
            }

            public override void SetContent(PipelineContent content)
                => _requestContent = content;

            public void AddEndOfHeaders()
            {
                var buffer = _requestBuffer.GetSpan(Http.CRLF.Length);
                Http.CRLF.CopyTo(buffer);
                _requestBuffer.Advance(Http.CRLF.Length);
                _endOfHeadersWritten = true;
            }

            ReadOnlySequence<byte> Headers => _responseBuffer.AsReadOnly().Slice(_headersStart, _contentStart - Http.CRLF.Length);

            protected override int Status => _statusCode;

            protected override Stream ResponseContentStream => new SequenceStream(_responseBuffer.AsReadOnly().Slice(_contentStart));

            protected override bool TryGetHeader(ReadOnlySpan<byte> name, out ReadOnlySpan<byte> value)
            {
                var headers = Headers;
                if (!headers.IsSingleSegment) throw new NotImplementedException();
                var span = headers.First.Span;
                int index = span.IndexOf(name);
                if (index < 0)
                {
                    value = default;
                    return false;
                }
                var header = span.Slice(index);
                var headerEnd = header.IndexOf(Http.CRLF);
                var headerStart = header.IndexOf((byte)':') + 1;
                while (header[headerStart] == ' ') headerStart++;
                value = header.Slice(headerStart, headerEnd - headerStart);
                return true;
            }

            public sealed override void Dispose()
            {
                _requestContent?.Dispose();
                _requestBuffer.Dispose();
                _responseBuffer.Dispose();
                _sslStream = null;
                _socket = null;
                base.Dispose();
            }

            public sealed override string ToString() => _responseBuffer.ToString();
        }
    }

    public class MockSocketTransport : SocketClientTransport
    {
        byte[][] _responses;

        public MockSocketTransport(params byte[][] responses) => _responses = responses;

        public override HttpMessage CreateMessage(PipelineOptions client, CancellationToken cancellation)
            => new MockSocketMessage(ref client, cancellation, _responses);

        class MockSocketMessage : SocketClientMessage
        {
            byte[][] _responses;
            int _responseNumber;

            public MockSocketMessage(ref PipelineOptions options, CancellationToken cancellation, byte[][] responses)
                : base(ref options, cancellation)
            {
                _responses = responses;
            }

            internal override Task<Sequence<byte>> ReceiveAsync(Sequence<byte> buffer)
            {
                var response = _responses[_responseNumber++];
                if (_responseNumber >= _responses.Length) _responseNumber = 0;
                var segment = buffer.GetMemory(response.Length);
                response.CopyTo(segment);
                buffer.Advance(response.Length);
                return Task.FromResult(buffer);
            }

            protected override Task SendAsync(ReadOnlySequence<byte> buffer)
                => Task.CompletedTask;
        }
    }

    class SequenceStream : Stream
    {
        ReadOnlySequence<byte> _bytes;
        long _position;

        public SequenceStream(ReadOnlySequence<byte> bytes)
            => _bytes = bytes;

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _bytes.Length;

        public override long Position { get => _position; set => _position = value; }

        public override void Flush()
        {}

        public override int Read(byte[] buffer, int offset, int count)
        {
            var source = _bytes.Slice(_position);
            var destination = buffer.AsSpan(offset, count);

            source.CopyTo(destination);
            return (int)Math.Min(destination.Length, source.Length);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin) { _position = offset; return _position; }
            else throw new NotImplementedException();
        }

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();
    }
}
