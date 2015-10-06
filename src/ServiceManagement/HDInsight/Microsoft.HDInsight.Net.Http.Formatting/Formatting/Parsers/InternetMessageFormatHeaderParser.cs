// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Net.Http.Headers;
    using System.Text;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Buffer-oriented RFC 5322 style Internet Message Format parser which can be used to pass header 
    /// fields used in HTTP and MIME message entities. 
    /// </summary>
    internal class InternetMessageFormatHeaderParser
    {
        internal const int MinHeaderSize = 2;

        private int _totalBytesConsumed;
        private int _maxHeaderSize;

        private HeaderFieldState _headerState;
        private HttpHeaders _headers;
        private CurrentHeaderFieldStore _currentHeader;

        /// <summary>
        /// Initializes a new instance of the <see cref="InternetMessageFormatHeaderParser"/> class.
        /// </summary>
        /// <param name="headers">Concrete <see cref="HttpHeaders"/> instance where header fields are added as they are parsed.</param>
        /// <param name="maxHeaderSize">Maximum length of complete header containing all the individual header fields.</param>
        public InternetMessageFormatHeaderParser(HttpHeaders headers, int maxHeaderSize)
        {
            // The minimum length which would be an empty header terminated by CRLF
            if (maxHeaderSize < InternetMessageFormatHeaderParser.MinHeaderSize)
            {
                throw Error.ArgumentMustBeGreaterThanOrEqualTo("maxHeaderSize", maxHeaderSize, MinHeaderSize);
            }

            if (headers == null)
            {
                throw Error.ArgumentNull("headers");
            }

            this._headers = headers;
            this._maxHeaderSize = maxHeaderSize;
            this._currentHeader = new CurrentHeaderFieldStore();
        }

        private enum HeaderFieldState
        {
            Name = 0,
            Value,
            AfterCarriageReturn,
            FoldingLine
        }

        /// <summary>
        /// Parse a buffer of RFC 5322 style header fields and add them to the <see cref="HttpHeaders"/> collection.
        /// Bytes are parsed in a consuming manner from the beginning of the buffer meaning that the same bytes can not be 
        /// present in the buffer.
        /// </summary>
        /// <param name="buffer">Request buffer from where request is read</param>
        /// <param name="bytesReady">Size of request buffer</param>
        /// <param name="bytesConsumed">Offset into request buffer</param>
        /// <returns>State of the parser. Call this method with new data until it reaches a final state.</returns>
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
                parseStatus = InternetMessageFormatHeaderParser.ParseHeaderFields(
                    buffer,
                    bytesReady,
                    ref bytesConsumed,
                    ref this._headerState,
                    this._maxHeaderSize,
                    ref this._totalBytesConsumed,
                    this._currentHeader,
                    this._headers);
            }
            catch (Exception)
            {
                parseStatus = ParserState.Invalid;
            }

            return parseStatus;
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "This is a parser which cannot be split up for performance reasons.")]
        private static ParserState ParseHeaderFields(
            byte[] buffer,
            int bytesReady,
            ref int bytesConsumed,
            ref HeaderFieldState requestHeaderState,
            int maximumHeaderLength,
            ref int totalBytesConsumed,
            CurrentHeaderFieldStore currentField,
            HttpHeaders headers)
        {
            Contract.Assert((bytesReady - bytesConsumed) >= 0, "ParseHeaderFields()|(inputBufferLength - bytesParsed) < 0");
            Contract.Assert(maximumHeaderLength <= 0 || totalBytesConsumed <= maximumHeaderLength, "ParseHeaderFields()|Headers already read exceeds limit.");

            // Remember where we started.
            int initialBytesParsed = bytesConsumed;
            int segmentStart;

            // Set up parsing status with what will happen if we exceed the buffer.
            ParserState parseStatus = ParserState.DataTooBig;
            int effectiveMax = maximumHeaderLength <= 0 ? Int32.MaxValue : maximumHeaderLength - totalBytesConsumed + initialBytesParsed;
            if (bytesReady < effectiveMax)
            {
                parseStatus = ParserState.NeedMoreData;
                effectiveMax = bytesReady;
            }

            Contract.Assert(bytesConsumed < effectiveMax, "We have already consumed more than the max header length.");

            switch (requestHeaderState)
            {
                case HeaderFieldState.Name:
                    segmentStart = bytesConsumed;
                    while (buffer[bytesConsumed] != ':')
                    {
                        if (buffer[bytesConsumed] == '\r')
                        {
                            if (!currentField.IsEmpty())
                            {
                                parseStatus = ParserState.Invalid;
                                goto quit;
                            }
                            else
                            {
                                // Move past the '\r'
                                requestHeaderState = HeaderFieldState.AfterCarriageReturn;
                                if (++bytesConsumed == effectiveMax)
                                {
                                    goto quit;
                                }

                                goto case HeaderFieldState.AfterCarriageReturn;
                            }
                        }

                        if (++bytesConsumed == effectiveMax)
                        {
                            string headerFieldName = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentField.Name.Append(headerFieldName);
                            goto quit;
                        }
                    }

                    if (bytesConsumed > segmentStart)
                    {
                        string headerFieldName = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                        currentField.Name.Append(headerFieldName);
                    }

                    // Move past the ':'
                    requestHeaderState = HeaderFieldState.Value;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case HeaderFieldState.Value;

                case HeaderFieldState.Value:
                    segmentStart = bytesConsumed;
                    while (buffer[bytesConsumed] != '\r')
                    {
                        if (++bytesConsumed == effectiveMax)
                        {
                            string headerFieldValue = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentField.Value.Append(headerFieldValue);
                            goto quit;
                        }
                    }

                    if (bytesConsumed > segmentStart)
                    {
                        string headerFieldValue = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                        currentField.Value.Append(headerFieldValue);
                    }

                    // Move past the CR
                    requestHeaderState = HeaderFieldState.AfterCarriageReturn;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case HeaderFieldState.AfterCarriageReturn;

                case HeaderFieldState.AfterCarriageReturn:
                    if (buffer[bytesConsumed] != '\n')
                    {
                        parseStatus = ParserState.Invalid;
                        goto quit;
                    }

                    if (currentField.IsEmpty())
                    {
                        parseStatus = ParserState.Done;
                        bytesConsumed++;
                        goto quit;
                    }

                    requestHeaderState = HeaderFieldState.FoldingLine;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case HeaderFieldState.FoldingLine;

                case HeaderFieldState.FoldingLine:
                    if (buffer[bytesConsumed] != ' ' && buffer[bytesConsumed] != '\t')
                    {
                        currentField.CopyTo(headers);
                        requestHeaderState = HeaderFieldState.Name;
                        if (bytesConsumed == effectiveMax)
                        {
                            goto quit;
                        }

                        goto case HeaderFieldState.Name;
                    }

                    // Unfold line by inserting SP instead
                    currentField.Value.Append(' ');

                    // Continue parsing header field value
                    requestHeaderState = HeaderFieldState.Value;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case HeaderFieldState.Value;
            }

        quit:
            totalBytesConsumed += bytesConsumed - initialBytesParsed;
            return parseStatus;
        }

        /// <summary>
        /// Maintains information about the current header field being parsed. 
        /// </summary>
        private class CurrentHeaderFieldStore
        {
            private const int DefaultFieldNameAllocation = 128;
            private const int DefaultFieldValueAllocation = 2 * 1024;

            private static readonly char[] _linearWhiteSpace = new char[] { ' ', '\t' };

            private readonly StringBuilder _name = new StringBuilder(CurrentHeaderFieldStore.DefaultFieldNameAllocation);
            private readonly StringBuilder _value = new StringBuilder(CurrentHeaderFieldStore.DefaultFieldValueAllocation);

            /// <summary>
            /// Gets the header field name.
            /// </summary>
            public StringBuilder Name
            {
                get { return this._name; }
            }

            /// <summary>
            /// Gets the header field value.
            /// </summary>
            public StringBuilder Value
            {
                get { return this._value; }
            }

            /// <summary>
            /// Copies current header field to the provided <see cref="HttpHeaders"/> instance.
            /// </summary>
            /// <param name="headers">The headers.</param>
            public void CopyTo(HttpHeaders headers)
            {
                headers.Add(this._name.ToString(), this._value.ToString().Trim(CurrentHeaderFieldStore._linearWhiteSpace));
                this.Clear();
            }

            /// <summary>
            /// Determines whether this instance is empty.
            /// </summary>
            /// <returns>
            ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
            /// </returns>
            public bool IsEmpty()
            {
                return this._name.Length == 0 && this._value.Length == 0;
            }

            /// <summary>
            /// Clears this instance.
            /// </summary>
            private void Clear()
            {
                this._name.Clear();
                this._value.Clear();
            }
        }
    }
}
