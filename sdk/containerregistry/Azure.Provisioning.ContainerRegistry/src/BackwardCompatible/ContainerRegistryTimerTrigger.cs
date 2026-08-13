// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The properties of a timer trigger.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTimerTrigger from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistryTimerTrigger : ProvisionableConstruct
{
    /// <summary>
    /// The CRON expression for the task schedule.
    /// </summary>
    public BicepValue<string> Schedule
    {
        get { Initialize(); return _schedule!; }
        set { Initialize(); _schedule!.Assign(value); }
    }
    private BicepValue<string>? _schedule;

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
    /// Creates a new ContainerRegistryTimerTrigger.
    /// </summary>
    public ContainerRegistryTimerTrigger()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistryTimerTrigger.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _schedule = DefineProperty<string>("Schedule", ["schedule"]);
        _status = DefineProperty<ContainerRegistryTriggerStatus>("Status", ["status"]);
        _name = DefineProperty<string>("Name", ["name"]);
    }
}

#pragma warning restore CS0618
