// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec renamed or removed this extensible-enum type from the generated surface; keep the previous GA enum wrapper so existing signatures and constants remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the SecurityAlertMinimalSeverity structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SecurityAlertMinimalSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityAlertMinimalSeverity"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public SecurityAlertMinimalSeverity(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Gets the High value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity High { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the Low value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity Low { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the Medium value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity Medium { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetHashCode operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
