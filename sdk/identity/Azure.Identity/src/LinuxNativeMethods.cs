// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Azure.Identity
{
    internal static class LinuxNativeMethods
    {
        public enum SecretSchemaAttributeType
        {
            SECRET_SCHEMA_ATTRIBUTE_STRING = 0,
            SECRET_SCHEMA_ATTRIBUTE_INTEGER = 1,
            SECRET_SCHEMA_ATTRIBUTE_BOOLEAN = 2,
        }

        public enum SecretSchemaFlags
        {
            SECRET_SCHEMA_NONE = 0,
            SECRET_SCHEMA_DONT_MATCH_NAME = 2,
        }

        internal struct GError
        {
            public uint Domain;
            public int Code;
            public string Message;
        }

        [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
        public static extern IntPtr secret_schema_new(IntPtr name, int flags, IntPtr attribute1, int attribute1Type, IntPtr attribute2, int attribute2Type, IntPtr end);

        [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
        public static extern void secret_schema_unref (IntPtr schema);

        [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
        public static extern IntPtr secret_password_lookup_sync(IntPtr schema, IntPtr cancellable, out IntPtr error, IntPtr attribute1Type, IntPtr attribute1Value, IntPtr attribute2Type, IntPtr attribute2Value, IntPtr end);

        [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
        public static extern void secret_password_free(IntPtr password);
    }
}
