// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.ServiceModel.Rest.Core.Pipeline
{
    //internal class BufferedResponseContentStream : Stream
    //{
    //    private readonly MemoryStream _stream;

    //    public BufferedResponseContentStream(MemoryStream stream)
    //    {
    //        _stream = stream;
    //    }

    //    public override bool CanRead => _stream.CanRead;

    //    public override bool CanSeek => _stream.CanSeek;

    //    public override bool CanWrite => _stream.CanWrite;

    //    public override long Length => _stream.Length;

    //    public override long Position
    //    {
    //        get => _stream.Position;
    //        set => _stream.Position = value;
    //    }

    //    public override void Flush() => _stream.Flush();

    //    public override int Read(byte[] buffer, int offset, int count)
    //        => _stream.Read(buffer, offset, count);

    //    public override long Seek(long offset, SeekOrigin origin)
    //        => _stream.Seek(offset, origin);

    //    public override void SetLength(long value)
    //        => _stream.SetLength(value);

    //    public override void Write(byte[] buffer, int offset, int count)
    //        => _stream.Write(buffer, offset, count);

    //    protected override void Dispose(bool disposing)
    //    {
    //        base.Dispose(disposing);
    //    }
    //}
}
