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

        private static string GetErrorMessageString(int status) =>
            status switch
            {
                SecStatusCodeNoSuchKeychain => $"The keychain does not exist. [{status}]",
                SecStatusCodeInvalidKeychain => $"The keychain is not valid. [{status}]",
                SecStatusCodeAuthFailed => $"Authorization/Authentication failed. [{status}]",
                SecStatusCodeDuplicateItem => $"The item already exists. [{status}]",
                SecStatusCodeItemNotFound => $"The item cannot be found. [{status}]",
                SecStatusCodeInteractionNotAllowed => $"Interaction with the Security Server is not allowed. [{status}]",
                SecStatusCodeInteractionRequired => $"User interaction is required. [{status}]",
                SecStatusCodeNoSuchAttr => $"The attribute does not exist. [{status}]",
                _ => $"Unknown error. [{status}]",
            };

        public static class Imports
        {
            private const string CoreFoundationLibrary = "/System/Library/Frameworks/CoreFoundation.framework/Versions/A/CoreFoundation";
            private const string SecurityLibrary = "/System/Library/Frameworks/Security.framework/Security";

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
