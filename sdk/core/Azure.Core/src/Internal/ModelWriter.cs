// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;

namespace Azure.Core.Internal
{
    internal sealed partial class ModelWriter : IDisposable
    {
        private readonly IModelJsonSerializable<object> _model;
        private readonly ModelSerializerOptions _options;

        private volatile SequenceBuilder? _sequenceBuilder;

        // write lock is used to synchronize between dispose and serialization
        // read lock is used to block disposing while a copy to is in progress
        private ReaderWriterLockSlim? _lock;
        private ReaderWriterLockSlim Lock => _lock ??= new ReaderWriterLockSlim();

        public ModelWriter(IModelJsonSerializable<object> model, ModelSerializerOptions options)
        {
            _model = model;
            _options = options;
        }

        private SequenceBuilder GetSequenceBuilder()
        {
            if (_sequenceBuilder is null)
            {
                Lock.EnterWriteLock();
                try
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
                finally
                {
                    Lock.ExitWriteLock();
                }
            }
            return _sequenceBuilder;
        }

        public void CopyTo(Stream stream, CancellationToken cancellation)
        {
            //can't get the write lock from inside the read lock
            SequenceBuilder sequenceBuilder = GetSequenceBuilder();
            Lock.EnterReadLock();
            try
            {
                sequenceBuilder.CopyTo(stream, cancellation);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public bool TryComputeLength(out long length)
        {
            //can't get the write lock from inside the read lock
            SequenceBuilder sequenceBuilder = GetSequenceBuilder();
            Lock.EnterReadLock();
            try
            {
                return sequenceBuilder.TryComputeLength(out length);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public async Task CopyToAsync(Stream stream, CancellationToken cancellation)
        {
            //can't get the write lock from inside the read lock
            SequenceBuilder sequenceBuilder = GetSequenceBuilder();
            Lock.EnterReadLock();
            try
            {
                await sequenceBuilder.CopyToAsync(stream, cancellation).ConfigureAwait(false);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public void Dispose()
        {
            Lock.EnterWriteLock();
            try
            {
                _sequenceBuilder?.Dispose();
                _sequenceBuilder = null;
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }

        public BinaryData ToBinaryData()
        {
            //can't get the write lock from inside the read lock
            SequenceBuilder sequenceBuilder = GetSequenceBuilder();
            Lock.EnterReadLock();
            try
            {
                bool gotLength = sequenceBuilder.TryComputeLength(out long length);
                Debug.Assert(gotLength);
                using var stream = new MemoryStream((int)length);
                sequenceBuilder.CopyTo(stream, default);
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }
    }
}
