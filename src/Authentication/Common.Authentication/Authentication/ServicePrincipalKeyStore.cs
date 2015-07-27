// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Security;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Helper class to store service principal keys and retrieve them
    /// from the Windows Credential Store.
    /// </summary>
    public static class ServicePrincipalKeyStore
    {
        private const string keyStoreUserName = "PowerShellServicePrincipalKey";
        private const string targetNamePrefix = "AzureSession:target=";

        public static void SaveKey(string appId, string tenantId, SecureString serviceKey)
        {
            var credential = new CredStore.NativeMethods.Credential
            {
                flags = 0,
                type = CredStore.CredentialType.Generic,
                targetName = CreateKey(appId, tenantId),
                targetAlias = null,
                comment = null,
                lastWritten = new FILETIME {dwHighDateTime = 0, dwLowDateTime = 0},
                persist = 2, // persist on local machine
                attibuteCount = 0,
                attributes = IntPtr.Zero,
                userName = keyStoreUserName
            };

            // Pull bits out of SecureString to put in credential
            IntPtr credPtr = IntPtr.Zero;
            try
            {
                credential.credentialBlob = Marshal.SecureStringToGlobalAllocUnicode(serviceKey);
                credential.credentialBlobSize = (uint)(serviceKey.Length * Marshal.SystemDefaultCharSize);

                int size = Marshal.SizeOf(credential);
                credPtr = Marshal.AllocHGlobal(size);

                Marshal.StructureToPtr(credential, credPtr, false);
                CredStore.NativeMethods.CredWrite(credPtr, 0);
            }
            finally
            {
                if (credPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(credPtr);
                }

                Marshal.ZeroFreeGlobalAllocUnicode(credential.credentialBlob);
            }
        }

        public static SecureString GetKey(string appId, string tenantId)
        {
            IntPtr pCredential = IntPtr.Zero;
            try
            {
                if (CredStore.NativeMethods.CredRead(
                    CreateKey(appId, tenantId),
                    CredStore.CredentialType.Generic, 0,
                    out pCredential))
                {
                    var credential = (CredStore.NativeMethods.Credential)
                        Marshal.PtrToStructure(pCredential, typeof (CredStore.NativeMethods.Credential));
                    unsafe
                    {
                        return new SecureString((char*) (credential.credentialBlob),
                            (int)(credential.credentialBlobSize/Marshal.SystemDefaultCharSize));
                    }
                }
                return null;
            }
            catch 
            {
                // we could be running in an environment that does not have credentials store
            }
            finally
            {
                if (pCredential != IntPtr.Zero)
                {
                    CredStore.NativeMethods.CredFree(pCredential);
                }   
            }

            return null;
        }


        public static void DeleteKey(string appId, string tenantId)
        {
            CredStore.NativeMethods.CredDelete(CreateKey(appId, tenantId), CredStore.CredentialType.Generic, 0);
        }

        private static string CreateKey(string appId, string tenantId)
        {
            return string.Format("{0}AppId={1};Tenant={2}", targetNamePrefix, appId, tenantId);
        }
    }
}
