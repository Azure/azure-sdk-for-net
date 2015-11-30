// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Handlers
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Internal;

    /// <summary>
    /// This implementation of <see cref="System.Net.Http.DelegatingStream"/> registers how much data has been 
    /// read (received) versus written (sent) for a particular HTTP operation. The implementation
    /// is client side in that the total bytes to send is taken from the request and the total
    /// bytes to read is taken from the response. In a server side scenario, it would be the
    /// other way around (reading the request and writing the response).
    /// </summary>
    internal class ProgressStream : DelegatingStream
    {
        private readonly ProgressMessageHandler _handler;
        private readonly HttpRequestMessage _request;

        private long _bytesReceived;
        private long? _totalBytesToReceive;

        private long _bytesSent;
        private long? _totalBytesToSend;

        public ProgressStream(Stream innerStream, ProgressMessageHandler handler, HttpRequestMessage request, HttpResponseMessage response)
            : base(innerStream)
        {
            Contract.Assert(handler != null);
            Contract.Assert(request != null);

            if (request.Content != null)
            {
                this._totalBytesToSend = request.Content.Headers.ContentLength;
            }

            if (response != null && response.Content != null)
            {
                this._totalBytesToReceive = response.Content.Headers.ContentLength;
            }

            this._handler = handler;
            this._request = request;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = this.InnerStream.Read(buffer, offset, count);
            this.ReportBytesReceived(bytesRead, userState: null);
            return bytesRead;
        }

        public override int ReadByte()
        {
            int byteRead = this.InnerStream.ReadByte();
            this.ReportBytesReceived(byteRead == -1 ? 0 : 1, userState: null);
            return byteRead;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            int readCount = await this.InnerStream.ReadAsync(buffer, offset, count, cancellationToken);
            this.ReportBytesReceived(readCount, userState: null);
            return readCount;
        }
#if !NETFX_CORE // BeginX and EndX are not supported on streams in portable libraries
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return this.InnerStream.BeginRead(buffer, offset, count, callback, state);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            int bytesRead = this.InnerStream.EndRead(asyncResult);
            this.ReportBytesReceived(bytesRead, asyncResult.AsyncState);
            return bytesRead;
        }
#endif

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.InnerStream.Write(buffer, offset, count);
            this.ReportBytesSent(count, userState: null);
        }

        public override void WriteByte(byte value)
        {
            this.InnerStream.WriteByte(value);
            this.ReportBytesSent(1, userState: null);
        }

       public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await this.InnerStream.WriteAsync(buffer, offset, count, cancellationToken);
            this.ReportBytesSent(count, userState: null);
        }

#if !NETFX_CORE // BeginX and EndX are not supported on streams in portable libraries
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return new ProgressWriteAsyncResult(this.InnerStream, this, buffer, offset, count, callback, state);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            ProgressWriteAsyncResult.End(asyncResult);
        }
#endif

        internal void ReportBytesSent(int bytesSent, object userState)
        {
            if (bytesSent > 0)
            {
                this._bytesSent += bytesSent;
                int percentage = 0;
                if (this._totalBytesToSend.HasValue && this._totalBytesToSend != 0)
                {
                    percentage = (int)((100L * this._bytesSent) / this._totalBytesToSend);
                }

                // We only pass the request as it is guaranteed to be non-null (the response may be null)
                this._handler.OnHttpRequestProgress(this._request, new HttpProgressEventArgs(percentage, userState, this._bytesSent, this._totalBytesToSend));
            }
        }

        private void ReportBytesReceived(int bytesReceived, object userState)
        {
            if (bytesReceived > 0)
            {
                this._bytesReceived += bytesReceived;
                int percentage = 0;
                if (this._totalBytesToReceive.HasValue && this._totalBytesToReceive != 0)
                {
                    percentage = (int)((100L * this._bytesReceived) / this._totalBytesToReceive);
                }

                // We only pass the request as it is guaranteed to be non-null (the response may be null)
                this._handler.OnHttpResponseProgress(this._request, new HttpProgressEventArgs(percentage, userState, this._bytesReceived, this._totalBytesToReceive));
            }
        }
    }
}
