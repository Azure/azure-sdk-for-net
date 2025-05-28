// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.ComponentModel;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Hash data type
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public class Hash
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Type of Hash
        /// </summary>
        public HashType HashType { get; set; }

        /// <summary>
        /// Value of Hash
        /// </summary>
        public byte[] HashValue { get; set; }

        /// <summary>
        /// Override Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj is Hash hash)
            {
                return HashType == hash.HashType &&
                   StructuralComparisons.StructuralEqualityComparer.Equals(HashValue, hash.HashValue);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            int hashCode = HashType.GetHashCode();
            if (HashValue != null)
            {
                foreach (var val in HashValue)
                {
                    hashCode = HashCode.Combine(hashCode, val);
                }
            }
            return hashCode;
        }
    }
}
