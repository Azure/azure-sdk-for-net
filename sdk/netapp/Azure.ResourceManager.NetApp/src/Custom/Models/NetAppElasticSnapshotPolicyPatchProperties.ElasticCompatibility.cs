// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppElasticSnapshotPolicyPatchProperties { public NetAppElasticSnapshotPolicyPatchProperties(ElasticSnapshotPolicyHourlySchedule hourlySchedule = default, ElasticSnapshotPolicyDailySchedule dailySchedule = default, ElasticSnapshotPolicyWeeklySchedule weeklySchedule = default, ElasticSnapshotPolicyMonthlySchedule monthlySchedule = default, ElasticSnapshotPolicyStatus? policyStatus = default) { HourlySchedule = hourlySchedule; DailySchedule = dailySchedule; WeeklySchedule = weeklySchedule; MonthlySchedule = monthlySchedule; PolicyStatus = policyStatus; } public ElasticSnapshotPolicyHourlySchedule HourlySchedule { get; set; } public ElasticSnapshotPolicyDailySchedule DailySchedule { get; set; } public ElasticSnapshotPolicyWeeklySchedule WeeklySchedule { get; set; } public ElasticSnapshotPolicyMonthlySchedule MonthlySchedule { get; set; } public ElasticSnapshotPolicyStatus? PolicyStatus { get; set; } }
}
