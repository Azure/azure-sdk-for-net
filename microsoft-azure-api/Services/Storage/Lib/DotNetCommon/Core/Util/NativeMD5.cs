//-----------------------------------------------------------------------
// <copyright file="NativeMD5.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// The class is provides the helper functions to do Fisma compliant MD5.
    /// </summary>
    internal class NativeMD5 : IDisposable
    {
        /// <summary>
        /// Cryptographic service provider.
        /// </summary>
        private const uint ProvRsaFull = 0x00000001;

        /// <summary>
        /// Access to the private keys is not required and the user interface can be bypassed.
        /// </summary>
        private const uint CryptVerifyContext = 0xF0000000;

        /// <summary>
        /// ALG_ID value that identifies the hash algorithm to use.
        /// </summary>
        private const uint CalgMD5 = 0x00008003;

        /// <summary>
        /// The hash value or message hash for the hash object specified by hashHandle. 
        /// </summary>
        private const uint HashVal = 0x00000002;

        /// <summary>
        /// The address to which the function copies a handle to the new hash object. Has to be released by calling the CryptDestroyHash function after we are finished using the hash object.
        /// </summary>
        private IntPtr hashHandle;

        /// <summary>
        /// A handle to a CSP created by a call to CryptAcquireContext.
        /// </summary>
        private IntPtr hashProv;

        private NativeMD5()
        {
            if (this.hashProv == IntPtr.Zero)
            {
                this.ValidateReturnCode(CryptAcquireContext(out this.hashProv, null, null, ProvRsaFull, CryptVerifyContext));
            }

            this.ValidateReturnCode(CryptCreateHash(this.hashProv, CalgMD5, IntPtr.Zero, 0, out this.hashHandle));
        }

        /// <summary>
        /// Create a Fisma hash.
        /// </summary> 
        public static NativeMD5 Create()
        {
            return new NativeMD5();
        }

        /// <summary>
        /// Calculates an ongoing hash.
        /// </summary>
        /// <param name="inputBuffer">The data to calculate the hash on.</param>
        /// <param name="inputOffset">The offset in the input buffer to calculate from.</param>
        /// <param name="inputCount">The number of bytes to use from input.</param> 
        public void TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            GCHandle handle = GCHandle.Alloc(inputBuffer, GCHandleType.Pinned);
            try
            {
                IntPtr buffPtr = handle.AddrOfPinnedObject();
                if (inputOffset != 0)
                {
                    buffPtr = new IntPtr(buffPtr.ToInt64() + inputOffset);
                }

                this.ValidateReturnCode(CryptHashData(this.hashHandle, buffPtr, inputCount, 0));
            }
            finally
            {
                handle.Free();
            }
        }

        /// <summary>
        /// Retrieves the string representation of the hash. (Completes the creation of the hash).
        /// </summary>
        /// <param name="inputBuffer">The data to calculate the hash on.</param>
        /// <param name="inputOffset">The offset in the input buffer to calculate from.</param>
        /// <param name="inputCount">The number of bytes to use from input.</param>
        /// <returns>A byte aray that is the content of the hash.</returns>
        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            if (inputCount != 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            byte[] hashBytes = new byte[16];
            int hashLength = hashBytes.Length;
            this.ValidateReturnCode(CryptGetHashParam(this.hashHandle, HashVal, hashBytes, ref hashLength, 0));

            return hashBytes;
        }

        /// <summary>
        /// Validates the status returned by all the crypto functions and throws exception.
        /// </summary>
        /// <param name="status">The boolean status returned by the crypto functions.</param>
        public void ValidateReturnCode(bool status)
        {
            if (!status)
            {
                int error = Marshal.GetLastWin32Error();
                throw new InvalidOperationException(string.Format(SR.CryptoFunctionFailed, error));
            }
        }

        /// <summary>
        /// Releases the unmanaged resources and optionally releases the managed resources.
        /// </summary>
        public void Dispose()
        {
            this.ValidateReturnCode(CryptDestroyHash(this.hashHandle));
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptAcquireContext(
            out IntPtr hashProv,
            string pszContainer,
            string pszProvider,
            uint provType,
            uint flags);

        [DllImport("advapi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptDestroyHash(
            IntPtr hashHandle);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptGetHashParam(
            IntPtr hashHandle,
            uint param,
            byte[] data,
            ref int pdwDataLen,
            uint flags);

        [DllImport("advapi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptCreateHash(
            IntPtr hashProv,
            uint algId,
            IntPtr hashKey,
            uint flags,
            out IntPtr hashHandle);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptHashData(
            IntPtr hashHandle,
            IntPtr data,
            int dataLen,
            uint flags);
    }
}