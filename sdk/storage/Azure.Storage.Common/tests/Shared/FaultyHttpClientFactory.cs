// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test.Shared
{
    internal sealed class FaultyDownloadPipelinePolicy : HttpPipelinePolicy
    {
        private readonly int _raiseExceptionAt;
        private readonly Exception _exceptionToRaise;

        public FaultyDownloadPipelinePolicy(int raiseExceptionAt, Exception exceptionToRaise)
        {
            _raiseExceptionAt = raiseExceptionAt;
            _exceptionToRaise = exceptionToRaise;
        }

        public override async ValueTask ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            await InjectFaultAsync(message, isAsync: true).ConfigureAwait(false);
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessNext(message, pipeline);
            InjectFaultAsync(message, isAsync: false).EnsureCompleted();
        }

        private async Task InjectFaultAsync(HttpPipelineMessage message, bool isAsync)
        {
            if (message.Response != null)
            {
                // Copy to a MemoryStream first because RetriableStreamImpl
                // doesn't support Position
                var intermediate = new MemoryStream();
                if (message.Response.ContentStream != null)
                {
                    if (isAsync)
                    {
                        await message.Response.ContentStream.CopyToAsync(intermediate).ConfigureAwait(false);
                    }
                    else
                    {
                        message.Response.ContentStream.CopyTo(intermediate);
                    }

                    intermediate.Seek(0, SeekOrigin.Begin);
                }

                // Use a faulty stream for the Response Content
                message.Response.ContentStream = new FaultyStream(
                    intermediate,
                    _raiseExceptionAt,
                    1,
                    _exceptionToRaise);
            }
        }
    }

    internal class FaultyHttpContent : HttpContent
    {
        private readonly HttpContent _innerContent;
        private readonly Stream _faultyStream;

        public FaultyHttpContent(HttpContent httpContent, FaultyStream faultyStream)
        {
            _innerContent = httpContent;
            foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.IEnumerable<string>> item in _innerContent.Headers)
            {
                Headers.Add(item.Key, item.Value);
            }

            _faultyStream = faultyStream;
        }

        protected override Task<Stream> CreateContentReadStreamAsync() => Task.FromResult(_faultyStream);

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context) => _faultyStream.CopyToAsync(stream);

        protected override bool TryComputeLength(out long length)
        {
            length = _faultyStream.Length;
            return true;
        }
    }

    internal class FaultyStream : Stream
    {
        private readonly Stream _innerStream;
        private readonly int _raiseExceptionAt;
        private readonly Exception _exceptionToRaise;
        private int _remainingExceptions;

        public FaultyStream(Stream innerStream, int raiseExceptionAt, int maxExceptions, Exception exceptionToRaise)
        {
            _innerStream = innerStream;
            _raiseExceptionAt = raiseExceptionAt;
            _exceptionToRaise = exceptionToRaise;
            _remainingExceptions = maxExceptions;
        }

        public override bool CanRead => _innerStream.CanRead;

        public override bool CanSeek => _innerStream.CanSeek;

        public override bool CanWrite => _innerStream.CanWrite;

        public override long Length => _innerStream.Length;

        public override long Position
        {
            get => _innerStream.Position;
            set => _innerStream.Position = value;
        }

        public override void Flush() => _innerStream.Flush();

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_remainingExceptions == 0 || Position + count <= _raiseExceptionAt || Position + count >= _innerStream.Length)
            {
                return _innerStream.Read(buffer, offset, count);
            }
            else
            {
                _remainingExceptions--;
                throw _exceptionToRaise;
            }
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (_remainingExceptions == 0 || Position + count <= _raiseExceptionAt || Position + count >= _innerStream.Length)
            {
                return _innerStream.ReadAsync(buffer, offset, count, cancellationToken);
            }
            else
            {
                _remainingExceptions--;
                throw _exceptionToRaise;
            }
        }

        public override int ReadByte()
        {
            if (_remainingExceptions == 0 || Position <= _raiseExceptionAt || Position >= _innerStream.Length)
            {
                return _innerStream.ReadByte();
            }
            else
            {
                _remainingExceptions--;
                throw _exceptionToRaise;
            }
        }

        public override long Seek(long offset, SeekOrigin origin) => _innerStream.Seek(offset, origin);

        public override void SetLength(long value) => _innerStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => _innerStream.Write(buffer, offset, count);
    }

}
