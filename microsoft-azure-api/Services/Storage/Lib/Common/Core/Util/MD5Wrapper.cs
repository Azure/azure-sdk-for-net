//-----------------------------------------------------------------------
// <copyright file="MD5Wrapper.cs" company="Microsoft">
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
    using System.IO;
#if RT
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Security.Cryptography;
    using Windows.Security.Cryptography.Core;
    using Windows.Storage.Streams;
#elif !COMMON
    using System.Security.Cryptography;
    using Microsoft.WindowsAzure.Storage.Auth;
#endif

    /// <summary>
    /// Wrapper class for MD5.
    /// </summary>
    internal class MD5Wrapper
#if !COMMON
 : IDisposable
#endif
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
        private readonly bool version1MD5 = CloudStorageAccount.UseV1MD5;

#if RT
        private CryptographicHash hash = null;
#elif !COMMON
        private MD5 hash = null;
        private NativeMD5 nativeMD5Hash = null;
#endif

        internal MD5Wrapper()
        {
#if RT
            this.hash = HashAlgorithmProvider.OpenAlgorithm("MD5").CreateHash();
#elif DNCP 
            if (this.version1MD5)
            {
                this.hash = MD5.Create();
            }
            else
            {
                this.nativeMD5Hash = NativeMD5.Create();
            }
#endif
        }

        /// <summary>
        /// Calculates an on-going hash using the input byte array.
        /// </summary>
        /// <param name="input">The input array used for calculating the hash.</param>
        /// <param name="offset">The offset in the input buffer to calculate from.</param>
        /// <param name="count">The number of bytes to use from input.</param>
        internal void UpdateHash(byte[] input, int offset, int count)
        {
            if (count > 0)
            {
#if RT
                this.hash.Append(input.AsBuffer(offset, count));
#elif DNCP
                if (this.version1MD5)
                {
                    this.hash.TransformBlock(input, offset, count, null, 0);
                }
                else
                {
                    this.nativeMD5Hash.TransformBlock(input, offset, count);
                }
#endif
            }
        }

        /// <summary>
        /// Retrieves the string representation of the hash. (Completes the creation of the hash).
        /// </summary>
        /// <returns>A byte array that is the content of the hash.</returns>
        internal string ComputeHash()
        {
#if RT
            IBuffer md5HashBuff = this.hash.GetValueAndReset();
            return CryptographicBuffer.EncodeToBase64String(md5HashBuff);
#elif COMMON
            return null;
#elif DNCP
            byte[] bytes;
            if (this.version1MD5)
            {
                this.hash.TransformFinalBlock(new byte[0], 0, 0);
                bytes = this.hash.Hash;
            }
            else
            {
                bytes = this.nativeMD5Hash.TransformFinalBlock(new byte[0], 0, 0);
            }

            // Convert hash to string
            return Convert.ToBase64String(bytes);
#endif
        }

        /// <summary>
        /// Computes the hash value of the specified MemoryStream.
        /// </summary>
        /// <param name="memoryStream">The memory stream to calculate hash on. </param>
        /// <returns>The computed hash value string.</returns>
        internal string ComputeHash(MemoryStream memoryStream)
        {
#if RT
            this.hash.Append(memoryStream.GetWindowsRuntimeBuffer());
            IBuffer md5HashBuff = this.hash.GetValueAndReset();
            return CryptographicBuffer.EncodeToBase64String(md5HashBuff);
#elif COMMON
            return null;

#elif DNCP 
            byte[] bytes;

            if (this.version1MD5)
            {
                bytes = this.hash.ComputeHash(memoryStream);
            }
            else
            {
                int length = (int)memoryStream.Length;
                this.nativeMD5Hash.TransformBlock(memoryStream.ToArray(), 0, length);
                bytes = this.nativeMD5Hash.TransformFinalBlock(new byte[0], 0, 0);
            }

                // Convert hash to string
                return Convert.ToBase64String(bytes);
#endif
        }

#if !COMMON
        void IDisposable.Dispose()
        {
#if RT
            this.hash = null;
#else
            if (!this.version1MD5)
            {
                if (this.nativeMD5Hash != null)
                {
                    this.nativeMD5Hash.Dispose();
                    this.nativeMD5Hash = null;
                }
            }
            else
            {
                this.hash = null;
            }
#endif
       }
#endif
    }
}