// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Monitor.Query.Tests
{
    // Logs take a long time to get ingested we send them only once and reuse for all the tests
    // Increment the DataVersion when changing the values to force a re-send
    public class LogsTestData
    {
        private static readonly string DataVersion = "1";
        private static Task _initialization;
        private static readonly object _initializationLock = new object();
        // The data retention time is 31 day by-default so we need to make sure the data we posted is still
        // being retained.
        // Make the windows start the monday of a previous week.
        private DateTimeOffset RetentionWindowStart;

        public static string IntColumnNameSent = "IntColumn";
        public static string IntColumnName = "Int";

        public static string StringColumnNameSent = "StringColumn";
        public static string StringColumnName = "String";

        public static string BoolColumnNameSent = "BoolColumn";
        public static string BoolColumnName = "Bool";

        public static string FloatColumnNameSent = "FloatColumn";
        public static string FloatColumnName = "Float";

        public static string DoubleColumnName = "Double";

        public static string TimeGeneratedColumnNameSent = "EventTimeGenerated";
        public static string TimeGeneratedColumnName = "TimeGenerated";

        public readonly List<Dictionary<string, object>> TableA;

        private string TableANameSent => nameof(TableA) + DataVersion + "_" + RetentionWindowStart.DayOfYear;

        public string TableAName => TableANameSent + "_CL";
        public QueryTimeRange DataTimeRange => new QueryTimeRange(RetentionWindowStart, TimeSpan.FromDays(15));

        private readonly MonitorQueryTestEnvironment _testEnvironment;

        public LogsTestData(RecordedTestBase<MonitorQueryTestEnvironment> test)
        {
            _testEnvironment = test.TestEnvironment;

            var recordingUtcNow = DateTime.SpecifyKind(test.Recording.UtcNow.Date, DateTimeKind.Utc);
            RetentionWindowStart = recordingUtcNow.AddDays(-14);

            TableA = new()
            {
                new()
                {
                    { IntColumnNameSent, 1},
                    { StringColumnNameSent, "a"},
                    { BoolColumnNameSent, false},
                    { FloatColumnNameSent, 0f },
                    { TimeGeneratedColumnNameSent, RetentionWindowStart }
                },
                new()
                {
                    { IntColumnNameSent, 2},
                    { StringColumnNameSent, "b"},
                    { BoolColumnNameSent, true},
                    { FloatColumnNameSent, 1.2f },
                    { TimeGeneratedColumnNameSent, RetentionWindowStart.AddDays(2) }
                },
                new()
                {
                    { IntColumnNameSent, 3},
                    { StringColumnNameSent, "c"},
                    { BoolColumnNameSent, false},
                    { FloatColumnNameSent, 1.1f },
                    { TimeGeneratedColumnNameSent, RetentionWindowStart.AddDays(5) }
                }
            };
        }

        public async Task InitializeAsync()
        {
            if (_testEnvironment.Mode == RecordedTestMode.Playback)
            {
                return;
            }

            lock (_initializationLock)
            {
                _initialization ??= Task.WhenAll(
                    InitializeData(_testEnvironment.WorkspaceId, _testEnvironment.WorkspaceKey),
                    InitializeData(_testEnvironment.SecondaryWorkspaceId, _testEnvironment.SecondaryWorkspaceKey));
            }

            await _initialization;
        }

        private async Task InitializeData(string workspaceId, string workspaceKey)
        {
            var count = await QueryCount(workspaceId);

            if (count == 0)
            {
                var senderClient = new LogSenderClient(workspaceId, _testEnvironment.MonitorIngestionEndpoint, workspaceKey);
                await senderClient.SendAsync(TableANameSent, TableA);
            }
            else
            {
                return;
            }

            while (count == 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(30));
                count = await QueryCount(workspaceId);
            }
        }

        private async Task<int> QueryCount(string workspaceId)
        {
            var logsClient = new LogsQueryClient(new Uri(_testEnvironment.GetLogsAudience() + "/v1"), _testEnvironment.Credential);
            try
            {
                var query = $"{TableAName}" +
                    $" | distinct * |" +
                    $"project {StringColumnName}, {IntColumnName}, {BoolColumnName}, {FloatColumnName} |" +
                    $"count";
                var customColumnsQuery = await logsClient.QueryWorkspaceAsync<int>(workspaceId, query,
                    DataTimeRange);
                var customColumns = customColumnsQuery.Value.Single();
                return customColumns;
            }
            catch
            {
                return 0;
            }
        }
    }
}
