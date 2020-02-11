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
            IntPtr credentials = IntPtr.Zero;
            try
            {
                if (!WindowsNativeMethods.CredRead($"{serviceName}/{accountName}", WindowsNativeMethods.CRED_TYPE.GENERIC, 0, out credentials))
                {
                    var error = Marshal.GetLastWin32Error();
                    if (error != WindowsNativeMethods.ERROR_NOT_FOUND)
                    {
                        throw new InvalidOperationException();
                    }

                    throw new InvalidOperationException(MessageFromErrorCode(error));
                }

                WindowsNativeMethods.CredentialData credData = Marshal.PtrToStructure<WindowsNativeMethods.CredentialData>(credentials);
                return Marshal.PtrToStringAnsi(credData.CredentialBlob, (int) credData.CredentialBlobSize);
            }
            finally
            {
                if (credentials != IntPtr.Zero)
                {
                    WindowsNativeMethods.CredFree(credentials);
                }
            }
        }

        private static string MessageFromErrorCode(int errorCode)
        {
            // Twy Win32 first
            uint flags = WindowsNativeMethods.FORMAT_MESSAGE_ALLOCATE_BUFFER | WindowsNativeMethods.FORMAT_MESSAGE_FROM_SYSTEM | WindowsNativeMethods.FORMAT_MESSAGE_IGNORE_INSERTS;
            IntPtr messageBuffer = IntPtr.Zero;

            var length = WindowsNativeMethods.FormatMessage(flags, IntPtr.Zero, errorCode, 0, ref messageBuffer, 0, IntPtr.Zero);
            if (length == 0)
            {
                // If failed, try to convert NTSTATUS to Win32 error
                int code = WindowsNativeMethods.RtlNtStatusToDosError(errorCode);
                return new Win32Exception(code).Message;
            }

            string message = null;
            if (messageBuffer != IntPtr.Zero)
            {
                message = Marshal.PtrToStringUni(messageBuffer);
                Marshal.FreeHGlobal(messageBuffer);
            }

            return message ?? string.Empty;
        }
    }
}
