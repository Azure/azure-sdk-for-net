// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// NTFS file attributes for Files and Directories.
    /// </summary>
    [Flags]
    public enum NtfsFileAttributes
    {
        /// <summary>
        /// The File or Directory is read-only.
        /// </summary>
        ReadOnly = 1,

        /// <summary>
        /// The File or Directory is hidden, and thus is not included in an ordinary directory listing.
        /// </summary>
        Hidden = 2,

        /// <summary>
        /// The File or Directory is a systemfile.  That is, the file is part of the operating system
        /// or is used exclusively by the operating system.
        /// </summary>
        System = 4,

        /// <summary>
        /// The file  or directory is a standard file that has no special attributes. This attribute is
        /// valid only if it is used alone.
        /// </summary>
        None = 8,

        /// <summary>
        /// The file is a directory.
        /// </summary>
        Directory = 16,

        /// <summary>
        /// The file is a candidate for backup or removal.
        /// </summary>
        Archive = 32,

        /// <summary>
        /// The file or directory is temporary. A temporary file contains data that is needed while an
        /// application is executing but is not needed after the application is finished.
        /// File systems try to keep all the data in memory for quicker access rather than
        /// flushing the data back to mass storage. A temporary file should be deleted by
        /// the application as soon as it is no longer needed.
        /// </summary>
        Temporary = 64,

        /// <summary>
        /// The file or directory is offline. The data of the file is not immediately available.
        /// </summary>
        Offline = 128,

        /// <summary>
        /// The file or directory will not be indexed by the operating system's content indexing service.
        /// </summary>
        NotContentIndexed = 256,

        /// <summary>
        /// The file or directory is excluded from the data integrity scan. When this value
        /// is applied to a directory, by default, all new files and subdirectories within
        /// that directory are excluded from data integrity.
        /// </summary>
        NoScrubData = 512
    }
}
