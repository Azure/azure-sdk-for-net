// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.ComponentModel;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Defines the protocols permitted for Storage requests made with a shared
    /// access signature.
    /// </summary>
    public readonly struct SasProtocol : IEquatable<SasProtocol>
    {
        private const string NoneName = null;
        private const string HttpsName = "https";
        private const string HttpsAndHttpName = "https,http";

        /// <summary>
        /// No protocol has been specified.
        /// </summary>
        public static SasProtocol None => new SasProtocol(NoneName);

        /// <summary>
        /// Only requests issued over HTTPS will be permitted.
        /// </summary>
        public static SasProtocol Https => new SasProtocol(HttpsName);

        /// <summary>
        /// Only requests issued over HTTPS or HTTP will be permitted.  This is
        /// the default value.
        /// </summary>
        public static SasProtocol HttpsAndHttp => new SasProtocol(HttpsAndHttpName);

        /// <summary>
        /// Gets the name of the protocol.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="SasProtocol"/> type.
        /// </summary>
        /// <param name="name">A string representation of the protocol.</param>
        SasProtocol(string name) =>
            this.Value = name;

        /// <summary>
        /// Gets a string representation of the protocol.
        /// </summary>
        /// <returns>A string representation of the protocol.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() =>
            this.Value ?? "";

        /// <summary>
        /// Check if two <see cref="SasProtocol"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(SasProtocol o1, SasProtocol o2) =>
            o1.Value == o2.Value;

        /// <summary>
        /// Check if two <see cref="SasProtocol"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(SasProtocol o1, SasProtocol o2) =>
            o1.Value != o2.Value;

        /// <summary>
        /// Get a hash code for the <see cref="SasProtocol"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="SasProtocol"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            this.Value?.GetHashCode() ?? 0;

        /// <summary>
        /// Check if two <see cref="SasProtocol"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SasProtocol other && this.Equals(other);

        /// <summary>
        /// Check if two <see cref="SasProtocol"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(SasProtocol other)
            => this.Value == other.Value;

        /// <summary>
        /// Parse a string representation of a protocol.
        /// </summary>
        /// <param name="s">A string representation of a protocol.</param>
        /// <returns>A <see cref="SasProtocol"/>.</returns>
        public static SasProtocol Parse(string s)
        {
            switch (s)
            {
                case null:
                case "":
                    return None;
                case HttpsName:
                    return Https;
                case HttpsAndHttpName:
                    return HttpsAndHttp;
                default:
                    throw new ArgumentOutOfRangeException(nameof(s), $"Invalid {nameof(SasProtocol)} value");
            }
        }
    }
}
