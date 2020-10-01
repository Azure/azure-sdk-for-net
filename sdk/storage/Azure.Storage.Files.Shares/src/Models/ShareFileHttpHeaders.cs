// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Files.Shares.Models
{
    // TODO can we make the info link not blob-centric?

    /// <summary>
    /// Standard HTTP properties supported by the files.
    /// These properties are represented as standard HTTP headers use standard
    /// names, as specified in the Header Field Definitions section 14 of the
    /// HTTP/1.1 protocol specification.
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-and-retrieving-properties-and-metadata-for-blob-resources">
    /// Setting and retrieving properties and metadata for service resources</see>.
    /// </summary>
    public class ShareFileHttpHeaders
    {
        /// <summary>
        /// The MIME content type of the file.
        /// </summary>
        public string ContentType { get; set; }

#pragma warning disable CA1819 // Properties should not return arrays
        /// <summary>
        /// An MD5 hash of the file content. This hash is used to verify the
        /// integrity of the file content during transport.  When this header is
        /// specified, the storage service checks the hash that has arrived
        /// with the one that was sent. If the two hashes do not match, the
        /// operation will fail with error code 400 (Bad Request).
        /// </summary>
        public byte[] ContentHash { get; set; }

        /// <summary>
        /// Specifies which content encodings have been applied to the file.
        /// This value is returned to the client when the Get File operation
        /// is performed on the file resource. The client can use this value
        /// when returned to decode the file content.
        /// </summary>
        public string[] ContentEncoding { get; set; }

        /// <summary>
        /// Specifies the natural languages used by this resource.
        /// </summary>
        public string[] ContentLanguage { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Conveys additional information about how to process the response
        /// payload, and also can be used to attach additional metadata.  For
        /// example, if set to attachment, it indicates that the user-agent
        /// should not display the response, but instead show a Save As dialog
        /// with a filename other than the file name specified.
        /// </summary>
        public string ContentDisposition { get; set; }

        /// <summary>
        /// Specify directives for caching mechanisms.
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// Check if two FileHttpHeaders instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the FileHttpHeaders.
        /// </summary>
        /// <returns>Hash code for the FileHttpHeaders.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
