//-----------------------------------------------------------------------
// <copyright file="ContainerListingDetails.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the ContainerListingDetails enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Specifies which details to include when listing the containers in this storage account.
    /// </summary>
    [Flags]
    public enum ContainerListingDetails
    {
        /// <summary>
        /// No additional details.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Retrieve container metadata.
        /// </summary>
        Metadata = 0x1,

        /// <summary>
        /// Retrieve all available details.
        /// </summary>
        All = 0x1
    }
}
