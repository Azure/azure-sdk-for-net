// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The ContainerRegistrySourceTriggerEvent.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceTriggerEvent from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistrySourceTriggerEvent
{
    /// <summary>
    /// commit.
    /// </summary>
    [DataMember(Name = "commit")]
    Commit,

    /// <summary>
    /// pullrequest.
    /// </summary>
    [DataMember(Name = "pullrequest")]
    PullRequest,
}

#pragma warning restore CS0618
