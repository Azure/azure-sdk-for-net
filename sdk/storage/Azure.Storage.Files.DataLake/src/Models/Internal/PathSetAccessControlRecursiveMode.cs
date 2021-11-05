// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Mode "set" sets POSIX access control rights on files and directories, "modify" modifies one or more POSIX access control rights
    /// that pre-exist on files and directories, "remove" removes one or more POSIX access control rights  that were present earlier on files and directories.
    /// </summary>
    internal enum PathSetAccessControlRecursiveMode
    {
        /// <summary>
        /// set
        /// </summary>
        Set,

        /// <summary>
        /// modify
        /// </summary>
        Modify,

        /// <summary>
        /// remove
        /// </summary>
        Remove
    }
}
