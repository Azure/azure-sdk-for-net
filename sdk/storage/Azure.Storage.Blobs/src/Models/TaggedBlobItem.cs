// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Blob info from a FindBlobsByTags.
    /// </summary>
    public class TaggedBlobItem : IEquatable<TaggedBlobItem>
    {
        /// <summary>
        /// Blob Name.
        /// </summary>
        public string BlobName { get; internal set; }

        /// <summary>
        /// Container Name.
        /// </summary>
        public string BlobContainerName { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FilterBlobItem instances.
        /// You can use BlobsModelFactory.FilterBlobItem instead.
        /// </summary>
        internal TaggedBlobItem() { }

        /// <summary>
        /// Check if two TaggedBlobItem instances are equal.
        /// </summary>
        /// <param name="left">
        /// The first instance to compare.
        /// </param>
        /// <param name="right">
        /// The first instance to compare.
        /// </param>
        /// <returns>
        /// True if they're equal, false otherwise.
        /// </returns>
        public static bool operator ==(TaggedBlobItem left, TaggedBlobItem right) => left.Equals(right);

        /// <summary>
        /// Check if two TaggedBlobItem instances are not equal.
        /// </summary>
        /// <param name="left">
        /// The first instance to compare.
        /// </param>
        /// <param name="right">
        /// The first instance to compare.
        /// </param>
        /// <returns>
        /// True if they're not equal, false otherwise.
        /// </returns>
        public static bool operator !=(TaggedBlobItem left, TaggedBlobItem right) => !(left == right);

        /// <summary>
        /// Checks if two TaggedBlobItem are equal to each other.
        /// </summary>
        /// <param name="obj">The other instance to compare to.</param>
        public override bool Equals(object obj)
            => obj is TaggedBlobItem other && Equals(other);

        /// <summary>
        /// Get a hash code for the TaggedBlobItem.
        /// </summary>
        /// <returns>Hash code for the TaggedBlobItem.</returns>
        public override int GetHashCode()
            => BlobName.GetHashCode()
            ^ BlobContainerName.GetHashCode();

        /// <summary>
        /// Checks if two TaggedBlobItem are equal to each other.
        /// </summary>
        /// <param name="other">
        /// The other instance to compare to.
        /// </param>
        /// <returns></returns>
        public bool Equals(TaggedBlobItem other)
            => BlobName == other.BlobName
            && BlobContainerName == other.BlobContainerName;
    }
}
