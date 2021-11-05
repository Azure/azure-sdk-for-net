// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Threading;

namespace Azure.Storage.Internal.Avro
{
    internal class AvroReader : IDisposable
    {
        /// <summary>
        /// Stream containing the body of the Avro file.
        /// </summary>
        private readonly Stream _dataStream;

        /// <summary>
        /// Stream containing the header of the Avro file.
        /// </summary>
        private readonly Stream _headerStream;

        /// <summary>
        /// Sync marker.
        /// </summary>
        private byte[] _syncMarker;

        /// <summary>
        /// Avro metadata.
        /// </summary>
        private Dictionary<string, string> _metadata;

        /// <summary>
        /// Avro schema.
        /// </summary>
        private AvroType _itemType;

        /// <summary>
        /// The number of items remaining in the current block.
        /// </summary>
        private long _itemsRemainingInBlock;

        /// <summary>
        /// The byte offset within the Avro file (both header and data)
        /// of the start of the current block.
        /// </summary>
        public virtual long BlockOffset { get; private set; }

        /// <summary>
        /// The index of the current object within the current block.
        /// </summary>
        /// <returns></returns>
        public virtual long ObjectIndex { get; private set; }

        /// <summary>
        /// If this Avro Reader has been initalized.
        /// </summary>
        private bool _initalized;

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Remembers where we started if partial data stream was provided.
        /// </summary>
        private readonly long _initialBlockOffset;

        /// <summary>
        /// Constructor for an AvroReader that will read from the
        /// beginning of an Avro file.
        /// </summary>
        public AvroReader(Stream dataStream)
        {
            if (dataStream.CanSeek)
            {
                _dataStream = dataStream;
                _headerStream = dataStream;
            }
            else
            {
                _dataStream = new StreamWithPosition(dataStream);
                _headerStream = _dataStream;
            }

            _metadata = new Dictionary<string, string>();
            _initalized = false;
        }

        /// <summary>
        /// Constructor for an Avro Reader that will read beginning
        /// in the middle of an Avro file.
        /// </summary>
        public AvroReader(
            Stream dataStream,
            Stream headerStream,
            long currentBlockOffset,
            long indexWithinCurrentBlock)
        {
            if (dataStream.CanSeek)
            {
                _dataStream = dataStream;
            }
            else
            {
                _dataStream = new StreamWithPosition(dataStream);
            }

            if (headerStream.CanSeek)
            {
                _headerStream = headerStream;
            }
            else
            {
                _headerStream = new StreamWithPosition(headerStream);
            }

            _metadata = new Dictionary<string, string>();
            _initalized = false;
            _initialBlockOffset = currentBlockOffset;
            BlockOffset = currentBlockOffset;
            ObjectIndex = indexWithinCurrentBlock;
            _initalized = false;
        }

        /// <summary>
        /// Constructor for mocking.  Do not use.
        /// </summary>
        public AvroReader() { }

        public virtual async Task Initalize(bool async, CancellationToken cancellationToken = default)
        {
            // Four bytes, ASCII 'O', 'b', 'j', followed by 1.
            byte[] header = await AvroParser.ReadFixedBytesAsync(_headerStream, AvroConstants.InitBytes.Length, async, cancellationToken).ConfigureAwait(false);
            if (!header.SequenceEqual(AvroConstants.InitBytes))
            {
                throw new ArgumentException("Stream is not an Avro file.");
            }

            // File metadata is written as if defined by the following map schema:
            // { "type": "map", "values": "bytes"}
            _metadata = await AvroParser.ReadMapAsync(_headerStream, AvroParser.ReadStringAsync, async, cancellationToken).ConfigureAwait(false);

            // Validate codec
            _metadata.TryGetValue(AvroConstants.CodecKey, out string codec);
            if (!(codec == null || codec == "null"))
            {
                throw new ArgumentException("Codecs are not supported");
            }

            // The 16-byte, randomly-generated sync marker for this file.
            _syncMarker = await AvroParser.ReadFixedBytesAsync(_headerStream, AvroConstants.SyncMarkerSize, async, cancellationToken).ConfigureAwait(false);

            // Parse the schema
            using JsonDocument schema = JsonDocument.Parse(_metadata[AvroConstants.SchemaKey]);
            _itemType = AvroType.FromSchema(schema.RootElement);

            if (BlockOffset == 0)
            {
                BlockOffset = _initialBlockOffset + _dataStream.Position;
            }

            // Populate _itemsRemainingInCurrentBlock
            _itemsRemainingInBlock = await AvroParser.ReadLongAsync(_dataStream, async, cancellationToken).ConfigureAwait(false);

            // skip block length
            await AvroParser.ReadLongAsync(_dataStream, async, cancellationToken).ConfigureAwait(false);

            _initalized = true;

            if (ObjectIndex > 0)
            {
                for (int i = 0; i < ObjectIndex; i++)
                {
                    await _itemType.ReadAsync(_dataStream, async, cancellationToken).ConfigureAwait(false);
                    _itemsRemainingInBlock--;
                }
            }
        }

        public virtual bool HasNext() => !_initalized || _itemsRemainingInBlock > 0;

        public virtual async Task<object> Next(bool async, CancellationToken cancellationToken = default)
        {
            // Initialize AvroReader, if necessary.
            if (!_initalized)
            {
                await Initalize(async, cancellationToken).ConfigureAwait(false);
            }

            if (!HasNext())
            {
                throw new ArgumentException("There are no more items in the stream");
            }

            object result = await _itemType.ReadAsync(_dataStream, async, cancellationToken).ConfigureAwait(false);

            _itemsRemainingInBlock--;
            ObjectIndex++;

            if (_itemsRemainingInBlock == 0)
            {
                byte[] marker = await AvroParser.ReadFixedBytesAsync(_dataStream, 16, async, cancellationToken).ConfigureAwait(false);

                BlockOffset = _initialBlockOffset + _dataStream.Position;
                ObjectIndex = 0;

                if (!_syncMarker.SequenceEqual(marker))
                {
                    throw new ArgumentException("Stream is not a valid Avro file.");
                }

                try
                {
                    _itemsRemainingInBlock = await AvroParser.ReadLongAsync(_dataStream, async, cancellationToken).ConfigureAwait(false);
                }
                catch (InvalidOperationException)
                {
                    // We hit the end of the stream.
                }

                if (_itemsRemainingInBlock > 0)
                {
                    // Ignore block size
                    await AvroParser.ReadLongAsync(_dataStream, async, cancellationToken).ConfigureAwait(false);
                }
            }

            return result;
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dataStream.Dispose();
                _headerStream.Dispose();
            }

            _disposed = true;
        }
    }
}
