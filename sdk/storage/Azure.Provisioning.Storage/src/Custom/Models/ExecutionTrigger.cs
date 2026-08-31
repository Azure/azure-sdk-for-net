// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Storage;

public partial class ExecutionTrigger : ProvisionableConstruct
{
    /// <summary>
    /// The trigger type of the storage task assignment execution.
    ///
    /// This property is obsoleted and will be removed in future versions. Please use
    /// <see cref="ExecutionTrigger.TaskExecutionTriggerType"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsoleted and will be removed in a future version. Please use TaskExecutionTriggerType with TaskExecutionTriggerType.RunOnce or TaskExecutionTriggerType.OnSchedule instead.")]
#pragma warning disable CS0618 // Compatibility property intentionally uses the obsolete shipped enum.
    public BicepValue<ExecutionTriggerType> TriggerType
#pragma warning restore CS0618
    {
        get { Initialize(); return _triggerType!; }
        set { Initialize(); _triggerType!.Assign(value); }
    }
#pragma warning disable CS0618 // Compatibility field intentionally uses the obsolete shipped enum.
    private BicepValue<ExecutionTriggerType>? _triggerType;
#pragma warning restore CS0618

    // The generator emits TaskExecutionTriggerType with a new enum type; retain the shipped TriggerType property
    // and ExecutionTriggerType enum on the same "type" path.
    partial void DefineAdditionalProperties()
    {
#pragma warning disable CS0618 // Compatibility property registration intentionally uses the obsolete shipped enum.
        _triggerType = DefineProperty<ExecutionTriggerType>("TriggerType", ["type"]);
#pragma warning restore CS0618
    }
}
