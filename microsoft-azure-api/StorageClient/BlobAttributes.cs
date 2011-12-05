//-----------------------------------------------------------------------
// <copyright file="BlobAttributes.cs" company="Microsoft">
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
//    Contains code for the BlobAttributes class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using Protocol;

    /// <summary>
    /// Represents a blob's attributes.
    /// </summary>
    public class BlobAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobAttributes"/> class.
        /// </summary>
        public BlobAttributes()
        {
            this.Properties = new BlobProperties();
            this.Metadata = new NameValueCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobAttributes"/> class from an existing <see cref="BlobAttributes"/> object.
        /// </summary>
        /// <param name="other">The set of blob attributes to clone.</param>
        public BlobAttributes(BlobAttributes other)
        {
            this.Properties = new BlobProperties(other.Properties);

            if (other.Metadata != null)
            {
                this.Metadata = new NameValueCollection(other.Metadata);
            }

            this.Snapshot = other.Snapshot;
            this.Uri = other.Uri;
        }

        /// <summary>
        /// Gets the blob's system properties.
        /// </summary>
        /// <value>The blob's properties.</value>
        public BlobProperties Properties { get; internal set; }

        /// <summary>
        /// Gets the user-defined metadata for the blob.
        /// </summary>
        /// <value>The blob's metadata, as a collection of name-value pairs.</value>
        public NameValueCollection Metadata { get; internal set; }

        /// <summary>
        /// Gets the blob's URI.
        /// </summary>
        /// <value>The absolute URI to the blob.</value>
        public Uri Uri { get; internal set; }

        /// <summary>
        /// Gets the date and time that the blob snapshot was taken, if this blob is a snapshot.
        /// </summary>
        /// <value>The blob's snapshot time if the blob is a snapshot; otherwise, <c>null</c>.</value>
        /// <remarks>
        /// If the blob is not a snapshot, the value of this property is <c>null</c>.
        /// </remarks>
        public DateTime? Snapshot { get; internal set; }
    }
}
