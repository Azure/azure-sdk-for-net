// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// PageRange.
    /// </summary>
    internal readonly partial struct PageRange : IEquatable<PageRange>
    {
        /// <summary>
        /// Prevent direct instantiation of PageRange instances.
        /// You can use BlobsModelFactory.PageRange instead.
        /// </summary>
        internal PageRange(
            long start,
            long end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Check if two PageRange instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [System.ComponentModel.EditorBrowsable((System.ComponentModel.EditorBrowsableState.Never))]
        public bool Equals(PageRange other)
        {
            if (!Start.Equals(other.Start))
            {
                return false;
            }
            if (!End.Equals(other.End))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if two PageRange instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [System.ComponentModel.EditorBrowsable((System.ComponentModel.EditorBrowsableState.Never))]
        public override bool Equals(object obj) => obj is PageRange && Equals((PageRange)obj);

        /// <summary>
        /// Get a hash code for the PageRange.
        /// </summary>
        [System.ComponentModel.EditorBrowsable((System.ComponentModel.EditorBrowsableState.Never))]
        public override int GetHashCode()
        {
            var hashCode = new Azure.Core.HashCodeBuilder();
            hashCode.Add(Start);
            hashCode.Add(End);

            return hashCode.ToHashCode();
        }
    }
}
