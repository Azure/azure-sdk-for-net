// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// The QueueServiceSasPermissions type simplifies creating the permissions string for a queue's access policy.
    /// Initialize an instance of this type and then call its ToString method to set AccessPolicy's Permission field.
    /// </summary>
    public struct QueueServiceSasPermissions : IEquatable<QueueServiceSasPermissions>
    {
        public bool Read { get; set; }
        public bool Add { get; set; }
        public bool Update { get; set; }
        public bool ProcessMessages { get; set; }

        /// <summary>
        /// ToString produces the access policy permission string for an Azure Storage queue.
        /// Call this method to set AccessPolicy's Permission field.
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

            if (this.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }

            if (this.Update)
            {
                sb.Append(Constants.Sas.Permissions.Update);
            }

            if (this.ProcessMessages)
            {
                sb.Append(Constants.Sas.Permissions.Process);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Parse initializes the QueueServiceSasPermissions's fields from a string.
        /// </summary>
        /// <param name="s">
        /// string to parse
        /// </param>
        /// <returns>
        /// <see cref="QueueServiceSasPermissions"/>
        /// </returns>
        public static QueueServiceSasPermissions Parse(string s)
        {
            // Clear the flags
            var p = new QueueServiceSasPermissions(); 
            foreach (var c in s)
            {
                switch (c)
                {
                    case Constants.Sas.Permissions.Read: p.Read = true; break;
                    case Constants.Sas.Permissions.Add: p.Add = true; break;
                    case Constants.Sas.Permissions.Update: p.Update = true; break;
                    case Constants.Sas.Permissions.Process: p.ProcessMessages = true; break;
                    default:
                        throw new ArgumentException("invalid permission: " + c);
                }
            }
            return p;
        }

        /// <summary>
        /// Check if two QueueServiceSasPermissions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is QueueServiceSasPermissions other
            && this.Equals(other)
            ;

        /// <summary>
        /// Get a hash code for the QueueServiceSasPermissions.
        /// </summary>
        /// <returns>Hash code for the QueueServiceSasPermissions.</returns>
        public override int GetHashCode()
            => (this.Add ? 0b0001 : 0)
             + (this.ProcessMessages ? 0b0010 : 0)
             + (this.Read ? 0b0100 : 0)
             + (this.Update ? 0b1000 : 0)
            ;

        /// <summary>
        /// Check if two QueueServiceSasPermissions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(QueueServiceSasPermissions other)
            => other.Add == this.Add
                && other.ProcessMessages == this.ProcessMessages
                && other.Read == this.Read
                && other.Update == this.Update
                ;

        /// <summary>
        /// Check if two QueueServiceSasPermissions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(QueueServiceSasPermissions left, QueueServiceSasPermissions right) => left.Equals(right);

        /// <summary>
        /// Check if two QueueServiceSasPermissions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(QueueServiceSasPermissions left, QueueServiceSasPermissions right) => !(left == right);
    }
}
