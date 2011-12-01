//-----------------------------------------------------------------------
// <copyright file="PutPageProperties.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the PutPageProperties class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Represents properties for writing to a page blob.
    /// </summary>
    public class PutPageProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PutPageProperties"/> class.
        /// </summary>
        public PutPageProperties()
        {
        }

        /// <summary>
        /// Gets or sets the range of bytes to write to.
        /// </summary>
        /// <value>The page range.</value>
        public PageRange Range { get; set; }

        /// <summary>
        /// Gets or sets the type of write operation.
        /// </summary>
        /// <value>The type of page write operation.</value>
        public PageWrite PageWrite { get; set; }
    }
}
