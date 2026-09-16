// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The type of the base image dependency.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskBaseImageDependencyType from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistryBaseImageDependencyType
{
    /// <summary>
    /// BuildTime.
    /// </summary>
    BuildTime,

    /// <summary>
    /// RunTime.
    /// </summary>
    RunTime,
}

#pragma warning restore CS0618
