// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobContainerAccessPolicy
    /// </summary>
    public class BlobContainerAccessPolicy : IXmlSerializable
    {
        internal static BlobContainerAccessPolicy FromResponse(Response response)
        {
            var document = XDocument.Load(response.ContentStream, LoadOptions.PreserveWhitespace);
            return DeserializeBlobContainerAccessPolicy(document.Root);
        }

        /// <summary>
        /// Indicated whether data in the container may be accessed publicly and the level of access.
        /// </summary>
        public PublicAccessType BlobPublicAccess { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified.
        /// Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// a collection of signed identifiers
        /// </summary>
        public IEnumerable<BlobSignedIdentifier> SignedIdentifiers { get; internal set; }

        /// <summary>
        /// Creates a new BlobContainerAccessPolicy instance.
        /// </summary>
        public BlobContainerAccessPolicy()
        {
            SignedIdentifiers = new List<BlobSignedIdentifier>();
        }

        // Add these (what is on generated models in <Model>.Serialization.cs)
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            throw new NotImplementedException();
        }

        internal static BlobContainerAccessPolicy DeserializeBlobContainerAccessPolicy(XElement element)
        {
            throw new NotImplementedException();
        }
    }
}
