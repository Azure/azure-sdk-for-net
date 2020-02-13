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

            byte[] serviceNameBytes = Encoding.UTF8.GetBytes(serviceName);
            byte[] accountNameBytes = Encoding.UTF8.GetBytes(accountName);

            IntPtr credentialsPtr = IntPtr.Zero;
            int code, freeCode;
            string result = null;

            try
            {
                code = MacosNativeMethods.SecKeychainFindGenericPassword(
                    IntPtr.Zero, serviceNameBytes.Length, serviceNameBytes, accountNameBytes.Length, accountNameBytes, out int passwordLength, out credentialsPtr, IntPtr.Zero);

                if (code == MacosNativeMethods.SecStatusCodeSuccess && passwordLength > 0)
                {
                    result =  Marshal.PtrToStringAnsi(credentialsPtr, passwordLength);
                }
            }
            finally
            {
                freeCode = credentialsPtr != IntPtr.Zero
                    ? MacosNativeMethods.SecKeychainItemFreeContent(IntPtr.Zero, credentialsPtr)
                    : MacosNativeMethods.SecStatusCodeSuccess;
            }

            return code != MacosNativeMethods.SecStatusCodeSuccess
                ? throw new InvalidOperationException(GetErrorMessageString(code))
                : freeCode != MacosNativeMethods.SecStatusCodeSuccess
                    ? throw new InvalidOperationException(GetErrorMessageString(freeCode))
                    : result ?? throw new InvalidOperationException("Unknown error");
        }

        private static string GetErrorMessageString(int status)
        {
            IntPtr messagePtr = IntPtr.Zero;
            try
            {
                messagePtr = MacosNativeMethods.SecCopyErrorMessageString(status, IntPtr.Zero);
                return GetStringFromCFStringPtr(messagePtr);
            }
            catch
            {
                return status.ToString(CultureInfo.InvariantCulture);
            }
            finally
            {
                if (messagePtr != IntPtr.Zero)
                {
                    MacosNativeMethods.CFRelease(messagePtr);
                }
            }
        }

        private static string GetStringFromCFStringPtr (IntPtr handle)
        {
            IntPtr stringPtr = IntPtr.Zero;
            try
            {
                stringPtr = MacosNativeMethods.CFStringGetCharactersPtr(handle);

                if (stringPtr == IntPtr.Zero)
                {
                    int length = MacosNativeMethods.CFStringGetLength (handle);
                    var range = new MacosNativeMethods.CFRange(0, length);
                    stringPtr = Marshal.AllocCoTaskMem(length * 2);
                    MacosNativeMethods.CFStringGetCharacters(handle, range, stringPtr);
                }

                return Marshal.PtrToStringAuto(stringPtr, 0);

            }
            finally
            {
                if (stringPtr != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem (stringPtr);
                }
            }
        }
    }
}
