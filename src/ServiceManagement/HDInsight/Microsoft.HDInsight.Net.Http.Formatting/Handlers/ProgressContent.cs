// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Handlers
{
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Wraps an inner <see cref="HttpContent"/> in order to insert a <see cref="ProgressStream"/> on writing data.
    /// </summary>
    internal class ProgressContent : HttpContent
    {
        private readonly HttpContent _innerContent;
        private readonly ProgressMessageHandler _handler;
        private readonly HttpRequestMessage _request;

        public ProgressContent(HttpContent innerContent, ProgressMessageHandler handler, HttpRequestMessage request)
        {
            Contract.Assert(innerContent != null);
            Contract.Assert(handler != null);
            Contract.Assert(request != null);

            this._innerContent = innerContent;
            this._handler = handler;
            this._request = request;

            innerContent.Headers.CopyTo(this.Headers);
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            ProgressStream progressStream = new ProgressStream(stream, this._handler, this._request, response: null);
            return this._innerContent.CopyToAsync(progressStream);
        }

        protected override bool TryComputeLength(out long length)
        {
            long? contentLength = this._innerContent.Headers.ContentLength;
            if (contentLength.HasValue)
            {
                length = contentLength.Value;
                return true;
            }

            length = -1;
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                this._innerContent.Dispose();
            }
        }
    }
}
