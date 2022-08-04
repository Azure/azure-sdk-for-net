// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Smb Properties to copy from the source file.
    /// </summary>
    [Flags]
    public enum CopyableFileSmbProperties
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// File Attributes.
        /// </summary>
        FileAttributes = 1,

        /// <summary>
        /// Created On.
        /// </summary>
        CreatedOn = 2,

        /// <summary>
        /// Last Written On.
        /// </summary>
        LastWrittenOn = 4,

        /// <summary>
        /// Changed On.
        /// </summary>
        ChangedOn = 8,

        /// <summary>
        /// All.
        /// </summary>
        All = ~None
    }
}
