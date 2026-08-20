// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The type of run.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskRunType from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistryRunType
{
    /// <summary>
    /// QuickBuild.
    /// </summary>
    QuickBuild,

    /// <summary>
    /// QuickRun.
    /// </summary>
    QuickRun,

    /// <summary>
    /// AutoBuild.
    /// </summary>
    AutoBuild,

    /// <summary>
    /// AutoRun.
    /// </summary>
    AutoRun,
}

#pragma warning restore CS0618
