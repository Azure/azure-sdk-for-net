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
#if WINDOWS_DESKTOP && ! WINDOWS_PHONE
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;

    /// <summary>
    /// The class is provides the helper functions to do FISMA compliant MD5.
    /// </summary>
    internal sealed class NativeMD5 : MD5
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
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources", Justification = "We release this handle using CryptDestroyHash")]
        private IntPtr hashHandle;

        /// <summary>
        /// A handle to a CSP created by a call to CryptAcquireContext.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources", Justification = "We release this handle using CryptReleaseContext")]
        private IntPtr hashProv;

        /// <summary>
        /// Whether this object has been torn down or not.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of NativeMD5.
        /// </summary> 
        public NativeMD5()
            : base()
        {
            NativeMD5.ValidateReturnCode(NativeMethods.CryptAcquireContextW(out this.hashProv, null, null, ProvRsaFull, CryptVerifyContext));
            this.Initialize();
        }

        /// <summary>
        /// Finalizes an instance of the NativeMD5 class, unhooking it from all events.
        /// </summary>
        ~NativeMD5()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Initializes an implementation of the NativeMD5 class.
        /// </summary>
        public override void Initialize()
        {
            if (this.hashHandle != IntPtr.Zero)
            {
                NativeMethods.CryptDestroyHash(this.hashHandle);
                this.hashHandle = IntPtr.Zero;
            }

            NativeMD5.ValidateReturnCode(NativeMethods.CryptCreateHash(this.hashProv, CalgMD5, IntPtr.Zero, 0, out this.hashHandle));
        }

        /// <summary>
        /// Routes data written to the object into the hash algorithm for computing the hash.
        /// </summary>
        /// <param name="array">The input to compute the hash code for.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="dataLen">The number of bytes in the byte array to use as data.</param>
        protected override void HashCore(byte[] array, int offset, int dataLen)
        {
            GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);
            try
            {
                IntPtr buffPtr = handle.AddrOfPinnedObject();
                if (offset != 0)
                {
                    buffPtr = IntPtr.Add(buffPtr, offset);
                }

                NativeMD5.ValidateReturnCode(NativeMethods.CryptHashData(this.hashHandle, buffPtr, dataLen, 0));
            }
            finally
            {
                handle.Free();
            }
        }

        /// <summary>
        /// Finalizes the hash computation after the last data is processed by the cryptographic stream object.
        /// </summary>
        /// <returns>The computed hash code.</returns>
        protected override byte[] HashFinal()
        {
            byte[] hashBytes = new byte[16];
            int hashLength = hashBytes.Length;
            NativeMD5.ValidateReturnCode(NativeMethods.CryptGetHashParam(this.hashHandle, HashVal, hashBytes, ref hashLength, 0));
            return hashBytes;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the NativeMD5.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (this.hashHandle != IntPtr.Zero)
                {
                    NativeMethods.CryptDestroyHash(this.hashHandle);
                    this.hashHandle = IntPtr.Zero;
                }

                if (this.hashProv != IntPtr.Zero)
                {
                    NativeMethods.CryptReleaseContext(this.hashProv, 0);
                    this.hashProv = IntPtr.Zero;
                }

                this.disposed = true;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Validates the status returned by all the crypto functions and throws exception per the return code.
        /// </summary>
        /// <param name="status">The boolean status returned by the crypto functions.</param>
        private static void ValidateReturnCode(bool status)
        {
            if (!status)
            {
                int error = Marshal.GetLastWin32Error();
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, SR.CryptoFunctionFailed, error));
            }
        }
    }
#endif
}