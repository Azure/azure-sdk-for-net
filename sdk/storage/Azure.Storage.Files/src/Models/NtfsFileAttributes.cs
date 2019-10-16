// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Storage.Files.Models;

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// NTFS file attributes for Files and Directories.
    /// </summary>
    public struct NtfsFileAttributes : IEquatable<NtfsFileAttributes>
    {
        /// <summary>
        /// The File or Directory has no NTFS attributes.
        /// </summary>
        public bool None { get; set; }

        /// <summary>
        /// The File or Directory is read-only.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// The File or Directory is hidden, and thus is not included in an ordinary directory listing.
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// The File or Directory is a systemfile.  That is, the file is part of the operating system
        /// or is used exclusively by the operating system.
        /// </summary>
        public bool System { get; set; }

        /// <summary>
        /// The file  or directory is a standard file that has no special attributes. This attribute is
        /// valid only if it is used alone.
        /// </summary>
        public bool Normal { get; set; }

        /// <summary>
        /// The file is a directory.
        /// </summary>
        public bool Directory { get; set; }

        /// <summary>
        /// The file is a candidate for backup or removal.
        /// </summary>
        public bool Archive { get; set; }

        /// <summary>
        /// The file or directory is temporary. A temporary file contains data that is needed while an
        /// application is executing but is not needed after the application is finished.
        /// File systems try to keep all the data in memory for quicker access rather than
        /// flushing the data back to mass storage. A temporary file should be deleted by
        /// the application as soon as it is no longer needed.
        /// </summary>
        public bool Temporary { get; set; }

        /// <summary>
        /// The file or directory is offline. The data of the file is not immediately available.
        /// </summary>
        public bool Offline { get; set; }

        /// <summary>
        /// The file or directory will not be indexed by the operating system's content indexing service.
        /// </summary>
        public bool NotContentIndexed { get; set; }

        /// <summary>
        /// The file or directory is excluded from the data integrity scan. When this value
        /// is applied to a directory, by default, all new files and subdirectories within
        /// that directory are excluded from data integrity.
        /// </summary>
        public bool NoScrubData { get; set; }

        /// <summary>
        /// Checks if two FileNtfsAttributes are equal.
        /// </summary>
        /// <param name="other">The other instance to compare to.</param>
        /// <returns></returns>
        public override bool Equals(object other)
            => other is NtfsFileAttributes attributes && Equals(attributes);

        /// <summary>
        /// Checks if two FileNtfsAttributes are equal to each other.
        /// </summary>
        /// <param name="other">TThe other instance to compare to.</param>
        /// <returns></returns>
        public bool Equals(NtfsFileAttributes other)
            => None == other.None
            && ReadOnly == other.ReadOnly
            && Hidden == other.Hidden
            && System == other.System
            && Normal == other.Normal
            && Directory == other.Directory
            && Archive == other.Archive
            && Temporary == other.Temporary
            && Offline == other.Offline
            && NotContentIndexed == other.NotContentIndexed
            && NoScrubData == other.NoScrubData;

        /// <summary>
        /// Get a hash code for the FileNtfsAttributes.
        /// </summary>
        /// <returns>Hash code for the FileNtfsAttributes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (None ? 0b00000000001 : 0) +
            (ReadOnly ? 0b00000000010 : 0) +
            (Hidden ? 0b00000000100 : 0) +
            (System ? 0b00000001000 : 0) +
            (Normal ? 0b00000010000 : 0) +
            (Directory ? 0b00000100000 : 0) +
            (Archive ? 0b00001000000 : 0) +
            (Temporary ? 0b00010000000 : 0) +
            (Offline ? 0b00100000000 : 0) +
            (NotContentIndexed ? 0b01000000000 : 0) +
            (NoScrubData ? 0b10000000000 : 0);

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (None)
            {
                stringBuilder.Append(nameof(None) + "|");
            }

            if (ReadOnly)
            {
                stringBuilder.Append(nameof(ReadOnly) + "|");
            }

            if (Hidden)
            {
                stringBuilder.Append(nameof(Hidden) + "|");
            }

            if (System)
            {
                stringBuilder.Append(nameof(System) + "|");
            }

            if (Normal)
            {
                stringBuilder.Append(nameof(Normal) + "|");
            }

            if (Directory)
            {
                stringBuilder.Append(nameof(Directory) + "|");
            }

            if (Archive)
            {
                stringBuilder.Append(nameof(Archive) + "|");
            }

            if (Temporary)
            {
                stringBuilder.Append(nameof(Temporary) + "|");
            }

            if (Offline)
            {
                stringBuilder.Append(nameof(Offline) + "|");
            }

            if (NotContentIndexed)
            {
                stringBuilder.Append(nameof(NotContentIndexed) + "|");
            }

            if (NoScrubData)
            {
                stringBuilder.Append(nameof(NoScrubData) + "|");
            }

            if (stringBuilder[stringBuilder.Length - 1] == '|')
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Parses a NTFS attributes string to a nullable FileNtfsAttributes
        /// </summary>
        /// <param name="attributesString">string to parse</param>
        /// <returns></returns>
        public static NtfsFileAttributes? Parse(string attributesString)
        {
            if (attributesString == null)
            {
                return null;
            }
            var attributes = new NtfsFileAttributes();
            var splitString = attributesString.Split('|');

            if (splitString.Length == 0)
            {
                throw Errors.InvalidArgument(attributesString);
            }

            foreach (var s in splitString)
            {
                var trimmed = s.Trim();

                if (trimmed.Equals(nameof(ReadOnly), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.ReadOnly = true;
                }
                else if (trimmed.Equals(nameof(Hidden), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.Hidden = true;
                }
                else if (trimmed.Equals(nameof(System), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.System = true;
                }
                else if (trimmed.Equals(nameof(Normal), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.Normal = true;
                }
                else if (trimmed.Equals(nameof(Directory), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.Directory = true;
                }
                else if (trimmed.Equals(nameof(Archive), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.Archive = true;
                }
                else if (trimmed.Equals(nameof(Temporary), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.Temporary = true;
                }
                else if (trimmed.Equals(nameof(Offline), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.Offline = true;
                }
                else if (trimmed.Equals(nameof(NotContentIndexed), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.NotContentIndexed = true;
                }
                else if (trimmed.Equals(nameof(NoScrubData), StringComparison.InvariantCultureIgnoreCase))
                {
                    attributes.NoScrubData = true;
                }
                else
                {
                    throw Errors.InvalidArgument(trimmed);
                }
            }
            return attributes;
        }

        /// <summary>
        /// Check if two FileNtfsAttributes instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(NtfsFileAttributes left, NtfsFileAttributes right) => left.Equals(right);

        /// <summary>
        /// Check if two FileNtfsAttributes instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(NtfsFileAttributes left, NtfsFileAttributes right) => !(left == right);
    }
}
