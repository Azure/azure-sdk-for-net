// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.ClientModel.Tests.Internal;

internal sealed class NativeMemoryManager : MemoryManager<byte>
{
    private readonly int _length;
    private IntPtr _ptr;
    private int _retainedCount;
    private bool _disposed;

    public NativeMemoryManager(int length)
    {
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        _length = length;
        _ptr = Marshal.AllocHGlobal(length);
    }

#pragma warning disable CA2015 // Finalizer is defined for testing purposes
    ~NativeMemoryManager()
    {
        Debug.WriteLine($"{nameof(NativeMemoryManager)} being finalized");
        Dispose(false);
    }
#pragma warning restore CA2015

    public bool IsDisposed
    {
        get
        {
            lock (this)
            {
                return _disposed && _retainedCount == 0;
            }
        }
    }

    public override Memory<byte> Memory => CreateMemory(_length);

    public bool IsRetained
    {
        get
        {
            lock (this)
            {
                return _retainedCount > 0;
            }
        }
    }

    public override unsafe Span<byte> GetSpan() => new Span<byte>((void*)_ptr, _length);

    public override unsafe MemoryHandle Pin(int elementIndex = 0)
    {
        // Note that this intentionally allows elementIndex == _length to
        // support pinning zero-length instances.
        if ((uint)elementIndex > (uint)_length)
        {
            throw new ArgumentOutOfRangeException(nameof(elementIndex));
        }

        lock (this)
        {
            if (_retainedCount == 0 && _disposed)
            {
                throw new Exception();
            }
            _retainedCount++;
        }

        void* pointer = (void*)((byte*)_ptr + elementIndex);    // T = byte
        return new MemoryHandle(pointer, default, this);
    }

    public override void Unpin()
    {
        lock (this)
        {
            if (_retainedCount > 0)
            {
                _retainedCount--;
                if (_retainedCount == 0)
                {
                    if (_disposed)
                    {
                        Marshal.FreeHGlobal(_ptr);
                        _ptr = IntPtr.Zero;
                    }
                }
            }
        }
    }

    protected override void Dispose(bool disposing)
    {
        lock (this)
        {
            _disposed = true;
            if (_retainedCount == 0)
            {
                Marshal.FreeHGlobal(_ptr);
                _ptr = IntPtr.Zero;
            }
        }
    }
}
