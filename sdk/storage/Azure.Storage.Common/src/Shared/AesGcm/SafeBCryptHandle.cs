// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;
using System.Runtime.InteropServices;

namespace Azure.Storage.Shared.AesGcm
{
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)
    /// <summary>
    /// From
    /// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Microsoft/Win32/SafeHandles/SafeBCryptHandle.cs
    ///
    /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
    /// </summary>
    internal abstract class SafeBCryptHandle : SafeHandle, IDisposable
    {
        protected SafeBCryptHandle()
            : base(IntPtr.Zero, true)
        {
        }

        public sealed override bool IsInvalid
        {
            get
            {
                return handle == IntPtr.Zero;
            }
        }

        protected abstract override bool ReleaseHandle();
    }
#endif
}
