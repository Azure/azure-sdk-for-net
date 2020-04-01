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

        public static IntPtr secret_schema_new(string name, SecretSchemaFlags flags, string attribute1, SecretSchemaAttributeType attribute1Type, string attribute2, SecretSchemaAttributeType attribute2Type)
        {
            IntPtr namePtr = Marshal.StringToHGlobalAnsi(name);
            IntPtr attribute1Ptr = Marshal.StringToHGlobalAnsi(attribute1);
            IntPtr attribute2Ptr = Marshal.StringToHGlobalAnsi(attribute2);

            try
            {
                return Imports.secret_schema_new(namePtr, (int)flags, attribute1Ptr, (int)attribute1Type, attribute2Ptr, (int)attribute2Type, IntPtr.Zero);
            }
            finally
            {
                Marshal.FreeHGlobal(attribute2Ptr);
                Marshal.FreeHGlobal(attribute1Ptr);
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public static string secret_password_lookup_sync(IntPtr schemaPtr, IntPtr cancellable, string attribute1Type, string attribute1Value, string attribute2Type, string attribute2Value)
        {
            IntPtr attribute1NamePtr = Marshal.StringToHGlobalAnsi(attribute1Type);
            IntPtr attribute1ValuePtr = Marshal.StringToHGlobalAnsi(attribute1Value);
            IntPtr attribute2NamePtr = Marshal.StringToHGlobalAnsi(attribute2Type);
            IntPtr attribute2ValuePtr = Marshal.StringToHGlobalAnsi(attribute2Value);
            IntPtr passwordPtr = IntPtr.Zero;

            try
            {
                passwordPtr = Imports.secret_password_lookup_sync(schemaPtr, cancellable, out var errorPtr, attribute1NamePtr, attribute1ValuePtr, attribute2NamePtr, attribute2ValuePtr, IntPtr.Zero);
                HandleError(errorPtr, "An error was encountered while reading secret from keyring");
                return passwordPtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(passwordPtr) : null;
            }
            finally
            {
                secret_password_free(passwordPtr);
                Marshal.FreeHGlobal(attribute1NamePtr);
                Marshal.FreeHGlobal(attribute1ValuePtr);
                Marshal.FreeHGlobal(attribute2NamePtr);
                Marshal.FreeHGlobal(attribute2ValuePtr);
            }
        }

        public static void secret_password_store_sync(IntPtr schemaPtr, string collection, string label, string password, IntPtr cancellable, string attribute1Type, string attribute1Value, string attribute2Type, string attribute2Value)
        {
            IntPtr collectionPtr = Marshal.StringToHGlobalAnsi(collection);
            IntPtr labelPtr = Marshal.StringToHGlobalAnsi(label);
            IntPtr passwordPtr = Marshal.StringToHGlobalAnsi(password);
            IntPtr attribute1TypePtr = Marshal.StringToHGlobalAnsi(attribute1Type);
            IntPtr attribute1ValuePtr = Marshal.StringToHGlobalAnsi(attribute1Value);
            IntPtr attribute2TypePtr = Marshal.StringToHGlobalAnsi(attribute2Type);
            IntPtr attribute2ValuePtr = Marshal.StringToHGlobalAnsi(attribute2Value);

            try
            {
                _ = Imports.secret_password_store_sync(schemaPtr, collectionPtr, labelPtr, passwordPtr, cancellable, out var errorPtr, attribute1TypePtr, attribute1ValuePtr, attribute2TypePtr, attribute2ValuePtr, IntPtr.Zero);
                HandleError(errorPtr, "An error was encountered while writing secret to keyring");
            }
            finally
            {
                Marshal.FreeHGlobal(collectionPtr);
                Marshal.FreeHGlobal(labelPtr);
                Marshal.FreeHGlobal(attribute1TypePtr);
                Marshal.FreeHGlobal(attribute1ValuePtr);
                Marshal.FreeHGlobal(attribute2TypePtr);
                Marshal.FreeHGlobal(attribute2ValuePtr);
            }
        }

        public static void secret_password_clear_sync(IntPtr schemaPtr, IntPtr cancellable, string attribute1Type, string attribute1Value, string attribute2Type, string attribute2Value)
        {
            IntPtr attribute1NamePtr = Marshal.StringToHGlobalAnsi(attribute1Type);
            IntPtr attribute1ValuePtr = Marshal.StringToHGlobalAnsi(attribute1Value);
            IntPtr attribute2NamePtr = Marshal.StringToHGlobalAnsi(attribute2Type);
            IntPtr attribute2ValuePtr = Marshal.StringToHGlobalAnsi(attribute2Value);

            try
            {
                _ = Imports.secret_password_clear_sync(schemaPtr, cancellable, out var errorPtr, attribute1NamePtr, attribute1ValuePtr, attribute2NamePtr, attribute2ValuePtr, IntPtr.Zero);
                HandleError(errorPtr, "An error was encountered while clearing secret from keyring ");
            }
            finally
            {
                Marshal.FreeHGlobal(attribute1NamePtr);
                Marshal.FreeHGlobal(attribute1ValuePtr);
                Marshal.FreeHGlobal(attribute2NamePtr);
                Marshal.FreeHGlobal(attribute2ValuePtr);
            }
        }

        public static void secret_password_free(IntPtr passwordPtr)
        {
            if (passwordPtr != IntPtr.Zero)
            {
                Imports.secret_password_free(passwordPtr);
            }
        }

        public static void secret_schema_unref(IntPtr schemaPtr)
        {
            if (schemaPtr != IntPtr.Zero)
            {
                Imports.secret_schema_unref(schemaPtr);
            }
        }

        private static void HandleError(IntPtr errorPtr, string errorMessage)
        {
            if (errorPtr == IntPtr.Zero)
            {
                return;
            }

            GError error;
            try
            {
                error = Marshal.PtrToStructure<GError>(errorPtr);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An exception was encountered while processing libsecret error: {ex}");
            }

            throw new InvalidOperationException($"{errorMessage}, domain:'{error.Domain}', code:'{error.Code}', message:'{error.Message}'");
        }

        private static class Imports
        {
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
            public static extern int secret_password_store_sync(IntPtr schema, IntPtr collection, IntPtr label, IntPtr password, IntPtr cancellable, out IntPtr error, IntPtr attribute1Type, IntPtr attribute1Value, IntPtr attribute2Type, IntPtr attribute2Value, IntPtr end);

            [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
            public static extern int secret_password_clear_sync(IntPtr schema, IntPtr cancellable, out IntPtr error, IntPtr attribute1Type, IntPtr attribute1Value, IntPtr attribute2Type, IntPtr attribute2Value, IntPtr end);

            [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
            public static extern void secret_password_free(IntPtr password);
        }
    }
}
