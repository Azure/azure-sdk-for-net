// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    internal static class LogsQueryClientExtensions
    {
        private static string s_workspaceId = string.Empty;

        public static void SetQueryWorkSpaceId(this LogsQueryClient client, string workspaceId) => s_workspaceId = workspaceId;

        public static async Task<LogsTable?> CheckForRecordAsync(this LogsQueryClient client, string query)
        {
            LogsTable? table = null;
            int count = 0;

            // Try every 30 secs for total of 5 minutes.
            int maxTries = 10;
            while (count == 0 && maxTries > 0)
            {
                Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                    s_workspaceId,
                    query,
                    new QueryTimeRange(TimeSpan.FromMinutes(30)));

                table = response.Value.Table;

                count = table.Rows.Count;

                if (count > 0)
                {
                    break;
                }

                maxTries--;

                await Task.Delay(TimeSpan.FromSeconds(30));
            }

            return table;
        }
    }
}
