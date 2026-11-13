// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// Describes the properties of a secret object value.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSecretObject from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistrySecretObject : ProvisionableConstruct
{
    /// <summary>
    /// The value of the secret. The format of this value will be determined
    /// based on the type of the secret object. If the type is
    /// Opaque, the value will be             used as is without any
    /// modification.
    /// </summary>
    public BicepValue<string> Value
    {
        get { Initialize(); return _value!; }
        set { Initialize(); _value!.Assign(value); }
    }
    private BicepValue<string>? _value;

    /// <summary>
    /// The type of the secret object which determines how the value of the
    /// secret object has to be             interpreted.
    /// </summary>
    public BicepValue<ContainerRegistrySecretObjectType> ObjectType
    {
        get { Initialize(); return _objectType!; }
        set { Initialize(); _objectType!.Assign(value); }
    }
    private BicepValue<ContainerRegistrySecretObjectType>? _objectType;

    /// <summary>
    /// Creates a new ContainerRegistrySecretObject.
    /// </summary>
    public ContainerRegistrySecretObject()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistrySecretObject.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _value = DefineProperty<string>("Value", ["value"]);
        _objectType = DefineProperty<ContainerRegistrySecretObjectType>("ObjectType", ["type"]);
    }
}

#pragma warning restore CS0618
