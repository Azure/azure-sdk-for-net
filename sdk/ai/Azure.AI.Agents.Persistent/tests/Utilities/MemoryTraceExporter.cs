﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using OpenTelemetry;
using OpenTelemetry.Trace;
using System.Diagnostics;
using Moq;

namespace Azure.AI.Agents.Persistent.Tests.Utilities
{
    public class MemoryTraceExporter : BaseExporter<Activity>
    {
        private readonly List<Activity> _activities = new();

        public override ExportResult Export(in Batch<Activity> batch)
        {
            foreach (var activity in batch)
            {
                _activities.Add(activity);
            }
            return ExportResult.Success;
        }

        public IReadOnlyList<Activity> GetExportedActivities() => _activities;

        public void Clear() => _activities.Clear();
    }
}
