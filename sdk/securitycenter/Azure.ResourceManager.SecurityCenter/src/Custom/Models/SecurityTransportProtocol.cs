// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec renamed or removed this extensible-enum type from the generated surface; keep the previous GA enum wrapper so existing signatures and constants remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the SecurityTransportProtocol structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SecurityTransportProtocol : IEquatable<SecurityTransportProtocol>
    {
        private readonly string _value;
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityTransportProtocol"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public SecurityTransportProtocol(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary>
        /// Gets the Tcp value preserved from the previous public API surface.
        /// </summary>
        public static SecurityTransportProtocol Tcp { get; } = new SecurityTransportProtocol("Tcp");
        /// <summary>
        /// Gets the Udp value preserved from the previous public API surface.
        /// </summary>
        public static SecurityTransportProtocol Udp { get; } = new SecurityTransportProtocol("Udp");
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(SecurityTransportProtocol other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) => obj is SecurityTransportProtocol other && Equals(other);
        /// <summary>
        /// Provides a compatibility shim for the GetHashCode operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator ==(SecurityTransportProtocol left, SecurityTransportProtocol right) => left.Equals(right);
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator SecurityTransportProtocol(string value) => new SecurityTransportProtocol(value);
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(SecurityTransportProtocol left, SecurityTransportProtocol right) => !left.Equals(right);
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() => _value ?? string.Empty;
    }
}
