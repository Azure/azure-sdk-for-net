// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

using Azure.Provisioning.Primitives;
using System;

namespace Azure.Provisioning.Redis;

/// <summary>
/// Patch schedule entry for a Premium Redis Cache.
/// </summary>
public partial class RedisPatchScheduleSetting : ProvisionableConstruct
{
    /// <summary>
    /// Day of the week when a cache can be patched.
    /// </summary>
    public BicepValue<RedisDayOfWeek> DayOfWeek { get => _dayOfWeek; set => _dayOfWeek.Assign(value); }
    private readonly BicepValue<RedisDayOfWeek> _dayOfWeek;

    /// <summary>
    /// Start hour after which cache patching can start.
    /// </summary>
    public BicepValue<int> StartHourUtc { get => _startHourUtc; set => _startHourUtc.Assign(value); }
    private readonly BicepValue<int> _startHourUtc;

    /// <summary>
    /// ISO8601 timespan specifying how much time cache patching can take.
    /// </summary>
    public BicepValue<TimeSpan> MaintenanceWindow { get => _maintenanceWindow; set => _maintenanceWindow.Assign(value); }
    private readonly BicepValue<TimeSpan> _maintenanceWindow;

    /// <summary>
    /// Creates a new RedisPatchScheduleSetting.
    /// </summary>
    public RedisPatchScheduleSetting()
    {
        _dayOfWeek = BicepValue<RedisDayOfWeek>.DefineProperty(this, "DayOfWeek", ["dayOfWeek"]);
        _startHourUtc = BicepValue<int>.DefineProperty(this, "StartHourUtc", ["startHourUtc"]);
        _maintenanceWindow = BicepValue<TimeSpan>.DefineProperty(this, "MaintenanceWindow", ["maintenanceWindow"], format: "P");
    }
}
