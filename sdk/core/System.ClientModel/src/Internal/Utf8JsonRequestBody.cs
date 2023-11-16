// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

// TODO: it might be nice to make this type internal and have a method
// on a different type that returns this as an implementation of RequestBody
// This would probably require modifications to generated code.
public class Utf8JsonRequestBody : RequestBody
{
    private readonly MemoryStream _stream;
    private readonly RequestBody _content;

    private bool _disposed;

    public Utf8JsonWriter JsonWriter { get; }

    public Utf8JsonRequestBody()
    {
        _stream = new MemoryStream();
        _content = CreateFromStream(_stream);
        JsonWriter = new Utf8JsonWriter(_stream);
    }

    public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
    {
        await JsonWriter.FlushAsync(cancellation).ConfigureAwait(false);
        await _content.WriteToAsync(stream, cancellation).ConfigureAwait(false);
    }

    public override void WriteTo(Stream stream, CancellationToken cancellation)
    {
        JsonWriter.Flush();
        _content.WriteTo(stream, cancellation);
    }

    public override bool TryComputeLength(out long length)
    {
        length = JsonWriter.BytesCommitted + JsonWriter.BytesPending;
        return true;
    }

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var stream = _stream;
            stream?.Dispose();

            var content = _content;
            content?.Dispose();

            var writer = JsonWriter;
            writer?.Dispose();

            _disposed = true;
        }
    }

    public override void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
