// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// Properties for a registry image.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskImageDescriptor from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistryImageDescriptor : ProvisionableConstruct
{
    /// <summary>
    /// The registry login server.
    /// </summary>
    public BicepValue<string> Registry
    {
        get { Initialize(); return _registry!; }
        set { Initialize(); _registry!.Assign(value); }
    }
    private BicepValue<string>? _registry;

    /// <summary>
    /// The repository name.
    /// </summary>
    public BicepValue<string> Repository
    {
        get { Initialize(); return _repository!; }
        set { Initialize(); _repository!.Assign(value); }
    }
    private BicepValue<string>? _repository;

    /// <summary>
    /// The tag name.
    /// </summary>
    public BicepValue<string> Tag
    {
        get { Initialize(); return _tag!; }
        set { Initialize(); _tag!.Assign(value); }
    }
    private BicepValue<string>? _tag;

    /// <summary>
    /// The sha256-based digest of the image manifest.
    /// </summary>
    public BicepValue<string> Digest
    {
        get { Initialize(); return _digest!; }
        set { Initialize(); _digest!.Assign(value); }
    }
    private BicepValue<string>? _digest;

    /// <summary>
    /// Creates a new ContainerRegistryImageDescriptor.
    /// </summary>
    public ContainerRegistryImageDescriptor()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistryImageDescriptor.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _registry = DefineProperty<string>("Registry", ["registry"]);
        _repository = DefineProperty<string>("Repository", ["repository"]);
        _tag = DefineProperty<string>("Tag", ["tag"]);
        _digest = DefineProperty<string>("Digest", ["digest"]);
    }
}

#pragma warning restore CS0618
