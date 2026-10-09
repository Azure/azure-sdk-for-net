// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The OS of agent machine.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskOS from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistryOS
{
    /// <summary>
    /// Windows.
    /// </summary>
    Windows,

    /// <summary>
    /// Linux.
    /// </summary>
    Linux,
}

#pragma warning restore CS0618
