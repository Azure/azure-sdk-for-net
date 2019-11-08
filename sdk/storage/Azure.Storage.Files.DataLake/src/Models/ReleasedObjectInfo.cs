// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Provides the version state of a succesfully released blob or container
    /// object.
    /// </summary>
    public readonly struct ReleasedObjectInfo : IEquatable<ReleasedObjectInfo>
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations
        /// conditionally.  If the request version is 2011-08-18 or newer, the
        /// ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; }

        /// <summary>
        /// Returns the date and time the object was last modified. Any
        /// operation that modifies the blob or container, including an update
        /// of the object's metadata or properties, changes the last-modified
        /// time of the object.
        /// </summary>
        public DateTimeOffset LastModified { get; }

        /// <summary>
        /// Creates a new <see cref="ReleasedObjectInfo"/>.
        /// </summary>
        /// <param name="eTag">
        /// The <see cref="ETag"/> contains a value that you can use to perform
        /// operations conditionally.
        /// </param>
        /// <param name="lastModified">
        /// The date and time the object was last modified.
        /// </param>
        public ReleasedObjectInfo(ETag eTag, DateTimeOffset lastModified)
        {
            ETag = eTag;
            LastModified = lastModified;
        }

        /// <summary>
        /// Creates a new <see cref="ReleasedObjectInfo"/>.
        /// </summary>
        /// <param name="info">A released <see cref="PathInfo"/>.</param>
        internal ReleasedObjectInfo(PathInfo info)
            : this(info.ETag, info.LastModified)
        {
        }

        /// <summary>
        /// Creates a new <see cref="ReleasedObjectInfo"/>.
        /// </summary>
        /// <param name="info">A released <see cref="FileSystemInfo"/>.</param>
        internal ReleasedObjectInfo(FileSystemInfo info)
            : this(info.ETag, info.LastModified)
        {
        }

        /// <summary>
        /// Creates a string representation of a
        /// <see cref="ReleasedObjectInfo"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Check if two <see cref="ReleasedObjectInfo"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is ReleasedObjectInfo other && Equals(other);

        /// <summary>
        /// Check if two <see cref="ReleasedObjectInfo"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(ReleasedObjectInfo other) =>
            ETag == other.ETag &&
            LastModified == other.LastModified;

        /// <summary>
        /// Get a hash code for the <see cref="ReleasedObjectInfo"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="ReleasedObjectInfo"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            ETag.GetHashCode() ^
            LastModified.GetHashCode();

        /// <summary>
        /// Check if two <see cref="ReleasedObjectInfo"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(ReleasedObjectInfo left, ReleasedObjectInfo right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two <see cref="ReleasedObjectInfo"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(ReleasedObjectInfo left, ReleasedObjectInfo right) =>
            !(left == right);
    }
}
