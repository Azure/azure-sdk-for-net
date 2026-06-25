// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveApplicationControlIssueSummary class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class AdaptiveApplicationControlIssueSummary
    {
        internal AdaptiveApplicationControlIssueSummary() { }
        /// <summary>
        /// Gets the Issue value preserved from the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlIssue? Issue { get; }
        /// <summary>
        /// Gets the NumberOfVms value preserved from the previous public API surface.
        /// </summary>
        public float? NumberOfVms { get; }
    }
}
