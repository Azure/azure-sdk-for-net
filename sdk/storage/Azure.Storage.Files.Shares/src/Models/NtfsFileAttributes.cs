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

namespace Azure.Storage.Files.Shares
{
    /// <summary>
    /// File enum extensions.
    /// </summary>
    internal static partial class ShareExtensions
    {
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>string</returns>
        public static string ToAttributesString(this NtfsFileAttributes attributes)
        {
            var stringBuilder = new StringBuilder();

            if ((attributes & NtfsFileAttributes.ReadOnly) == NtfsFileAttributes.ReadOnly)
            {
                AppendAttribute(nameof(NtfsFileAttributes.ReadOnly), stringBuilder);
            }
            if ((attributes & NtfsFileAttributes.Hidden) == NtfsFileAttributes.Hidden)
            {
                AppendAttribute(nameof(NtfsFileAttributes.Hidden), stringBuilder);
            }
            if ((attributes & NtfsFileAttributes.System) == NtfsFileAttributes.System)
            {
                AppendAttribute(nameof(NtfsFileAttributes.System), stringBuilder);
            }
            if ((attributes & NtfsFileAttributes.None) == NtfsFileAttributes.None)
            {
                AppendAttribute(nameof(NtfsFileAttributes.None), stringBuilder);
            }
            if ((attributes & NtfsFileAttributes.Directory) == NtfsFileAttributes.Directory)
            {
                AppendAttribute(nameof(NtfsFileAttributes.Directory), stringBuilder);
            }
            if ((attributes & NtfsFileAttributes.Archive) == NtfsFileAttributes.Archive)
            {
                AppendAttribute(nameof(NtfsFileAttributes.Archive), stringBuilder);
            }
            if ((attributes & NtfsFileAttributes.Temporary) == NtfsFileAttributes.Temporary)
            {
                AppendAttribute(nameof(NtfsFileAttributes.Temporary), stringBuilder);
            }
            if ((attributes & NtfsFileAttributes.Offline) == NtfsFileAttributes.Offline)
            {
                AppendAttribute(nameof(NtfsFileAttributes.Offline), stringBuilder);
            }
            if ((attributes & NtfsFileAttributes.NotContentIndexed) == NtfsFileAttributes.NotContentIndexed)
            {
                AppendAttribute(nameof(NtfsFileAttributes.NotContentIndexed), stringBuilder);
            }
            if ((attributes & NtfsFileAttributes.NoScrubData) == NtfsFileAttributes.NoScrubData)
            {
                AppendAttribute(nameof(NtfsFileAttributes.NoScrubData), stringBuilder);
            }
            if (stringBuilder[stringBuilder.Length - 1] == '|')
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Helper method to append attribute name to stringbuilder.
        /// </summary>
        /// <param name="attributeName">name of attribute</param>
        /// <param name="stringBuilder">stringbuilder reference</param>
        private static void AppendAttribute(string attributeName, StringBuilder stringBuilder)
        {
            stringBuilder.Append(attributeName);
            stringBuilder.Append('|');
        }

        /// <summary>
        /// Parses a NTFS attributes string to a nullable FileNtfsAttributes.
        /// </summary>
        /// <param name="attributesString">string to parse</param>
        /// <returns></returns>
        public static NtfsFileAttributes? ToFileAttributes(string attributesString)
        {
            if (attributesString == null)
            {
                return null;
            }
            var splitString = attributesString.Split('|');

            if (splitString.Length == 0)
            {
                throw Errors.InvalidArgument(attributesString);
            }

            NtfsFileAttributes attributes = default;
            foreach (var s in splitString)
            {
                var trimmed = s.Trim();

                if (trimmed.Equals(nameof(NtfsFileAttributes.ReadOnly), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.ReadOnly;
                }
                else if (trimmed.Equals(nameof(NtfsFileAttributes.Hidden), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.Hidden;
                }
                else if (trimmed.Equals(nameof(NtfsFileAttributes.System), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.System;
                }
                else if (trimmed.Equals(nameof(NtfsFileAttributes.None), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.None;
                }
                else if (trimmed.Equals(nameof(NtfsFileAttributes.Directory), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.Directory;
                }
                else if (trimmed.Equals(nameof(NtfsFileAttributes.Archive), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.Archive;
                }
                else if (trimmed.Equals(nameof(NtfsFileAttributes.Temporary), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.Temporary;
                }
                else if (trimmed.Equals(nameof(NtfsFileAttributes.Offline), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.Offline;
                }
                else if (trimmed.Equals(nameof(NtfsFileAttributes.NotContentIndexed), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.NotContentIndexed;
                }
                else if (trimmed.Equals(nameof(NtfsFileAttributes.NoScrubData), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes |= NtfsFileAttributes.NoScrubData;
                }
                else
                {
                    throw Errors.InvalidArgument(trimmed);
                }
            }
            return attributes;
        }
    }
}
