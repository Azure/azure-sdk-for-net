//-----------------------------------------------------------------------
// <copyright file="BlobPrefixEntry.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobPrefixEntry class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Represents the blob name prefix that is returned in the XML response for a blob listing operation.
    /// </summary>
    public class BlobPrefixEntry : IListBlobEntry
    {
        /// <summary>
        /// Gets the blob name prefix.
        /// </summary>
        /// <value>The blob name prefix.</value>
        public string Name
        {
            get;
            internal set;
        }
    }
}