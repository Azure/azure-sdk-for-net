// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Represents a single block in a block blob.  It describes the block's ID and size.
    /// </summary>
    [CodeGenModel("Block")]
    public readonly partial struct BlobBlock : IEquatable<BlobBlock>
    {
        /// <summary>
        /// Check if two BlobBlock instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [System.ComponentModel.EditorBrowsable((System.ComponentModel.EditorBrowsableState.Never))]
        public bool Equals(BlobBlock other)
        {
            if (!System.StringComparer.Ordinal.Equals(Name, other.Name))
            {
                return false;
            }
            if (!Size.Equals(other.Size))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if two BlobBlock instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [System.ComponentModel.EditorBrowsable((System.ComponentModel.EditorBrowsableState.Never))]
        public override bool Equals(object obj) => obj is BlobBlock && Equals((BlobBlock)obj);

        /// <summary>
        /// Get a hash code for the BlobBlock.
        /// </summary>
        [System.ComponentModel.EditorBrowsable((System.ComponentModel.EditorBrowsableState.Never))]
        public override int GetHashCode()
        {
            var hashCode = new Azure.Core.HashCodeBuilder();
            if (Name != null)
            {
                hashCode.Add(Name, System.StringComparer.Ordinal);
            }
            hashCode.Add(Size);

            return hashCode.ToHashCode();
        }
    }
}
