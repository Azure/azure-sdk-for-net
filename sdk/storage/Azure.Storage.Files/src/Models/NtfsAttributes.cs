// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// NTFS file attributes for Files and Directories.
    /// </summary>
    [Flags]
    public enum NtfsAttributes
    {
        /// <summary>
        /// Clear all flags.
        /// </summary>
        None = 0,

        /// <summary>
        /// The File or Directory is read-only.
        /// </summary>
        ReadOnly = FileAttributes.ReadOnly,

        /// <summary>
        /// The File or Directory is hidden, and thus is not included in an ordinary directory listing.
        /// </summary>
        Hidden = FileAttributes.Hidden,

        /// <summary>
        /// The File or Directory is a systemfile.  That is, the file is part of the operating system
        /// or is used exclusively by the operating system.
        /// </summary>
        System = FileAttributes.System,

        /// <summary>
        /// The file  or directory is a standard file that has no special attributes. This attribute is
        /// valid only if it is used alone.
        /// </summary>
        Normal = FileAttributes.Normal,

        /// <summary>
        /// The file is a directory.
        /// </summary>
        Directory = FileAttributes.Directory,

        /// <summary>
        /// The file is a candidate for backup or removal.
        /// </summary>
        Archive = FileAttributes.Archive,

        /// <summary>
        /// The file or directory is temporary. A temporary file contains data that is needed while an
        /// application is executing but is not needed after the application is finished.
        /// File systems try to keep all the data in memory for quicker access rather than
        /// flushing the data back to mass storage. A temporary file should be deleted by
        /// the application as soon as it is no longer needed.
        /// </summary>
        Temporary = FileAttributes.Temporary,

        /// <summary>
        /// The file or directory is offline. The data of the file is not immediately available.
        /// </summary>
        Offline = FileAttributes.Offline,

        /// <summary>
        /// The file or directory will not be indexed by the operating system's content indexing service.
        /// </summary>
        NotContentIndexed = FileAttributes.NotContentIndexed,

        /// <summary>
        /// The file or directory is excluded from the data integrity scan. When this value
        /// is applied to a directory, by default, all new files and subdirectories within
        /// that directory are excluded from data integrity.
        /// </summary>
        NoScrubData = FileAttributes.NoScrubData
    }

    /// <summary>
    /// CloudFileNtfsAttributesHelper helper.
    /// </summary>
    internal class CloudFileNtfsAttributesHelper
    {
        private static readonly Dictionary<NtfsAttributes, string> dictionary = new Dictionary<NtfsAttributes, string>()
        {
            { NtfsAttributes.ReadOnly, "ReadOnly" },
            { NtfsAttributes.Hidden, "Hidden" },
            { NtfsAttributes.System, "System" },
            { NtfsAttributes.Normal, "Normal" },
            { NtfsAttributes.Directory, "Directory" },
            { NtfsAttributes.Archive, "Archive" },
            { NtfsAttributes.Temporary, "Temporary" },
            { NtfsAttributes.Offline, "Offline" },
            { NtfsAttributes.NotContentIndexed, "NotContentIndexed" },
            { NtfsAttributes.NoScrubData, "NoScrubData" },
        };

        /// <summary>
        /// Converts a CloudFileNtfsAttributes to a string
        /// </summary>
        /// <param name="attributes"><see cref="NtfsAttributes"/></param>
        /// <returns>string</returns>
        internal static string ToString(NtfsAttributes? attributes)
            => attributes == null
                ? null
                : String.Join("|", dictionary.Select(
                    r =>
                    {
                        return attributes.Value.HasFlag(r.Key) ? r.Value : null;
                    })
                .Where(r => r != null));
        /// <summary>
        /// Parses an attributes string to a <see cref="NtfsAttributes"/>
        /// </summary>
        /// <param name="attributesString">string</param>
        /// <returns><see cref="NtfsAttributes"/></returns>
        internal static NtfsAttributes? ToAttributes(string attributesString)
        {
            if (attributesString == null)
            {
                return null;
            }
            var attributes = NtfsAttributes.None;
            var splitString = attributesString.Split('|');
            foreach (var s in splitString)
            {
                var trimmed = s.Trim();

                attributes |= dictionary.FirstOrDefault(r => r.Value == trimmed).Key;
            }
            return attributes;
        }
    }
}
