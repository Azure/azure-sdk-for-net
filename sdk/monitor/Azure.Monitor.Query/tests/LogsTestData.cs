// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query;

namespace Azure.Monitor.Query.Tests
{
    // Logs take a long time to get ingested we send them only once and reuse for all the tests
    // Increment the DataVersion when changing the values to force a re-send
    public class LogsTestData
    {
        private static readonly string DataVersion = "1";
        // The data retention time is 31 day by-default so we need to make sure the data we posted is still
        // being retained.
        // Make the windows start the monday of a previous week.
        private DateTimeOffset RetentionWindowStart;

        public static string IntColumnNameSent = "IntColumn";
        public static string IntColumnName = IntColumnNameSent + "_d";

        public static string StringColumnNameSent = "StringColumn";
        public static string StringColumnName = StringColumnNameSent + "_s";

        public static string BoolColumnNameSent = "BoolColumn";
        public static string BoolColumnName = BoolColumnNameSent + "_b";

        public static string FloatColumnNameSent = "FloatColumn";
        public static string FloatColumnName = FloatColumnNameSent + "_d";

        public static string TimeGeneratedColumnNameSent = "EventTimeGenerated";
        public static string TimeGeneratedColumnName = "TimeGenerated";

        public readonly List<Dictionary<string, object>> TableA;

        private string TableANameSent => nameof(TableA) + DataVersion + "_" + RetentionWindowStart.DayOfYear;
        public string TableAName => TableANameSent + "_CL";
        public DateTimeRange DataTimeRange => new DateTimeRange(RetentionWindowStart, TimeSpan.FromDays(7));

        private readonly MonitorQueryClientTestEnvironment _testEnvironment;
        private static bool _initialized;

        public LogsTestData(RecordedTestBase<MonitorQueryClientTestEnvironment> test)
        {
            _testEnvironment = test.TestEnvironment;

            // Make sure we don't need to re-record every week
            var recordingUtcNow = DateTime.SpecifyKind(test.Recording.UtcNow.Date, DateTimeKind.Utc);
            RetentionWindowStart = recordingUtcNow.AddDays(DayOfWeek.Monday - recordingUtcNow.DayOfWeek - 7);

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
                    { IntColumnNameSent, 3},
                    { StringColumnNameSent, "b"},
                    { BoolColumnNameSent, true},
                    { FloatColumnNameSent, 1.2f },
                    { TimeGeneratedColumnNameSent, RetentionWindowStart.AddDays(2) }
                },
                new()
                {
                    { IntColumnNameSent, 1},
                    { StringColumnNameSent, "c"},
                    { BoolColumnNameSent, false},
                    { FloatColumnNameSent, 1.1f },
                    { TimeGeneratedColumnNameSent, RetentionWindowStart.AddDays(5) }
                },
            };
        }

        public async Task InitializeAsync()
        {
            if (_testEnvironment.Mode == RecordedTestMode.Playback || _initialized)
            {
                return;
            }

            _initialized = true;

            var count = await QueryCount();

            if (count == 0)
            {
                var senderClient = new LogSenderClient(_testEnvironment.WorkspaceId, _testEnvironment.MonitorIngestionEndpoint, _testEnvironment.WorkspaceKey);
                await senderClient.SendAsync(TableANameSent, TableA);
            }
            else
            {
                return;
            }

            while (count == 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(30));
                count = await QueryCount();
            }
        }

        private async Task<int> QueryCount()
        {
            var logsClient = new LogsClient(_testEnvironment.LogsEndpoint, _testEnvironment.Credential);
            try
            {
                var countResponse = await logsClient.QueryAsync<int>(_testEnvironment.WorkspaceId, $"{TableAName} | count", DataTimeRange);
                var count = countResponse.Value.Single();
                return count;
            }
            catch
            {
                return 0;
            }
        }
    }
}