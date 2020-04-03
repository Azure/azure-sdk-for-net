// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Azure.Identity
{
    internal static class LinuxNativeMethods
    {
        public const string SECRET_COLLECTION_SESSION = "session";

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
            return Imports.secret_schema_new(name, (int)flags, attribute1, (int)attribute1Type, attribute2, (int)attribute2Type, IntPtr.Zero);
        }

        public static string secret_password_lookup_sync(IntPtr schemaPtr, IntPtr cancellable, string attribute1Type, string attribute1Value, string attribute2Type, string attribute2Value)
        {
            IntPtr passwordPtr = Imports.secret_password_lookup_sync(schemaPtr, cancellable, out IntPtr errorPtr, attribute1Type, attribute1Value, attribute2Type, attribute2Value, IntPtr.Zero);
            HandleError(errorPtr, "An error was encountered while reading secret from keyring");
            return passwordPtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(passwordPtr) : null;
        }

        public static void secret_password_store_sync(IntPtr schemaPtr, string collection, string label, string password, IntPtr cancellable, string attribute1Type, string attribute1Value, string attribute2Type, string attribute2Value)
        {
            _ = Imports.secret_password_store_sync(schemaPtr, collection, label, password, cancellable, out IntPtr errorPtr, attribute1Type, attribute1Value, attribute2Type, attribute2Value, IntPtr.Zero);
            HandleError(errorPtr, "An error was encountered while writing secret to keyring");
        }

        public static void secret_password_clear_sync(IntPtr schemaPtr, IntPtr cancellable, string attribute1Type, string attribute1Value, string attribute2Type, string attribute2Value)
        {
            _ = Imports.secret_password_clear_sync(schemaPtr, cancellable, out IntPtr errorPtr, attribute1Type, attribute1Value, attribute2Type, attribute2Value, IntPtr.Zero);
            HandleError(errorPtr, "An error was encountered while clearing secret from keyring ");
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
                throw new InvalidOperationException($"An exception was encountered while processing libsecret error: {ex}", ex);
            }

            throw new InvalidOperationException($"{errorMessage}, domain:'{error.Domain}', code:'{error.Code}', message:'{error.Message}'");
        }

        private static class Imports
        {
            [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
            public static extern IntPtr secret_schema_new(string name, int flags, string attribute1, int attribute1Type, string attribute2, int attribute2Type, IntPtr end);

            [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall)]
            public static extern void secret_schema_unref (IntPtr schema);

            [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern IntPtr secret_password_lookup_sync(IntPtr schema, IntPtr cancellable, out IntPtr error, string attribute1Type, string attribute1Value, string attribute2Type, string attribute2Value, IntPtr end);

            [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern int secret_password_store_sync(IntPtr schema, string collection, string label, string password, IntPtr cancellable, out IntPtr error, string attribute1Type, string attribute1Value, string attribute2Type, string attribute2Value, IntPtr end);

            [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern int secret_password_clear_sync(IntPtr schema, IntPtr cancellable, out IntPtr error, string attribute1Type, string attribute1Value, string attribute2Type, string attribute2Value, IntPtr end);

            [DllImport("libsecret-1.so.0", CallingConvention = CallingConvention.StdCall)]
            public static extern void secret_password_free(IntPtr password);
        }
    }
}
