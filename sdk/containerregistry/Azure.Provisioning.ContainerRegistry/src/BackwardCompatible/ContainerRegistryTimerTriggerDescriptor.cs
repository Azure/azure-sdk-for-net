// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The ContainerRegistryTimerTriggerDescriptor.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTimerTriggerDescriptor from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistryTimerTriggerDescriptor : ProvisionableConstruct
{
    /// <summary>
    /// The timer trigger name that caused the run.
    /// </summary>
    public BicepValue<string> TimerTriggerName
    {
        get { Initialize(); return _timerTriggerName!; }
        set { Initialize(); _timerTriggerName!.Assign(value); }
    }
    private BicepValue<string>? _timerTriggerName;

    /// <summary>
    /// The occurrence that triggered the run.
    /// </summary>
    public BicepValue<string> ScheduleOccurrence
    {
        get { Initialize(); return _scheduleOccurrence!; }
        set { Initialize(); _scheduleOccurrence!.Assign(value); }
    }
    private BicepValue<string>? _scheduleOccurrence;

    /// <summary>
    /// Creates a new ContainerRegistryTimerTriggerDescriptor.
    /// </summary>
    public ContainerRegistryTimerTriggerDescriptor()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistryTimerTriggerDescriptor.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _timerTriggerName = DefineProperty<string>("TimerTriggerName", ["timerTriggerName"]);
        _scheduleOccurrence = DefineProperty<string>("ScheduleOccurrence", ["scheduleOccurrence"]);
    }
}

#pragma warning restore CS0618
