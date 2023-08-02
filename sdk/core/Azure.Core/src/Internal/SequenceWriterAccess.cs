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

        private ReaderWriterLockSlim? _lock;
        private ReaderWriterLockSlim Lock => _lock ??= new ReaderWriterLockSlim();

        public SequenceWriterAccess(IModelJsonSerializable<object> model, ModelSerializerOptions options)
        {
            _model = model;
            _options = options;
        }

        private SequenceWriter GetWriter(IModelJsonSerializable<object> model)
        {
            if (_writer is null)
            {
                SequenceWriter writer = new SequenceWriter();
                using var jsonWriter = new Utf8JsonWriter(writer);
                model.Serialize(jsonWriter, _options);
                jsonWriter.Flush();
                _writer = writer;
            }
            return _writer;
        }

        public void WriteTo(Stream stream, CancellationToken cancellation)
        {
            Lock.EnterReadLock();
            try
            {
                GetWriter(_model).CopyTo(stream, cancellation);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public bool TryComputeLength(out long length)
        {
            Lock.EnterReadLock();
            try
            {
                return GetWriter(_model).TryComputeLength(out length);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            Lock.EnterReadLock();
            try
            {
                await GetWriter(_model).CopyToAsync(stream, cancellation).ConfigureAwait(false);
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
