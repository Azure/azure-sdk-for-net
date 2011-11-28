//-----------------------------------------------------------------------
// <copyright file="SharedAccessPermissions.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the SharedAccessPermissions enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Text;

    /// <summary>
    /// Specifies the set of possible permissions for a shared access policy.
    /// </summary>
    [Flags]
    public enum SharedAccessPermissions
    {
        /// <summary>
        /// No shared access granted.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Read access granted.
        /// </summary>
        Read = 0x1,

        /// <summary>
        /// Write access granted.
        /// </summary>
        Write = 0x2,

        /// <summary>
        /// Delete access granted for blobs.
        /// </summary>
        Delete = 0x4,

        /// <summary>
        /// List access granted.
        /// </summary>
        List = 0x8
    }
}