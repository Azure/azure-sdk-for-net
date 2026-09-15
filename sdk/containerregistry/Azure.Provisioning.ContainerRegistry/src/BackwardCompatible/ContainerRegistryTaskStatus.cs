// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The current status of task.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskStatus from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistryTaskStatus
{
    /// <summary>
    /// Disabled.
    /// </summary>
    Disabled,

    /// <summary>
    /// Enabled.
    /// </summary>
    Enabled,
}

#pragma warning restore CS0618
