//-----------------------------------------------------------------------
// <copyright file="StreamUtilities.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the StreamUtilities class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// A class containing common functionality across the two blob streams.
    /// </summary>
    internal static class StreamUtilities
    {
        /// <summary>
        /// Verifies the parameters to a read/write operation.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>.</param>
        /// <param name="count">The maximum number of bytes to be access in <paramref name="buffer"/>.</param>        /// <exception cref="System.ArgumentException">The sum of offset and count is greater than the buffer length.</exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">offset or count is negative.</exception>
        internal static void CheckBufferArguments(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "Offset must be positive");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Count must be positive");
            }

            if ((buffer.Length - offset) < count)
            {
                throw new ArgumentException("Offset subtracted from the buffer length is less than count", "offset");
            }   
        }

        /// <summary>
        /// Calculates an ongoing hash.
        /// </summary>
        /// <param name="input">The data to calculate the hash on.</param>
        /// <param name="offset">The offset in the input buffer to calculate from.</param>
        /// <param name="count">The number of bytes to use from input.</param>
        /// <param name="hash">The hash algorithm to use.</param>
        internal static void ComputeHash(byte[] input, int offset, int count, HashAlgorithm hash)
        {
            hash.TransformBlock(input, offset, count, null, 0);
        }

        /// <summary>
        /// Retrieves the string representation of the hash. (Completes the creation of the hash).
        /// </summary>
        /// <param name="hash">The hashing object.</param>
        /// <returns>A string that is the content of the hash.</returns>
        internal static string GetHashValue(HashAlgorithm hash)
        {
            // Finalize the hash
            hash.TransformFinalBlock(new byte[0], 0, 0);
            var bytes = hash.Hash;

            // Convert hash to string
            return Convert.ToBase64String(bytes);
        }
    }
}
