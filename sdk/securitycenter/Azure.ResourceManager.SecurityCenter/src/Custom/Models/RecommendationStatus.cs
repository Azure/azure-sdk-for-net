// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec renamed or removed this extensible-enum type from the generated surface; keep the previous GA enum wrapper so existing signatures and constants remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the RecommendationStatus structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct RecommendationStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendationStatus"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public RecommendationStatus(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Gets the NoStatus value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus NoStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the NotAvailable value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus NotAvailable { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the NotRecommended value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus NotRecommended { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the Recommended value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus Recommended { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
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
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus left, Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus left, Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
