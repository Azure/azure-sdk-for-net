// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitory.Query;

namespace Azure.Template.Tests
{
    // Logs take a long time to get ingested we send them only once and reuse for all the tests
    // Increment the DataVersion when changing the values to force a re-send
    public class LogsTestData
    {
        private static readonly string DataVersion = "1";

        public static string IntColumnNameSent = "IntColumn";
        public static string IntColumnName = IntColumnNameSent + "_d";

        public static string StringColumnNameSent = "StringColumn";
        public static string StringColumnName = StringColumnNameSent + "_s";

        public static string BoolColumnNameSent = "BoolColumn";
        public static string BoolColumnName = BoolColumnNameSent + "_b";

        public static string FloatColumnNameSent = "FloatColumn";
        public static string FloatColumnName = FloatColumnNameSent + "_d";

        public static readonly List<Dictionary<string, object>> TableA = new()
        {
            new() { { IntColumnNameSent, 1}, { StringColumnNameSent, "a"}, { BoolColumnNameSent, false}, { FloatColumnNameSent, 0f } },
            new() { { IntColumnNameSent, 3}, { StringColumnNameSent, "b"}, { BoolColumnNameSent, true}, { FloatColumnNameSent, 1.2f } },
            new() { { IntColumnNameSent, 1}, { StringColumnNameSent, "c"}, { BoolColumnNameSent, false}, { FloatColumnNameSent, 1.1f } },
        };

        private static string TableANameSent = nameof(TableA) + DataVersion;
        public static string TableAName = TableANameSent + "_CL";

        private readonly MonitorQueryClientTestEnvironment _testEnvironment;
        private bool _initialized;

        public LogsTestData(MonitorQueryClientTestEnvironment testEnvironment)
        {
            _testEnvironment = testEnvironment;
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
            var logsClient = new LogsClient(_testEnvironment.Credential);
            try
            {
                var countResponse = await logsClient.QueryAsync<int>(_testEnvironment.WorkspaceId, $"{TableAName} | count");
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