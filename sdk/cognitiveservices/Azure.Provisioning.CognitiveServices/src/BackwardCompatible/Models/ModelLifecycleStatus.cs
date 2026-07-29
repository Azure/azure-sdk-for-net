// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.CognitiveServices;

/// <summary>
/// Model lifecycle status.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
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
