//-----------------------------------------------------------------------
// <copyright file="ListBlobEntry.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a blob item returned in the XML response for a blob listing operation.
    /// </summary>
#if RTMD
    internal
#else
    public
#endif
        sealed class ListBlobEntry : IListBlobEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBlobEntry"/> class.
        /// </summary>
        /// <param name="name">The name of the blob.</param>
        /// <param name="attributes">The blob's attributes.</param>
        internal ListBlobEntry(string name, BlobAttributes attributes)
        {
            this.Name = name;
            this.Attributes = attributes;
        }

        /// <summary>
        /// Stores the blob item's attributes.
        /// </summary>
        internal BlobAttributes Attributes { get; private set; }

        /// <summary>
        /// Gets the name of the blob item.
        /// </summary>
        /// <value>The name of the blob item.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the blob item's system properties.
        /// </summary>
        /// <value>The blob item's properties.</value>
        public BlobProperties Properties
        {
            get
            {
                return this.Attributes.Properties;
            }
        }

        /// <summary>
        /// Gets the user-defined metadata for the blob item.
        /// </summary>
        /// <value>The blob item's metadata, as a collection of name-value pairs.</value>
        public IDictionary<string, string> Metadata
        {
            get
            {
                return this.Attributes.Metadata;
            }
        }

        /// <summary>
        /// Gets the blob item's URI.
        /// </summary>
        /// <value>The absolute URI to the blob item.</value>
        public Uri Uri
        {
            get
            {
                return this.Attributes.Uri;
            }
        }

        /// <summary>
        /// Gets the date and time that the blob snapshot was taken, if this blob is a snapshot.
        /// </summary>
        /// <value>The blob's snapshot time if the blob is a snapshot; otherwise, <c>null</c>.</value>
        /// <remarks>
        /// If the blob is not a snapshot, the value of this property is <c>null</c>.
        /// </remarks>
        public DateTimeOffset? SnapshotTime
        {
            get
            {
                return this.Attributes.SnapshotTime;
            }
        }

        /// <summary>
        /// Gets the state of the most recent or pending copy operation.
        /// </summary>
        /// <value>A <see cref="CopyState"/> object containing the copy state, or null if no copy blob state exists for this blob.</value>
        public CopyState CopyState
        {
            get
            {
                return this.Attributes.CopyState;
            }
        }
    }
}
