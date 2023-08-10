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
    public sealed partial class ModelWriterInterlocked : IDisposable
    {
        private static readonly object _disposed = new object();
        private readonly IModelJsonSerializable<object> _model;
        private readonly ModelSerializerOptions _options;
        private readonly int _segmentSize;

        private object? _sequenceBuilder;

        /// <summary>
        /// Initializes a new instance of <see cref="ModelWriter"/>.
        /// </summary>
        /// <param name="model">The model to serialize.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <param name="segmentSize"></param>
        public ModelWriterInterlocked(IModelJsonSerializable<object> model, ModelSerializerOptions options, int segmentSize = 16384)
        {
            _model = model;
            _options = options;
            _segmentSize = segmentSize;
        }

        private SequenceBuilder GetSequenceBuilder()
        {
            var comparand = _sequenceBuilder;

            var cached = comparand is not null && comparand != _disposed
                ? Interlocked.CompareExchange(ref _sequenceBuilder, null, comparand)
                : comparand;

            if (cached is SequenceBuilder sequenceBuilder && cached == comparand)
            {
                return sequenceBuilder;
            }

            if (cached == _disposed)
            {
                throw new ObjectDisposedException(nameof(ModelWriter));
            }

            sequenceBuilder = new SequenceBuilder(_segmentSize);
            using var jsonWriter = new Utf8JsonWriter(sequenceBuilder);
            _model.Serialize(jsonWriter, _options);
            jsonWriter.Flush();

            return sequenceBuilder;
        }

        private void Return(SequenceBuilder sequenceBuilder)
        {
            if (Interlocked.CompareExchange(ref _sequenceBuilder, sequenceBuilder, null) != null)
            {
                // Other instance of SequenceBuilder is cached or ModelWriter is disposed
                // Dispose our instance of sequenceBuilder
                sequenceBuilder.Dispose();
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            var cached = Interlocked.Exchange(ref _sequenceBuilder, _disposed);
            if (cached is SequenceBuilder sequenceBuilder)
            {
                sequenceBuilder.Dispose();
            }
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
                var data = new byte[length];
                var span = new Span<byte>(data);
                builder.CopyToSpan(span);
                return new BinaryData(data);
            }
            finally
            {
                Return(builder);
            }
        }
    }
}
