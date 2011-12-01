//-----------------------------------------------------------------------
// <copyright file="BlobContainerEntry.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobContainerEntry class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Represents a container item returned in the XML response for a container listing operation.
    /// </summary>
    public class BlobContainerEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerEntry"/> class.
        /// </summary>
        internal BlobContainerEntry()
        {
        }

        /// <summary>
        /// Gets the attributes for this container item.
        /// </summary>
        /// <value>The container item's attributes.</value>
        public BlobContainerAttributes Attributes { get; internal set; }
    }
}