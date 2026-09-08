// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;
using System;
using System.ComponentModel;

namespace Azure.Provisioning.Monitor;

// This compatibility type preserves the previously shipped classic Alert Rule API, which is not represented in the current TypeSpec specification.
/// <summary>
/// A rule condition based on a certain number of locations failing.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class LocationThresholdRuleCondition : AlertRuleCondition
{
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
    /// the number of locations that must fail to activate the alert.
    /// </summary>
    public BicepValue<int> FailedLocationCount
    {
        get { Initialize(); return _failedLocationCount!; }
        set { Initialize(); _failedLocationCount!.Assign(value); }
    }
    private BicepValue<int>? _failedLocationCount;

    /// <summary>
    /// Creates a new LocationThresholdRuleCondition.
    /// </summary>
    public LocationThresholdRuleCondition() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// LocationThresholdRuleCondition.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _windowSize = DefineProperty<TimeSpan>("WindowSize", ["windowSize"]);
        _failedLocationCount = DefineProperty<int>("FailedLocationCount", ["failedLocationCount"]);
    }
}
