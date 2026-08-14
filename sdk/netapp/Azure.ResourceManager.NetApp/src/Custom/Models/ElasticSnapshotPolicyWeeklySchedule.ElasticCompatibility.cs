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
    public partial class ElasticSnapshotPolicyWeeklySchedule { public ElasticSnapshotPolicyWeeklySchedule(int? snapshotsToKeep = default, IEnumerable<DayOfWeek> days = default, int? hour = default, int? minute = default) { SnapshotsToKeep = snapshotsToKeep; Days = days is null ? new ChangeTrackingList<DayOfWeek>() : new List<DayOfWeek>(days); Hour = hour; Minute = minute; } public int? SnapshotsToKeep { get; set; } public IList<DayOfWeek> Days { get; } public int? Hour { get; set; } public int? Minute { get; set; } }
}
