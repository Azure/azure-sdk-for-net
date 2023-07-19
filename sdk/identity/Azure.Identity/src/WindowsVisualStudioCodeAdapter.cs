// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace Azure.Identity
{
    internal sealed class WindowsVisualStudioCodeAdapter : IVisualStudioCodeAdapter
    {
        private static readonly string s_userSettingsJsonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Code", "User", "settings.json");

        public string GetUserSettingsPath() => s_userSettingsJsonPath;

        public string GetCredentials(string serviceName, string accountName)
        {
            IntPtr credentials = WindowsNativeMethods.CredRead($"{serviceName}/{accountName}", WindowsNativeMethods.CRED_TYPE.GENERIC);
            try
            {
                WindowsNativeMethods.CredentialData credData = Marshal.PtrToStructure<WindowsNativeMethods.CredentialData>(credentials);
                return Marshal.PtrToStringAnsi(credData.CredentialBlob, (int) credData.CredentialBlobSize);
            }
            finally
            {
                WindowsNativeMethods.CredFree(credentials);
            }
        }
    }
}
