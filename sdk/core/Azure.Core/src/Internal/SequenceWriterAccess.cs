// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;

namespace Azure.Core.Internal
{
    internal sealed class SequenceWriterAccess
    {
        private readonly IModelJsonSerializable<object> _model;
        private readonly ModelSerializerOptions _options;

        private SequenceWriter? _writer;

        // write lock is used to synchronize between dispose and serialization
        // read lock is used to block disposing while a copy to is in progress
        private ReaderWriterLockSlim? _lock;
        private ReaderWriterLockSlim Lock => _lock ??= new ReaderWriterLockSlim();

        public SequenceWriterAccess(IModelJsonSerializable<object> model, ModelSerializerOptions options)
        {
            _model = model;
            _options = options;
        }

        private SequenceWriter GetWriter()
        {
            if (_writer is null)
            {
                Lock.EnterWriteLock();
                if (_writer is null)
                {
                    SequenceWriter writer = new SequenceWriter();
                    using var jsonWriter = new Utf8JsonWriter(writer);
                    _model.Serialize(jsonWriter, _options);
                    jsonWriter.Flush();
                    _writer = writer;
                }
                Lock.ExitWriteLock();
            }
            return _writer;
        }

        public void CopyTo(Stream stream, CancellationToken cancellation)
        {
            //can't get the write lock from inside the read lock
            SequenceWriter writer = GetWriter();
            Lock.EnterReadLock();
            try
            {
                writer.CopyTo(stream, cancellation);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public bool TryComputeLength(out long length)
        {
            //can't get the write lock from inside the read lock
            SequenceWriter writer = GetWriter();
            Lock.EnterReadLock();
            try
            {
                return writer.TryComputeLength(out length);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public async Task CopyToAsync(Stream stream, CancellationToken cancellation)
        {
            //can't get the write lock from inside the read lock
            SequenceWriter writer = GetWriter();
            Lock.EnterReadLock();
            try
            {
                await writer.CopyToAsync(stream, cancellation).ConfigureAwait(false);
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
                _writer?.Dispose();
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
    }
}
