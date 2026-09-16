// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// Type of Payload body for Base image update triggers.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskUpdateTriggerPayloadType from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistryUpdateTriggerPayloadType
{
    /// <summary>
    /// Default.
    /// </summary>
    Default,

    /// <summary>
    /// Token.
    /// </summary>
    Token,
}

#pragma warning restore CS0618
