// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    internal static class LogsQueryClientExtensions
    {
        private static string s_workspaceId = string.Empty;
        private static TimeSpan s_queryDelay = TimeSpan.FromSeconds(30);

        public static void SetQueryWorkSpaceId(this LogsQueryClient client, string workspaceId) => s_workspaceId = workspaceId;

        public static async Task<LogsTable?> QueryTelemetryAsync(this LogsQueryClient client, string description, string query)
        {
            Debug.WriteLine($"UnitTest: Query Telemetry ({description})");
            TestContext.Out.WriteLine($"Query Telemetry ({description})");

            // Try every 30 secs for total of 5 minutes.
            int maxTries = 10;
            for (int attempt = 1; attempt <= maxTries; attempt++)
            {
                Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                    s_workspaceId,
                    query,
                    new QueryTimeRange(TimeSpan.FromMinutes(30)));

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
