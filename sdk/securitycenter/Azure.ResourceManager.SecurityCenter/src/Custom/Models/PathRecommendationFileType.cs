// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits extensible-enum CLR types that are still referenced by the current TypeSpec model graph; this previous GA enum name is no longer generated, but existing public signatures still reference it. Keep the enum wrapper so constants, conversions, and equality remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the PathRecommendationFileType structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public readonly partial struct PathRecommendationFileType : IEquatable<PathRecommendationFileType>
    {
        private readonly string _value;
        /// <summary>
        /// Initializes a new instance of the <see cref="PathRecommendationFileType"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public PathRecommendationFileType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary>
        /// Gets the Dll value preserved from the previous public API surface.
        /// </summary>
        public static PathRecommendationFileType Dll { get; } = new PathRecommendationFileType("Dll");
        /// <summary>
        /// Gets the Exe value preserved from the previous public API surface.
        /// </summary>
        public static PathRecommendationFileType Exe { get; } = new PathRecommendationFileType("Exe");
        /// <summary>
        /// Gets the Executable value preserved from the previous public API surface.
        /// </summary>
        public static PathRecommendationFileType Executable { get; } = new PathRecommendationFileType("Executable");
        /// <summary>
        /// Gets the Msi value preserved from the previous public API surface.
        /// </summary>
        public static PathRecommendationFileType Msi { get; } = new PathRecommendationFileType("Msi");
        /// <summary>
        /// Gets the Script value preserved from the previous public API surface.
        /// </summary>
        public static PathRecommendationFileType Script { get; } = new PathRecommendationFileType("Script");
        /// <summary>
        /// Gets the Unknown value preserved from the previous public API surface.
        /// </summary>
        public static PathRecommendationFileType Unknown { get; } = new PathRecommendationFileType("Unknown");
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(PathRecommendationFileType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) => obj is PathRecommendationFileType other && Equals(other);
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
        public static bool operator ==(PathRecommendationFileType left, PathRecommendationFileType right) => left.Equals(right);
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator PathRecommendationFileType(string value) => new PathRecommendationFileType(value);
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(PathRecommendationFileType left, PathRecommendationFileType right) => !left.Equals(right);
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() => _value ?? string.Empty;
    }
}
