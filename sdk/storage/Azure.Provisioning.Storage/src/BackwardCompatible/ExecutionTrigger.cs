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
    public BicepValue<ExecutionTriggerType> TriggerType
    {
        get { Initialize(); return _triggerType!; }
        set { Initialize(); _triggerType!.Assign(value); }
    }
    private BicepValue<ExecutionTriggerType>? _triggerType;

    private partial void DefineAdditionalProperties()
    {
        _triggerType = DefineProperty<ExecutionTriggerType>("TriggerType", ["type"]);
    }
}
