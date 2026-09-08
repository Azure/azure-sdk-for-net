// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;
using System;
using System.ComponentModel;

namespace Azure.Provisioning.Monitor;

// This compatibility type preserves the previously shipped classic Alert Rule API, which is not represented in the current TypeSpec specification.
/// <summary>
/// How the data that is collected should be combined over time.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class ManagementEventAggregationCondition : ProvisionableConstruct
{
    /// <summary>
    /// the condition operator.
    /// </summary>
    public BicepValue<MonitorConditionOperator> Operator
    {
        get { Initialize(); return _operator!; }
        set { Initialize(); _operator!.Assign(value); }
    }
    private BicepValue<MonitorConditionOperator>? _operator;

    /// <summary>
    /// The threshold value that activates the alert.
    /// </summary>
    public BicepValue<double> Threshold
    {
        get { Initialize(); return _threshold!; }
        set { Initialize(); _threshold!.Assign(value); }
    }
    private BicepValue<double>? _threshold;

    /// <summary>
    /// the period of time (in ISO 8601 duration format) that is used to
    /// monitor alert activity based on the threshold. If specified then it
    /// must be between 5 minutes and 1 day.
    /// </summary>
    public BicepValue<TimeSpan> WindowSize
    {
        get { Initialize(); return _windowSize!; }
        set { Initialize(); _windowSize!.Assign(value); }
    }
    private BicepValue<TimeSpan>? _windowSize;

    /// <summary>
    /// Creates a new ManagementEventAggregationCondition.
    /// </summary>
    public ManagementEventAggregationCondition()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ManagementEventAggregationCondition.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _operator = DefineProperty<MonitorConditionOperator>("Operator", ["operator"]);
        _threshold = DefineProperty<double>("Threshold", ["threshold"]);
        _windowSize = DefineProperty<TimeSpan>("WindowSize", ["windowSize"]);
    }
}
