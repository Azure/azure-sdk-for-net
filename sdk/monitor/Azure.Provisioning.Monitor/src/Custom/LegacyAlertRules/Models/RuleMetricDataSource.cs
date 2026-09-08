// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;
using System;
using System.ComponentModel;

namespace Azure.Provisioning.Monitor;

// This compatibility type preserves the previously shipped classic Alert Rule API, which is not represented in the current TypeSpec specification.
/// <summary>
/// A rule metric data source. The discriminator value is always
/// RuleMetricDataSource in this case.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class RuleMetricDataSource : RuleDataSource
{
    /// <summary>
    /// the name of the metric that defines what the rule monitors.
    /// </summary>
    public BicepValue<string> MetricName
    {
        get { Initialize(); return _metricName!; }
        set { Initialize(); _metricName!.Assign(value); }
    }
    private BicepValue<string>? _metricName;

    /// <summary>
    /// Creates a new RuleMetricDataSource.
    /// </summary>
    public RuleMetricDataSource() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of RuleMetricDataSource.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("odata.type", ["odata.type"], defaultValue: "Microsoft.Azure.Management.Insights.Models.RuleMetricDataSource");
        _metricName = DefineProperty<string>("MetricName", ["metricName"]);
    }
}
