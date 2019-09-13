// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Specifies the permissions available to an account level shared access
    /// signature.  Use <see cref="ToString"/> to produce a <see cref="string"/>
    /// that can be for <see cref="AccountSasBuilder.Permissions"/>.
    /// </summary>
    public struct AccountSasPermissions : IEquatable<AccountSasPermissions>
    {
        /// <summary>
        /// Gets a value indicating whether Read permissions are granted to the
        /// specified resource type.  Valid for all resources types.
        /// </summary>
        public bool Read { get; set; }

        /// <summary>
        /// Gets a value indicating whether Write permissions are granted to
        /// the specified resource type.  Valid for all resources types.
        /// </summary>
        public bool Write { get; set; }

        /// <summary>
        /// Gets a value indicating whether Delete permissions are granted to
        /// the specified resource type.  Valid for Container and Object
        /// resource types, except for queue messages.
        /// </summary>
        public bool Delete { get; set; }

        /// <summary>
        /// Gets a value indicating whether List permissions are granted to the
        /// specified resource type.  Valid for Service and Container resource
        /// types only.
        /// </summary>
        public bool List { get; set; }

        /// <summary>
        /// Gets a value indicating whether Add permissions are granted to
        /// the specified resource type.  Valid for the following Object
        /// resource types only: queue messages and append blobs.
        /// </summary>
        public bool Add { get; set; }

        /// <summary>
        /// Gets a value indicating whether Create permissions are granted to
        /// the specified resource type.  Valid for the following Object
        /// resource types only: blobs and files.  Users can create new blobs
        /// or files, but may not overwrite existing blobs or files.
        /// </summary>
        public bool Create { get; set; }

        /// <summary>
        /// Gets a value indicating whether Update permissions are granted to
        /// the specified resource type.  Valid for queue messages only.
        /// </summary>
        public bool Update { get; set; }

        /// <summary>
        /// Gets a value indicating whether Process permissions are granted to
        /// the specified resource type.  Valid for queue messages only.
        /// </summary>
        public bool Process { get; set; }

        /// <summary>
        /// Creates a string representing which permissions can be allowed for
        /// <see cref="AccountSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>
        /// A string representing which permissions are allowed.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Read) { sb.Append(Constants.Sas.Permissions.Read); }
            if (Write) { sb.Append(Constants.Sas.Permissions.Write); }
            if (Delete) { sb.Append(Constants.Sas.Permissions.Delete); }
            if (List) { sb.Append(Constants.Sas.Permissions.List); }
            if (Add) { sb.Append(Constants.Sas.Permissions.Add); }
            if (Create) { sb.Append(Constants.Sas.Permissions.Create); }
            if (Update) { sb.Append(Constants.Sas.Permissions.Update); }
            if (Process) { sb.Append(Constants.Sas.Permissions.Process); }
            return sb.ToString();
        }

        /// <summary>
        /// Check if two <see cref="AccountSasPermissions"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is AccountSasPermissions other &&
            Equals(other);

        /// <summary>
        /// Get a hash code for the <see cref="AccountSasPermissions"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="AccountSasPermissions"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (Add ? 0b00000001 : 0) +
            (Delete ? 0b00000010 : 0) +
            (List ? 0b00000100 : 0) +
            (Process ? 0b00001000 : 0) +
            (Read ? 0b00010000 : 0) +
            (Update ? 0b00100000 : 0) +
            (Write ? 0b01000000 : 0) +
            (Create ? 0b1000000 : 0);

        /// <summary>
        /// Check if two <see cref="AccountSasPermissions"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(AccountSasPermissions other) =>
            other.Add == Add &&
            other.Delete == Delete &&
            other.List == List &&
            other.Process == Process &&
            other.Read == Read &&
            other.Update == Update &&
            other.Write == Write &&
            other.Create == Create;

        /// <summary>
        /// Check if two <see cref="AccountSasPermissions"/> instances are
        /// equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(AccountSasPermissions left, AccountSasPermissions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two <see cref="AccountSasPermissions"/> instances are not
        /// equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(AccountSasPermissions left, AccountSasPermissions right) =>
            !(left == right);

        /// <summary>
        /// Parse a string representing which permissions are granted by a
        /// shared access signature.
        /// </summary>
        /// <param name="s">
        /// A string representing which permissions are granted.
        /// </param>
        /// <returns>
        /// An <see cref="AccountSasPermissions"/> instance.
        /// </returns>
        public static AccountSasPermissions Parse(string s)
        {
            var p = new AccountSasPermissions(); // Clear out the flags
            foreach (var ch in s)
            {
                switch (ch)
                {
                    case Constants.Sas.Permissions.Read: p.Read = true; break;
                    case Constants.Sas.Permissions.Write: p.Write = true; break;
                    case Constants.Sas.Permissions.Delete: p.Delete = true; break;
                    case Constants.Sas.Permissions.List: p.List = true; break;
                    case Constants.Sas.Permissions.Add: p.Add = true; break;
                    case Constants.Sas.Permissions.Create: p.Create = true; break;
                    case Constants.Sas.Permissions.Update: p.Update = true; break;
                    case Constants.Sas.Permissions.Process: p.Process = true; break;
                    default: throw Errors.InvalidPermission(ch);
                }
            }
            return p;
        }
    }
}
