//-----------------------------------------------------------------------
// <copyright file="BlobContainerAttributes.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobContainerAttributes class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;

    /// <summary>
    /// Represents a container's attributes, including its properties and metadata.
    /// </summary>
    public class BlobContainerAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerAttributes"/> class.
        /// </summary>
        public BlobContainerAttributes()
        {
            this.Metadata = new NameValueCollection();
            this.Properties = new BlobContainerProperties();
        }

        /// <summary>
        /// Gets the user-defined metadata for the container.
        /// </summary>
        /// <value>The container's metadata, as a collection of name-value pairs.</value>
        public NameValueCollection Metadata { get; internal set; }

        /// <summary>
        /// Gets the container's system properties.
        /// </summary>
        /// <value>The container's properties.</value>
        public BlobContainerProperties Properties { get; internal set; }

        /// <summary>
        /// Gets the name of the container.
        /// </summary>
        /// <value>The container's name.</value>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the container's URI.
        /// </summary>
        /// <value>The absolute URI to the container.</value>
        public Uri Uri { get; internal set; }
    }
}