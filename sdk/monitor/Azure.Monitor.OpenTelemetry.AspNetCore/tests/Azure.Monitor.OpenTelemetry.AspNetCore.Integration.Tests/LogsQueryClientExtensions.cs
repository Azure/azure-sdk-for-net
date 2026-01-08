// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using NUnit.Framework;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    internal static class LogsQueryClientExtensions
    {
        private static TimeSpan s_queryDelay = TimeSpan.FromSeconds(30);

        public static async Task<LogsTable?> QueryTelemetryAsync(this LogsQueryClient client, string workspaceId, string description, string query)
        {
            // Try every 30 secs for total of 10 minutes.
            // This delay should reasonably accomodate known delays:
            // There can be a delay in provisioning resources and permissions.
            // There can be a delay in ingesting data, or in the query service.
            int maxTries = 20;
            for (int attempt = 1; attempt <= maxTries; attempt++)
            {
                Debug.WriteLine($"UnitTest: Query Telemetry ({description}) attempt {attempt}/{maxTries}");
                TestContext.Out.WriteLine($"Query Telemetry ({description}) attempt {attempt}/{maxTries}");

                Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                    workspaceId,
                    query,
                    new LogsQueryTimeRange(TimeSpan.FromMinutes(30)));

                if (response.Value.Table.Rows.Count > 0)
                {
                    return response.Value.Table;
                }

                Debug.WriteLine($"UnitTest: Query attempt {attempt}/{maxTries} returned no records. Waiting {s_queryDelay.TotalSeconds} seconds...");
                TestContext.Out.WriteLine($"Query attempt {attempt}/{maxTries} returned no records. Waiting {s_queryDelay.TotalSeconds} seconds...");
                await Task.Delay(s_queryDelay);
            }

            return null;
        }
    }
}
