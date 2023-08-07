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
    public sealed partial class ModelWriter : IDisposable
    {
        private readonly IModelJsonSerializable<object> _model;
        private readonly ModelSerializerOptions _options;

        private volatile SequenceBuilder? _sequenceBuilder;
        private volatile bool _isDisposed;

        private volatile int _readCount;

        private ManualResetEvent? _readersFinished;
        private ManualResetEvent ReadersFinished => _readersFinished ??= new ManualResetEvent(true);

        /// <summary>
        /// Initializes a new instance of <see cref="ModelWriter"/>.
        /// </summary>
        /// <param name="model">The model to serialize.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        public ModelWriter(IModelJsonSerializable<object> model, ModelSerializerOptions options)
        {
            _model = model;
            _options = options;
        }

        private readonly object _sequenceLock = new object();
        private SequenceBuilder GetSequenceBuilder()
        {
            if (_sequenceBuilder is null)
            {
                lock (_sequenceLock)
                {
                    if (_sequenceBuilder is null)
                    {
                        SequenceBuilder sequenceBuilder = new SequenceBuilder();
                        using var jsonWriter = new Utf8JsonWriter(sequenceBuilder);
                        _model.Serialize(jsonWriter, _options);
                        jsonWriter.Flush();
                        _sequenceBuilder = sequenceBuilder;
                    }
                }
            }
            return _sequenceBuilder;
        }

        internal void CopyTo(Stream stream, CancellationToken cancellation)
        {
            IncrementRead();
            try
            {
                GetSequenceBuilder().CopyTo(stream, cancellation);
            }
            finally
            {
                DecrementRead();
            }
        }

        internal bool TryComputeLength(out long length)
        {
            IncrementRead();
            try
            {
                return GetSequenceBuilder().TryComputeLength(out length);
            }
            finally
            {
                DecrementRead();
            }
        }

        internal async Task CopyToAsync(Stream stream, CancellationToken cancellation)
        {
            IncrementRead();
            try
            {
                await GetSequenceBuilder().CopyToAsync(stream, cancellation).ConfigureAwait(false);
            }
            finally
            {
                DecrementRead();
            }
        }

        /// <summary>
        /// Converts the <see cref="ModelWriter"/> to a <see cref="BinaryData"/>.
        /// </summary>
        /// <returns>A <see cref="BinaryData"/> representation of the serialized <see cref="IModelJsonSerializable{T}"/> in JSON format.</returns>
        public BinaryData ToBinaryData()
        {
            IncrementRead();
            try
            {
                SequenceBuilder sequenceBuilder = GetSequenceBuilder();
                bool gotLength = sequenceBuilder.TryComputeLength(out long length);
                Debug.Assert(gotLength);
                using var stream = new MemoryStream((int)length);
                sequenceBuilder.CopyTo(stream, default);
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
            finally
            {
                DecrementRead();
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                lock (_sequenceLock)
                {
                    if (!_isDisposed)
                    {
                        _isDisposed = true;

                        if (_readersFinished is null || _readersFinished.WaitOne())
                        {
                            // if we never get this event safer to leak than corrupt memory with use-after-free
                            _sequenceBuilder?.Dispose();
                        }

                        _sequenceBuilder = null;
                        _readersFinished?.Dispose();
                        _readersFinished = null;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void IncrementRead()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(ModelWriter));
            }
            if (Interlocked.Increment(ref _readCount) > 0)
            {
                ReadersFinished.Reset();
            }
            if (_isDisposed)
            {
                DecrementRead();
                throw new ObjectDisposedException(nameof(ModelWriter));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DecrementRead()
        {
            if (Interlocked.Decrement(ref _readCount) == 0)
            {
                // notify we reached zero readers in case dispose is waiting
                ReadersFinished.Set();
            }
        }
    }
}
