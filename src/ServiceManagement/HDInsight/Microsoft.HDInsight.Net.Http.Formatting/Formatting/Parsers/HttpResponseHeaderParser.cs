// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// The <see cref="HttpResponseHeaderParser"/> combines <see cref="HttpStatusLineParser"/> for parsing the HTTP Status Line  
    /// and <see cref="InternetMessageFormatHeaderParser"/> for parsing each header field. 
    /// </summary>
    internal class HttpResponseHeaderParser
    {
        internal const int DefaultMaxStatusLineSize = 2 * 1024;
        internal const int DefaultMaxHeaderSize = 16 * 1024; // Same default size as IIS has for HTTP requests

        private HttpUnsortedResponse _httpResponse;
        private HttpResponseState _responseStatus = HttpResponseState.StatusLine;

        private HttpStatusLineParser _statusLineParser;
        private InternetMessageFormatHeaderParser _headerParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseHeaderParser"/> class.
        /// </summary>
        /// <param name="httpResponse">The parsed HTTP response without any header sorting.</param>
        public HttpResponseHeaderParser(HttpUnsortedResponse httpResponse)
            : this(httpResponse, DefaultMaxStatusLineSize, DefaultMaxHeaderSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseHeaderParser"/> class.
        /// </summary>
        /// <param name="httpResponse">The parsed HTTP response without any header sorting.</param>
        /// <param name="maxResponseLineSize">The max length of the HTTP status line.</param>
        /// <param name="maxHeaderSize">The max length of the HTTP header.</param>
        public HttpResponseHeaderParser(HttpUnsortedResponse httpResponse, int maxResponseLineSize, int maxHeaderSize)
        {
            if (httpResponse == null)
            {
                throw Error.ArgumentNull("httpResponse");
            }

            this._httpResponse = httpResponse;

            // Create status line parser
            this._statusLineParser = new HttpStatusLineParser(this._httpResponse, maxResponseLineSize);

            // Create header parser
            this._headerParser = new InternetMessageFormatHeaderParser(this._httpResponse.HttpHeaders, maxHeaderSize);
        }

        private enum HttpResponseState
        {
            StatusLine = 0, // parsing status line
            ResponseHeaders // reading headers
        }

        /// <summary>
        /// Parse an HTTP response header and fill in the <see cref="HttpResponseMessage"/> instance.
        /// </summary>
        /// <param name="buffer">Response buffer from where response is read</param>
        /// <param name="bytesReady">Size of response buffer</param>
        /// <param name="bytesConsumed">Offset into response buffer</param>
        /// <returns>State of the parser.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception is propagated.")]
        public ParserState ParseBuffer(
            byte[] buffer,
            int bytesReady,
            ref int bytesConsumed)
        {
            if (buffer == null)
            {
                throw Error.ArgumentNull("buffer");
            }

            ParserState parseStatus = ParserState.NeedMoreData;
            ParserState subParseStatus = ParserState.NeedMoreData;

            switch (this._responseStatus)
            {
                case HttpResponseState.StatusLine:
                    try
                    {
                        subParseStatus = this._statusLineParser.ParseBuffer(buffer, bytesReady, ref bytesConsumed);
                    }
                    catch (Exception)
                    {
                        subParseStatus = ParserState.Invalid;
                    }

                    if (subParseStatus == ParserState.Done)
                    {
                        this._responseStatus = HttpResponseState.ResponseHeaders;
                        subParseStatus = ParserState.NeedMoreData;
                        goto case HttpResponseState.ResponseHeaders;
                    }
                    else if (subParseStatus != ParserState.NeedMoreData)
                    {
                        // Report error - either Invalid or DataTooBig
                        parseStatus = subParseStatus;
                        break;
                    }

                    break; // read more data

                case HttpResponseState.ResponseHeaders:
                    if (bytesConsumed >= bytesReady)
                    {
                        // we already can tell we need more data
                        break;
                    }

                    try
                    {
                        subParseStatus = this._headerParser.ParseBuffer(buffer, bytesReady, ref bytesConsumed);
                    }
                    catch (Exception)
                    {
                        subParseStatus = ParserState.Invalid;
                    }

                    if (subParseStatus == ParserState.Done)
                    {
                        parseStatus = subParseStatus;
                    }
                    else if (subParseStatus != ParserState.NeedMoreData)
                    {
                        parseStatus = subParseStatus;
                        break;
                    }

                    break; // need more data
            }

            return parseStatus;
        }
    }
}
