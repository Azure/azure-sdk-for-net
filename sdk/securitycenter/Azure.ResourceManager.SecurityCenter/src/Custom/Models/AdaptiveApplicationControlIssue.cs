// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec renamed or removed this extensible-enum type from the generated surface; keep the previous GA enum wrapper so existing signatures and constants remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveApplicationControlIssue structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct AdaptiveApplicationControlIssue : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveApplicationControlIssue"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public AdaptiveApplicationControlIssue(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Gets the ExecutableViolationsAudited value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue ExecutableViolationsAudited { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the MsiAndScriptViolationsAudited value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue MsiAndScriptViolationsAudited { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the MsiAndScriptViolationsBlocked value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue MsiAndScriptViolationsBlocked { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the RulesViolatedManually value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue RulesViolatedManually { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the ViolationsAudited value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue ViolationsAudited { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the ViolationsBlocked value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue ViolationsBlocked { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
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
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
