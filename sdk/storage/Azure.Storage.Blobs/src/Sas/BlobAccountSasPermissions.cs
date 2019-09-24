// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="BlobAccountSasPermissions"/> supports reading and writing 
    /// permissions string for a storage account's access policy.  Use
    /// <see cref="ToString"/> to generate a permissions string.
    /// </summary>
    public struct BlobAccountSasPermissions : IEquatable<BlobAccountSasPermissions>
    {
        /// <summary>
        /// Get or sets whether Read is permitted.
        /// </summary>
        public bool Read { get; set; }

        /// <summary>
        /// Get or sets whether Add is permitted.
        /// </summary>
        public bool Add { get; set; }

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
        /// Get or sets whether List is permitted.
        /// </summary>
        public bool List { get; set; }

        /// <summary>
        /// Create a permissions string.
        /// </summary>
        /// <returns>A permissions string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Read) { sb.Append(Constants.Sas.Permissions.Read); }
            if (Add) { sb.Append(Constants.Sas.Permissions.Add); }
            if (Create) { sb.Append(Constants.Sas.Permissions.Create); }
            if (Write) { sb.Append(Constants.Sas.Permissions.Write); }
            if (Delete) { sb.Append(Constants.Sas.Permissions.Delete); }
            if (List) { sb.Append(Constants.Sas.Permissions.List); }
            return sb.ToString();
        }

        /// <summary>
        /// Parse a permissions string into a new <see cref="BlobAccountSasPermissions"/>.
        /// </summary>
        /// <param name="s">Permissions string to parse.</param>
        /// <returns>The parsed <see cref="BlobAccountSasPermissions"/>.</returns>
        public static BlobAccountSasPermissions Parse(string s)
        {
            var p = new BlobAccountSasPermissions();
            foreach (var c in s)
            {
                switch (c)
                {
                    case Constants.Sas.Permissions.Read:
                        p.Read = true;
                        break;
                    case Constants.Sas.Permissions.Add:
                        p.Add = true;
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
                    case Constants.Sas.Permissions.List:
                        p.List = true;
                        break;
                    default:
                        throw Errors.InvalidPermission(c);
                }
            }
            return p;
        }

        /// <summary>
        /// Check if two BlobAccountSasPermissions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is BlobAccountSasPermissions other && Equals(other);

        /// <summary>
        /// Get a hash code for the BlobAccountSasPermissions.
        /// </summary>
        /// <returns>Hash code for the BlobAccountSasPermissions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (Read ? 0b000001 : 0) +
            (Add ? 0b000010 : 0) +
            (Create ? 0b000100 : 0) +
            (Write ? 0b001000 : 0) +
            (Delete ? 0b010000 : 0) +
            (List ? 0b100000 : 0);

        /// <summary>
        /// Check if two BlobAccountSasPermissions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(BlobAccountSasPermissions left, BlobAccountSasPermissions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two BlobAccountSasPermissions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(BlobAccountSasPermissions left, BlobAccountSasPermissions right) =>
            !(left == right);

        /// <summary>
        /// Check if two BlobAccountSasPermissions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(BlobAccountSasPermissions other) =>
            Read == other.Read &&
            Add == other.Add &&
            Create == other.Create &&
            Write == other.Write &&
            Delete == other.Delete &&
            List == other.List;
    }
}
