// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The image update trigger that caused a build.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskImageUpdateTrigger from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistryImageUpdateTrigger : ProvisionableConstruct
{
    /// <summary>
    /// The unique ID of the trigger.
    /// </summary>
    public BicepValue<Guid> Id
    {
        get { Initialize(); return _id!; }
        set { Initialize(); _id!.Assign(value); }
    }
    private BicepValue<Guid>? _id;

    /// <summary>
    /// The timestamp when the image update happened.
    /// </summary>
    public BicepValue<DateTimeOffset> Timestamp
    {
        get { Initialize(); return _timestamp!; }
        set { Initialize(); _timestamp!.Assign(value); }
    }
    private BicepValue<DateTimeOffset>? _timestamp;

    /// <summary>
    /// The list of image updates that caused the build.
    /// </summary>
    public BicepList<ContainerRegistryImageDescriptor> Images
    {
        get { Initialize(); return _images!; }
        set { Initialize(); _images!.Assign(value); }
    }
    private BicepList<ContainerRegistryImageDescriptor>? _images;

    /// <summary>
    /// Creates a new ContainerRegistryImageUpdateTrigger.
    /// </summary>
    public ContainerRegistryImageUpdateTrigger()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistryImageUpdateTrigger.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _id = DefineProperty<Guid>("Id", ["id"]);
        _timestamp = DefineProperty<DateTimeOffset>("Timestamp", ["timestamp"]);
        _images = DefineListProperty<ContainerRegistryImageDescriptor>("Images", ["images"]);
    }
}

#pragma warning restore CS0618
