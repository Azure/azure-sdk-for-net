// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.InteropServices;
using Azure.Core;

namespace Azure.Identity
{
    internal sealed class LinuxVisualStudioCodeAdapter : IVisualStudioCodeAdapter
    {
        private static readonly string s_userSettingsJsonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Code", "User", "settings.json");

        public string GetUserSettingsPath() => s_userSettingsJsonPath;

        public string GetCredentials(string serviceName, string accountName)
        {
            Argument.AssertNotNullOrEmpty(serviceName, nameof(serviceName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));

            IntPtr schemaPtr = IntPtr.Zero;
            IntPtr credentialsPtr = IntPtr.Zero;

            try
            {
                schemaPtr = GetLibsecretSchema();
                credentialsPtr = LookupPassword(schemaPtr, serviceName, accountName, out IntPtr errorPtr);

                if (errorPtr == IntPtr.Zero)
                {
                    return credentialsPtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(credentialsPtr) : null;
                }

                LinuxNativeMethods.GError error = Marshal.PtrToStructure<LinuxNativeMethods.GError>(errorPtr);
                throw new InvalidOperationException(error.Message);
            }
            finally
            {
                if (credentialsPtr != IntPtr.Zero)
                {
                    LinuxNativeMethods.secret_password_free(credentialsPtr);
                }

                if (schemaPtr != IntPtr.Zero)
                {
                    LinuxNativeMethods.secret_schema_unref(schemaPtr);
                }
            }
        }

        private static IntPtr LookupPassword(in IntPtr schemaPtr, string serviceName, string accountName, out IntPtr errorPtr)
        {
            IntPtr attribute1Name = Marshal.StringToHGlobalAnsi("service");
            IntPtr attribute1Value = Marshal.StringToHGlobalAnsi(serviceName);
            IntPtr attribute2Name = Marshal.StringToHGlobalAnsi("account");
            IntPtr attribute2Value = Marshal.StringToHGlobalAnsi(accountName);

            try
            {
                return LinuxNativeMethods.secret_password_lookup_sync(schemaPtr, IntPtr.Zero, out errorPtr, attribute1Name, attribute1Value, attribute2Name, attribute2Value, IntPtr.Zero);
            }
            finally
            {
                Marshal.FreeHGlobal(attribute1Name);
                Marshal.FreeHGlobal(attribute1Value);
                Marshal.FreeHGlobal(attribute2Name);
                Marshal.FreeHGlobal(attribute2Value);
            }
        }

        private static IntPtr GetLibsecretSchema()
        {
            IntPtr namePtr = Marshal.StringToHGlobalAnsi("org.freedesktop.Secret.Generic");
            IntPtr attribute1Ptr = Marshal.StringToHGlobalAnsi("service");
            IntPtr attribute2Ptr = Marshal.StringToHGlobalAnsi("account");

            try
            {
                return LinuxNativeMethods.secret_schema_new(
                    namePtr,
                    (int)LinuxNativeMethods.SecretSchemaFlags.SECRET_SCHEMA_DONT_MATCH_NAME,
                    attribute1Ptr,
                    (int)LinuxNativeMethods.SecretSchemaAttributeType.SECRET_SCHEMA_ATTRIBUTE_STRING,
                    attribute2Ptr,
                    (int)LinuxNativeMethods.SecretSchemaAttributeType.SECRET_SCHEMA_ATTRIBUTE_STRING,
                    IntPtr.Zero);
            }
            finally
            {
                Marshal.FreeHGlobal(attribute2Ptr);
                Marshal.FreeHGlobal(attribute1Ptr);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }
}
