// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.CognitiveServices;

// TypeSpec still defines this enum for the operation-only AccountModel model graph, which the
// provisioning emitter excludes. Keep the members shipped in 1.2.0 because
// CognitiveServicesAccountModel.LifecycleStatus exposed this enum in the public API.
/// <summary>
/// Model lifecycle status.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsolete and will be removed in a future release.")]
public enum ModelLifecycleStatus
{
    /// <summary>
    /// GenerallyAvailable.
    /// </summary>
    GenerallyAvailable,

    /// <summary>
    /// Preview.
    /// </summary>
    Preview,

    /// <summary>
    /// Stable.
    /// </summary>
    Stable,

    /// <summary>
    /// Deprecating.
    /// </summary>
    Deprecating,

    /// <summary>
    /// Deprecated.
    /// </summary>
    Deprecated,
}
