// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Specifies the services accessible from an account level shared access
    /// signature.  Use <see cref="ToString"/> to produce a value that can be
    /// used for <see cref="AccountSasBuilder.Services"/>.
    /// </summary>
    public struct AccountSasServices : IEquatable<AccountSasServices>
    {
        /// <summary>
        /// Gets a value indicating whether Azure Blob Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        public bool Blobs { get; set; }

        /// <summary>
        /// Gets a value indicating whether Azure Queue Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        public bool Queues { get; set; }

        /// <summary>
        /// Gets a value indicating whether Azure File Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        public bool Files { get; set; }

        /// <summary>
        /// Creates a string representing which services can be used for
        /// <see cref="AccountSasBuilder.Services"/>.
        /// </summary>
        /// <returns>
        /// A string representing which services are allowed.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Blobs) { sb.Append(Constants.Sas.AccountServices.Blob); }
            if (this.Queues) { sb.Append(Constants.Sas.AccountServices.Queue); }
            if (this.Files) { sb.Append(Constants.Sas.AccountServices.File); }
            return sb.ToString();
        }

        /// <summary>
        /// Check if two <see cref="AccountSasServices"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is AccountSasServices other &&
            this.Equals(other);

        /// <summary>
        /// Get a hash code for the <see cref="AccountSasServices"/>.
        /// </summary>
        /// <returns>
        /// Hash code for the <see cref="AccountSasServices"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (this.Blobs  ? 0b001 : 0) +
            (this.Queues ? 0b010 : 0) +
            (this.Files  ? 0b100 : 0);

        /// <summary>
        /// Check if two <see cref="AccountSasServices"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(AccountSasServices other) =>
            other.Blobs == this.Blobs &&
            other.Queues == this.Queues &&
            other.Files == this.Files;

        /// <summary>
        /// Check if two <see cref="AccountSasServices"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(AccountSasServices left, AccountSasServices right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two <see cref="AccountSasServices"/> instances are not
        /// equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(AccountSasServices left, AccountSasServices right) =>
            !(left == right);

        /// <summary>
        /// Parse a string representing which services are accessible from a
        /// shared access signature.
        /// </summary>
        /// <param name="s">
        /// A string representing which services are accessible.
        /// </param>
        /// <returns>
        /// An <see cref="AccountSasServices"/> instance.
        /// </returns>
        public static AccountSasServices Parse(string s)
        {
            var svcs = new AccountSasServices();
            foreach (var ch in s)
            {
                switch (ch)
                {
                    case Constants.Sas.AccountServices.Blob: svcs.Blobs = true; break;
                    case Constants.Sas.AccountServices.Queue: svcs.Queues = true; break;
                    case Constants.Sas.AccountServices.File: svcs.Files = true; break;
                    default: throw Errors.InvalidService(ch);
                }
            }
            return svcs;
        }
    }
}
