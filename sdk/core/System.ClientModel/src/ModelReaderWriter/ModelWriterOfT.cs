// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal
{
    /// <summary>
    /// Provides an efficient way to write <see cref="IJsonModel{T}"/> into a <see cref="BinaryData"/> using multiple pooled buffers.
    /// </summary>
    internal partial class ModelWriter<T> : IDisposable
    {
        private readonly IJsonModel<T> _model;
        private readonly ModelReaderWriterOptions _options;

        private readonly object _writeLock = new object();
        private readonly object _readLock = new object();

        private volatile SequenceBuilder? _sequenceBuilder;
        private volatile bool _isDisposed;

        private volatile int _readCount;

        private ManualResetEvent? _readersFinished;
        private ManualResetEvent ReadersFinished => _readersFinished ??= new ManualResetEvent(true);

        /// <summary>
        /// Initializes a new instance of <see cref="ModelWriter{T}"/>.
        /// </summary>
        /// <param name="model">The model to write.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <exception cref="NotSupportedException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        public ModelWriter(IJsonModel<T> model, ModelReaderWriterOptions options)
        {
            _model = model;
            _options = options;
        }

        private SequenceBuilder GetSequenceBuilder()
        {
            if (_sequenceBuilder is null)
            {
                lock (_writeLock)
                {
                    if (_isDisposed)
                    {
                        throw new ObjectDisposedException(nameof(ModelWriter<object>));
                    }

                    if (_sequenceBuilder is null)
                    {
                        SequenceBuilder sequenceBuilder = new SequenceBuilder();
                        using var jsonWriter = new Utf8JsonWriter(sequenceBuilder);
                        _model.Write(jsonWriter, _options);
                        jsonWriter.Flush();
                        _sequenceBuilder = sequenceBuilder;
                    }
                }
            }
            return _sequenceBuilder;
        }

        internal void CopyTo(Stream stream, CancellationToken cancellation)
        {
            SequenceBuilder builder = GetSequenceBuilder();
            IncrementRead();
            try
            {
                builder.CopyTo(stream, cancellation);
            }
            finally
            {
                DecrementRead();
            }
        }

        internal bool TryComputeLength(out long length)
        {
            SequenceBuilder builder = GetSequenceBuilder();
            IncrementRead();
            try
            {
                return builder.TryComputeLength(out length);
            }
            finally
            {
                DecrementRead();
            }
        }

        internal async Task CopyToAsync(Stream stream, CancellationToken cancellation)
        {
            SequenceBuilder builder = GetSequenceBuilder();
            IncrementRead();
            try
            {
                await builder.CopyToAsync(stream, cancellation).ConfigureAwait(false);
            }
            finally
            {
                DecrementRead();
            }
        }

        /// <summary>
        /// Converts the <see cref="ModelWriter{T}"/> to a <see cref="BinaryData"/>.
        /// </summary>
        /// <returns>A <see cref="BinaryData"/> representation of the written <see cref="IJsonModel{T}"/> in JSON format.</returns>
        public BinaryData ToBinaryData()
        {
            SequenceBuilder builder = GetSequenceBuilder();
            IncrementRead();
            try
            {
                bool gotLength = builder.TryComputeLength(out long length);
                if (length > int.MaxValue)
                {
                    throw new InvalidOperationException($"Length of serialized model is too long.  Value was {length} max is {int.MaxValue}");
                }
                Debug.Assert(gotLength);
                using var stream = new MemoryStream((int)length);
                builder.CopyTo(stream, default);
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
                lock (_writeLock)
                {
                    if (!_isDisposed)
                    {
                        _isDisposed = true;

                        if (_readersFinished is null || _readersFinished.WaitOne())
                        {
                            //only dispose if no readers ever happened or if all readers are done
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
                throw new ObjectDisposedException(nameof(ModelWriter<object>));
            }

            lock (_readLock)
            {
                _readCount++;
                ReadersFinished.Reset();
            }

            if (_isDisposed)
            {
                DecrementRead();
                throw new ObjectDisposedException(nameof(ModelWriter<object>));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DecrementRead()
        {
            lock (_readLock)
            {
                _readCount--;
                if (_readCount == 0)
                {
                    // notify we reached zero readers in case dispose is waiting
                    ReadersFinished.Set();
                }
            }
        }
    }
}
