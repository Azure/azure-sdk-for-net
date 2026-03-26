// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Internal.Avro;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class ChunkBase<TEvent>
    {
        private readonly AvroReader _avroReader;
        private readonly Func<Dictionary<string, object>, TEvent> _eventParser;

        public virtual long BlockOffset { get; private set; }
        public virtual long EventIndex { get; private set; }
        public virtual string ChunkPath { get; private set; }

        public ChunkBase(AvroReader avroReader, long blockOffset, long eventIndex, string chunkPath, Func<Dictionary<string, object>, TEvent> eventParser)
        {
            _avroReader = avroReader;
            BlockOffset = blockOffset;
            EventIndex = eventIndex;
            ChunkPath = chunkPath;
            _eventParser = eventParser;
        }

        public virtual bool HasNext() => _avroReader.HasNext();

        public virtual async Task<TEvent> Next(bool async, CancellationToken cancellationToken = default)
        {
            if (!HasNext()) return default;
            Dictionary<string, object> result = (Dictionary<string, object>)await _avroReader.Next(async, cancellationToken).ConfigureAwait(false);
            BlockOffset = _avroReader.BlockOffset;
            EventIndex = _avroReader.ObjectIndex;
            return _eventParser(result);
        }

        internal ChunkBase() { }
    }
}
