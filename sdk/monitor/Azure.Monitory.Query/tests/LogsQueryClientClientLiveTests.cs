// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitory.Query;
using Azure.Monitory.Query.Models;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    public class LogsQueryClientClientLiveTests: RecordedTestBase<MonitorQueryClientTestEnvironment>
    {
        public LogsQueryClientClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private LogsClient CreateClient()
        {
            return InstrumentClient(new LogsClient(
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsClientOptions())
            ));
        }

        [Test]
        public async Task CanQuery()
        {
            var client = CreateClient();

            var results = await client.QueryAsync(TestEnvironment.WorkspaceId, "Heartbeat");

            var resultTable = results.Value.Tables.Single();
            CollectionAssert.IsNotEmpty(resultTable.Columns);
         }

        [Test]
        public async Task CanQueryBatch()
        {
            var client = CreateClient();
            LogsBatchQuery batch = InstrumentClient(client.CreateBatchQuery());
            string id1 = batch.AddQuery(TestEnvironment.WorkspaceId, "Heartbeat");
            string id2 = batch.AddQuery(TestEnvironment.WorkspaceId, "Heartbeat");
            Response<LogsBatchQueryResult> response = await batch.SubmitAsync();

            var result1 = response.Value.GetResult(id1);
            var result2 = response.Value.GetResult(id2);

            CollectionAssert.IsNotEmpty(result1.Tables[0].Columns);
            CollectionAssert.IsNotEmpty(result2.Tables[0].Columns);
        }
    }
}
