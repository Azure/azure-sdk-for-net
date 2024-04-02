// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#if !NET6_0_OR_GREATER
internal class PrototypeMultipartContent : RequestContent
{
    private const string CRLF = "\r\n";
    private const string EOMPC = "==";
    private const string MPFD = "multipart/form-data";
    private static readonly byte[] EOMPC8 = Encoding.UTF8.GetBytes(EOMPC);

    private List<Part> _parts = new List<Part>();
    private byte[] _boundary;

    // TODO: optimize
    public string ContentType { get; }

    //public PrototypeMultipartContent(ReadOnlySpan<byte> boundary)
    //{
    //    ValidateBoundary(boundary);
    //    int length = boundary.Length + CRLF.Length;
    //    _boundary = new byte[length];
    //    boundary.CopyTo(_boundary);
    //    "\r\n"u8.CopyTo(_boundary.AsSpan(boundary.Length));

    //}

    public PrototypeMultipartContent(string boundary)
    {
        int length = boundary.Length + CRLF.Length;
        _boundary = new byte[length];
        int utf8Length = Encoding.UTF8.GetBytes(boundary, 0, boundary.Length, _boundary, 0);
        ValidateBoundary(_boundary.AsSpan(0, boundary.Length));
        "\r\n"u8.CopyTo(_boundary.AsSpan(utf8Length));

        // TODO: Optimize
        ContentType = MPFD + "; boundary=\"" + boundary + "\"";
    }

    public void Add(RequestContent content, params (string Name, string Value)[] headers)
    {
        int bufferLength = 0;
        foreach ((string Name, string Value) header in headers)
        {
            bufferLength += GetLength(header.Name, header.Value);
            ThrowIfNotAscii(header.Name);
            ThrowIfNotAscii(header.Value);
        }
        bufferLength += 2;
        byte[] bytes = new byte[bufferLength];
        int written = 0;
        foreach ((string Name, string Value) header in headers)
        {
            written += WriteHeader(bytes, written, header.Name, header.Value);
        }
        written += WriteCRLF(bytes.AsSpan(written));
        var part = new Part(content, bytes);
        _parts.Add(part);
    }

    private void Add(RequestContent content,
        ReadOnlySpan<byte> header1Name, ReadOnlySpan<byte> header1Value,
        ReadOnlySpan<byte> header2Name, ReadOnlySpan<byte> header2Value,
        ReadOnlySpan<byte> header3Name, ReadOnlySpan<byte> header3Value)
    {
        int bufferLength = GetLength(header1Name, header1Value) + GetLength(header2Name, header2Value) + GetLength(header3Name, header3Value) + "\r\n".Length;
        byte[] bytes = new byte[bufferLength];
        int written = 0;
        written += WriteHeader(bytes.AsSpan(written), header1Name, header1Value);
        written += WriteHeader(bytes.AsSpan(written), header2Name, header2Value);
        written += WriteHeader(bytes.AsSpan(written), header3Name, header3Value);
        written += WriteCRLF(bytes.AsSpan(written));
        var part = new Part(content, bytes);
        _parts.Add(part);
    }

    public void Add(RequestContent content,
        ReadOnlySpan<byte> header1Name, ReadOnlySpan<byte> header1Value,
        ReadOnlySpan<byte> header2Name, ReadOnlySpan<byte> header2Value)
    {
        int bufferLength = GetLength(header1Name, header1Value) + GetLength(header2Name, header2Value) + "\r\n".Length;
        byte[] bytes = new byte[bufferLength];
        int written = 0;
        written += WriteHeader(bytes.AsSpan(written), header1Name, header1Value);
        written += WriteHeader(bytes.AsSpan(written), header2Name, header2Value);
        written += WriteCRLF(bytes.AsSpan(written));
        var part = new Part(content, bytes);
        _parts.Add(part);
    }

    public void Add(RequestContent content,
        ReadOnlySpan<byte> headerName, ReadOnlySpan<byte> headerValue)
    {
        int bufferLength = GetLength(headerName, headerValue) + "\r\n".Length;
        byte[] bytes = new byte[bufferLength];
        int written = 0;
        written += WriteHeader(bytes, headerName, headerValue);
        WriteCRLF(bytes.AsSpan(written));
        var part = new Part(content, bytes);
        _parts.Add(part);
    }

    public override bool TryComputeLength(out long length)
    {
        length = 0;
        foreach (var part in _parts)
        {
            length += _boundary.Length;
            if (!part.TryComputeLength(out long partLength))
            {
                return false;
            }
            length += partLength;
        }
        length += _boundary.Length;
        length -= CRLF.Length; // last boundary has no newline
        length += EOMPC.Length; // instead is followed by "=="
        return true;
    }

    public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
    {
        foreach (var part in _parts)
        {
            await stream.WriteAsync(_boundary, 0, _boundary.Length).ConfigureAwait(false);
            await part.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
        }
        await stream.WriteAsync(_boundary, 0, _boundary.Length - CRLF.Length).ConfigureAwait(false);
        await stream.WriteAsync(EOMPC8, 0, EOMPC8.Length).ConfigureAwait(false);
    }

