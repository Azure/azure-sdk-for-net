// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Azure.Core;

namespace Azure.Identity
{
    internal sealed class MacosVisualStudioCodeAdapter : IVisualStudioCodeAdapter
    {
        private static readonly string s_userSettingsJsonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Library", "Application Support", "Code", "User", "settings.json");

        public string GetUserSettingsPath() => s_userSettingsJsonPath;

        public string GetCredentials(string serviceName, string accountName)
        {
            Argument.AssertNotNullOrEmpty(serviceName, nameof(serviceName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));

            IntPtr credentialsPtr = IntPtr.Zero;
            IntPtr itemRef = IntPtr.Zero;

            try
            {
                MacosNativeMethods.SecKeychainFindGenericPassword(IntPtr.Zero, serviceName, accountName, out int passwordLength, out credentialsPtr, out itemRef);
                return passwordLength > 0 ? Marshal.PtrToStringAnsi(credentialsPtr, passwordLength) : throw new InvalidOperationException("No password found");
            }
            finally
            {
                try
                {
                    MacosNativeMethods.SecKeychainItemFreeContent(IntPtr.Zero, credentialsPtr);
                }
                finally
                {
                    MacosNativeMethods.CFRelease(itemRef);
                }
            }
        }
    }
}
