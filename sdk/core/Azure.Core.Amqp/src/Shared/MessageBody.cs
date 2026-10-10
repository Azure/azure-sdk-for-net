// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Amqp.Framing;

#nullable enable

namespace Azure.Core.Amqp
{
    /// <summary>
    /// The body abstractions allow optimizing several use cases to make sure body memory is only converted when needed and as little as possible.
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

        public static MessageBody FromDataSegments(IEnumerable<Data> segments)
        {
            // AMQP library almost always returns List<Data> or Data[], and in many cases there is only a single segment.
            // We can optimize for that case to avoid the list allocation and enumeration overhead.
            if (segments is not IList<Data> { Count: 1 } single)
            {
                return new EagerCopyingMessageBody(segments ?? Enumerable.Empty<Data>());
            }

            return new EagerCopyingSingleSegmentMessageBody(GetDataAsMemory(single[0]));
        }

        protected abstract ReadOnlyMemory<byte> WrittenMemory { get; }

        public abstract IEnumerator<ReadOnlyMemory<byte>> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator ReadOnlyMemory<byte>(MessageBody memory)
        {
            return memory.WrittenMemory;
        }

        private static ReadOnlyMemory<byte> GetDataAsMemory(Data data) =>
            data.Value switch
            {
                byte[] bytes => (ReadOnlyMemory<byte>)bytes,
                ArraySegment<byte> seg => seg,
                _ => ReadOnlyMemory<byte>.Empty
            };

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
            private ArrayBufferWriter<byte>? _writer;
            private IList<ReadOnlyMemory<byte>>? _segments;
            private IEnumerable<ReadOnlyMemory<byte>>? _lazySegments;

            internal CopyingOnConversionMessageBody(IEnumerable<ReadOnlyMemory<byte>> dataSegments)
            {
                _lazySegments = dataSegments;
            }

            protected override ReadOnlyMemory<byte> WrittenMemory
            {
                get
                {
                    if (_lazySegments != null)
                    {
                        // fields are lazy initialized to not occupy unnecessary memory when there are no data segments
                        Segments.Append(_lazySegments, ref _writer!, ref _segments!);
                        _lazySegments = null;
                    }

                    return _writer?.WrittenMemory ?? ReadOnlyMemory<byte>.Empty;
                }
            }

            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
            {
                return _segments?.GetEnumerator() ?? _lazySegments!.GetEnumerator();
            }
        }

        /// <summary>
        /// Eagerly copies the provided data segment into a single continuous buffer.
        /// Important for the receive path to make sure the buffers managed by the underlying AMQP library can be released on dispose.
        /// </summary>
        private sealed class EagerCopyingSingleSegmentMessageBody : MessageBody
        {
            private readonly ArrayBufferWriter<byte> _writer;

            internal EagerCopyingSingleSegmentMessageBody(ReadOnlyMemory<byte> segment)
            {
                _writer = segment.Length > 0
                    ? new ArrayBufferWriter<byte>(segment.Length)
                    : new ArrayBufferWriter<byte>();

                if (segment.Length > 0)
                {
                    _writer.Write(segment.Span);
                }
            }

            protected override ReadOnlyMemory<byte> WrittenMemory => _writer.WrittenMemory;

            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
            {
                yield return _writer.WrittenMemory;
            }
        }

        /// <summary>
        /// Eagerly copies the provided data segments into a single continuous buffer while still keeping around a list of the individual copied segments.
        /// Important for the receive path to make sure the buffers managed by the underlying AMQP library can be released on dispose.
        /// </summary>
        private sealed class EagerCopyingMessageBody : MessageBody
        {
            private readonly ArrayBufferWriter<byte> _writer;
            private readonly IList<ReadOnlyMemory<byte>> _segments;

            internal EagerCopyingMessageBody(IEnumerable<Data> dataSegments)
            {
                // fields are lazy initialized to not occupy unnecessary memory when there are no data segments
                Segments.Append(dataSegments, ref _writer!, ref _segments!);
            }

            protected override ReadOnlyMemory<byte> WrittenMemory => _writer?.WrittenMemory ?? ReadOnlyMemory<byte>.Empty;

            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
            {
                return _segments.GetEnumerator();
            }
        }

        private static class Segments
        {
            public static void Append<T>(IEnumerable<T> dataSegments, ref ArrayBufferWriter<byte> refWriter,
                ref IList<ReadOnlyMemory<byte>> refSegments)
            {
                int length = 0;
                int numberOfSegments = 0;
                List<ReadOnlyMemory<byte>>? segments = null;
                foreach (var segment in dataSegments)
                {
                    segments ??= dataSegments is IReadOnlyCollection<Data> readOnlyList
                        ? new List<ReadOnlyMemory<byte>>(readOnlyList.Count)
                        : new List<ReadOnlyMemory<byte>>();
                    ReadOnlyMemory<byte> dataToAppend = segment switch
                    {
                        ReadOnlyMemory<byte> romSegment => romSegment,
                        Data data => GetDataAsMemory(data),
                        _ => ThrowArgumentOutOfRange(nameof(segment))
                    };
                    length += dataToAppend.Length;
                    numberOfSegments++;
                    segments.Add(dataToAppend);
                }

                if (segments == null)
                {
                    return;
                }

                refWriter = length > 0 ? new ArrayBufferWriter<byte>(length) : new ArrayBufferWriter<byte>();
                refSegments = segments;

                for (var i = 0; i < numberOfSegments; i++)
                {
                    var dataToAppend = segments[i];
                    int writtenBefore = refWriter.WrittenCount;
                    refWriter.Write(dataToAppend.Span);
                    segments[i] = refWriter.WrittenMemory.Slice(writtenBefore, dataToAppend.Length);
                }
            }

            private static ReadOnlyMemory<byte> ThrowArgumentOutOfRange(string paramName)
            {
                throw new ArgumentOutOfRangeException(paramName, "Provided data segment is not compatible.");
            }
        }
    }
}
