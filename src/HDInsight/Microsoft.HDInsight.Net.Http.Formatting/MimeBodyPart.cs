// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers;

    /// <summary>
    /// Maintains information about MIME body parts parsed by <see cref="MimeMultipartBodyPartParser"/>.
    /// </summary>
    internal class MimeBodyPart : IDisposable
    {
        private static readonly Type _streamType = typeof(Stream);
        private Stream _outputStream;
        private MultipartStreamProvider _streamProvider;
        private HttpContent _parentContent;
        private HttpContent _content;
        private HttpContentHeaders _headers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MimeBodyPart"/> class.
        /// </summary>
        /// <param name="streamProvider">The stream provider.</param>
        /// <param name="maxBodyPartHeaderSize">The max length of the MIME header within each MIME body part.</param>
        /// <param name="parentContent">The part's parent content</param>
        public MimeBodyPart(MultipartStreamProvider streamProvider, int maxBodyPartHeaderSize, HttpContent parentContent)
        {
            Contract.Assert(streamProvider != null);
            Contract.Assert(parentContent != null);
            this._streamProvider = streamProvider;
            this._parentContent = parentContent;
            this.Segments = new List<ArraySegment<byte>>(2);
            this._headers = FormattingUtilities.CreateEmptyContentHeaders();
            this.HeaderParser = new InternetMessageFormatHeaderParser(this._headers, maxBodyPartHeaderSize);
        }

        /// <summary>
        /// Gets the header parser.
        /// </summary>
        /// <value>
        /// The header parser.
        /// </value>
        public InternetMessageFormatHeaderParser HeaderParser { get; private set; }

        /// <summary>
        /// Gets the part's content as an HttpContent.
        /// </summary>
        /// <value>
        /// The part's content, or null if the part had no content.
        /// </value>
        public HttpContent GetCompletedHttpContent()
        {
            Contract.Assert(this.IsComplete);

            if (this._content == null)
            {
                return null;
            }

            this._headers.CopyTo(this._content.Headers);
            return this._content;
        }

        /// <summary>
        /// Gets the set of <see cref="ArraySegment{T}"/> pointing to the read buffer with
        /// contents of this body part.
        /// </summary>
        public List<ArraySegment<byte>> Segments { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the body part has been completed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is the final body part.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool IsFinal { get; set; }

        /// <summary>
        /// Writes the <paramref name="segment"/> into the part's output stream.
        /// </summary>
        /// <param name="segment">The current segment to be written to the part's output stream.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        public async Task WriteSegment(ArraySegment<byte> segment, CancellationToken cancellationToken)
        {
            var stream = this.GetOutputStream();
            await stream.WriteAsync(segment.Array, segment.Offset, segment.Count, cancellationToken);
        }

        /// <summary>
        /// Gets the output stream.
        /// </summary>
        /// <returns>The output stream to write the body part to.</returns>
        private Stream GetOutputStream()
        {
            if (this._outputStream == null)
            {
                try
                {
                    this._outputStream = this._streamProvider.GetStream(this._parentContent, this._headers);
                }
                catch (Exception e)
                {
                    throw Error.InvalidOperation(e, Resources.ReadAsMimeMultipartStreamProviderException, this._streamProvider.GetType().Name);
                }

                if (this._outputStream == null)
                {
                    throw Error.InvalidOperation(Resources.ReadAsMimeMultipartStreamProviderNull, this._streamProvider.GetType().Name, _streamType.Name);
                }

                if (!this._outputStream.CanWrite)
                {
                    throw Error.InvalidOperation(Resources.ReadAsMimeMultipartStreamProviderReadOnly, this._streamProvider.GetType().Name, _streamType.Name);
                }
                this._content = new StreamContent(this._outputStream);
            }

            return this._outputStream;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.CleanupOutputStream();
                this.CleanupHttpContent();
                this._parentContent = null;
                this.HeaderParser = null;
                this.Segments.Clear();
            }
        }

        /// <summary>
        /// In the success case, the HttpContent is to be used after this Part has been parsed and disposed of.
        /// Only if Dispose has been called on a non-completed part, the parsed HttpContent needs to be disposed of as well.
        /// </summary>
        private void CleanupHttpContent()
        {
            if (!this.IsComplete && this._content != null)
            {
                this._content.Dispose();
            }

            this._content = null;
        }

        /// <summary>
        /// Resets the output stream by either closing it or, in the case of a <see cref="MemoryStream"/> resetting
        /// position to 0 so that it can be read by the caller.
        /// </summary>
        private void CleanupOutputStream()
        {
            if (this._outputStream != null)
            {
                MemoryStream output = this._outputStream as MemoryStream;
                if (output != null)
                {
                    output.Position = 0;
                }
                else
                {
#if NETFX_CORE
                    _outputStream.Dispose();
#else
                    this._outputStream.Close();
#endif
                }

                this._outputStream = null;
            }
        }
    }
}
