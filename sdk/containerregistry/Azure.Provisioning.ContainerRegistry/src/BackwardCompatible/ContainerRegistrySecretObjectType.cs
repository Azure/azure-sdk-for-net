// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The type of the secret object which determines how the value of the secret
/// object has to be             interpreted.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSecretObjectType from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum ContainerRegistrySecretObjectType
{
    /// <summary>
    /// Opaque.
    /// </summary>
    Opaque,

    /// <summary>
    /// Vaultsecret.
    /// </summary>
    [DataMember(Name = "Vaultsecret")]
    VaultSecret,
}

#pragma warning restore CS0618
