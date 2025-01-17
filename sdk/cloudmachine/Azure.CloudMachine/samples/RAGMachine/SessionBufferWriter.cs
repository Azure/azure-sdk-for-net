using System;
using System.Buffers;
using Microsoft.AspNetCore.Http;

internal class SessionBufferWriter : IBufferWriter<byte>
{
    private readonly ISession _session;
    private readonly string _key;
    private Memory<byte> _currentMemory;
    private int _position;
    private const int DefaultBufferSize = 4096;
    private byte[] _buffer;

    public SessionBufferWriter(ISession session, string key)
    {
        _session = session;
        _key = key;
        _buffer = ArrayPool<byte>.Shared.Rent(DefaultBufferSize);
        _currentMemory = _buffer;
        _position = 0;
    }

    void IBufferWriter<byte>.Advance(int count)
    {
        _position += count;
    }

    Memory<byte> IBufferWriter<byte>.GetMemory(int sizeHint)
    {
        EnsureCapacity(sizeHint);
        return _currentMemory.Slice(_position);
    }

    Span<byte> IBufferWriter<byte>.GetSpan(int sizeHint)
    {
        EnsureCapacity(sizeHint);
        return _currentMemory.Span.Slice(_position);
    }

    private void EnsureCapacity(int sizeHint)
    {
        if (sizeHint == 0)
            sizeHint = DefaultBufferSize;

        if (_buffer.Length - _position < sizeHint)
        {
            int newSize = Math.Max(_buffer.Length * 2, _position + sizeHint);
            byte[] newBuffer = ArrayPool<byte>.Shared.Rent(newSize);
            Buffer.BlockCopy(_buffer, 0, newBuffer, 0, _position);
            ArrayPool<byte>.Shared.Return(_buffer);
            _buffer = newBuffer;
            _currentMemory = _buffer;
        }
    }

    public void Commit()
    {
        byte[] data = new byte[_position];
        Buffer.BlockCopy(_buffer, 0, data, 0, _position);
        _session.Set(_key, data);
        ArrayPool<byte>.Shared.Return(_buffer);
        _buffer = null!;
    }
}
