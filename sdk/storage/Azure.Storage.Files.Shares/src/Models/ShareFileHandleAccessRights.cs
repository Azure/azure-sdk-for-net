// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Access right for a file handle.
    /// </summary>
    [Flags]
    public enum ShareFileHandleAccessRights
    {
        /// <summary>
        /// Indicates no operations are permitted.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that Read is permitted.
        /// </summary>
        Read = 1,

        /// <summary>
        /// Indicates that Write is permitted.
        /// </summary>
        Write = 2,

        /// <summary>
        /// Indicates that Delete is permitted.
        /// </summary>
        Delete = 4
    }
}
