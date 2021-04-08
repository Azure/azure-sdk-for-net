// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitory.Query;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    public class LogsQueryClientClientLiveTests: RecordedTestBase<MonitorQueryClientTestEnvironment>
    {
        public LogsQueryClientClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private LogsQueryClient CreateClient()
        {
            return InstrumentClient(new LogsQueryClient(
                TestEnvironment.Credential,
                InstrumentClientOptions(new MonitorQueryClientOptions())
            ));
        }

        [Test]
        public async Task CanQuery()
        {
            var client = CreateClient();

            var results = await client.QueryAsync(TestEnvironment.WorkspaceId, "Heartbeat");

            var resultTable = results.Value.Tables.Single();
            CollectionAssert.IsNotEmpty(resultTable.Columns);
            CollectionAssert.IsEmpty(resultTable.Rows);
        }
    }
}