    public override void WriteTo(Stream stream, CancellationToken cancellationToken)
    {
        foreach (var part in _parts)
        {
            stream.Write(_boundary, 0, _boundary.Length);
            part.WriteTo(stream, cancellationToken);
        }
        stream.Write(_boundary, 0, _boundary.Length - CRLF.Length);
        stream.Write(EOMPC8, 0, EOMPC8.Length);
    }

    public override void Dispose() { }

    private int GetLength(ReadOnlySpan<byte> headerName, ReadOnlySpan<byte> headerValue)
        => headerName.Length + headerValue.Length + 4; // ": " + "\r\n"

    private int GetLength(string headerName, string headerValue)
        => headerName.Length + headerValue.Length + 4; // ": " + "\r\n"

    private int WriteHeader(Span<byte> buffer, ReadOnlySpan<byte> headerName, ReadOnlySpan<byte> headerValue)
    {
        int bytesWritten = 0;
        headerName.CopyTo(buffer);
        bytesWritten += headerName.Length;
        ": "u8.CopyTo(buffer.Slice(bytesWritten));
        bytesWritten += 2;
        headerValue.CopyTo(buffer.Slice(bytesWritten));
        bytesWritten += headerValue.Length;
        "\r\n"u8.CopyTo(buffer.Slice(bytesWritten));
        bytesWritten += 2;
        return bytesWritten;
    }

    private int WriteHeader(byte[] buffer, int bufferIndex, string headerName, string headerValue)
    {
        bufferIndex += Encoding.UTF8.GetBytes(headerName, 0, headerName.Length, buffer, bufferIndex);
        ": "u8.CopyTo(buffer.AsSpan(bufferIndex));
        bufferIndex += 2;
        bufferIndex += Encoding.UTF8.GetBytes(headerValue, 0, headerValue.Length, buffer, bufferIndex);
        "\r\n"u8.CopyTo(buffer.AsSpan(bufferIndex));
        bufferIndex += 2;
        return bufferIndex;
    }

    private int WriteCRLF(Span<byte> buffer)
    {
        "\r\n"u8.CopyTo(buffer);
        return 2;
    }

    private static void ValidateBoundary(ReadOnlySpan<byte> boundaryUtf8)
    {
        // RFC 2046 Section 5.1.1
        if (boundaryUtf8.Length > 70)
        {
            throw new ArgumentOutOfRangeException(nameof(boundaryUtf8), $"The field cannot be longer than {70} characters.");
        }

        if (boundaryUtf8[boundaryUtf8.Length - 1] == (byte)' ')
        {
            throw new ArgumentException($"The format of value boundary is invalid. The boundary cannot end in a space", nameof(boundaryUtf8));
        }

        ReadOnlySpan<byte> allowedSymbols = @"0123456789'()+_,-./:=? "u8;
        foreach (byte utf8Char in boundaryUtf8)
        {
            if (!(
                 (utf8Char >= 'a' && utf8Char <= 'z') || // alpha.
                 (utf8Char >= 'A' && utf8Char <= 'Z') || // ALPHA.
                 allowedSymbols.IndexOf(utf8Char) != -1)   // symbols and digits.
            )
            {
                throw new ArgumentException($"The format of value boundary is invalid.", nameof(boundaryUtf8));
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ThrowIfNotAscii(string headerText)
    {
        ReadOnlySpan<char> characters = headerText.AsSpan();
        //#if NET8_0_OR_GREATER
        //        if (!Ascii.IsValid(characters)) Throw(headerText);
        //#else
        foreach (char ch in characters)
        {
            if (ch > 127)
                Throw(headerText);
        }
        //#endif
    }
    private void Throw(string headerText) => throw new ArgumentOutOfRangeException(nameof(headerText));
}

internal readonly struct Part
{
    private const string CRLF = "\r\n";
    private static readonly byte[] CRLF8 = Encoding.UTF8.GetBytes(CRLF);

    internal readonly RequestContent _data;
    internal readonly byte[] _headers; // TODO: should these arrays be borrowed from the pool?

    public Part(RequestContent data, byte[] headers)
    {
        _data = data;
        _headers = headers;
    }

    public bool TryComputeLength(out long length)
    {
        if (_data.TryComputeLength(out length))
        {
            length += _headers.Length;
            length += CRLF8.Length;
            return true;
        }
        return false;
    }

    public async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
    {
        await stream.WriteAsync(_headers, 0, _headers.Length).ConfigureAwait(false);
        await stream.WriteAsync(CRLF8, 0, CRLF8.Length).ConfigureAwait(false);
        await _data.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
    }

    public void WriteTo(Stream stream, CancellationToken cancellationToken)
    {
        stream.Write(_headers, 0, _headers.Length);
        stream.Write(CRLF8, 0, CRLF8.Length);
        _data.WriteTo(stream, cancellationToken); // TODO: how are we goign to validate that the boundary is not contained in data?
    }
}
#endif
