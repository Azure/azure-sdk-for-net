// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Specifies if the file last write time should be set to the current time,
    /// or the file last write time currently associated with the file should be preserved.
    /// </summary>
    public enum FileLastWrittenOn
    {
        /// <summary>
        /// Default.  Set the file last write time to the current time.
        /// </summary>
        Now,

        /// <summary>
        /// Preserve the file last write time that is currently associated with the file.
        /// </summary>
        Preserve
    }
}
