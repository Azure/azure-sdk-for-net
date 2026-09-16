// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Internal.Avro;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Reads change feed events from a single Avro chunk file, tracking block offset and event index
    /// for cursor support. Parameterized by event type so the same logic serves Blob and Files change feeds.
    /// </summary>
    internal class ChunkBase<TEvent> where TEvent : IChangeFeedEvent
    {
        private readonly AvroReader _avroReader;
        private readonly Func<Dictionary<string, object>, TEvent> _eventParser;

        /// <summary>
        /// Byte offset of the current Avro block within the chunk.
        /// </summary>
        public virtual long BlockOffset { get; private set; }

        /// <summary>
        /// Zero-based index of the current event within the Avro block.
        /// </summary>
        public virtual long EventIndex { get; private set; }

        /// <summary>
        /// Blob path of this chunk.
        /// </summary>
        public virtual string ChunkPath { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkBase{TEvent}"/> class.
        /// </summary>
        /// <param name="avroReader">The Avro reader positioned at the start of the chunk or a resumed block.</param>
        /// <param name="blockOffset">Initial block byte offset (non-zero when resuming from a cursor).</param>
        /// <param name="eventIndex">Initial event index within the block (non-zero when resuming).</param>
        /// <param name="chunkPath">Blob path of the chunk.</param>
        /// <param name="eventParser">Delegate that converts a raw Avro record into a typed event.</param>
        public ChunkBase(
            AvroReader avroReader,
            long blockOffset,
            long eventIndex,
            string chunkPath,
            Func<Dictionary<string, object>, TEvent> eventParser)
        {
            _avroReader = avroReader;
            BlockOffset = blockOffset;
            EventIndex = eventIndex;
            ChunkPath = chunkPath;
            _eventParser = eventParser;
        }

        /// <summary>
        /// Returns true if the underlying Avro reader has more events.
        /// </summary>
        public virtual bool HasNext() => _avroReader.HasNext();

        /// <summary>
        /// Reads the next event from this chunk, advancing the block offset and event index.
        /// </summary>
        /// <returns>The next typed event, or default if no more events remain.</returns>
        public virtual async Task<TEvent> Next(bool async, CancellationToken cancellationToken = default)
        {
            if (!HasNext()) return default;
            Dictionary<string, object> result = (Dictionary<string, object>)await _avroReader.Next(async, cancellationToken).ConfigureAwait(false);
            BlockOffset = _avroReader.BlockOffset;
            EventIndex = _avroReader.ObjectIndex;
            // Invoke the configured parser delegate to convert the raw Avro dictionary into a strongly-typed event.
            return _eventParser(result);
        }

        /// <summary>
        /// Constructor for mocking. Do not use directly.
        /// </summary>
        internal ChunkBase() { }
    }
}
