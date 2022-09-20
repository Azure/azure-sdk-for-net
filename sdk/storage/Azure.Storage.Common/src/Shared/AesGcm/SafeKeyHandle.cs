// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Storage.Shared.AesGcm
{
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)
    /// <summary>
    /// From
    /// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Windows/BCrypt/Cng.cs#L152
    ///
    /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
    /// </summary>
    internal static partial class Interop
    {
        internal static partial class BCrypt
        {
            internal sealed partial class SafeKeyHandle : SafeBCryptHandle
            {
                private SafeAlgorithmHandle _parentHandle;

                public void SetParentHandle(SafeAlgorithmHandle parentHandle)
                {
                    Debug.Assert(_parentHandle == null);
                    Debug.Assert(parentHandle != null);
                    Debug.Assert(!parentHandle.IsInvalid);

                    bool ignore = false;
                    parentHandle.DangerousAddRef(ref ignore);

                    _parentHandle = parentHandle;
                }

                protected sealed override bool ReleaseHandle()
                {
                    if (_parentHandle != null)
                    {
                        _parentHandle.DangerousRelease();
                        _parentHandle = null;
                    }

                    uint ntStatus = BCryptDestroyKey(handle);
                    return ntStatus == 0;
                }

                [DllImport(Constants.ClientSideEncryption.BCryptdll)]
                private static extern uint BCryptDestroyKey(IntPtr hKey);
            }
        }
    }
#endif
}
