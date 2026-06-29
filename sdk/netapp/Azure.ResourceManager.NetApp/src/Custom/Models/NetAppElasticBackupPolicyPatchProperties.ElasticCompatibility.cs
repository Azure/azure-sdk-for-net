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
    public partial class NetAppElasticBackupPolicyPatchProperties { public NetAppElasticBackupPolicyPatchProperties(int? dailyBackupsToKeep = default, int? weeklyBackupsToKeep = default, int? monthlyBackupsToKeep = default, ElasticBackupPolicyState? policyState = default) { DailyBackupsToKeep = dailyBackupsToKeep; WeeklyBackupsToKeep = weeklyBackupsToKeep; MonthlyBackupsToKeep = monthlyBackupsToKeep; PolicyState = policyState; } public int? DailyBackupsToKeep { get; set; } public int? WeeklyBackupsToKeep { get; set; } public int? MonthlyBackupsToKeep { get; set; } public ElasticBackupPolicyState? PolicyState { get; set; } }
}
