// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// Variant of the CPU.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskVariant from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistryCpuVariant
{
    /// <summary>
    /// v6.
    /// </summary>
    [DataMember(Name = "v6")]
    V6,

    /// <summary>
    /// v7.
    /// </summary>
    [DataMember(Name = "v7")]
    V7,

    /// <summary>
    /// v8.
    /// </summary>
    [DataMember(Name = "v8")]
    V8,
}

#pragma warning restore CS0618
