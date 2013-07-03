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
    using System.Diagnostics.CodeAnalysis;

#if WINDOWS_RT
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Security.Cryptography;
    using Windows.Security.Cryptography.Core;
    using Windows.Storage.Streams;
#else
    using System.Security.Cryptography;
#endif

    /// <summary>
    /// Wrapper class for MD5.
    /// </summary>
    internal class MD5Wrapper : IDisposable
    {
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
        private readonly bool version1MD5 = CloudStorageAccount.UseV1MD5;

#if WINDOWS_RT
        private CryptographicHash hash = null;
#elif WINDOWS_PHONE

#else
        private MD5 hash = null;
#endif

        [SuppressMessage("Microsoft.Cryptographic.Standard", "CA5350:MD5CannotBeUsed", Justification = "Used as a hash, not encryption")]
        internal MD5Wrapper()
        {
#if WINDOWS_RT
            this.hash = HashAlgorithmProvider.OpenAlgorithm("MD5").CreateHash();
#elif WINDOWS_PHONE
            throw new NotSupportedException(SR.WindowsPhoneDoesNotSupportMD5);
#else
            this.hash = this.version1MD5 ? MD5.Create() : new NativeMD5();
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
#if WINDOWS_RT
                this.hash.Append(input.AsBuffer(offset, count));
#elif WINDOWS_PHONE
                throw new NotSupportedException(SR.WindowsPhoneDoesNotSupportMD5);
#else
                this.hash.TransformBlock(input, offset, count, null, 0);
#endif
            }
        }

        /// <summary>
        /// Retrieves the string representation of the hash. (Completes the creation of the hash).
        /// </summary>
        /// <returns>String representation of the computed hash value.</returns>
        internal string ComputeHash()
        {
#if WINDOWS_RT
            IBuffer md5HashBuff = this.hash.GetValueAndReset();
            return CryptographicBuffer.EncodeToBase64String(md5HashBuff);
#elif WINDOWS_PHONE
            throw new NotSupportedException(SR.WindowsPhoneDoesNotSupportMD5);
#else
            this.hash.TransformFinalBlock(new byte[0], 0, 0);
            return Convert.ToBase64String(this.hash.Hash);
#endif
        }

        public void Dispose()
        {
#if WINDOWS_DESKTOP && !WINDOWS_PHONE
            if (this.hash != null)
            {
                ((IDisposable)this.hash).Dispose();
                this.hash = null;
            }
#endif
        }
    }
}