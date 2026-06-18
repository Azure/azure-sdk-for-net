// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec renamed or removed this extensible-enum type from the generated surface; keep the previous GA enum wrapper so existing signatures and constants remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterCloudPermission structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SecurityCenterCloudPermission : IEquatable<SecurityCenterCloudPermission>
    {
        private readonly string _value;
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityCenterCloudPermission"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public SecurityCenterCloudPermission(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary>
        /// Gets the AwsAmazonSsmAutomationRole value preserved from the previous public API surface.
        /// </summary>
        public static SecurityCenterCloudPermission AwsAmazonSsmAutomationRole { get; } = new SecurityCenterCloudPermission("AwsAmazonSsmAutomationRole");
        /// <summary>
        /// Gets the AwsAwsSecurityHubReadOnlyAccess value preserved from the previous public API surface.
        /// </summary>
        public static SecurityCenterCloudPermission AwsAwsSecurityHubReadOnlyAccess { get; } = new SecurityCenterCloudPermission("AwsAwsSecurityHubReadOnlyAccess");
        /// <summary>
        /// Gets the AwsSecurityAudit value preserved from the previous public API surface.
        /// </summary>
        public static SecurityCenterCloudPermission AwsSecurityAudit { get; } = new SecurityCenterCloudPermission("AwsSecurityAudit");
        /// <summary>
        /// Gets the GcpSecurityCenterAdminViewer value preserved from the previous public API surface.
        /// </summary>
        public static SecurityCenterCloudPermission GcpSecurityCenterAdminViewer { get; } = new SecurityCenterCloudPermission("GcpSecurityCenterAdminViewer");
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(SecurityCenterCloudPermission other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) => obj is SecurityCenterCloudPermission other && Equals(other);
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
        public static bool operator ==(SecurityCenterCloudPermission left, SecurityCenterCloudPermission right) => left.Equals(right);
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator SecurityCenterCloudPermission(string value) => new SecurityCenterCloudPermission(value);
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(SecurityCenterCloudPermission left, SecurityCenterCloudPermission right) => !left.Equals(right);
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() => _value ?? string.Empty;
    }
}
