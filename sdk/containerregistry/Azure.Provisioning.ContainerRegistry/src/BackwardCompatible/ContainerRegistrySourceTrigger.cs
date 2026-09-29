// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The properties of a source based trigger.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceTrigger from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistrySourceTrigger : ProvisionableConstruct
{
    /// <summary>
    /// The properties that describes the source(code) for the task.
    /// </summary>
    public SourceCodeRepoProperties SourceRepository
    {
        get { Initialize(); return _sourceRepository!; }
        set { Initialize(); AssignOrReplace(ref _sourceRepository, value); }
    }
    private SourceCodeRepoProperties? _sourceRepository;

    /// <summary>
    /// The source event corresponding to the trigger.
    /// </summary>
    public BicepList<ContainerRegistrySourceTriggerEvent> SourceTriggerEvents
    {
        get { Initialize(); return _sourceTriggerEvents!; }
        set { Initialize(); _sourceTriggerEvents!.Assign(value); }
    }
    private BicepList<ContainerRegistrySourceTriggerEvent>? _sourceTriggerEvents;

    /// <summary>
    /// The current status of trigger.
    /// </summary>
    public BicepValue<ContainerRegistryTriggerStatus> Status
    {
        get { Initialize(); return _status!; }
        set { Initialize(); _status!.Assign(value); }
    }
    private BicepValue<ContainerRegistryTriggerStatus>? _status;

    /// <summary>
    /// The name of the trigger.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }
    private BicepValue<string>? _name;

    /// <summary>
    /// Creates a new ContainerRegistrySourceTrigger.
    /// </summary>
    public ContainerRegistrySourceTrigger()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistrySourceTrigger.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _sourceRepository = DefineModelProperty<SourceCodeRepoProperties>("SourceRepository", ["sourceRepository"]);
        _sourceTriggerEvents = DefineListProperty<ContainerRegistrySourceTriggerEvent>("SourceTriggerEvents", ["sourceTriggerEvents"]);
        _status = DefineProperty<ContainerRegistryTriggerStatus>("Status", ["status"]);
        _name = DefineProperty<string>("Name", ["name"]);
    }
}

#pragma warning restore CS0618
