//-----------------------------------------------------------------------
// <copyright file="BlobEntry.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobEntry class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Represents a blob item returned in the XML response for a blob listing operation.
    /// </summary>
    public class BlobEntry : IListBlobEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobEntry"/> class.
        /// </summary>
        /// <param name="name">The name of the blob.</param>
        /// <param name="attributes">The blob's attributes.</param>
        internal BlobEntry(string name, BlobAttributes attributes)
        {
            this.Name = name;
            this.Attributes = attributes;
        }

        /// <summary>
        /// Gets the attributes for this blob item.
        /// </summary>
        /// <value>The blob item's attributes.</value>
        public BlobAttributes Attributes { get; private set; }

        /// <summary>
        /// Gets the name of the blob item.
        /// </summary>
        /// <value>The name of the blob item.</value>
        public string Name { get; private set; }
    }
}