// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Standard HTTP properties supported by containers and blobs.
    /// These properties are represented as standard HTTP headers use standard
    /// names, as specified in the Header Field Definitions section 14 of the
    /// HTTP/1.1 protocol specification.
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-and-retrieving-properties-and-metadata-for-blob-resources">
    /// Setting and retrieving properties and metadata for Blob service resources</see>.
    /// </summary>
    public class BlobDirectoryHttpHeaders
    {
        /// <summary>
        /// The MIME content type of the blob.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Specifies which content encodings have been applied to the blob.
        /// This value is returned to the client when the Get Blob operation
        /// is performed on the blob resource. The client can use this value
        /// when returned to decode the blob content.
        /// </summary>
        public string ContentEncoding { get; set; }

        /// <summary>
        /// Specifies the natural languages used by this resource.
        /// </summary>
        public string ContentLanguage { get; set; }

        /// <summary>
        /// Conveys additional information about how to process the response
        /// payload, and also can be used to attach additional metadata.  For
        /// example, if set to attachment, it indicates that the user-agent
        /// should not display the response, but instead show a Save As dialog
        /// with a filename other than the blob name specified.
        /// </summary>
        public string ContentDisposition { get; set; }

        /// <summary>
        /// Specify directives for caching mechanisms.
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// Creates a string representation of a
        /// <see cref="BlobDirectoryHttpHeaders"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Check if two <see cref="BlobDirectoryHttpHeaders"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the <see cref="BlobDirectoryHttpHeaders"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="BlobDirectoryHttpHeaders"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
