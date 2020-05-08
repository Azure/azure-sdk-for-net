// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Azure.Identity
{
    internal static class MacosNativeMethods
    {
        public const int SecStatusCodeSuccess = 0;
        public const int SecStatusCodeNoSuchKeychain = -25294;
        public const int SecStatusCodeInvalidKeychain = -25295;
        public const int SecStatusCodeAuthFailed = -25293;
        public const int SecStatusCodeDuplicateItem = -25299;
        public const int SecStatusCodeItemNotFound = -25300;
        public const int SecStatusCodeInteractionNotAllowed = -25308;
        public const int SecStatusCodeInteractionRequired = -25315;
        public const int SecStatusCodeNoSuchAttr = -25303;

        public readonly struct CFRange
        {
            public readonly int Location, Length;
            public CFRange (int location, int length)
            {
                Location = location;
                Length = length;
            }
        }

        public static void SecKeychainFindGenericPassword(IntPtr keychainOrArray, string serviceName, string accountName, out int passwordLength, out IntPtr credentialsPtr, out IntPtr itemRef)
        {
            byte[] serviceNameBytes = Encoding.UTF8.GetBytes(serviceName);
            byte[] accountNameBytes = Encoding.UTF8.GetBytes(accountName);

            ThrowIfError(Imports.SecKeychainFindGenericPassword(keychainOrArray, serviceNameBytes.Length, serviceNameBytes, accountNameBytes.Length, accountNameBytes, out passwordLength, out credentialsPtr, out itemRef));
        }

        public static void SecKeychainAddGenericPassword(IntPtr keychainOrArray, string serviceName, string accountName, string password, out IntPtr itemRef)
        {
            byte[] serviceNameBytes = Encoding.UTF8.GetBytes(serviceName);
            byte[] accountNameBytes = Encoding.UTF8.GetBytes(accountName);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            ThrowIfError(Imports.SecKeychainAddGenericPassword(keychainOrArray, serviceNameBytes.Length, serviceNameBytes, accountNameBytes.Length, accountNameBytes, password.Length, passwordBytes, out itemRef));
        }

        public static void SecKeychainItemDelete(IntPtr itemRef) => ThrowIfError(Imports.SecKeychainItemDelete(itemRef));

        public static void SecKeychainItemFreeContent(IntPtr attrList, IntPtr data) => ThrowIfError(Imports.SecKeychainItemFreeContent(attrList, data));

        public static void CFRelease(IntPtr cfRef)
        {
            if (cfRef != IntPtr.Zero)
            {
                Imports.CFRelease(cfRef);
            }
        }

        private static void ThrowIfError(int status)
        {
            if (status != SecStatusCodeSuccess)
            {
                throw new InvalidOperationException(GetErrorMessageString(status));
            }
        }

        private static string GetErrorMessageString(int status)
        {
            IntPtr messagePtr = IntPtr.Zero;
            try
            {
                messagePtr = Imports.SecCopyErrorMessageString(status, IntPtr.Zero);
                return GetStringFromCFStringPtr(messagePtr);
            }
            catch
            {
                return status switch
                {
                    SecStatusCodeNoSuchKeychain => $"The keychain does not exist. [0x{status:x}]",
                    SecStatusCodeInvalidKeychain => $"The keychain is not valid. [0x{status:x}]",
                    SecStatusCodeAuthFailed => $"Authorization/Authentication failed. [0x{status:x}]",
                    SecStatusCodeDuplicateItem => $"The item already exists. [0x{status:x}]",
                    SecStatusCodeItemNotFound => $"The item cannot be found. [0x{status:x}]",
                    SecStatusCodeInteractionNotAllowed => $"Interaction with the Security Server is not allowed. [0x{status:x}]",
                    SecStatusCodeInteractionRequired => $"User interaction is required. [0x{status:x}]",
                    SecStatusCodeNoSuchAttr => $"The attribute does not exist. [0x{status:x}]",
                    _ => $"Unknown error. [0x{status:x}]",
                };
            }
            finally
            {
                CFRelease(messagePtr);
            }
        }

        private static string GetStringFromCFStringPtr(IntPtr handle)
        {
            IntPtr stringPtr = IntPtr.Zero;
            try
            {
                int length = Imports.CFStringGetLength (handle);
                stringPtr = Imports.CFStringGetCharactersPtr(handle);

                if (stringPtr == IntPtr.Zero)
                {
                    var range = new CFRange(0, length);
                    stringPtr = Marshal.AllocCoTaskMem(length * 2);
                    Imports.CFStringGetCharacters(handle, range, stringPtr);
                }

                return Marshal.PtrToStringAuto(stringPtr, length);
            }
            finally
            {
                if (stringPtr != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem (stringPtr);
                }
            }
        }

        public static class Imports
        {
            private const string CoreFoundationLibrary = "/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation";
            private const string SecurityLibrary = "/System/Library/Frameworks/Security.framework/Security";

            [DllImport (CoreFoundationLibrary, CharSet=CharSet.Unicode)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
            public static extern int CFStringGetLength (IntPtr handle);

            [DllImport (CoreFoundationLibrary, CharSet=CharSet.Unicode)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
            public static extern IntPtr CFStringGetCharactersPtr (IntPtr handle);

            [DllImport (CoreFoundationLibrary, CharSet=CharSet.Unicode)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
            public static extern IntPtr CFStringGetCharacters (IntPtr handle, CFRange range, IntPtr buffer);

            [DllImport (CoreFoundationLibrary, CharSet=CharSet.Unicode)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
            public static extern void CFRelease(IntPtr cfRef);

            [DllImport (SecurityLibrary)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
            public static extern int SecKeychainFindGenericPassword (
                IntPtr keychainOrArray,
                int serviceNameLength,
                byte[] serviceName,
                int accountNameLength,
                byte[] accountName,
                out int passwordLength,
                out IntPtr passwordData,
                out IntPtr itemRef);

            [DllImport (SecurityLibrary)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
            public static extern int SecKeychainAddGenericPassword (
                IntPtr keychain,
                int serviceNameLength,
                byte[] serviceName,
                int accountNameLength,
                byte[] accountName,
                int passwordLength,
                byte[] passwordData,
                out IntPtr itemRef);

            [DllImport (SecurityLibrary)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
            public static extern int SecKeychainItemDelete(IntPtr itemRef);

            [DllImport (SecurityLibrary)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
            public static extern int SecKeychainItemFreeContent (IntPtr attrList, IntPtr data);

            [DllImport (SecurityLibrary)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
            public static extern IntPtr SecCopyErrorMessageString (int status, IntPtr reserved);
        }
    }
}
