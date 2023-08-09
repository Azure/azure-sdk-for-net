// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Provides an efficient way to serialize <see cref="IModelJsonSerializable{T}"/> into a <see cref="BinaryData"/> using multiple pooled buffers.
    /// </summary>
    public sealed partial class ModelWriterLocks : IDisposable
    {
        private readonly IModelJsonSerializable<object> _model;
        private readonly ModelSerializerOptions _options;
        private readonly int _segmentSize;
        private readonly object _lock = new();

        private SequenceBuilder? _sequenceBuilder;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of <see cref="ModelWriter"/>.
        /// </summary>
        /// <param name="model">The model to serialize.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <param name="segmentSize"></param>
        public ModelWriterLocks(IModelJsonSerializable<object> model, ModelSerializerOptions options, int segmentSize = 4096)
        {
            _model = model;
            _options = options;
            _segmentSize = segmentSize;
        }

        private SequenceBuilder GetSequenceBuilder()
        {
            lock (_lock)
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(ModelWriter));
                }

                if (_sequenceBuilder is {} cached)
                {
                    _sequenceBuilder = null;
                    return cached;
                }
            }

            var sequenceBuilder = new SequenceBuilder(_segmentSize);
            using var jsonWriter = new Utf8JsonWriter(sequenceBuilder);
            _model.Serialize(jsonWriter, _options);
            jsonWriter.Flush();

            return sequenceBuilder;
        }

        private void Return(SequenceBuilder sequenceBuilder)
        {
            lock (_lock)
            {
                if (!_disposed && _sequenceBuilder is null)
                {
                    _sequenceBuilder = sequenceBuilder;
                    return;
                }
            }

            // Other instance of SequenceBuilder is cached or ModelWriter is disposed
            // Dispose our instance of sequenceBuilder
            sequenceBuilder.Dispose();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            SequenceBuilder? cached;
            lock (_lock)
            {
                if (_disposed)
                {
                    return;
                }

                _disposed = true;
                cached = _sequenceBuilder;
                _sequenceBuilder = null;
            }

            cached?.Dispose();
        }

        internal void CopyTo(Stream stream, CancellationToken cancellation)
        {
            SequenceBuilder builder = GetSequenceBuilder();
            try
            {
                builder.CopyTo(stream, cancellation);
            }
            finally
            {
                Return(builder);
            }
        }

        internal bool TryComputeLength(out long length)
        {
            SequenceBuilder builder = GetSequenceBuilder();
            try
            {
                return builder.TryComputeLength(out length);
            }
            finally
            {
                Return(builder);
            }
        }

        internal async Task CopyToAsync(Stream stream, CancellationToken cancellation)
        {
            SequenceBuilder builder = GetSequenceBuilder();
            try
            {
                await builder.CopyToAsync(stream, cancellation).ConfigureAwait(false);
            }
            finally
            {
                Return(builder);
            }
        }

        /// <summary>
        /// Converts the <see cref="ModelWriter"/> to a <see cref="BinaryData"/>.
        /// </summary>
        /// <returns>A <see cref="BinaryData"/> representation of the serialized <see cref="IModelJsonSerializable{T}"/> in JSON format.</returns>
        public BinaryData ToBinaryData()
        {
            SequenceBuilder builder = GetSequenceBuilder();
            try
            {
                bool gotLength = builder.TryComputeLength(out long length);
                Debug.Assert(gotLength);
                using var stream = new MemoryStream((int)length);
                builder.CopyTo(stream, default);
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
            finally
            {
                Return(builder);
            }
        }
    }
}
