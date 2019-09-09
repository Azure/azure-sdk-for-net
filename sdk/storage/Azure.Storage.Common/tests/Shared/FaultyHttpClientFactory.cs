// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test.Shared
{
    sealed class FaultyDownloadPipelinePolicy : HttpPipelinePolicy
    {
        readonly int _raiseExceptionAt;
        readonly Exception _exceptionToRaise;

        public FaultyDownloadPipelinePolicy(int raiseExceptionAt, Exception exceptionToRaise)
        {
            this._raiseExceptionAt = raiseExceptionAt;
            this._exceptionToRaise = exceptionToRaise;
        }

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            await this.InjectFaultAsync(message, pipeline, isAsync: true).ConfigureAwait(false);
        }
        
        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessNext(message, pipeline);
            this.InjectFaultAsync(message, pipeline, isAsync: false).EnsureCompleted();
        }

        private async Task InjectFaultAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool isAsync)
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
                    this._raiseExceptionAt,
                    1,
                    this._exceptionToRaise);
            }
        }
    }

    class FaultyHttpContent : HttpContent
    {
        readonly HttpContent innerContent;
        readonly Stream faultyStream;

        public FaultyHttpContent(HttpContent httpContent, FaultyStream faultyStream)
        {
            this.innerContent = httpContent;
            foreach (var item in this.innerContent.Headers)
            {
                this.Headers.Add(item.Key, item.Value);
            }

            this.faultyStream = faultyStream;
        }

        protected override Task<Stream> CreateContentReadStreamAsync() => Task.FromResult(this.faultyStream);

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context) => this.faultyStream.CopyToAsync(stream);

        protected override bool TryComputeLength(out long length)
        {
            length = this.faultyStream.Length;
            return true;
        }
    }

    class FaultyStream : Stream
    {
        readonly Stream innerStream;
        readonly int raiseExceptionAt;
        readonly Exception exceptionToRaise;
        int remainingExceptions;

        public FaultyStream(Stream innerStream, int raiseExceptionAt, int maxExceptions, Exception exceptionToRaise)
        {
            this.innerStream = innerStream;
            this.raiseExceptionAt = raiseExceptionAt;
            this.exceptionToRaise = exceptionToRaise;
            this.remainingExceptions = maxExceptions;
        }

        public override bool CanRead => this.innerStream.CanRead;

        public override bool CanSeek => this.innerStream.CanSeek;

        public override bool CanWrite => this.innerStream.CanWrite;

        public override long Length => this.innerStream.Length;

        public override long Position
        {
            get => this.innerStream.Position;
            set => this.innerStream.Position = value;
        }

        public override void Flush() => this.innerStream.Flush();

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (this.remainingExceptions == 0 || this.Position + count <= this.raiseExceptionAt || this.Position + count >= this.innerStream.Length)
            {
                return this.innerStream.Read(buffer, offset, count);
            }
            else
            {
                this.remainingExceptions--;
                throw this.exceptionToRaise;
            }
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (this.remainingExceptions == 0 || this.Position + count <= this.raiseExceptionAt || this.Position + count >= this.innerStream.Length)
            {
                return this.innerStream.ReadAsync(buffer, offset, count, cancellationToken);
            }
            else
            {
                this.remainingExceptions--;
                throw this.exceptionToRaise;
            }
        }

        public override int ReadByte()
        {
            if (this.remainingExceptions == 0 || this.Position <= this.raiseExceptionAt || this.Position >= this.innerStream.Length)
            {
                return this.innerStream.ReadByte();
            }
            else
            {
                this.remainingExceptions--;
                throw this.exceptionToRaise;
            }
        }

        public override long Seek(long offset, SeekOrigin origin) => this.innerStream.Seek(offset, origin);

        public override void SetLength(long value) => this.innerStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => this.innerStream.Write(buffer, offset, count);
    }

}
