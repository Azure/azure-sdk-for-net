// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// The QueueAccountSasPermissions type simplifies creating the permissions string for an Azure Storage queue SAS.
    /// Initialize an instance of this type and then call its ToString method to set AccessPolicy's Permissions field.
    /// </summary>
    public struct QueueAccountSasPermissions : IEquatable<QueueAccountSasPermissions>
    {
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
        public bool List { get; set; }
        public bool Add { get; set; }
        public bool Update { get; set; }
        public bool Process { get; set; }

        /// <summary>
        /// String produces the SAS permissions string for an Azure Storage queue.
        /// Call this method to set AccessPolicy's Permissions field.
        /// </summary>
        /// <returns>
        /// string
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }

            if (this.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }

            if (this.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }

            if (this.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }

            if (this.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }

            if (this.Update)
            {
                sb.Append(Constants.Sas.Permissions.Update);
            }

            if (this.Process)
            {
                sb.Append(Constants.Sas.Permissions.Process);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Parse initializes the QueueAccountSasPermissions's fields from a string.
        /// </summary>
        /// <param name="s">
        /// String to parse.
        /// </param>
        /// <returns>
        /// <see cref="QueueAccountSasPermissions"/>
        /// </returns>
        public static QueueAccountSasPermissions Parse(string s)
        {
            var p = new QueueAccountSasPermissions(); // Clear the flags
            foreach (var c in s)
            {
                switch (c)
                {
                    case Constants.Sas.Permissions.Read: p.Read = true; break;
                    case Constants.Sas.Permissions.Write: p.Write = true; break;
                    case Constants.Sas.Permissions.Delete: p.Delete = true; break;
                    case Constants.Sas.Permissions.List: p.List = true; break;
                    case Constants.Sas.Permissions.Add: p.Add = true; break;
                    case Constants.Sas.Permissions.Update: p.Update = true; break;
                    case Constants.Sas.Permissions.Process: p.Process = true; break;
                    default: throw Errors.InvalidPermission(c);
                }
            }
            return p;
        }

        /// <summary>
        /// Check if two QueueAccountSasPermissions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is QueueAccountSasPermissions other
            && this.Equals(other)
            ;

        /// <summary>
        /// Get a hash code for the QueueAccountSasPermissions.
        /// </summary>
        /// <returns>Hash code for the QueueAccountSasPermissions.</returns>
        public override int GetHashCode()
            => (this.Add ? 0b0000001 : 0)
             + (this.Delete ? 0b0000010 : 0)
             + (this.List ? 0b0000100 : 0)
             + (this.Process ? 0b0001000 : 0)
             + (this.Read ? 0b0010000 : 0)
             + (this.Update ? 0b0100000 : 0)
             + (this.Write ? 0b1000000 : 0)
            ;

        /// <summary>
        /// Check if two QueueAccountSasPermissions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(QueueAccountSasPermissions other)
            => other.Add == this.Add
                && other.Delete == this.Delete
                && other.List == this.List
                && other.Process == this.Process
                && other.Read == this.Read
                && other.Update == this.Update
                && other.Write == this.Write
                ;

        /// <summary>
        /// Check if two QueueAccountSasPermissions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(QueueAccountSasPermissions left, QueueAccountSasPermissions right) => left.Equals(right);

        /// <summary>
        /// Check if two QueueAccountSasPermissions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(QueueAccountSasPermissions left, QueueAccountSasPermissions right) => !(left == right);
    }
}
