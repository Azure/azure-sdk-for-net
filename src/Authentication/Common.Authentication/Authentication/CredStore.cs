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
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Class wrapping PInvoke signatures for Windows Credential store
    /// </summary>
    internal static class CredStore
    {
        internal enum CredentialType
        {
            Generic = 1,
        } 

        internal static class NativeMethods
        {
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            internal extern static bool CredRead(
                string targetName,
                CredentialType type,
                int flags,
                [Out] out IntPtr pCredential
                );

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            internal extern static bool CredEnumerate(
                string targetName,
                int flags,
                [Out] out int count,
                [Out] out IntPtr pCredential
                );

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            internal extern static bool CredDelete(
                string targetName,
                CredentialType type,
                int flags
                );

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            internal extern static bool CredWrite(
                IntPtr pCredential,
                int flags
                );

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            internal extern static bool CredFree(
                IntPtr pCredential
                );

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable", Justification = "Wrapper for native struct")]
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            internal struct Credential
            {
                public Credential(string userName, string key, string value)
                {
                    this.flags = 0;
                    this.type = CredentialType.Generic;

                    // set the key in the targetName 
                    this.targetName = key;

                    this.targetAlias = null;
                    this.comment = null;
                    this.lastWritten.dwHighDateTime = 0;
                    this.lastWritten.dwLowDateTime = 0;

                    // set the value in credentialBlob. 
                    this.credentialBlob = Marshal.StringToHGlobalUni(value);
                    this.credentialBlobSize = (uint)((value.Length + 1) * 2);

                    this.persist = 1;
                    this.attibuteCount = 0;
                    this.attributes = IntPtr.Zero;
                    this.userName = userName;
                }

                internal uint flags;
                internal CredentialType type;
                internal string targetName;
                internal string comment;
                internal System.Runtime.InteropServices.ComTypes.FILETIME lastWritten;
                internal uint credentialBlobSize;
                internal IntPtr credentialBlob;
                internal uint persist;
                internal uint attibuteCount;
                internal IntPtr attributes;
                internal string targetAlias;
                internal string userName;
            }             
        }
    }
}
