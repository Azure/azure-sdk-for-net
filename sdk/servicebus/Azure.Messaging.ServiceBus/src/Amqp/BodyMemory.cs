// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal sealed class BodyMemory : IEnumerable<ReadOnlyMemory<byte>>
    {
        private ArrayBufferWriter<byte> _writer;
        private IList<ReadOnlyMemory<byte>> _segments;
        private IEnumerable<ReadOnlyMemory<byte>> _lazySegments;

        private ReadOnlyMemory<byte> WrittenMemory
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
        private BodyMemory(IEnumerable<ReadOnlyMemory<byte>> dataSegments)
        {
            _lazySegments = dataSegments;
        }

        // for the receive path the combined memory is precomputed because we need to copy the underlying AMQP data anyway
        private BodyMemory(IEnumerable<Data> dataSegments)
        {
            foreach (var segment in dataSegments)
            {
                Append(segment);
            }
        }

        public static BodyMemory FromReadOnlyMemory(IEnumerable<ReadOnlyMemory<byte>> segments)
        {
            return segments as BodyMemory ?? new BodyMemory(segments);
        }

        public static BodyMemory FromAmqpData(IEnumerable<Data> segments)
        {
            return new BodyMemory(segments ?? Enumerable.Empty<Data>());
        }

        public IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
        {
            return _segments?.GetEnumerator() ?? _lazySegments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        private void Append(Data segment)
        {
            ReadOnlyMemory<byte> dataToAppend = segment.Value switch
            {
                byte[] byteArray => byteArray,
                ArraySegment<byte> arraySegment => arraySegment,
                _ => ReadOnlyMemory<byte>.Empty
            };

            Append(dataToAppend);
        }

        public static implicit operator ReadOnlyMemory<byte>(BodyMemory memory)
        {
            return memory.WrittenMemory;
        }
    }
}
