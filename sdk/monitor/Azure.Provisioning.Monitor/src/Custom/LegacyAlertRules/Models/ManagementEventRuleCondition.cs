// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;
using System;
using System.ComponentModel;

namespace Azure.Provisioning.Monitor;

// This compatibility type preserves the previously shipped classic Alert Rule API, which is not represented in the current TypeSpec specification.
/// <summary>
/// A management event rule condition.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class ManagementEventRuleCondition : AlertRuleCondition
{
    /// <summary>
    /// How the data that is collected should be combined over time and when
    /// the alert is activated. Note that for management event alerts
    /// aggregation is optional – if it is not provided then any event will
    /// cause the alert to activate.
    /// </summary>
    public ManagementEventAggregationCondition Aggregation
    {
        get { Initialize(); return _aggregation!; }
        set { Initialize(); AssignOrReplace(ref _aggregation, value); }
    }
    private ManagementEventAggregationCondition? _aggregation;

    /// <summary>
    /// Creates a new ManagementEventRuleCondition.
    /// </summary>
    public ManagementEventRuleCondition() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of ManagementEventRuleCondition.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("odata.type", ["odata.type"], defaultValue: "Microsoft.Azure.Management.Insights.Models.ManagementEventRuleCondition");
        _aggregation = DefineModelProperty<ManagementEventAggregationCondition>("Aggregation", ["aggregation"]);
    }
}
