// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal abstract class BodyMemory : IEnumerable<ReadOnlyMemory<byte>>
    {
        public static BodyMemory FromReadOnlyMemory(IEnumerable<ReadOnlyMemory<byte>> segments)
        {
            return segments switch
            {
                BodyMemory bodyMemory => bodyMemory,
                _ => new SendWithMultipleDataSegmentsBodyMemory(segments)
            };
        }

        public static BodyMemory FromReadOnlyMemory(ReadOnlyMemory<byte> segment)
        {
            return new SendWithSingleDataSegmentBodyMemory(segment);
        }

        public static BodyMemory FromAmqpData(IEnumerable<Data> segments)
        {
            return new ReceiveBodyMemory(segments ?? Enumerable.Empty<Data>());
        }

        protected abstract ReadOnlyMemory<byte> WrittenMemory { get; }

        public abstract IEnumerator<ReadOnlyMemory<byte>> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator ReadOnlyMemory<byte>(BodyMemory memory)
        {
            return memory.WrittenMemory;
        }

        private sealed class SendWithSingleDataSegmentBodyMemory : BodyMemory
        {
            public SendWithSingleDataSegmentBodyMemory(ReadOnlyMemory<byte> dataSegment)
            {
                WrittenMemory = dataSegment;
            }

            protected override ReadOnlyMemory<byte> WrittenMemory { get; }

            public override IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
            {
                yield return WrittenMemory;
            }
        }

        private sealed class ReceiveBodyMemory : BodyMemory
        {
            private ArrayBufferWriter<byte> _writer;
            private IList<ReadOnlyMemory<byte>> _segments;

            // for the receive path the combined memory is precomputed because we need to copy the underlying AMQP data anyway
            internal ReceiveBodyMemory(IEnumerable<Data> dataSegments)
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
                ReadOnlyMemory<byte> dataToAppend = segment.Value switch
                {
                    byte[] byteArray => byteArray,
                    ArraySegment<byte> arraySegment => arraySegment,
                    _ => ReadOnlyMemory<byte>.Empty
                };

                _writer ??= new ArrayBufferWriter<byte>();
                _segments ??= new List<ReadOnlyMemory<byte>>();

                var memory = _writer.GetMemory(dataToAppend.Length);
                dataToAppend.CopyTo(memory);
                _writer.Advance(dataToAppend.Length);
                _segments.Add(memory.Slice(0, dataToAppend.Length));
            }
        }

        private sealed class SendWithMultipleDataSegmentsBodyMemory : BodyMemory
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

            // for the send path the combined memory for the body is not precomputed
            internal SendWithMultipleDataSegmentsBodyMemory(IEnumerable<ReadOnlyMemory<byte>> dataSegments)
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
    }
}
