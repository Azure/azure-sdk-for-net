// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Access right for a file handle.
    /// </summary>
    [Flags]
    public enum ShareFileHandleAccessRight
    {
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
        Delete = 4,

        /// <summary>
        /// Indicates that all access rights are set.
        /// </summary>
        All = ~0
    }
}
