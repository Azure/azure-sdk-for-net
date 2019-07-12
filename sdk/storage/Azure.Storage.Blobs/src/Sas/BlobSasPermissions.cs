// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="BlobSasPermissions"/> supports reading and writing
    /// permissions string for a blob's access policy.  Use <see cref="ToString"/>
    /// to generate a permissions string you can provide to
    /// <see cref="BlobSasBuilder.Permissions"/>.
    /// </summary>
    public struct BlobSasPermissions : IEquatable<BlobSasPermissions>
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
        /// Create a permissions string to provide
        /// <see cref="BlobSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Read) { sb.Append(Constants.Sas.Permissions.Read); }
            if (this.Add) { sb.Append(Constants.Sas.Permissions.Add); }
            if (this.Create) { sb.Append(Constants.Sas.Permissions.Create); }
            if (this.Write) { sb.Append(Constants.Sas.Permissions.Write); }
            if (this.Delete) { sb.Append(Constants.Sas.Permissions.Delete); }
            return sb.ToString();
        }

        /// <summary>
        /// Parse a permissions string into a new <see cref="BlobSasPermissions"/>.
        /// </summary>
        /// <param name="s">Permissions string to parse.</param>
        /// <returns>The parsed <see cref="BlobSasPermissions"/>.</returns>
        public static BlobSasPermissions Parse(string s)
        {
            // Clear the flags
            var p = new BlobSasPermissions();
            foreach (var c in s)
            {
                switch (c)
                {
                    case Constants.Sas.Permissions.Read: p.Read = true; break;
                    case Constants.Sas.Permissions.Add: p.Add = true; break;
                    case Constants.Sas.Permissions.Create: p.Create = true; break;
                    case Constants.Sas.Permissions.Write: p.Write = true; break;
                    case Constants.Sas.Permissions.Delete: p.Delete = true; break;
                    default: throw Errors.InvalidPermission(c);
                }
            }
            return p;
        }

        /// <summary>
        /// Check if two BlobSasPermissions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => obj is BlobSasPermissions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the BlobSasPermissions.
        /// </summary>
        /// <returns>Hash code for the BlobSasPermissions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
            => (this.Read   ? 0b00001 : 0)
             + (this.Add    ? 0b00010 : 0)
             + (this.Create ? 0b00100 : 0)
             + (this.Write  ? 0b01000 : 0)
             + (this.Delete ? 0b10000 : 0)
            ;

        /// <summary>
        /// Check if two BlobSasPermissions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(BlobSasPermissions left, BlobSasPermissions right) => left.Equals(right);

        /// <summary>
        /// Check if two BlobSasPermissions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(BlobSasPermissions left, BlobSasPermissions right) => !(left == right);

        /// <summary>
        /// Check if two BlobSasPermissions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(BlobSasPermissions other)
            => this.Read == other.Read
            && this.Add == other.Add
            && this.Create == other.Create
            && this.Write == other.Write
            && this.Delete == other.Delete
            ;
    }
}
