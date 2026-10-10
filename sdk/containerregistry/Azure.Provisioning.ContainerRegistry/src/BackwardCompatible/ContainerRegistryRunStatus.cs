// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The current status of the run.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskRunStatus from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistryRunStatus
{
    /// <summary>
    /// Queued.
    /// </summary>
    Queued,

    /// <summary>
    /// Started.
    /// </summary>
    Started,

    /// <summary>
    /// Running.
    /// </summary>
    Running,

    /// <summary>
    /// Succeeded.
    /// </summary>
    Succeeded,

    /// <summary>
    /// Failed.
    /// </summary>
    Failed,

    /// <summary>
    /// Canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// Error.
    /// </summary>
    Error,

    /// <summary>
    /// Timeout.
    /// </summary>
    Timeout,
}

#pragma warning restore CS0618
