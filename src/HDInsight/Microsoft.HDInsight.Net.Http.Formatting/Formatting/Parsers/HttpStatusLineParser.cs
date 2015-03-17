// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Net;
    using System.Text;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// HTTP Status line parser for parsing the first line (the status line) in an HTTP response.
    /// </summary>
    internal class HttpStatusLineParser
    {
        internal const int MinStatusLineSize = 15;
        private const int DefaultTokenAllocation = 2 * 1024;
        private const int MaxStatusCode = 1000;

        private int _totalBytesConsumed;
        private int _maximumHeaderLength;

        private HttpStatusLineState _statusLineState;
        private HttpUnsortedResponse _httpResponse;
        private StringBuilder _currentToken = new StringBuilder(DefaultTokenAllocation);

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpStatusLineParser"/> class.
        /// </summary>
        /// <param name="httpResponse"><see cref="HttpUnsortedResponse"/> instance where the response line properties will be set as they are parsed.</param>
        /// <param name="maxStatusLineSize">Maximum length of HTTP header.</param>
        public HttpStatusLineParser(HttpUnsortedResponse httpResponse, int maxStatusLineSize)
        {
            // The minimum length which would be an empty header terminated by CRLF
            if (maxStatusLineSize < MinStatusLineSize)
            {
                throw Error.ArgumentMustBeGreaterThanOrEqualTo("maxStatusLineSize", maxStatusLineSize, MinStatusLineSize);
            }

            if (httpResponse == null)
            {
                throw Error.ArgumentNull("httpResponse");
            }

            this._httpResponse = httpResponse;
            this._maximumHeaderLength = maxStatusLineSize;
        }

        private enum HttpStatusLineState
        {
            BeforeVersionNumbers = 0,
            MajorVersionNumber,
            MinorVersionNumber,
            StatusCode,
            ReasonPhrase,
            AfterCarriageReturn
        }

        /// <summary>
        /// Parse an HTTP status line. 
        /// Bytes are parsed in a consuming manner from the beginning of the response buffer meaning that the same bytes can not be 
        /// present in the response buffer.
        /// </summary>
        /// <param name="buffer">Response buffer from where response is read</param>
        /// <param name="bytesReady">Size of response buffer</param>
        /// <param name="bytesConsumed">Offset into response buffer</param>
        /// <returns>State of the parser.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception is translated to parse state.")]
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

            if (bytesConsumed >= bytesReady)
            {
                // We already can tell we need more data
                return parseStatus;
            }

            try
            {
                parseStatus = ParseStatusLine(
                    buffer,
                    bytesReady,
                    ref bytesConsumed,
                    ref this._statusLineState,
                    this._maximumHeaderLength,
                    ref this._totalBytesConsumed,
                    this._currentToken,
                    this._httpResponse);
            }
            catch (Exception)
            {
                parseStatus = ParserState.Invalid;
            }

            return parseStatus;
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "This is a parser which cannot be split up for performance reasons.")]
        private static ParserState ParseStatusLine(
            byte[] buffer,
            int bytesReady,
            ref int bytesConsumed,
            ref HttpStatusLineState statusLineState,
            int maximumHeaderLength,
            ref int totalBytesConsumed,
            StringBuilder currentToken,
            HttpUnsortedResponse httpResponse)
        {
            Contract.Assert((bytesReady - bytesConsumed) >= 0, "ParseRequestLine()|(bytesReady - bytesConsumed) < 0");
            Contract.Assert(maximumHeaderLength <= 0 || totalBytesConsumed <= maximumHeaderLength, "ParseRequestLine()|Headers already read exceeds limit.");

            // Remember where we started.
            int initialBytesParsed = bytesConsumed;
            int segmentStart;

            // Set up parsing status with what will happen if we exceed the buffer.
            ParserState parseStatus = ParserState.DataTooBig;
            int effectiveMax = maximumHeaderLength <= 0 ? Int32.MaxValue : (maximumHeaderLength - totalBytesConsumed + bytesConsumed);
            if (bytesReady < effectiveMax)
            {
                parseStatus = ParserState.NeedMoreData;
                effectiveMax = bytesReady;
            }

            Contract.Assert(bytesConsumed < effectiveMax, "We have already consumed more than the max header length.");

            switch (statusLineState)
            {
                case HttpStatusLineState.BeforeVersionNumbers:
                    segmentStart = bytesConsumed;
                    while (buffer[bytesConsumed] != '/')
                    {
                        if (buffer[bytesConsumed] < 0x21 || buffer[bytesConsumed] > 0x7a)
                        {
                            parseStatus = ParserState.Invalid;
                            goto quit;
                        }

                        if (++bytesConsumed == effectiveMax)
                        {
                            string token = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(token);
                            goto quit;
                        }
                    }

                    if (bytesConsumed > segmentStart)
                    {
                        string token = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                        currentToken.Append(token);
                    }

                    // Validate value
                    string version = currentToken.ToString();
                    if (String.CompareOrdinal(FormattingUtilities.HttpVersionToken, version) != 0)
                    {
                        throw new FormatException(Error.Format(Resources.HttpInvalidVersion, version, FormattingUtilities.HttpVersionToken));
                    }

                    currentToken.Clear();

                    // Move past the '/'
                    statusLineState = HttpStatusLineState.MajorVersionNumber;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case HttpStatusLineState.MajorVersionNumber;

                case HttpStatusLineState.MajorVersionNumber:
                    segmentStart = bytesConsumed;
                    while (buffer[bytesConsumed] != '.')
                    {
                        if (buffer[bytesConsumed] < '0' || buffer[bytesConsumed] > '9')
                        {
                            parseStatus = ParserState.Invalid;
                            goto quit;
                        }

                        if (++bytesConsumed == effectiveMax)
                        {
                            string major = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(major);
                            goto quit;
                        }
                    }

                    if (bytesConsumed > segmentStart)
                    {
                        string major = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                        currentToken.Append(major);
                    }

                    // Move past the "."
                    currentToken.Append('.');
                    statusLineState = HttpStatusLineState.MinorVersionNumber;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case HttpStatusLineState.MinorVersionNumber;

                case HttpStatusLineState.MinorVersionNumber:
                    segmentStart = bytesConsumed;
                    while (buffer[bytesConsumed] != ' ')
                    {
                        if (buffer[bytesConsumed] < '0' || buffer[bytesConsumed] > '9')
                        {
                            parseStatus = ParserState.Invalid;
                            goto quit;
                        }

                        if (++bytesConsumed == effectiveMax)
                        {
                            string minor = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(minor);
                            goto quit;
                        }
                    }

                    if (bytesConsumed > segmentStart)
                    {
                        string minor = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                        currentToken.Append(minor);
                    }

                    // Copy out value
                    httpResponse.Version = Version.Parse(currentToken.ToString());
                    currentToken.Clear();

                    // Move past the SP
                    statusLineState = HttpStatusLineState.StatusCode;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case HttpStatusLineState.StatusCode;

                case HttpStatusLineState.StatusCode:
                    segmentStart = bytesConsumed;
                    while (buffer[bytesConsumed] != ' ')
                    {
                        if (buffer[bytesConsumed] < '0' || buffer[bytesConsumed] > '9')
                        {
                            parseStatus = ParserState.Invalid;
                            goto quit;
                        }

                        if (++bytesConsumed == effectiveMax)
                        {
                            string method = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(method);
                            goto quit;
                        }
                    }

                    if (bytesConsumed > segmentStart)
                    {
                        string method = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                        currentToken.Append(method);
                    }

                    // Copy value out
                    int statusCode = Int32.Parse(currentToken.ToString(), CultureInfo.InvariantCulture);
                    if (statusCode < 100 || statusCode > 1000)
                    {
                        throw new FormatException(Error.Format(Resources.HttpInvalidStatusCode, statusCode, 100, 1000));
                    }

                    httpResponse.StatusCode = (HttpStatusCode)statusCode;
                    currentToken.Clear();

                    // Move past the SP
                    statusLineState = HttpStatusLineState.ReasonPhrase;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case HttpStatusLineState.ReasonPhrase;

                case HttpStatusLineState.ReasonPhrase:
                    segmentStart = bytesConsumed;
                    while (buffer[bytesConsumed] != '\r')
                    {
                        if (buffer[bytesConsumed] < 0x20 || buffer[bytesConsumed] > 0x7a)
                        {
                            parseStatus = ParserState.Invalid;
                            goto quit;
                        }

                        if (++bytesConsumed == effectiveMax)
                        {
                            string addr = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(addr);
                            goto quit;
                        }
                    }

                    if (bytesConsumed > segmentStart)
                    {
                        string addr = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                        currentToken.Append(addr);
                    }

                    // Copy value out
                    httpResponse.ReasonPhrase = currentToken.ToString();
                    currentToken.Clear();

                    // Move past the CR
                    statusLineState = HttpStatusLineState.AfterCarriageReturn;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case HttpStatusLineState.AfterCarriageReturn;

                case HttpStatusLineState.AfterCarriageReturn:
                    if (buffer[bytesConsumed] != '\n')
                    {
                        parseStatus = ParserState.Invalid;
                        goto quit;
                    }

                    parseStatus = ParserState.Done;
                    bytesConsumed++;
                    break;
            }

        quit:
            totalBytesConsumed += bytesConsumed - initialBytesParsed;
            return parseStatus;
        }
    }
}
