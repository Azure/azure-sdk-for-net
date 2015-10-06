// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Complete MIME multipart parser that combines <see cref="MimeMultipartParser"/> for parsing the MIME message into individual body parts 
    /// and <see cref="InternetMessageFormatHeaderParser"/> for parsing each body part into a MIME header and a MIME body. The caller of the parser is returned
    /// the resulting MIME bodies which can then be written to some output.
    /// </summary>
    internal class MimeMultipartBodyPartParser : IDisposable
    {
        internal const long DefaultMaxMessageSize = Int64.MaxValue;
        private const int DefaultMaxBodyPartHeaderSize = 4 * 1024;

        // MIME parser
        private MimeMultipartParser _mimeParser;
        private MimeMultipartParser.State _mimeStatus = MimeMultipartParser.State.NeedMoreData;
        private ArraySegment<byte>[] _parsedBodyPart = new ArraySegment<byte>[2];
        private MimeBodyPart _currentBodyPart;
        private bool _isFirst = true;

        // Header field parser
        private ParserState _bodyPartHeaderStatus = ParserState.NeedMoreData;
        private int _maxBodyPartHeaderSize;

        // Stream provider
        private MultipartStreamProvider _streamProvider;

        private HttpContent _content;

        /// <summary>
        /// Initializes a new instance of the <see cref="MimeMultipartBodyPartParser"/> class.
        /// </summary>
        /// <param name="content">An existing <see cref="HttpContent"/> instance to use for the object's content.</param>
        /// <param name="streamProvider">A stream provider providing output streams for where to write body parts as they are parsed.</param>
        public MimeMultipartBodyPartParser(HttpContent content, MultipartStreamProvider streamProvider)
            : this(content, streamProvider, DefaultMaxMessageSize, DefaultMaxBodyPartHeaderSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MimeMultipartBodyPartParser"/> class.
        /// </summary>
        /// <param name="content">An existing <see cref="HttpContent"/> instance to use for the object's content.</param>
        /// <param name="streamProvider">A stream provider providing output streams for where to write body parts as they are parsed.</param>
        /// <param name="maxMessageSize">The max length of the entire MIME multipart message.</param>
        /// <param name="maxBodyPartHeaderSize">The max length of the MIME header within each MIME body part.</param>
        public MimeMultipartBodyPartParser(
            HttpContent content,
            MultipartStreamProvider streamProvider,
            long maxMessageSize,
            int maxBodyPartHeaderSize)
        {
            Contract.Assert(content != null, "content cannot be null.");
            Contract.Assert(streamProvider != null, "streamProvider cannot be null.");

            string boundary = ValidateArguments(content, maxMessageSize, true);

            this._mimeParser = new MimeMultipartParser(boundary, maxMessageSize);
            this._currentBodyPart = new MimeBodyPart(streamProvider, maxBodyPartHeaderSize, content);
            this._content = content;
            this._maxBodyPartHeaderSize = maxBodyPartHeaderSize;

            this._streamProvider = streamProvider;
        }

        /// <summary>
        /// Determines whether the specified content is MIME multipart content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <c>true</c> if the specified content is MIME multipart content; otherwise, <c>false</c>.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception is translated to false return.")]
        public static bool IsMimeMultipartContent(HttpContent content)
        {
            Contract.Assert(content != null, "content cannot be null.");
            try
            {
                string boundary = ValidateArguments(content, DefaultMaxMessageSize, false);
                return boundary != null;
            }
            catch (Exception)
            {
                return false;
            }
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
        /// Parses the data provided and generates parsed MIME body part bodies in the form of <see cref="ArraySegment{T}"/> which are ready to 
        /// write to the output stream.
        /// </summary>
        /// <param name="data">The data to parse</param>
        /// <param name="bytesRead">The number of bytes available in the input data</param>
        /// <returns>Parsed <see cref="MimeBodyPart"/> instances.</returns>
        public IEnumerable<MimeBodyPart> ParseBuffer(byte[] data, int bytesRead)
        {
            int bytesConsumed = 0;
            bool isFinal = false;

            // There's a special case here - if we've reached the end of the message and there's no optional
            // CRLF, then we're out of bytes to read, but we have finished the message. 
            //
            // If IsWaitingForEndOfMessage is true and we're at the end of the stream, then we're going to 
            // call into the parser again with an empty array as the buffer to signal the end of the parse. 
            // Then the final boundary segment will be marked as complete. 
            if (bytesRead == 0 && !this._mimeParser.IsWaitingForEndOfMessage)
            {
                this.CleanupCurrentBodyPart();
                throw new IOException(Resources.ReadAsMimeMultipartUnexpectedTermination);
            }

            // Make sure we remove an old array segments.
            this._currentBodyPart.Segments.Clear();

            while (this._mimeParser.CanParseMore(bytesRead, bytesConsumed))
            {
                this._mimeStatus = this._mimeParser.ParseBuffer(data, bytesRead, ref bytesConsumed, out this._parsedBodyPart[0], out this._parsedBodyPart[1], out isFinal);
                if (this._mimeStatus != MimeMultipartParser.State.BodyPartCompleted && this._mimeStatus != MimeMultipartParser.State.NeedMoreData)
                {
                    this.CleanupCurrentBodyPart();
                    throw Error.InvalidOperation(Resources.ReadAsMimeMultipartParseError, bytesConsumed, data);
                }

                // First body is empty preamble which we just ignore
                if (this._isFirst)
                {
                    if (this._mimeStatus == MimeMultipartParser.State.BodyPartCompleted)
                    {
                        this._isFirst = false;
                    }

                    continue;
                }

                // Parse the two array segments containing parsed body parts that the MIME parser gave us
                foreach (ArraySegment<byte> part in this._parsedBodyPart)
                {
                    if (part.Count == 0)
                    {
                        continue;
                    }

                    if (this._bodyPartHeaderStatus != ParserState.Done)
                    {
                        int headerConsumed = part.Offset;
                        this._bodyPartHeaderStatus = this._currentBodyPart.HeaderParser.ParseBuffer(part.Array, part.Count + part.Offset, ref headerConsumed);
                        if (this._bodyPartHeaderStatus == ParserState.Done)
                        {
                            // Add the remainder as body part content
                            this._currentBodyPart.Segments.Add(new ArraySegment<byte>(part.Array, headerConsumed, part.Count + part.Offset - headerConsumed));
                        }
                        else if (this._bodyPartHeaderStatus != ParserState.NeedMoreData)
                        {
                            this.CleanupCurrentBodyPart();
                            throw Error.InvalidOperation(Resources.ReadAsMimeMultipartHeaderParseError, headerConsumed, part.Array);
                        }
                    }
                    else
                    {
                        // Add the data as body part content
                        this._currentBodyPart.Segments.Add(part);
                    }
                }

                if (this._mimeStatus == MimeMultipartParser.State.BodyPartCompleted)
                {
                    // If body is completed then swap current body part
                    MimeBodyPart completed = this._currentBodyPart;
                    completed.IsComplete = true;
                    completed.IsFinal = isFinal;

                    this._currentBodyPart = new MimeBodyPart(this._streamProvider, this._maxBodyPartHeaderSize, this._content);

                    this._mimeStatus = MimeMultipartParser.State.NeedMoreData;
                    this._bodyPartHeaderStatus = ParserState.NeedMoreData;
                    yield return completed;
                }
                else
                {
                    // Otherwise return what we have 
                    yield return this._currentBodyPart;
                }
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._mimeParser = null;
                this.CleanupCurrentBodyPart();
            }
        }

        private static string ValidateArguments(HttpContent content, long maxMessageSize, bool throwOnError)
        {
            Contract.Assert(content != null, "content cannot be null.");
            if (maxMessageSize < MimeMultipartParser.MinMessageSize)
            {
                if (throwOnError)
                {
                    throw Error.ArgumentMustBeGreaterThanOrEqualTo("maxMessageSize", maxMessageSize, MimeMultipartParser.MinMessageSize);
                }
                else
                {
                    return null;
                }
            }

            MediaTypeHeaderValue contentType = content.Headers.ContentType;
            if (contentType == null)
            {
                if (throwOnError)
                {
                    throw Error.Argument("content", Resources.ReadAsMimeMultipartArgumentNoContentType, typeof(HttpContent).Name, "multipart/");
                }
                else
                {
                    return null;
                }
            }

            if (!contentType.MediaType.StartsWith("multipart", StringComparison.OrdinalIgnoreCase))
            {
                if (throwOnError)
                {
                    throw Error.Argument("content", Resources.ReadAsMimeMultipartArgumentNoMultipart, typeof(HttpContent).Name, "multipart/");
                }
                else
                {
                    return null;
                }
            }

            string boundary = null;
            foreach (NameValueHeaderValue p in contentType.Parameters)
            {
                if (p.Name.Equals("boundary", StringComparison.OrdinalIgnoreCase))
                {
                    boundary = FormattingUtilities.UnquoteToken(p.Value);
                    break;
                }
            }

            if (boundary == null)
            {
                if (throwOnError)
                {
                    throw Error.Argument("content", Resources.ReadAsMimeMultipartArgumentNoBoundary, typeof(HttpContent).Name, "multipart", "boundary");
                }
                else
                {
                    return null;
                }
            }

            return boundary;
        }

        private void CleanupCurrentBodyPart()
        {
            if (this._currentBodyPart != null)
            {
                this._currentBodyPart.Dispose();
                this._currentBodyPart = null;
            }
        }
    }
}
