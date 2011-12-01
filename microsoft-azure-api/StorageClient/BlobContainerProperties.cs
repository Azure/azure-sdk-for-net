//-----------------------------------------------------------------------
// <copyright file="BlobContainerProperties.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobContainerProperties class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;

    /// <summary>
    /// Represents the system properties for a container.
    /// </summary>
    public class BlobContainerProperties
    {
        /// <summary>
        /// Gets the ETag value for the container.
        /// </summary>
        /// <value>The container's ETag value.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "ETag",
            Justification = "ETag is the correct capitalization.")]
        public string ETag { get; internal set; }

        /// <summary>
        /// Gets the container's last-modified time, expressed as a UTC value.
        /// </summary>
        /// <value>The container's last-modified time.</value>
        public DateTime LastModifiedUtc { get; internal set; }
    }
}
