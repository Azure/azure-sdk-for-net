//-----------------------------------------------------------------------
// <copyright file="LeaseAction.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the LeaseAction enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Describes actions that can be performed on a lease.
    /// </summary>
    public enum LeaseAction
    {
        /// <summary>
        /// Acquire the lease.
        /// </summary>
        Acquire,

        /// <summary>
        /// Renew the lease.
        /// </summary>
        Renew,

        /// <summary>
        /// Release the lease.
        /// </summary>
        Release,

        /// <summary>
        /// Break the lease.
        /// </summary>
        Break
    }
}