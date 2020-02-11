// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Azure.Identity
{
    internal static class MacosNativeMethods
    {
        private const string CoreFoundationLibrary = "/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation";
        private const string SecurityLibrary = "/System/Library/Frameworks/Security.framework/Security";

        public readonly struct CFRange
        {
            public readonly int Location, Length;
            public CFRange (int location, int length)
            {
                Location = location;
                Length = length;
            }
        }

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

        public const int SecStatusCodeSuccess = 0;

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
            IntPtr itemRef);

        [DllImport (SecurityLibrary)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
        public static extern int SecKeychainItemFreeContent (IntPtr attrList, IntPtr data);

        [DllImport (SecurityLibrary)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
        public static extern IntPtr SecCopyErrorMessageString (int status, IntPtr reserved);
    }
}
