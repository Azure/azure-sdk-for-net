// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The properties of a trigger.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTriggerProperties from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistryTriggerProperties : ProvisionableConstruct
{
    /// <summary>
    /// The collection of timer triggers.
    /// </summary>
    public BicepList<ContainerRegistryTimerTrigger> TimerTriggers
    {
        get { Initialize(); return _timerTriggers!; }
        set { Initialize(); _timerTriggers!.Assign(value); }
    }
    private BicepList<ContainerRegistryTimerTrigger>? _timerTriggers;

    /// <summary>
    /// The collection of triggers based on source code repository.
    /// </summary>
    public BicepList<ContainerRegistrySourceTrigger> SourceTriggers
    {
        get { Initialize(); return _sourceTriggers!; }
        set { Initialize(); _sourceTriggers!.Assign(value); }
    }
    private BicepList<ContainerRegistrySourceTrigger>? _sourceTriggers;

    /// <summary>
    /// The trigger based on base image dependencies.
    /// </summary>
    public ContainerRegistryBaseImageTrigger BaseImageTrigger
    {
        get { Initialize(); return _baseImageTrigger!; }
        set { Initialize(); AssignOrReplace(ref _baseImageTrigger, value); }
    }
    private ContainerRegistryBaseImageTrigger? _baseImageTrigger;

    /// <summary>
    /// Creates a new ContainerRegistryTriggerProperties.
    /// </summary>
    public ContainerRegistryTriggerProperties()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistryTriggerProperties.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _timerTriggers = DefineListProperty<ContainerRegistryTimerTrigger>("TimerTriggers", ["timerTriggers"]);
        _sourceTriggers = DefineListProperty<ContainerRegistrySourceTrigger>("SourceTriggers", ["sourceTriggers"]);
        _baseImageTrigger = DefineModelProperty<ContainerRegistryBaseImageTrigger>("BaseImageTrigger", ["baseImageTrigger"]);
    }
}

#pragma warning restore CS0618
