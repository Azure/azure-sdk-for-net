// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Core.Amqp;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   A set of abstractions for an AMQP message body to allow optimization of allocations when using <see cref="EventData" />.
    ///   The goal of the approach is to ensure that body memory is converted on-demand and as infrequently as possible.
    /// </summary>
    ///
    internal abstract class MessageBody : IEnumerable<ReadOnlyMemory<byte>>
    {
        /// <summary>
        ///   The memory that was written to the message body.
        /// </summary>
        ///
        protected abstract ReadOnlyMemory<byte> WrittenMemory { get; }

        /// <summary>
        ///   Produces an enumerator for the segments of the message body.
        /// </summary>
        ///
        /// <returns>An enumerator that can be used to iterate through the segments of the message body.</returns>
        ///
        public abstract IEnumerator<ReadOnlyMemory<byte>> GetEnumerator();

        /// <summary>
        ///   Produces an enumerator for the segments of the message body.
        /// </summary>
        ///
        /// <returns>An enumerator that can be used to iterate through the segments of the message body.</returns>
        ///
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        ///   Creates an message body instance from a set of memory segments.
        /// </summary>
        ///
        /// <param name="segments">The memory segments that should comprise the message body.</param>
        ///
        /// <returns>The <see cref="MessageBody"/> comprised of the <paramref name="segments"/>.</returns>
        ///
        public static MessageBody FromReadOnlyMemorySegments(IEnumerable<ReadOnlyMemory<byte>> segments) =>
            segments switch
            {
                MessageBody bodyMemory => bodyMemory,
                _ => new CopyingOnConversionMessageBody(segments)
            };

        /// <summary>
        ///   Creates an message body instance from a single of memory segment.
        /// </summary>
        ///
        /// <param name="segment">The memory segment that should comprise the message body.</param>
        ///
        /// <returns>The <see cref="MessageBody"/> comprised of the <paramref name="segment"/>.</returns>
        ///
        public static MessageBody FromReadOnlyMemorySegment(ReadOnlyMemory<byte> segment) => new NonCopyingSingleSegmentMessageBody(segment);

        /// <summary>
        ///   Creates an message body instance from a set of AMQP <see cref="Data" /> segments.
        /// </summary>
        ///
        /// <param name="segments">The data segments that should comprise the message body.</param>
        ///
        /// <returns>The <see cref="MessageBody"/> comprised of the <paramref name="segments"/>.</returns>
        ///
        public static MessageBody FromDataSegments(IEnumerable<Data> segments) => new EagerCopyingMessageBody(segments ?? Enumerable.Empty<Data>());

        /// <summary>
        ///   Performs an implicit conversion from <see cref="MessageBody"/> to <see cref="ReadOnlyMemory{Byte}"/>.
        /// </summary>
        ///
        /// <param name="messageBody">The message body to convert.</param>
        ///
        /// <returns>The <see cref="ReadOnlyMemory{Byte}" /> produced by the conversion.</returns>
        ///
        public static implicit operator ReadOnlyMemory<byte>(MessageBody messageBody) => messageBody.WrittenMemory;

        /// <summary>
        ///   Represents a single memory segment as an enumerable type without allocating a copy.
        ///   This optimizes for the most common usage scenario when the <see cref="EventData" /> body
        ///   is set via the constructor and interacted with exclusively through that type.
        /// </summary>
        ///
        private sealed class NonCopyingSingleSegmentMessageBody : MessageBody
        {
            /// <summary>
            ///   The memory that was written to the message body.
            /// </summary>
            ///
            protected override ReadOnlyMemory<byte> WrittenMemory { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="NonCopyingSingleSegmentMessageBody"/> class.
            /// </summary>
            ///
            /// <param name="dataSegment">The data segment to create the body from.</param>
            ///
            public NonCopyingSingleSegmentMessageBody(ReadOnlyMemory<byte> dataSegment)
            {
                WrittenMemory = dataSegment;
            }

            /// <summary>
            ///   Produces an enumerator for the segments of the message body.
            /// </summary>
            ///
            /// <returns>An enumerator that can be used to iterate through the segments of the message body.</returns>
            ///
            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
            {
                yield return WrittenMemory;
            }
        }

        /// <summary>
        ///   Represents multiple segments as a continuous buffer, performing the necessary copies on demand while
        ///   continuing to track the segments individually.  This optimizes for the usage scenario of the body being
        ///   manipulated directly via the <see cref="AmqpAnnotatedMessage"/> that owns it.
        /// </summary>
        ///
        private sealed class CopyingOnConversionMessageBody : MessageBody
        {
            /// <summary>The writer used to build the continuous buffer from a set of segments.</summary>
            private ArrayBufferWriter<byte> _writer;

            ///<summary>The set of individual memory segments that comprise the body.</summary>
            private IList<ReadOnlyMemory<byte>> _segments;

            /// <summary>The set of individual memory segments that were captured on creation of the body, until they're copied into the buffer.</summary>
            private IEnumerable<ReadOnlyMemory<byte>> _lazySegments;

            /// <summary>
            ///   The memory that was written to the message body.
            /// </summary>
            ///
            protected override ReadOnlyMemory<byte> WrittenMemory
            {
                get
                {
                    if (_lazySegments != null)
                    {
                        foreach (var segment in _lazySegments)
                        {
                            AppendSegment(segment);
                        }

                        _lazySegments = null;
                    }

                    return _writer?.WrittenMemory ?? ReadOnlyMemory<byte>.Empty;
                }
            }

            /// <summary>
            ///   Initializes a new instance of the <see cref="CopyingOnConversionMessageBody"/> class.
            /// </summary>
            ///
            /// <param name="dataSegments">The data segments to create the body from.</param>
            ///
            public CopyingOnConversionMessageBody(IEnumerable<ReadOnlyMemory<byte>> dataSegments)
            {
                _lazySegments = dataSegments;
            }

            /// <summary>
            ///   Produces an enumerator for the segments of the message body.
            /// </summary>
            ///
            /// <returns>An enumerator that can be used to iterate through the segments of the message body.</returns>
            ///
            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator() =>
                _segments?.GetEnumerator() ?? _lazySegments.GetEnumerator();

            /// <summary>
            ///   Appends a memory segment to the continuous buffer.
            /// </summary>
            ///
            /// <param name="segment">The memory segment to append.</param>
            ///
            private void AppendSegment(ReadOnlyMemory<byte> segment)
            {
                _writer ??= new ArrayBufferWriter<byte>();
                _segments ??= new List<ReadOnlyMemory<byte>>();

                var memory = _writer.GetMemory(segment.Length);
                segment.CopyTo(memory);

                _writer.Advance(segment.Length);
                _segments.Add(memory.Slice(0, segment.Length));
            }
        }

        /// <summary>
        ///   Represents multiple segments as a continuous buffer, performing the necessary copies eagerly while
        ///   continuing to track the segments individually.  This optimizes for the usage scenario of the body being
        ///   created when messages are received, ensuring that buffers managed by the underling AMQP library can be safely
        ///   released.
        /// </summary>
        ///
        private sealed class EagerCopyingMessageBody : MessageBody
        {
            /// <summary>The writer used to build the continuous buffer from a set of segments.</summary>
            private ArrayBufferWriter<byte> _writer;

            ///<summary>The set of individual memory segments that comprise the body.</summary>
            private IList<ReadOnlyMemory<byte>> _segments;

            /// <summary>
            ///   The memory that was written to the message body.
            /// </summary>
            ///
            protected override ReadOnlyMemory<byte> WrittenMemory => _writer?.WrittenMemory ?? ReadOnlyMemory<byte>.Empty;

            /// <summary>
            ///   Initializes a new instance of the <see cref="EagerCopyingMessageBody"/> class.
            /// </summary>
            ///
            /// <param name="dataSegments">The data segments to create the body from.</param>
            ///
            public EagerCopyingMessageBody(IEnumerable<Data> dataSegments)
            {
                foreach (var segment in dataSegments)
                {
                    AppendSegment(segment);
                }
            }

            /// <summary>
            ///   Produces an enumerator for the segments of the message body.
            /// </summary>
            ///
            /// <returns>An enumerator that can be used to iterate through the segments of the message body.</returns>
            ///
            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator() => _segments.GetEnumerator();

            /// <summary>
            ///   Appends a memory segment to the continuous buffer.
            /// </summary>
            ///
            /// <param name="segment">The memory segment to append.</param>
            ///
            private void AppendSegment(Data segment)
            {
                _writer ??= new ArrayBufferWriter<byte>();
                _segments ??= new List<ReadOnlyMemory<byte>>();

                ReadOnlyMemory<byte> dataToAppend = segment.Value switch
                {
                    byte[] byteArray => byteArray,
                    ArraySegment<byte> arraySegment => arraySegment,
                    _ => ReadOnlyMemory<byte>.Empty
                };

                var memory = _writer.GetMemory(dataToAppend.Length);
                dataToAppend.CopyTo(memory);

                _writer.Advance(dataToAppend.Length);
                _segments.Add(memory.Slice(0, dataToAppend.Length));
            }
        }
    }
}
