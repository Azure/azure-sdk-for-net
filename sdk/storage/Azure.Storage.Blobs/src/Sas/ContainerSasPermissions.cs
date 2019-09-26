// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="ContainerSasPermissions"/> supports reading and writing
    /// permissions string for a containers's access policy.  Use <see cref="ToString"/>
    /// to generate a permissions string you can provide to
    /// <see cref="BlobSasBuilder.Permissions"/>.
    /// </summary>
    public struct ContainerSasPermissions : IEquatable<ContainerSasPermissions>
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
        /// Create a permissions string to provide
        /// <see cref="BlobSasBuilder.Permissions"/>.
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
        /// Parse a permissions string into a new <see cref="ContainerSasPermissions"/>.
        /// </summary>
        /// <param name="s">Permissions string to parse.</param>
        /// <returns>The parsed <see cref="ContainerSasPermissions"/>.</returns>
        public static ContainerSasPermissions Parse(string s)
        {
            var p = new ContainerSasPermissions();
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
        /// Check if two ContainerSasPermissions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is ContainerSasPermissions other && Equals(other);

        /// <summary>
        /// Get a hash code for the ContainerSasPermissions.
        /// </summary>
        /// <returns>Hash code for the ContainerSasPermissions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (Read ? 0b000001 : 0) +
            (Add ? 0b000010 : 0) +
            (Create ? 0b000100 : 0) +
            (Write ? 0b001000 : 0) +
            (Delete ? 0b010000 : 0) +
            (List ? 0b100000 : 0);

        /// <summary>
        /// Check if two ContainerSasPermissions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(ContainerSasPermissions left, ContainerSasPermissions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two ContainerSasPermissions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(ContainerSasPermissions left, ContainerSasPermissions right) =>
            !(left == right);

        /// <summary>
        /// Check if two ContainerSasPermissions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(ContainerSasPermissions other) =>
            Read == other.Read &&
            Add == other.Add &&
            Create == other.Create &&
            Write == other.Write &&
            Delete == other.Delete &&
            List == other.List;
    }
}
