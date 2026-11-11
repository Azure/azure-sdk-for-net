// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Provides the version state of a successfully released blob or container
    /// object.
    /// </summary>
    public class ReleasedObjectInfo
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
        /// The request priority the service applied to this request.
        /// </summary>
        public int? EffectiveRequestPriority { get; }

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
            : this(eTag, lastModified, effectiveRequestPriority: default)
        {
        }

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
        /// <param name="effectiveRequestPriority">
        /// The request priority the service applied to this request.
        /// </param>
        internal ReleasedObjectInfo(ETag eTag, DateTimeOffset lastModified, int? effectiveRequestPriority)
        {
            ETag = eTag;
            LastModified = lastModified;
            EffectiveRequestPriority = effectiveRequestPriority;
        }

        /// <summary>
        /// Creates a new <see cref="ReleasedObjectInfo"/>.
        /// </summary>
        /// <param name="info">A released <see cref="BlobInfo"/>.</param>
        internal ReleasedObjectInfo(BlobInfo info)
            : this(info.ETag, info.LastModified, info.EffectiveRequestPriority)
        {
        }

        /// <summary>
        /// Creates a new <see cref="ReleasedObjectInfo"/>.
        /// </summary>
        /// <param name="info">A released <see cref="BlobContainerInfo"/>.</param>
        internal ReleasedObjectInfo(BlobContainerInfo info)
            : this(info.ETag, info.LastModified, info.EffectiveRequestPriority)
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
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the <see cref="ReleasedObjectInfo"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="ReleasedObjectInfo"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
