// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Specifies the resource types accessible from an account level shared
    /// access signature.  Use <see cref="ToString"/> to produce a value that
    /// can be used for <see cref="AccountSasBuilder.ResourceTypes"/>.
    /// </summary>
    public struct AccountSasResourceTypes : IEquatable<AccountSasResourceTypes>
    {
        /// <summary>
        /// Gets a value indicating whether service-level APIs are accessible
        /// from this shared access signature (e.g., Get/Set Service
        /// Properties, Get Service Stats, List Containers/Queues/Tables/
        /// Shares).
        /// </summary>
        public bool Service { get; set; }

        /// <summary>
        /// Gets a value indicating whether container-level APIs are accessible
        /// from this shared access signature (e.g., Create/Delete Container,
        /// Create/Delete Queue, Create/Delete Table, Create/Delete Share, List
        /// Blobs/Files and Directories).
        /// </summary>
        public bool Container { get; set; }

#pragma warning disable CA1720 // Identifier contains type name
        /// <summary>
        /// Gets a value indicating whether object-level APIs for blobs, queue
        /// messages, and files are accessible from this shared access
        /// signature (e.g. Put Blob, Query Entity, Get Messages, Create File,
        /// etc.).
        /// </summary>
        public bool Object { get; set; }
#pragma warning restore CA1720 // Identifier contains type name

        /// <summary>
        /// Creates a string representing which resource types are allowed
        /// for <see cref="AccountSasBuilder.ResourceTypes"/>.
        /// </summary>
        /// <returns>
        /// A string representing which services are allowed.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Service) { sb.Append(Constants.Sas.AccountResources.Service); }
            if (Container) { sb.Append(Constants.Sas.AccountResources.Container); }
            if (Object) { sb.Append(Constants.Sas.AccountResources.Object); }
            return sb.ToString();
        }

        /// <summary>
        /// Check if two <see cref="AccountSasResourceTypes"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is AccountSasResourceTypes other &&
            Equals(other);

        /// <summary>
        /// Get a hash code for the <see cref="AccountSasResourceTypes"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="AccountSasResourceTypes"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (Service ? 0b001 : 0) +
            (Container ? 0b010 : 0) +
            (Object ? 0b100 : 0);

        /// <summary>
        /// Check if two <see cref="AccountSasResourceTypes"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(AccountSasResourceTypes other) =>
            other.Service == Service &&
            other.Container == Container &&
            other.Object == Object;

        /// <summary>
        /// Check if two <see cref="AccountSasResourceTypes"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(AccountSasResourceTypes left, AccountSasResourceTypes right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two <see cref="AccountSasResourceTypes"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(AccountSasResourceTypes left, AccountSasResourceTypes right) =>
            !(left == right);

        /// <summary>
        /// Parse a string representing which resource types are accessible
        /// from a shared access signature.
        /// </summary>
        /// <param name="s">
        /// A string representing which resource types are accessible.
        /// </param>
        /// <returns>
        /// An <see cref="AccountSasResourceTypes"/> instance.
        /// </returns>
        public static AccountSasResourceTypes Parse(string s)
        {
            var types = new AccountSasResourceTypes();
            foreach (var ch in s)
            {
                switch (ch)
                {
                    case Constants.Sas.AccountResources.Service:
                        types.Service = true;
                        break;
                    case Constants.Sas.AccountResources.Container:
                        types.Container = true;
                        break;
                    case Constants.Sas.AccountResources.Object:
                        types.Object = true;
                        break;
                    default:
                        throw Errors.InvalidResourceType(ch);
                }
            }
            return types;
        }
    }
}
