// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The OS architecture.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskArchitecture from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistryOSArchitecture
{
    /// <summary>
    /// amd64.
    /// </summary>
    [DataMember(Name = "amd64")]
    Amd64,

    /// <summary>
    /// x86.
    /// </summary>
    [DataMember(Name = "x86")]
    X86,

    /// <summary>
    /// 386.
    /// </summary>
    [DataMember(Name = "386")]
    ThreeHundredEightySix,

    /// <summary>
    /// arm.
    /// </summary>
    [DataMember(Name = "arm")]
    Arm,

    /// <summary>
    /// arm64.
    /// </summary>
    [DataMember(Name = "arm64")]
    Arm64,
}

#pragma warning restore CS0618
