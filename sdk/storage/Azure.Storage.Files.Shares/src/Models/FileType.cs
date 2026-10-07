// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The type of file or directory.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// Regular file.
        /// </summary>
        Regular,

        /// <summary>
        /// Directory.
        /// </summary>
        Directory,

        /// <summary>
        /// Symbolic link.
        /// </summary>
        SymLink,

        /// <summary>
        /// Block device.
        /// </summary>
        BlockDevice,

        /// <summary>
        /// Character device.
        /// </summary>
        CharacterDevice,

        /// <summary>
        /// Socket.
        /// </summary>
        Socket,

        /// <summary>
        /// FIFO.
        /// </summary>
        Fifo
    }
}
