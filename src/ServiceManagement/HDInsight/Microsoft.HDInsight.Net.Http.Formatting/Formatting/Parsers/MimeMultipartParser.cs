// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Text;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Buffer-oriented MIME multipart parser.
    /// </summary>
    internal class MimeMultipartParser
    {
        internal const int MinMessageSize = 10;

        private const int MaxBoundarySize = 256;

        private const byte HTAB = 0x09;
        private const byte SP = 0x20;
        private const byte CR = 0x0D;
        private const byte LF = 0x0A;
        private const byte Dash = 0x2D;
        private static readonly ArraySegment<byte> _emptyBodyPart = new ArraySegment<byte>(new byte[0]);

        private long _totalBytesConsumed;
        private long _maxMessageSize;

        private BodyPartState _bodyPartState;
        private string _boundary;
        private CurrentBodyPartStore _currentBoundary;

        /// <summary>
        /// Initializes a new instance of the <see cref="MimeMultipartParser"/> class.
        /// </summary>
        /// <param name="boundary">Message boundary</param>
        /// <param name="maxMessageSize">Maximum length of entire MIME multipart message.</param>
        public MimeMultipartParser(string boundary, long maxMessageSize)
        {
            // The minimum length which would be an empty message terminated by CRLF
            if (maxMessageSize < MimeMultipartParser.MinMessageSize)
            {
                throw Error.ArgumentMustBeGreaterThanOrEqualTo("maxMessageSize", maxMessageSize, MinMessageSize);
            }

            if (String.IsNullOrWhiteSpace(boundary))
            {
                throw Error.ArgumentNull("boundary");
            }

            if (boundary.Length > MaxBoundarySize - 10)
            {
                throw Error.ArgumentMustBeLessThanOrEqualTo("boundary", boundary.Length, MaxBoundarySize - 10);
            }

            if (boundary.EndsWith(" ", StringComparison.Ordinal))
            {
                throw Error.Argument("boundary", Resources.MimeMultipartParserBadBoundary);
            }

            this._maxMessageSize = maxMessageSize;
            this._boundary = boundary;
            this._currentBoundary = new CurrentBodyPartStore(this._boundary);
            this._bodyPartState = BodyPartState.AfterFirstLineFeed;
        }

        public bool IsWaitingForEndOfMessage
        {
            get
            {
                return
                    this._bodyPartState == BodyPartState.AfterBoundary &&
                    this._currentBoundary != null &&
                    this._currentBoundary.IsFinal;
            }
        }

        private enum BodyPartState
        {
            BodyPart = 0,
            AfterFirstCarriageReturn,
            AfterFirstLineFeed,
            AfterFirstDash,
            Boundary,
            AfterBoundary,
            AfterSecondDash,
            AfterSecondCarriageReturn
        }

        private enum MessageState
        {
            Boundary = 0, // about to parse boundary
            BodyPart, // about to parse body-part
            CloseDelimiter // about to read close-delimiter
        }

        /// <summary>
        /// Represents the overall state of the <see cref="MimeMultipartParser"/>.
        /// </summary>
        public enum State
        {
            /// <summary>
            /// Need more data
            /// </summary>
            NeedMoreData = 0,

            /// <summary>
            /// Parsing of a complete body part succeeded.
            /// </summary>
            BodyPartCompleted,

            /// <summary>
            /// Bad data format
            /// </summary>
            Invalid,

            /// <summary>
            /// Data exceeds the allowed size
            /// </summary>
            DataTooBig,
        }
        
        public bool CanParseMore(int bytesRead, int bytesConsumed)
        {
            if (bytesConsumed < bytesRead)
            {
                // If there's more bytes we haven't parsed, then we can parse more
                return true;
            }

            if (bytesRead == 0 && this.IsWaitingForEndOfMessage)
            {
                // If we're waiting for the end of the message and we've arrived there, we want parse to be called
                // again so we can mark the parse as complete.
                //
                // This can happen when the last boundary segment doesn't have a trailing CRLF. We need to wait until
                // the end of the message to complete the parse because we need to consume any trailing whitespace that's
                //present.
                return true;
            }

            return false;
        }

        /// <summary>
        /// Parse a MIME multipart message. Bytes are parsed in a consuming
        /// manner from the beginning of the request buffer meaning that the same bytes can not be 
        /// present in the request buffer.
        /// </summary>
        /// <param name="buffer">Request buffer from where request is read</param>
        /// <param name="bytesReady">Size of request buffer</param>
        /// <param name="bytesConsumed">Offset into request buffer</param>
        /// <param name="remainingBodyPart">Any body part that was considered as a potential MIME multipart boundary but which was in fact part of the body.</param>
        /// <param name="bodyPart">The bulk of the body part.</param>
        /// <param name="isFinalBodyPart">Indicates whether the final body part has been found.</param>
        /// <remarks>In order to get the complete body part, the caller is responsible for concatenating the contents of the 
        /// <paramref name="remainingBodyPart"/> and <paramref name="bodyPart"/> out parameters.</remarks>
        /// <returns>State of the parser.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception is translated to parse state.")]
        public State ParseBuffer(
            byte[] buffer,
            int bytesReady,
            ref int bytesConsumed,
            out ArraySegment<byte> remainingBodyPart,
            out ArraySegment<byte> bodyPart,
            out bool isFinalBodyPart)
        {
            if (buffer == null)
            {
                throw Error.ArgumentNull("buffer");
            }

            State parseStatus = State.NeedMoreData;
            remainingBodyPart = MimeMultipartParser._emptyBodyPart;
            bodyPart = MimeMultipartParser._emptyBodyPart;
            isFinalBodyPart = false;

            try
            {
                parseStatus = MimeMultipartParser.ParseBodyPart(
                    buffer,
                    bytesReady,
                    ref bytesConsumed,
                    ref this._bodyPartState,
                    this._maxMessageSize,
                    ref this._totalBytesConsumed,
                    this._currentBoundary);
            }
            catch (Exception)
            {
                parseStatus = State.Invalid;
            }

            remainingBodyPart = this._currentBoundary.GetDiscardedBoundary();
            bodyPart = this._currentBoundary.BodyPart;
            if (parseStatus == State.BodyPartCompleted)
            {
                isFinalBodyPart = this._currentBoundary.IsFinal;
                this._currentBoundary.ClearAll();
            }
            else
            {
                this._currentBoundary.ClearBodyPart();
            }

            return parseStatus;
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "This is a parser which cannot be split up for performance reasons.")]
        private static State ParseBodyPart(
            byte[] buffer,
            int bytesReady,
            ref int bytesConsumed,
            ref BodyPartState bodyPartState,
            long maximumMessageLength,
            ref long totalBytesConsumed,
            CurrentBodyPartStore currentBodyPart)
        {
            Contract.Assert((bytesReady - bytesConsumed) >= 0, "ParseBodyPart()|(bytesReady - bytesConsumed) < 0");
            Contract.Assert(maximumMessageLength <= 0 || totalBytesConsumed <= maximumMessageLength, "ParseBodyPart()|Message already read exceeds limit.");

            // Remember where we started.
            int segmentStart;
            int initialBytesParsed = bytesConsumed;

            if (bytesReady == 0 && bodyPartState == BodyPartState.AfterBoundary && currentBodyPart.IsFinal)
            {
                // We've seen the end of the stream - the final body part has no trailing CRLF
                return State.BodyPartCompleted;
            }

            // Set up parsing status with what will happen if we exceed the buffer.
            State parseStatus = State.DataTooBig;
            long effectiveMax = maximumMessageLength <= 0 ? Int64.MaxValue : (maximumMessageLength - totalBytesConsumed + bytesConsumed);
            if (effectiveMax == 0)
            {
                // effectiveMax is based on our max message size - if we've arrrived at the max size, then we need
                // to stop parsing.
                return State.DataTooBig;
            }

            if (bytesReady <= effectiveMax)
            {
                parseStatus = State.NeedMoreData;
                effectiveMax = bytesReady;
            }

            currentBodyPart.ResetBoundaryOffset();

            Contract.Assert(bytesConsumed < effectiveMax, "We have already consumed more than the max header length.");

            switch (bodyPartState)
            {
                case BodyPartState.BodyPart:
                    while (buffer[bytesConsumed] != MimeMultipartParser.CR)
                    {
                        if (++bytesConsumed == effectiveMax)
                        {
                            goto quit;
                        }
                    }

                    // Remember potential boundary
                    currentBodyPart.AppendBoundary(MimeMultipartParser.CR);

                    // Move past the CR
                    bodyPartState = BodyPartState.AfterFirstCarriageReturn;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case BodyPartState.AfterFirstCarriageReturn;

                case BodyPartState.AfterFirstCarriageReturn:
                    if (buffer[bytesConsumed] != MimeMultipartParser.LF)
                    {
                        currentBodyPart.ResetBoundary();
                        bodyPartState = BodyPartState.BodyPart;
                        goto case BodyPartState.BodyPart;
                    }

                    // Remember potential boundary
                    currentBodyPart.AppendBoundary(MimeMultipartParser.LF);

                    // Move past the CR
                    bodyPartState = BodyPartState.AfterFirstLineFeed;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case BodyPartState.AfterFirstLineFeed;

                case BodyPartState.AfterFirstLineFeed:
                    if (buffer[bytesConsumed] == MimeMultipartParser.CR)
                    {
                        // Remember potential boundary
                        currentBodyPart.ResetBoundary();
                        currentBodyPart.AppendBoundary(MimeMultipartParser.CR);

                        // Move past the CR
                        bodyPartState = BodyPartState.AfterFirstCarriageReturn;
                        if (++bytesConsumed == effectiveMax)
                        {
                            goto quit;
                        }

                        goto case BodyPartState.AfterFirstCarriageReturn;
                    }

                    if (buffer[bytesConsumed] != MimeMultipartParser.Dash)
                    {
                        currentBodyPart.ResetBoundary();
                        bodyPartState = BodyPartState.BodyPart;
                        goto case BodyPartState.BodyPart;
                    }

                    // Remember potential boundary
                    currentBodyPart.AppendBoundary(MimeMultipartParser.Dash);

                    // Move past the Dash
                    bodyPartState = BodyPartState.AfterFirstDash;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case BodyPartState.AfterFirstDash;

                case BodyPartState.AfterFirstDash:
                    if (buffer[bytesConsumed] != MimeMultipartParser.Dash)
                    {
                        currentBodyPart.ResetBoundary();
                        bodyPartState = BodyPartState.BodyPart;
                        goto case BodyPartState.BodyPart;
                    }

                    // Remember potential boundary
                    currentBodyPart.AppendBoundary(MimeMultipartParser.Dash);

                    // Move past the Dash
                    bodyPartState = BodyPartState.Boundary;
                    if (++bytesConsumed == effectiveMax)
                    {
                        goto quit;
                    }

                    goto case BodyPartState.Boundary;

                case BodyPartState.Boundary:
                    segmentStart = bytesConsumed;
                    while (buffer[bytesConsumed] != MimeMultipartParser.CR)
                    {
                        if (++bytesConsumed == effectiveMax)
                        {
                            if (currentBodyPart.AppendBoundary(buffer, segmentStart, bytesConsumed - segmentStart))
                            {
                                if (currentBodyPart.IsBoundaryComplete())
                                {
                                    // At this point we've seen the end of a boundary segment that is aligned at the end
                                    // of the buffer - this might be because we have another segment coming or it might
                                    // truly be the end of the message.
                                    bodyPartState = BodyPartState.AfterBoundary;
                                }
                            }
                            else
                            {
                                currentBodyPart.ResetBoundary();
                                bodyPartState = BodyPartState.BodyPart;
                            }
                            goto quit;
                        }
                    }
                    
                    if (bytesConsumed > segmentStart)
                    {
                        if (!currentBodyPart.AppendBoundary(buffer, segmentStart, bytesConsumed - segmentStart))
                        {
                            currentBodyPart.ResetBoundary();
                            bodyPartState = BodyPartState.BodyPart;
                            goto case BodyPartState.BodyPart;
                        }
                    }

                    goto case BodyPartState.AfterBoundary;

                case BodyPartState.AfterBoundary:

                    // This state means that we just saw the end of a boundary. It might by a 'normal' boundary, in which
                    // case it's followed by optional whitespace and a CRLF. Or it might be the 'final' boundary and will 
                    // be followed by '--', optional whitespace and an optional CRLF.
                    if (buffer[bytesConsumed] == MimeMultipartParser.Dash && !currentBodyPart.IsFinal)
                    {
                        currentBodyPart.AppendBoundary(MimeMultipartParser.Dash);
                        if (++bytesConsumed == effectiveMax)
                        {
                            bodyPartState = BodyPartState.AfterSecondDash;
                            goto quit;
                        }

                        goto case BodyPartState.AfterSecondDash;
                    }

                    // Capture optional whitespace
                    segmentStart = bytesConsumed;
                    while (buffer[bytesConsumed] != MimeMultipartParser.CR)
                    {
                        if (++bytesConsumed == effectiveMax)
                        {
                            if (!currentBodyPart.AppendBoundary(buffer, segmentStart, bytesConsumed - segmentStart))
                            {
                                // It's an unexpected character
                                currentBodyPart.ResetBoundary();
                                bodyPartState = BodyPartState.BodyPart;
                            }

                            goto quit;
                        }
                    }

                    if (bytesConsumed > segmentStart)
                    {
                        if (!currentBodyPart.AppendBoundary(buffer, segmentStart, bytesConsumed - segmentStart))
                        {
                            currentBodyPart.ResetBoundary();
                            bodyPartState = BodyPartState.BodyPart;
                            goto case BodyPartState.BodyPart;
                        }
                    }

                    if (buffer[bytesConsumed] == MimeMultipartParser.CR)
                    {
                        currentBodyPart.AppendBoundary(MimeMultipartParser.CR);
                        if (++bytesConsumed == effectiveMax)
                        {
                            bodyPartState = BodyPartState.AfterSecondCarriageReturn;
                            goto quit;
                        }

                        goto case BodyPartState.AfterSecondCarriageReturn;
                    }
                    else
                    {
                        // It's an unexpected character
                        currentBodyPart.ResetBoundary();
                        bodyPartState = BodyPartState.BodyPart;
                        goto case BodyPartState.BodyPart;
                    }

                case BodyPartState.AfterSecondDash:
                    if (buffer[bytesConsumed] == MimeMultipartParser.Dash)
                    {
                        currentBodyPart.AppendBoundary(MimeMultipartParser.Dash);
                        bytesConsumed++;
                        
                        if (currentBodyPart.IsBoundaryComplete())
                        {
                            Debug.Assert(currentBodyPart.IsFinal);

                            // If we get in here, it means we've see the trailing '--' of the last boundary - in order to consume all of the 
                            // remaining bytes, we don't mark the parse as complete again - wait until this method is called again with the 
                            // empty buffer to do that.
                            bodyPartState = BodyPartState.AfterBoundary;
                            parseStatus = State.NeedMoreData;
                            goto quit;
                        }
                        else
                        {
                            currentBodyPart.ResetBoundary();
                            if (bytesConsumed == effectiveMax)
                            {
                                goto quit;
                            }

                            goto case BodyPartState.BodyPart;
                        }
                    }
                    else
                    {
                        currentBodyPart.ResetBoundary();
                        bodyPartState = BodyPartState.BodyPart;
                        goto case BodyPartState.BodyPart;
                    }

                case BodyPartState.AfterSecondCarriageReturn:
                    if (buffer[bytesConsumed] != MimeMultipartParser.LF)
                    {
                        currentBodyPart.ResetBoundary();
                        bodyPartState = BodyPartState.BodyPart;
                        goto case BodyPartState.BodyPart;
                    }

                    currentBodyPart.AppendBoundary(MimeMultipartParser.LF);
                    bytesConsumed++;

                    bodyPartState = BodyPartState.BodyPart;
                    if (currentBodyPart.IsBoundaryComplete())
                    {
                        parseStatus = State.BodyPartCompleted;
                        goto quit;
                    }
                    else
                    {
                        currentBodyPart.ResetBoundary();
                        if (bytesConsumed == effectiveMax)
                        {
                            goto quit;
                        }

                        goto case BodyPartState.BodyPart;
                    }
            }

        quit:
            if (initialBytesParsed < bytesConsumed)
            {
                int boundaryLength = currentBodyPart.BoundaryDelta;
                if (boundaryLength > 0 && parseStatus != State.BodyPartCompleted)
                {
                    currentBodyPart.HasPotentialBoundaryLeftOver = true;
                }

                int bodyPartEnd = bytesConsumed - initialBytesParsed - boundaryLength;

                currentBodyPart.BodyPart = new ArraySegment<byte>(buffer, initialBytesParsed, bodyPartEnd);
            }

            totalBytesConsumed += bytesConsumed - initialBytesParsed;
            return parseStatus;
        }

        /// <summary>
        /// Maintains information about the current body part being parsed.
        /// </summary>
        [DebuggerDisplay("{DebuggerToString()}")]
        private class CurrentBodyPartStore
        {
            private const int InitialOffset = 2;

            private byte[] _boundaryStore = new byte[MaxBoundarySize];
            private int _boundaryStoreLength;

            private byte[] _referenceBoundary = new byte[MaxBoundarySize];
            private int _referenceBoundaryLength;

            private byte[] _boundary = new byte[MaxBoundarySize];
            private int _boundaryLength = 0;

            private ArraySegment<byte> _bodyPart = MimeMultipartParser._emptyBodyPart;
            private bool _isFinal;
            private bool _isFirst = true;
            private bool _releaseDiscardedBoundary;
            private int _boundaryOffset;

            /// <summary>
            /// Initializes a new instance of the <see cref="CurrentBodyPartStore"/> class.
            /// </summary>
            /// <param name="referenceBoundary">The reference boundary.</param>
            public CurrentBodyPartStore(string referenceBoundary)
            {
                Contract.Assert(referenceBoundary != null);

                this._referenceBoundary[0] = MimeMultipartParser.CR;
                this._referenceBoundary[1] = MimeMultipartParser.LF;
                this._referenceBoundary[2] = MimeMultipartParser.Dash;
                this._referenceBoundary[3] = MimeMultipartParser.Dash;
                this._referenceBoundaryLength = 4 + Encoding.UTF8.GetBytes(referenceBoundary, 0, referenceBoundary.Length, this._referenceBoundary, 4);

                this._boundary[0] = MimeMultipartParser.CR;
                this._boundary[1] = MimeMultipartParser.LF;
                this._boundaryLength = CurrentBodyPartStore.InitialOffset;
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance has potential boundary left over.
            /// </summary>
            /// <value>
            /// <c>true</c> if this instance has potential boundary left over; otherwise, <c>false</c>.
            /// </value>
            public bool HasPotentialBoundaryLeftOver { get; set; }

            /// <summary>
            /// Gets the boundary delta.
            /// </summary>
            public int BoundaryDelta
            {
                get { return (this._boundaryLength - this._boundaryOffset > 0) ? this._boundaryLength - this._boundaryOffset : this._boundaryLength; }
            }

            /// <summary>
            /// Gets or sets the body part.
            /// </summary>
            /// <value>
            /// The body part.
            /// </value>
            public ArraySegment<byte> BodyPart
            {
                get { return this._bodyPart; }

                set { this._bodyPart = value; }
            }

            /// <summary>
            /// Gets a value indicating whether this body part instance is final.
            /// </summary>
            /// <value>
            ///   <c>true</c> if this body part instance is final; otherwise, <c>false</c>.
            /// </value>
            public bool IsFinal
            {
                get { return this._isFinal; }
            }

            /// <summary>
            /// Resets the boundary offset.
            /// </summary>
            public void ResetBoundaryOffset()
            {
                this._boundaryOffset = this._boundaryLength;
            }

            /// <summary>
            /// Resets the boundary.
            /// </summary>
            public void ResetBoundary()
            {
                // If we had a potential boundary left over then store it so that we don't loose it
                if (this.HasPotentialBoundaryLeftOver)
                {
                    Buffer.BlockCopy(this._boundary, 0, this._boundaryStore, 0, this._boundaryOffset);
                    this._boundaryStoreLength = this._boundaryOffset;
                    this.HasPotentialBoundaryLeftOver = false;
                    this._releaseDiscardedBoundary = true;
                }

                this._boundaryLength = 0;
                this._boundaryOffset = 0;
            }

            /// <summary>
            /// Appends byte to the current boundary.
            /// </summary>
            /// <param name="data">The data to append to the boundary.</param>
            public void AppendBoundary(byte data)
            {
                this._boundary[this._boundaryLength++] = data;
            }

            /// <summary>
            /// Appends array of bytes to the current boundary.
            /// </summary>
            /// <param name="data">The data to append to the boundary.</param>
            /// <param name="offset">The offset into the data.</param>
            /// <param name="count">The number of bytes to append.</param>
            public bool AppendBoundary(byte[] data, int offset, int count)
            {
                // Check that potential boundary is not bigger than our reference boundary. 
                // Allow for 2 extra characters to include the final boundary which ends with 
                // an additional "--" sequence + plus up to 4 LWS characters (which are allowed). 
                if (this._boundaryLength + count > this._referenceBoundaryLength + 6)
                {
                    return false;
                }

                int cnt = this._boundaryLength;
                Buffer.BlockCopy(data, offset, this._boundary, this._boundaryLength, count);
                this._boundaryLength += count;

                // Verify that boundary matches so far
                int maxCount = Math.Min(this._boundaryLength, this._referenceBoundaryLength);
                for (; cnt < maxCount; cnt++)
                {
                    if (this._boundary[cnt] != this._referenceBoundary[cnt])
                    {
                        return false;
                    }
                }

                return true;
            }

            /// <summary>
            /// Gets the discarded boundary.
            /// </summary>
            /// <returns>An <see cref="ArraySegment{T}"/> containing the discarded boundary.</returns>
            public ArraySegment<byte> GetDiscardedBoundary()
            {
                if (this._boundaryStoreLength > 0 && this._releaseDiscardedBoundary)
                {
                    ArraySegment<byte> discarded = new ArraySegment<byte>(this._boundaryStore, 0, this._boundaryStoreLength);
                    this._boundaryStoreLength = 0;
                    return discarded;
                }

                return MimeMultipartParser._emptyBodyPart;
            }

            /// <summary>
            /// Determines whether current boundary is valid.
            /// </summary>
            /// <returns>
            ///   <c>true</c> if curent boundary is valid; otherwise, <c>false</c>.
            /// </returns>
            public bool IsBoundaryValid()
            {
                int offset = 0;
                if (this._isFirst)
                {
                    offset = CurrentBodyPartStore.InitialOffset;
                }

                int count = offset;
                for (; count < this._referenceBoundaryLength; count++)
                {
                    if (this._boundary[count] != this._referenceBoundary[count])
                    {
                        return false;
                    }
                }

                // Check for final
                bool boundaryIsFinal = false;
                if (this._boundary[count] == MimeMultipartParser.Dash &&
                    this._boundary[count + 1] == MimeMultipartParser.Dash)
                {
                    boundaryIsFinal = true;
                    count += 2;
                }

                // Rest of boundary must be ignorable whitespace in order for it to match
                for (; count < this._boundaryLength - 2; count++)
                {
                    if (this._boundary[count] != MimeMultipartParser.SP && this._boundary[count] != MimeMultipartParser.HTAB)
                    {
                        return false;
                    }
                }

                // We have a valid boundary so whatever we stored in the boundary story is no longer needed
                this._isFinal = boundaryIsFinal;
                this._isFirst = false;

                return true;
            }

            public bool IsBoundaryComplete()
            {
                if (!this.IsBoundaryValid())
                {
                    return false;
                }
                
                if (this._boundaryLength < this._referenceBoundaryLength)
                {
                    return false;
                }

                if (this._boundaryLength == this._referenceBoundaryLength + 1 &&
                    this._boundary[this._referenceBoundaryLength] == MimeMultipartParser.Dash)
                {
                    return false;
                }

                return true;
            }

            /// <summary>
            /// Clears the body part.
            /// </summary>
            public void ClearBodyPart()
            {
                this.BodyPart = MimeMultipartParser._emptyBodyPart;
            }

            /// <summary>
            /// Clears all.
            /// </summary>
            public void ClearAll()
            {
                this._releaseDiscardedBoundary = false;
                this.HasPotentialBoundaryLeftOver = false;
                this._boundaryLength = 0;
                this._boundaryOffset = 0;
                this._boundaryStoreLength = 0;
                this._isFinal = false;
                this.ClearBodyPart();
            }

            [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used for Debugger Display.")]
            private string DebuggerToString()
            {
                var referenceBoundary = Encoding.UTF8.GetString(this._referenceBoundary, 0, this._referenceBoundaryLength);
                var boundary = Encoding.UTF8.GetString(this._boundary, 0, this._boundaryLength);

                return String.Format(
                    CultureInfo.InvariantCulture, 
                    "Expected: {0} *** Current: {1}", 
                    referenceBoundary, 
                    boundary);
            }
        }
    }
}
