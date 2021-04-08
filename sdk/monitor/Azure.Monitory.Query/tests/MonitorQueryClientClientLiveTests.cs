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
    public class MonitorQueryClientClientLiveTests: RecordedTestBase<MonitorQueryClientTestEnvironment>
    {
        public MonitorQueryClientClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private MonitorQueryClient CreateClient()
        {
            return InstrumentClient(new MonitorQueryClient(
                TestEnvironment.Credential,
                InstrumentClientOptions(new MonitorQueryClientOptions()
                {Diagnostics = { LoggedHeaderNames = { "*" }}
                })
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
