// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits extensible-enum CLR types that are still referenced by the current TypeSpec model graph; this previous GA enum name is no longer generated, but existing public signatures still reference it. Keep the enum wrapper so constants, conversions, and equality remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveApplicationControlGroupSourceSystem structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct AdaptiveApplicationControlGroupSourceSystem : IEquatable<AdaptiveApplicationControlGroupSourceSystem>
    {
        private readonly string _value;
        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveApplicationControlGroupSourceSystem"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public AdaptiveApplicationControlGroupSourceSystem(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary>
        /// Gets the AzureAppLocker value preserved from the previous public API surface.
        /// </summary>
        public static AdaptiveApplicationControlGroupSourceSystem AzureAppLocker { get; } = new AdaptiveApplicationControlGroupSourceSystem("AzureAppLocker");
        /// <summary>
        /// Gets the AzureAuditD value preserved from the previous public API surface.
        /// </summary>
        public static AdaptiveApplicationControlGroupSourceSystem AzureAuditD { get; } = new AdaptiveApplicationControlGroupSourceSystem("AzureAuditD");
        /// <summary>
        /// Gets the NonAzureAppLocker value preserved from the previous public API surface.
        /// </summary>
        public static AdaptiveApplicationControlGroupSourceSystem NonAzureAppLocker { get; } = new AdaptiveApplicationControlGroupSourceSystem("NonAzureAppLocker");
        /// <summary>
        /// Gets the NonAzureAuditD value preserved from the previous public API surface.
        /// </summary>
        public static AdaptiveApplicationControlGroupSourceSystem NonAzureAuditD { get; } = new AdaptiveApplicationControlGroupSourceSystem("NonAzureAuditD");
        /// <summary>
        /// Gets the None value preserved from the previous public API surface.
        /// </summary>
        public static AdaptiveApplicationControlGroupSourceSystem None { get; } = new AdaptiveApplicationControlGroupSourceSystem("None");
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(AdaptiveApplicationControlGroupSourceSystem other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) => obj is AdaptiveApplicationControlGroupSourceSystem other && Equals(other);
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
        public static bool operator ==(AdaptiveApplicationControlGroupSourceSystem left, AdaptiveApplicationControlGroupSourceSystem right) => left.Equals(right);
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator AdaptiveApplicationControlGroupSourceSystem(string value) => new AdaptiveApplicationControlGroupSourceSystem(value);
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(AdaptiveApplicationControlGroupSourceSystem left, AdaptiveApplicationControlGroupSourceSystem right) => !left.Equals(right);
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() => _value ?? string.Empty;
    }
}
