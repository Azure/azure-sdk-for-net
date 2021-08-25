// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Azure.Identity
{
    internal static class WindowsNativeMethods
    {
        #pragma warning disable CA1712 // Do not prefix enum members
        public enum CRED_PERSIST : uint
        {
            CRED_PERSIST_SESSION = 1,
            CRED_PERSIST_LOCAL_MACHINE = 2,
            CRED_PERSIST_ENTERPRISE = 3
        }
#pragma warning restore CA1712 // Do not prefix enum members

        public enum CRED_TYPE
        {
            GENERIC = 1,
            DOMAIN_PASSWORD = 2,
            DOMAIN_CERTIFICATE = 3,
            DOMAIN_VISIBLE_PASSWORD = 4,
            MAXIMUM = 5
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct CredentialData
        {
            public uint Flags;
            public CRED_TYPE Type;
            public string TargetName;
            public string Comment;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastWritten;
            public uint CredentialBlobSize;
            public IntPtr CredentialBlob;
            public CRED_PERSIST Persist;
            public uint AttributeCount;
            public IntPtr Attributes;
            public string TargetAlias;
            public string UserName;
        }

        public const int ERROR_NOT_FOUND = 1168;

        public const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
        public const uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        public const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

        public static IntPtr CredRead(string target, CRED_TYPE type)
        {
            ThrowIfFailed(Imports.CredRead(target, type, 0, out IntPtr userCredential));
            return userCredential;
        }

        public static void CredWrite(IntPtr userCredential) => ThrowIfFailed(Imports.CredWrite(userCredential, 0));

        public static void CredDelete(string target, CRED_TYPE type) => ThrowIfFailed(Imports.CredDelete(target, type, 0));

        public static void CredFree(IntPtr userCredential)
        {
            if (userCredential != IntPtr.Zero)
            {
                Imports.CredFree(userCredential);
            }
        }

        private static void ThrowIfFailed(bool isSucceeded, [CallerMemberName] string methodName = default)
        {
            if (isSucceeded)
            {
                return;
            }

            var error = Marshal.GetLastWin32Error();
            var message = error == ERROR_NOT_FOUND ? $"{methodName} has failed but error is unknown." : MessageFromErrorCode(error);
            throw new InvalidOperationException(message);
        }

        private static string MessageFromErrorCode(int errorCode)
        {
            // Twy Win32 first
            uint flags = FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;

            IntPtr messageBuffer = IntPtr.Zero;
            string message = null;

            try
            {
                var length = Imports.FormatMessage(flags, IntPtr.Zero, errorCode, 0, ref messageBuffer, 0, IntPtr.Zero);
                if (length == 0)
                {
                    // If failed, try to convert NTSTATUS to Win32 error
                    int code = Imports.RtlNtStatusToDosError(errorCode);
                    return new Win32Exception(code).Message;
                }
            }
            finally
            {
                if (messageBuffer != IntPtr.Zero)
                {
                    message = Marshal.PtrToStringUni(messageBuffer);
                    Marshal.FreeHGlobal(messageBuffer);
                }
            }

            return message ?? string.Empty;
        }

        private static class Imports
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
            public static extern uint FormatMessage(uint dwFlags, IntPtr lpSource, int dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, IntPtr pArguments);

            [DllImport("ntdll.dll")]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
            public static extern int RtlNtStatusToDosError(int Status);

            [DllImport("advapi32.dll", EntryPoint = "CredReadW", CharSet = CharSet.Unicode, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
            public static extern bool CredRead(string target, CRED_TYPE type, int reservedFlag, out IntPtr userCredential);

            [DllImport("advapi32.dll", EntryPoint = "CredWriteW", CharSet = CharSet.Unicode, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
            public static extern bool CredWrite(IntPtr userCredential, int reservedFlag);

            [DllImport("advapi32.dll", EntryPoint = "CredDeleteW", CharSet = CharSet.Unicode, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
            public static extern bool CredDelete(string target, CRED_TYPE type, int reservedFlag);

            [DllImport("advapi32.dll", SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
            public static extern void CredFree([In] IntPtr buffer);
        }
    }
}
