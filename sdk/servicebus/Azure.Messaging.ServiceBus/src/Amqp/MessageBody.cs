// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    /// The body abstractions allow to optimize several use cases of <see cref="ServiceBusMessage"/> and
    /// <see cref="ServiceBusReceivedMessage"/> to make sure body memory is only converted when needed and as little as possible.
    /// </summary>
    internal abstract class MessageBody : IEnumerable<ReadOnlyMemory<byte>>
    {
        public static MessageBody FromReadOnlyMemorySegments(IEnumerable<ReadOnlyMemory<byte>> segments)
        {
            return segments switch
            {
                MessageBody bodyMemory => bodyMemory,
                _ => new CopyingOnConversionMessageBody(segments)
            };
        }

        public static MessageBody FromReadOnlyMemorySegment(ReadOnlyMemory<byte> segment)
        {
            return new NonCopyingSingleSegmentMessageBody(segment);
        }

        public static MessageBody FromDataSegments(IEnumerable<Data> segments, bool poolReceivedMessageBodies = false)
        {
            IEnumerable<Data> dataSegments = segments ?? Enumerable.Empty<Data>();
            return poolReceivedMessageBodies
                ? new EagerCopyingMessageBodyWithManagedBuffer(dataSegments)
                : new EagerCopyingMessageBody(dataSegments);
        }

        protected abstract ReadOnlyMemory<byte> WrittenMemory { get; }

        public abstract IEnumerator<ReadOnlyMemory<byte>> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Release()
        {
        }

        public static implicit operator ReadOnlyMemory<byte>(MessageBody memory)
        {
            return memory.WrittenMemory;
        }

        protected static ReadOnlyMemory<byte> Convert(Data segment)
        {
            return segment.Value switch
            {
                byte[] byteArray => byteArray,
                ArraySegment<byte> arraySegment => arraySegment,
                _ => ReadOnlyMemory<byte>.Empty
            };
        }

        /// <summary>
        /// Wraps a single data segment into an enumerable like type without copying to optimize for the most commonly used
        /// path by always bridging into enumerable like behavior without the additional overhead of underlying lists and copying.
        /// This is the common path for ServiceBusMessage when the Body is set via constructor or the Body property.
        /// </summary>
        private sealed class NonCopyingSingleSegmentMessageBody : MessageBody
        {
            public NonCopyingSingleSegmentMessageBody(ReadOnlyMemory<byte> dataSegment)
            {
                WrittenMemory = dataSegment;
            }

            protected override ReadOnlyMemory<byte> WrittenMemory { get; }

            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
            {
                yield return WrittenMemory;
            }
        }

        /// <summary>
        /// Copies the provided segments into a single continuous buffer on demand while still keeping around a list of the individual copied segments.
        /// This path is hit when users modify the body via the underlying AmqpAnnotatedMessage.
        /// </summary>
        private sealed class CopyingOnConversionMessageBody : MessageBody
        {
            private ArrayBufferWriter<byte> _writer;
            private IList<ReadOnlyMemory<byte>> _segments;
            private IEnumerable<ReadOnlyMemory<byte>> _lazySegments;

            protected override ReadOnlyMemory<byte> WrittenMemory
            {
                get
                {
                    if (_lazySegments != null)
                    {
                        foreach (var segment in _lazySegments)
                        {
                            Append(segment);
                        }

                        _lazySegments = null;
                    }

                    return _writer?.WrittenMemory ?? ReadOnlyMemory<byte>.Empty;
                }
            }

            internal CopyingOnConversionMessageBody(IEnumerable<ReadOnlyMemory<byte>> dataSegments)
            {
                _lazySegments = dataSegments;
            }

            private void Append(ReadOnlyMemory<byte> segment)
            {
                _writer ??= new ArrayBufferWriter<byte>();
                _segments ??= new List<ReadOnlyMemory<byte>>();

                var memory = _writer.GetMemory(segment.Length);
                segment.CopyTo(memory);
                _writer.Advance(segment.Length);
                _segments.Add(memory.Slice(0, segment.Length));
            }

            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
            {
                return _segments?.GetEnumerator() ?? _lazySegments.GetEnumerator();
            }
        }

        /// <summary>
        /// Eagerly copies the provided data segments into a single continuous buffer while still keeping around a list of the individual copied segments.
        /// Important for the receive path in order to make sure the buffers managed by the underlying AMQP library can be released on dispose.
        /// </summary>
        private sealed class EagerCopyingMessageBody : MessageBody
        {
            private ArrayBufferWriter<byte> _writer;
            private IList<ReadOnlyMemory<byte>> _segments;

            internal EagerCopyingMessageBody(IEnumerable<Data> dataSegments)
            {
                foreach (var segment in dataSegments)
                {
                    Append(segment);
                }
            }

            protected override ReadOnlyMemory<byte> WrittenMemory => _writer?.WrittenMemory ?? ReadOnlyMemory<byte>.Empty;

            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
            {
                return _segments.GetEnumerator();
            }

            private void Append(Data segment)
            {
                // fields are lazy initialized to not occupy unnecessary memory when there are no data segments
                _writer ??= new ArrayBufferWriter<byte>();
                _segments ??= new List<ReadOnlyMemory<byte>>();

                var dataToAppend = Convert(segment);

                var memory = _writer.GetMemory(dataToAppend.Length);
                dataToAppend.CopyTo(memory);
                _writer.Advance(dataToAppend.Length);
                _segments.Add(memory.Slice(0, dataToAppend.Length));
            }
        }

        /// <summary>
        /// Eagerly copies the provided data segments into a single continuous buffer while still keeping around a list of the individual copied segments.
        /// Important for the receive path in order to make sure the buffers managed by the underlying AMQP library can be released on dispose.
        /// </summary>
        private sealed class EagerCopyingMessageBodyWithManagedBuffer : MessageBody
        {
            private IList<ReadOnlyMemory<byte>> _segments;
            private byte[] _continuousBuffer;
            private ReadOnlyMemory<byte>? _writtenMemory;

            internal EagerCopyingMessageBodyWithManagedBuffer(IEnumerable<Data> dataSegments)
            {
                Append(dataSegments);
            }

            protected override ReadOnlyMemory<byte> WrittenMemory => _writtenMemory ?? ReadOnlyMemory<byte>.Empty;

            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
            {
                return _segments.GetEnumerator();
            }

            private void Append(IEnumerable<Data> dataSegments)
            {
                int length = 0;
                List<ReadOnlyMemory<byte>> convertedSegments = null;
                foreach (var dataSegment in dataSegments)
                {
                    convertedSegments ??= new List<ReadOnlyMemory<byte>>();
                    ReadOnlyMemory<byte> readOnlyMemory = Convert(dataSegment);
                    convertedSegments.Add(readOnlyMemory);
                    length += readOnlyMemory.Length;
                }

                if (convertedSegments == null)
                {
                    return;
                }

                _segments ??= new List<ReadOnlyMemory<byte>>();
                _continuousBuffer = ArrayPool<byte>.Shared.Rent(length);
                Memory<byte> asMemory = _continuousBuffer.AsMemory();
                int start = 0;
                foreach (ReadOnlyMemory<byte> segment in convertedSegments)
                {
                    Memory<byte> destination = asMemory.Slice(start, segment.Length);
                    segment.CopyTo(destination);
                    _segments.Add(destination);
                    start += segment.Length;
                }

                _writtenMemory = asMemory.Slice(0, length);
            }

            public override void Release()
            {
                if (_continuousBuffer == null)
                {
                    return;
                }

                _writtenMemory = null;
                _segments.Clear();
                ArrayPool<byte>.Shared.Return(_continuousBuffer);
            }
        }
    }
}
