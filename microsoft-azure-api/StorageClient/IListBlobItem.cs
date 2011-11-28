//-----------------------------------------------------------------------
// <copyright file="IListBlobItem.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the IListBlobItem interface.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Represents an item that may be returned by a blob listing operation.
    /// </summary>
    public interface IListBlobItem
    {
        /// <summary>
        /// Gets the URI to the blob item.
        /// </summary>
        /// <value>The blob item's URI.</value>
        Uri Uri { get; }

        /// <summary>
        /// Gets the blob item's parent.
        /// </summary>
        /// <value>The blob item's parent.</value>
        CloudBlobDirectory Parent { get; }

        /// <summary>
        /// Gets the blob item's container.
        /// </summary>
        /// <value>The blob item's container.</value>
        CloudBlobContainer Container { get; }
    }
}
