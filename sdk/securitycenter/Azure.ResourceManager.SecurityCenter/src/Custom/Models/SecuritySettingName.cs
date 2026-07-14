// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits extensible-enum CLR types that are still referenced by the current TypeSpec model graph; this previous GA enum name is no longer generated, but existing public signatures still reference it. Keep the enum wrapper so constants, conversions, and equality remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the SecuritySettingName structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SecuritySettingName : IEquatable<SecuritySettingName>
    {
        private readonly string _value;
        /// <summary>
        /// Initializes a new instance of the <see cref="SecuritySettingName"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public SecuritySettingName(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary>
        /// Gets the Mcas value preserved from the previous public API surface.
        /// </summary>
        public static SecuritySettingName Mcas { get; } = new SecuritySettingName("MCAS");
        /// <summary>
        /// Gets the Sentinel value preserved from the previous public API surface.
        /// </summary>
        public static SecuritySettingName Sentinel { get; } = new SecuritySettingName("Sentinel");
        /// <summary>
        /// Gets the Wdatp value preserved from the previous public API surface.
        /// </summary>
        public static SecuritySettingName Wdatp { get; } = new SecuritySettingName("WDATP");
        /// <summary>
        /// Gets the WdatpExcludeLinuxPublicPreview value preserved from the previous public API surface.
        /// </summary>
        public static SecuritySettingName WdatpExcludeLinuxPublicPreview { get; } = new SecuritySettingName("WDATP_EXCLUDE_LINUX_PUBLIC_PREVIEW");
        /// <summary>
        /// Gets the WdatpUnifiedSolution value preserved from the previous public API surface.
        /// </summary>
        public static SecuritySettingName WdatpUnifiedSolution { get; } = new SecuritySettingName("WDATP_UNIFIED_SOLUTION");
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(SecuritySettingName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) => obj is SecuritySettingName other && Equals(other);
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
        public static bool operator ==(SecuritySettingName left, SecuritySettingName right) => left.Equals(right);
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator SecuritySettingName(string value) => new SecuritySettingName(value);
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(SecuritySettingName left, SecuritySettingName right) => !left.Equals(right);
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() => _value ?? string.Empty;
    }
}
