//-----------------------------------------------------------------------
// <copyright file="BlobProperties.cs" company="Microsoft">
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
//    Contains code for the BlobProperties class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using Protocol;

    /// <summary>
    /// Represents the system properties for a blob.
    /// </summary>
    public class BlobProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobProperties"/> class.
        /// </summary>
        public BlobProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobProperties"/> class based on an existing instance.
        /// </summary>
        /// <param name="other">The set of properties to clone.</param>
        public BlobProperties(BlobProperties other)
        {
            this.BlobType = other.BlobType;
            this.ContentEncoding = other.ContentEncoding;
            this.ContentLanguage = other.ContentLanguage;
            this.Length = other.Length;
            this.ContentType = other.ContentType;
            this.ETag = other.ETag;
            this.LastModifiedUtc = other.LastModifiedUtc;
            this.LeaseStatus = other.LeaseStatus;
        }

        /// <summary>
        /// Gets or sets the cache-control value stored for the blob.
        /// </summary>
        /// <value>The blob's cache-control value.</value>
        public string CacheControl { get; set; }

        /// <summary>
        /// Gets or sets the content-encoding value stored for the blob.
        /// </summary>
        /// <value>The blob's content-encoding value.</value>
        /// <remarks>
        /// If this property has not been set for the blob, it returns null.
        /// </remarks>
        public string ContentEncoding { get; set; }

        /// <summary>
        /// Gets or sets the content-language value stored for the blob.
        /// </summary>
        /// <value>The blob's content-language value.</value>
        /// <remarks>
        /// If this property has not been set for the blob, it returns null.
        /// </remarks>
        public string ContentLanguage { get; set; }

        /// <summary>
        /// Gets the size of the blob, in bytes.
        /// </summary>
        /// <value>The blob's size in bytes.</value>
        public long Length { get; internal set; }

        /// <summary>
        /// Gets or sets the content-MD5 value stored for the blob.
        /// </summary>
        /// <value>The blob's content-MD5 hash.</value>
        public string ContentMD5 { get; set; }

        /// <summary>
        /// Gets or sets the content-type value stored for the blob.
        /// </summary>
        /// <value>The blob's content-type value.</value>
        /// <remarks>
        /// If this property has not been set for the blob, it returns null.
        /// </remarks>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets the blob's ETag value.
        /// </summary>
        /// <value>The blob's ETag value.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "ETag",
            Justification = "ETag is the proper capitalization.")]
        public string ETag { get; internal set; }

        /// <summary>
        /// Gets the the last-modified time for the blob, expressed as a UTC value.
        /// </summary>
        /// <value>The blob's last-modified time, in UTC format.</value>
        public DateTime LastModifiedUtc { get; internal set; }

        /// <summary>
        /// Gets the type of the blob.
        /// </summary>
        /// <value>A <see cref="BlobType"/> object that indicates the type of the blob.</value>
        public BlobType BlobType { get; internal set; }

        /// <summary>
        /// Gets the blob's lease status.
        /// </summary>
        /// <value>A <see cref="LeaseStatus"/> object that indicates the blob's lease status.</value>
        public LeaseStatus LeaseStatus { get; internal set; }
    }
}
