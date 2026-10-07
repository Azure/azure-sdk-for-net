// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The properties of a run argument.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskArgument from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistryRunArgument : ProvisionableConstruct
{
    /// <summary>
    /// The name of the argument.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }
    private BicepValue<string>? _name;

    /// <summary>
    /// The value of the argument.
    /// </summary>
    public BicepValue<string> Value
    {
        get { Initialize(); return _value!; }
        set { Initialize(); _value!.Assign(value); }
    }
    private BicepValue<string>? _value;

    /// <summary>
    /// Flag to indicate whether the argument represents a secret and want to
    /// be removed from build logs.
    /// </summary>
    public BicepValue<bool> IsSecret
    {
        get { Initialize(); return _isSecret!; }
        set { Initialize(); _isSecret!.Assign(value); }
    }
    private BicepValue<bool>? _isSecret;

    /// <summary>
    /// Creates a new ContainerRegistryRunArgument.
    /// </summary>
    public ContainerRegistryRunArgument()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of ContainerRegistryRunArgument.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"]);
        _value = DefineProperty<string>("Value", ["value"]);
        _isSecret = DefineProperty<bool>("IsSecret", ["isSecret"]);
    }
}

#pragma warning restore CS0618
