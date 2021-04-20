﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
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
        private LogsTestData _logsTestData;
        public LogsQueryClientClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _logsTestData = new LogsTestData(this);
            await _logsTestData.InitializeAsync();
        }

        private LogsClient CreateClient()
        {
            return InstrumentClient(new LogsClient(
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task CanQuery()
        {
            var client = CreateClient();

            var results = await client.QueryAsync(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} |" +
                $"project {LogsTestData.StringColumnName}, {LogsTestData.IntColumnName}, {LogsTestData.BoolColumnName}, {LogsTestData.FloatColumnName} |" +
                $"order by {LogsTestData.StringColumnName} asc");

            var resultTable = results.Value.Tables.Single();
            CollectionAssert.IsNotEmpty(resultTable.Columns);

            Assert.AreEqual("a", resultTable.Rows[0].GetString(0));
            Assert.AreEqual("a", resultTable.Rows[0].GetString(LogsTestData.StringColumnName));

            Assert.AreEqual(1, resultTable.Rows[0].GetInt32(1));
            Assert.AreEqual(1, resultTable.Rows[0].GetInt32(LogsTestData.IntColumnName));

            Assert.AreEqual(false, resultTable.Rows[0].GetBoolean(2));
            Assert.AreEqual(false, resultTable.Rows[0].GetBoolean(LogsTestData.BoolColumnName));

            Assert.AreEqual(0f, resultTable.Rows[0].GetSingle(3));
            Assert.AreEqual(0f, resultTable.Rows[0].GetSingle(LogsTestData.FloatColumnName));
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitiveString()
        {
            var client = CreateClient();

            var results = await client.QueryAsync<string>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | project {LogsTestData.StringColumnName} | order by {LogsTestData.StringColumnName} asc");

            CollectionAssert.AreEqual(new[] {"a","b","c"}, results.Value);
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitiveInt()
        {
            var client = CreateClient();

            var results = await client.QueryAsync<int>(TestEnvironment.WorkspaceId, $"{_logsTestData.TableAName} | count");

            Assert.AreEqual(_logsTestData.TableA.Count, results.Value[0]);
        }

        [RecordedTest]
        public async Task CanQueryIntoClass()
        {
            var client = CreateClient();

            var results = await client.QueryAsync<TestModel>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} |" +
                $"project-rename Name = {LogsTestData.StringColumnName}, Age = {LogsTestData.IntColumnName} |" +
                $"order by Name asc");

            CollectionAssert.AreEqual(new[]
            {
                new TestModel() { Age = 1, Name = "a"},
                new TestModel() { Age = 3, Name = "b"},
                new TestModel() { Age = 1, Name = "c"}
            }, results.Value);
        }

        [RecordedTest]
        public async Task CanQueryIntoDictionary()
        {
            var client = CreateClient();

            var results = await client.QueryAsync<Dictionary<string, object>>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} |" +
                $"project-rename Name = {LogsTestData.StringColumnName}, Age = {LogsTestData.IntColumnName} |" +
                $"project Name, Age |" +
                $"order by Name asc");

            CollectionAssert.AreEqual(new[]
            {
                new Dictionary<string, object>() { {"Age", 1}, {"Name", "a"}},
                new Dictionary<string, object>() { {"Age", 3}, {"Name", "b"}},
                new Dictionary<string, object>() { {"Age", 1}, {"Name", "c"}}
            }, results.Value);
        }

        [RecordedTest]
        public async Task CanQueryIntoIDictionary()
        {
            var client = CreateClient();

            var results = await client.QueryAsync<IDictionary<string, object>>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} |" +
                $"project-rename Name = {LogsTestData.StringColumnName}, Age = {LogsTestData.IntColumnName} |" +
                $"project Name, Age |" +
                $"order by Name asc");

            CollectionAssert.AreEqual(new[]
            {
                new Dictionary<string, object>() { {"Age", 1}, {"Name", "a"}},
                new Dictionary<string, object>() { {"Age", 3}, {"Name", "b"}},
                new Dictionary<string, object>() { {"Age", 1}, {"Name", "c"}}
            }, results.Value);
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task CanQueryWithTimespan()
        {
            // Get the time of the second event and add a bit of buffer to it (events are 2d apart)
            var minOffset = (DateTimeOffset)_logsTestData.TableA[1][LogsTestData.TimeGeneratedColumnNameSent];
            var timespan = Recording.UtcNow - minOffset;
            timespan = timespan.Add(TimeSpan.FromDays(1));

            var client = CreateClient();
            var results = await client.QueryAsync<string>(
                TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | project {LogsTestData.TimeGeneratedColumnName}",
                timespan);

            // We should get the second and the third events
            Assert.AreEqual(2, results.Value.Count);
            // TODO: Switch to querying DateTimeOffset
            Assert.True(results.Value.All(r => DateTimeOffset.Parse(r, null, DateTimeStyles.AssumeUniversal) >= minOffset));
        }

        [RecordedTest]
        public async Task CanQueryBatchWithTimespan()
        {
            // Get the time of the second event and add a bit of buffer to it (events are 2d apart)
            var minOffset = (DateTimeOffset)_logsTestData.TableA[1][LogsTestData.TimeGeneratedColumnNameSent];
            var timespan = Recording.UtcNow - minOffset;
            timespan = timespan.Add(TimeSpan.FromDays(1));

            var client = CreateClient();
            LogsBatchQuery batch = InstrumentClient(client.CreateBatchQuery());
            string id1 = batch.AddQuery(TestEnvironment.WorkspaceId, $"{_logsTestData.TableAName} | project {LogsTestData.TimeGeneratedColumnName}");
            string id2 = batch.AddQuery(TestEnvironment.WorkspaceId, $"{_logsTestData.TableAName} | project {LogsTestData.TimeGeneratedColumnName}", timespan);
            Response<LogsBatchQueryResult> response = await batch.SubmitAsync();

            var result1 = response.Value.GetResult<string>(id1);
            var result2 = response.Value.GetResult<string>(id2);

            // All rows
            Assert.AreEqual(3, result1.Count);
            // Filtered by the timestamp
            Assert.AreEqual(2, result2.Count);
            // TODO: Switch to querying DateTimeOffset
            Assert.True(result2.All(r => DateTimeOffset.Parse(r, null, DateTimeStyles.AssumeUniversal) >= minOffset));
        }

        private record TestModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
