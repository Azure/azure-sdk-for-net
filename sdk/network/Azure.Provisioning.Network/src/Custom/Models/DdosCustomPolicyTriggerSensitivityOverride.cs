// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

/// <summary> The legacy customized DDoS protection trigger rate sensitivity. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and is no longer used.")]
public enum DdosCustomPolicyTriggerSensitivityOverride
{
    /// <summary> Relaxed. </summary>
    Relaxed,

    /// <summary> Low. </summary>
    Low,

    /// <summary> Default. </summary>
    Default,

    /// <summary> High. </summary>
    High,
}
