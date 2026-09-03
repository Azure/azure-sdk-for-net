// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The parameters for a task run request.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskRunContent from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public partial class ContainerRegistryTaskRunContent : ContainerRegistryRunContent
{
    /// <summary>
    /// The resource ID of task against which run has to be queued.
    /// </summary>
    public BicepValue<ResourceIdentifier> TaskId
    {
        get { Initialize(); return _taskId!; }
        set { Initialize(); _taskId!.Assign(value); }
    }
    private BicepValue<ResourceIdentifier>? _taskId;

    /// <summary>
    /// Set of overridable parameters that can be passed when running a Task.
    /// </summary>
    public ContainerRegistryOverrideTaskStepProperties OverrideTaskStepProperties
    {
        get { Initialize(); return _overrideTaskStepProperties!; }
        set { Initialize(); AssignOrReplace(ref _overrideTaskStepProperties, value); }
    }
    private ContainerRegistryOverrideTaskStepProperties? _overrideTaskStepProperties;

    /// <summary>
    /// Creates a new ContainerRegistryTaskRunContent.
    /// </summary>
    public ContainerRegistryTaskRunContent() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistryTaskRunContent.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("type", ["type"], defaultValue: "TaskRunRequest");
        _taskId = DefineProperty<ResourceIdentifier>("TaskId", ["taskId"]);
        _overrideTaskStepProperties = DefineModelProperty<ContainerRegistryOverrideTaskStepProperties>("OverrideTaskStepProperties", ["overrideTaskStepProperties"]);
    }
}

#pragma warning restore CS0618
