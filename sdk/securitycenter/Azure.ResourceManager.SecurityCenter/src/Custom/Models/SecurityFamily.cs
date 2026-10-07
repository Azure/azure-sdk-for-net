// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityFamily structure.
    /// </summary>
    public readonly partial struct SecurityFamily
    {
        /// <summary>
        /// Gets the VulnerabilityAssessment value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityFamily VulnerabilityAssessment { get; }
    }
}
