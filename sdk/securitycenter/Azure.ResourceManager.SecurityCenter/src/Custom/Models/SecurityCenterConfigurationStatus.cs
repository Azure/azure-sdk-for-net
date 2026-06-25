// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits extensible-enum CLR types that are still referenced by the current TypeSpec model graph; this previous GA enum name is no longer generated, but existing public signatures still reference it. Keep the enum wrapper so constants, conversions, and equality remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterConfigurationStatus structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public readonly partial struct SecurityCenterConfigurationStatus : IEquatable<SecurityCenterConfigurationStatus>
    {
        private readonly string _value;
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityCenterConfigurationStatus"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public SecurityCenterConfigurationStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary>
        /// Gets the Configured value preserved from the previous public API surface.
        /// </summary>
        public static SecurityCenterConfigurationStatus Configured { get; } = new SecurityCenterConfigurationStatus("Configured");
        /// <summary>
        /// Gets the Failed value preserved from the previous public API surface.
        /// </summary>
        public static SecurityCenterConfigurationStatus Failed { get; } = new SecurityCenterConfigurationStatus("Failed");
        /// <summary>
        /// Gets the InProgress value preserved from the previous public API surface.
        /// </summary>
        public static SecurityCenterConfigurationStatus InProgress { get; } = new SecurityCenterConfigurationStatus("InProgress");
        /// <summary>
        /// Gets the NoStatus value preserved from the previous public API surface.
        /// </summary>
        public static SecurityCenterConfigurationStatus NoStatus { get; } = new SecurityCenterConfigurationStatus("NoStatus");
        /// <summary>
        /// Gets the NotConfigured value preserved from the previous public API surface.
        /// </summary>
        public static SecurityCenterConfigurationStatus NotConfigured { get; } = new SecurityCenterConfigurationStatus("NotConfigured");
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(SecurityCenterConfigurationStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) => obj is SecurityCenterConfigurationStatus other && Equals(other);
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
        public static bool operator ==(SecurityCenterConfigurationStatus left, SecurityCenterConfigurationStatus right) => left.Equals(right);
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator SecurityCenterConfigurationStatus(string value) => new SecurityCenterConfigurationStatus(value);
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(SecurityCenterConfigurationStatus left, SecurityCenterConfigurationStatus right) => !left.Equals(right);
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() => _value ?? string.Empty;
    }
}
