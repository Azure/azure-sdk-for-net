// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Represents a single block in a block blob.  It describes the block's ID and size.
    /// </summary>
    // CUSTOM:
    // - Move SARD field to this file to avoid CS0282 in the generated file
    // - Suppress parameterless ctor in favor of implicit one
    [CodeGenType("Block")]
    [CodeGenSuppress("BlobBlock")]
    public readonly partial struct BlobBlock : IEquatable<BlobBlock>
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        // All properties are rebuilt by hand in this class to avoid compile error CS0282

        /// <summary>
        /// The block size in bytes.
        /// </summary>
        [CodeGenMember("Size")]
        public long SizeLong { get; }

        /// <summary>
        /// This property is a backwards-compatible facade for <see cref="SizeLong"/>,
        /// which supports long values. Use <see cref="SizeLong"/> for full access of
        /// supported values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Size => checked((int)SizeLong);

        /// <summary>
        /// The base64 encoded block ID.
        /// </summary>
        [CodeGenMember("Name")]
        public string Name { get; }

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
