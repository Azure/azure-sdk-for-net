// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Azure.Storage.Files.DataLake
{
    internal class AutoPinner : IDisposable
    {
        private bool _disposed;
        private GCHandle _pinnedArray;

        public AutoPinner(Object obj)
        {
            _pinnedArray = GCHandle.Alloc(obj, GCHandleType.Pinned);
        }

        public static implicit operator IntPtr(AutoPinner ap)
        {
            return ap._pinnedArray.AddrOfPinnedObject();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _pinnedArray.Free();
            }

            _disposed = true;
        }
    }
}