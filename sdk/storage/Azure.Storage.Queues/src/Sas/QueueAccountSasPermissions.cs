// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="QueueAccountSasPermissions"/> supports reading and writing
    /// permissions string for a queue account's access policy.  Use
    /// <see cref="ToString"/> to generate a permissions string you can provide
    /// to <see cref="QueueSasBuilder.Permissions"/>.
    /// </summary>
    public struct QueueAccountSasPermissions : IEquatable<QueueAccountSasPermissions>
    {
        /// <summary>
        /// Get or sets whether Read is permitted.
        /// </summary>
        public bool Read { get; set; }

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
        /// Get or sets whether Add is permitted.
        /// </summary>
        public bool Add { get; set; }

        /// <summary>
        /// Get or sets whether Update is permitted.
        /// </summary>
        public bool Update { get; set; }

        /// <summary>
        /// Get or sets whether Process is permitted.
        /// </summary>
        public bool Process { get; set; }

        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="QueueSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Read) { sb.Append(Constants.Sas.Permissions.Read); }
            if (Write) { sb.Append(Constants.Sas.Permissions.Write); }
            if (Delete) { sb.Append(Constants.Sas.Permissions.Delete); }
            if (List) { sb.Append(Constants.Sas.Permissions.List); }
            if (Add) { sb.Append(Constants.Sas.Permissions.Add); }
            if (Update) { sb.Append(Constants.Sas.Permissions.Update); }
            if (Process) { sb.Append(Constants.Sas.Permissions.Process); }
            return sb.ToString();
        }

        /// <summary>
        /// Parse a permissions string into a new
        /// <see cref="QueueAccountSasPermissions"/>.
        /// </summary>
        /// <param name="s">Permissions string to parse.</param>
        /// <returns>
        /// The parsed <see cref="QueueAccountSasPermissions"/>.
        /// </returns>
        public static QueueAccountSasPermissions Parse(string s)
        {
            var p = new QueueAccountSasPermissions(); // Clear the flags
            foreach (var c in s)
            {
                switch (c)
                {
                    case Constants.Sas.Permissions.Read:
                        p.Read = true;
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
                    case Constants.Sas.Permissions.Add:
                        p.Add = true;
                        break;
                    case Constants.Sas.Permissions.Update:
                        p.Update = true;
                        break;
                    case Constants.Sas.Permissions.Process:
                        p.Process = true;
                        break;
                    default:
                        throw Errors.InvalidPermission(c);
                }
            }
            return p;
        }

        /// <summary>
        /// Check if two QueueAccountSasPermissions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is QueueAccountSasPermissions other && Equals(other);

        /// <summary>
        /// Get a hash code for the QueueAccountSasPermissions.
        /// </summary>
        /// <returns>Hash code for the QueueAccountSasPermissions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (Add ? 0b0000001 : 0) +
            (Delete ? 0b0000010 : 0) +
            (List ? 0b0000100 : 0) +
            (Process ? 0b0001000 : 0) +
            (Read ? 0b0010000 : 0) +
            (Update ? 0b0100000 : 0) +
            (Write ? 0b1000000 : 0);

        /// <summary>
        /// Check if two QueueAccountSasPermissions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(QueueAccountSasPermissions other) =>
            other.Add == Add &&
            other.Delete == Delete &&
            other.List == List &&
            other.Process == Process &&
            other.Read == Read &&
            other.Update == Update &&
            other.Write == Write;

        /// <summary>
        /// Check if two QueueAccountSasPermissions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(QueueAccountSasPermissions left, QueueAccountSasPermissions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two QueueAccountSasPermissions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(QueueAccountSasPermissions left, QueueAccountSasPermissions right) =>
            !(left == right);
    }
}
