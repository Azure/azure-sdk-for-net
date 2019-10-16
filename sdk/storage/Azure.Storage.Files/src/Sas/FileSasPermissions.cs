// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="FileSasPermissions"/> supports reading and writing
    /// permissions string for a file's access policy.  Use <see cref="ToString"/>
    /// to generate a permissions string you can provide to
    /// <see cref="FileSasBuilder.Permissions"/>.
    /// </summary>
    public struct FileSasPermissions : IEquatable<FileSasPermissions>
    {
        /// <summary>
        /// Get or sets whether Read is permitted.
        /// </summary>
        public bool Read { get; set; }

        /// <summary>
        /// Get or sets whether Create is permitted.
        /// </summary>
        public bool Create { get; set; }

        /// <summary>
        /// Get or sets whether Write is permitted.
        /// </summary>
        public bool Write { get; set; }

        /// <summary>
        /// Get or sets whether Delete is permitted.
        /// </summary>
        public bool Delete { get; set; }

        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="FileSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Read) { sb.Append(Constants.Sas.Permissions.Read); }
            if (Create) { sb.Append(Constants.Sas.Permissions.Create); }
            if (Write) { sb.Append(Constants.Sas.Permissions.Write); }
            if (Delete) { sb.Append(Constants.Sas.Permissions.Delete); }
            return sb.ToString();
        }

        /// <summary>
        /// Parse a permissions string into a new <see cref="FileSasPermissions"/>.
        /// </summary>
        /// <param name="s">Permissions string to parse.</param>
        /// <returns>The parsed <see cref="FileSasPermissions"/>.</returns>
        public static FileSasPermissions Parse(string s)
        {
            var p = new FileSasPermissions();
            foreach (var c in s)
            {
                switch (c)
                {
                    case Constants.Sas.Permissions.Read:
                        p.Read = true;
                        break;
                    case Constants.Sas.Permissions.Create:
                        p.Create = true;
                        break;
                    case Constants.Sas.Permissions.Write:
                        p.Write = true;
                        break;
                    case Constants.Sas.Permissions.Delete:
                        p.Delete = true;
                        break;
                    default:
                        throw Errors.InvalidPermission(c);
                }
            }
            return p;
        }

        /// <summary>
        /// Check if two FileSasPermissions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is FileSasPermissions other && Equals(other);

        /// <summary>
        /// Get a hash code for the FileSasPermissions.
        /// </summary>
        /// <returns>Hash code for the FileSasPermissions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (Read ? 0b0001 : 0) +
            (Create ? 0b0010 : 0) +
            (Write ? 0b0100 : 0) +
            (Delete ? 0b1000 : 0);

        /// <summary>
        /// Check if two FileSasPermissions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(FileSasPermissions left, FileSasPermissions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two FileSasPermissions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(FileSasPermissions left, FileSasPermissions right) =>
            !(left == right);

        /// <summary>
        /// Check if two FileSasPermissions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(FileSasPermissions other) =>
            Read == other.Read &&
            Create == other.Create &&
            Write == other.Write &&
            Delete == other.Delete;
    }
}
