// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.Net.ClientModel.Internal;

public class Utf8JsonContentWriter : IDisposable
{
    private readonly ArrayBufferWriter<byte> _bufferWriter;
    private readonly Utf8JsonWriter _jsonWriter;

    private BinaryData? _content;

    private bool _frozen = false;
    private bool _disposed;

    public Utf8JsonContentWriter()
    {
        _bufferWriter = new ArrayBufferWriter<byte>();
        _jsonWriter = new Utf8JsonWriter(_bufferWriter);
    }

    // TODO: consider making this write-once-only?
    // Would that be a better contract for models?
    // What does it mean to call write more than once in this context?
    public void Write(IUtf8JsonContentWriteable content)
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Content has been read; can no longer write to this writer.");
        }

        content.Write(_jsonWriter);
    }

    public BinaryData WrittenContent
    {
        get
        {
            if (!_frozen)
            {
                _jsonWriter.Flush();

                if (_bufferWriter.WrittenCount == 0)
                {
                    throw new InvalidOperationException("Cannot read WrittenContent before content has been written.");
                }

                _content = BinaryData.FromBytes(_bufferWriter.WrittenMemory);

                _frozen = true;
            }

            return _content!;
        }
    }

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var jsonWriter = _jsonWriter;
            jsonWriter?.Dispose();

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
