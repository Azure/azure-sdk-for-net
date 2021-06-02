// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class LogsQueryClientClientLiveTests : RecordedTestBase<MonitorQueryClientTestEnvironment>
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
                TestEnvironment.LogsEndpoint,
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
                $"order by {LogsTestData.StringColumnName} asc",
                _logsTestData.DataTimeRange);

            var resultTable = results.Value.Tables.Single();
            CollectionAssert.IsNotEmpty(resultTable.Columns);

            Assert.AreEqual("a", resultTable.Rows[0].GetString(0));
            Assert.AreEqual("a", resultTable.Rows[0].GetString(LogsTestData.StringColumnName));

            Assert.AreEqual(1, resultTable.Rows[0].GetInt32(1));
            Assert.AreEqual(1, resultTable.Rows[0].GetInt32(LogsTestData.IntColumnName));

            Assert.AreEqual(false, resultTable.Rows[0].GetBoolean(2));
            Assert.AreEqual(false, resultTable.Rows[0].GetBoolean(LogsTestData.BoolColumnName));

            Assert.AreEqual(0d, resultTable.Rows[0].GetDouble(3));
            Assert.AreEqual(0d, resultTable.Rows[0].GetDouble(LogsTestData.FloatColumnName));
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitiveString()
        {
            var client = CreateClient();

            var results = await client.QueryAsync<string>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | project {LogsTestData.StringColumnName} | order by {LogsTestData.StringColumnName} asc",
                _logsTestData.DataTimeRange);

            CollectionAssert.AreEqual(new[] {"a", "b", "c"}, results.Value);
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitiveInt()
        {
            var client = CreateClient();

            var results = await client.QueryAsync<int>(TestEnvironment.WorkspaceId, $"{_logsTestData.TableAName} | count",
                _logsTestData.DataTimeRange);

            Assert.AreEqual(_logsTestData.TableA.Count, results.Value[0]);
        }

        [RecordedTest]
        public async Task CanQueryIntoClass()
        {
            var client = CreateClient();

            var results = await client.QueryAsync<TestModel>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} |" +
                $"project-rename Name = {LogsTestData.StringColumnName}, Age = {LogsTestData.IntColumnName} |" +
                $"order by Name asc",
                _logsTestData.DataTimeRange);

            CollectionAssert.AreEqual(new[]
            {
                new TestModel() {Age = 1, Name = "a"},
                new TestModel() {Age = 3, Name = "b"},
                new TestModel() {Age = 1, Name = "c"}
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
                $"order by Name asc",
                _logsTestData.DataTimeRange);

            CollectionAssert.AreEqual(new[]
            {
                new Dictionary<string, object>() {{"Age", 1}, {"Name", "a"}},
                new Dictionary<string, object>() {{"Age", 3}, {"Name", "b"}},
                new Dictionary<string, object>() {{"Age", 1}, {"Name", "c"}}
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
                $"order by Name asc",
                _logsTestData.DataTimeRange);

            CollectionAssert.AreEqual(new[]
            {
                new Dictionary<string, object>() {{"Age", 1}, {"Name", "a"}},
                new Dictionary<string, object>() {{"Age", 3}, {"Name", "b"}},
                new Dictionary<string, object>() {{"Age", 1}, {"Name", "c"}}
            }, results.Value);
        }

        [RecordedTest]
        public async Task CanQueryBatch()
        {
            var client = CreateClient();
            LogsBatchQuery batch = new LogsBatchQuery();
            string id1 = batch.AddQuery(TestEnvironment.WorkspaceId, "Heartbeat", _logsTestData.DataTimeRange);
            string id2 = batch.AddQuery(TestEnvironment.WorkspaceId, "Heartbeat", _logsTestData.DataTimeRange);
            Response<LogsBatchQueryResult> response = await client.QueryBatchAsync(batch);

            var result1 = response.Value.GetResult(id1);
            var result2 = response.Value.GetResult(id2);

            CollectionAssert.IsNotEmpty(result1.Tables[0].Columns);
            CollectionAssert.IsNotEmpty(result2.Tables[0].Columns);
        }

        [RecordedTest]
        public async Task CanQueryAllSupportedTypes()
        {
            var client = CreateClient();

            Response<LogsQueryResult> results = await client.QueryAsync(TestEnvironment.WorkspaceId,
                $"datatable (DateTime: datetime, Bool:bool, Guid: guid, Int: int, Long:long, Double: double, String: string, Timespan: timespan, Decimal: decimal, NullBool: bool)" +
                "[" +
                "datetime(2015-12-31 23:59:59.9)," +
                "false," +
                "guid(74be27de-1e4e-49d9-b579-fe0b331d3642)," +
                "12345," +
                "1234567890123," +
                "12345.6789," +
                "\"string value\"," +
                "10s," +
                "decimal(0.10101)," +
                "bool(null)" +
                "]", _logsTestData.DataTimeRange);

            LogsQueryResultRow row = results.Value.PrimaryTable.Rows[0];

            var expectedDate = DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00");
            Assert.AreEqual(expectedDate, row.GetDateTimeOffset("DateTime"));
            Assert.AreEqual(expectedDate, row.GetDateTimeOffset(0));
            Assert.AreEqual(expectedDate, row.GetObject("DateTime"));
            Assert.AreEqual(false, row.GetBoolean("Bool"));
            Assert.AreEqual(false, row.GetBoolean(1));
            Assert.AreEqual(false, row.GetObject("Bool"));
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), row.GetGuid("Guid"));
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), row.GetGuid(2));
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), row.GetObject("Guid"));
            Assert.AreEqual(12345, row.GetInt32("Int"));
            Assert.AreEqual(12345, row.GetInt32(3));
            Assert.AreEqual(12345, row.GetObject("Int"));
            Assert.AreEqual(1234567890123, row.GetInt64("Long"));
            Assert.AreEqual(1234567890123, row.GetInt64(4));
            Assert.AreEqual(1234567890123, row.GetObject("Long"));
            Assert.AreEqual(12345.6789d, row.GetDouble("Double"));
            Assert.AreEqual(12345.6789d, row.GetDouble(5));
            Assert.AreEqual(12345.6789d, row.GetObject("Double"));
            Assert.AreEqual("string value", row.GetString("String"));
            Assert.AreEqual("string value", row.GetString(6));
            Assert.AreEqual("string value", row.GetObject("String"));
            Assert.AreEqual(TimeSpan.FromSeconds(10), row.GetTimeSpan("Timespan"));
            Assert.AreEqual(TimeSpan.FromSeconds(10), row.GetTimeSpan(7));
            Assert.AreEqual(TimeSpan.FromSeconds(10),  row.GetObject("Timespan"));
            Assert.AreEqual(0.10101m, row.GetDecimal("Decimal"));
            Assert.AreEqual(0.10101m, row.GetDecimal(8));
            Assert.AreEqual(0.10101m, row.GetObject("Decimal"));
            Assert.True(row.IsNull("NullBool"));
            Assert.True(row.IsNull(9));
            Assert.IsNull(row.GetObject("NullBool"));
        }

        [RecordedTest]
        public async Task CanQueryAllSupportedTypesIntoModel()
        {
            var client = CreateClient();

            Response<IReadOnlyList<TestModelForTypes>> results = await client.QueryAsync<TestModelForTypes>(TestEnvironment.WorkspaceId,
                $"datatable (DateTime: datetime, Bool:bool, Guid: guid, Int: int, Long:long, Double: double, String: string, Timespan: timespan, Decimal: decimal)" +
                "[" +
                "datetime(2015-12-31 23:59:59.9)," +
                "false," +
                "guid(74be27de-1e4e-49d9-b579-fe0b331d3642)," +
                "12345," +
                "1234567890123," +
                "12345.6789," +
                "'string value'," +
                "10s," +
                "decimal(0.10101)" +
                "]", _logsTestData.DataTimeRange);

            TestModelForTypes row = results.Value[0];

            Assert.AreEqual(DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00"), row.DateTime);
            Assert.AreEqual(false, row.Bool);
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), row.Guid);
            Assert.AreEqual(12345, row.Int);
            Assert.AreEqual(1234567890123, row.Long);
            Assert.AreEqual(12345.6789d, row.Double);
            Assert.AreEqual("string value", row.String);
            Assert.AreEqual(TimeSpan.FromSeconds(10), row.Timespan);
            Assert.AreEqual(0.10101m, row.Decimal);
        }

        [RecordedTest]
        public async Task CanQueryAllSupportedTypesIntoModelNullable()
        {
            var client = CreateClient();

            Response<IReadOnlyList<TestModelForTypesNullable>> results = await client.QueryAsync<TestModelForTypesNullable>(TestEnvironment.WorkspaceId,
                $"datatable (DateTime: datetime, Bool:bool, Guid: guid, Int: int, Long:long, Double: double, String: string, Timespan: timespan, Decimal: decimal)" +
                "[" +
                "datetime(2015-12-31 23:59:59.9)," +
                "false," +
                "guid(74be27de-1e4e-49d9-b579-fe0b331d3642)," +
                "12345," +
                "1234567890123," +
                "12345.6789," +
                "'string value'," +
                "10s," +
                "decimal(0.10101)" +
                "]", _logsTestData.DataTimeRange);

            TestModelForTypesNullable row = results.Value[0];

            Assert.AreEqual(DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00"), row.DateTime);
            Assert.AreEqual(false, row.Bool);
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), row.Guid);
            Assert.AreEqual(12345, row.Int);
            Assert.AreEqual(1234567890123, row.Long);
            Assert.AreEqual(12345.6789d, row.Double);
            Assert.AreEqual("string value", row.String);
            Assert.AreEqual(TimeSpan.FromSeconds(10), row.Timespan);
            Assert.AreEqual(0.10101m, row.Decimal);
        }

        [RecordedTest]
        public async Task CanQueryAllSupportedTypesIntoModelNulls()
        {
            var client = CreateClient();

            Response<IReadOnlyList<TestModelForTypesNullable>> results = await client.QueryAsync<TestModelForTypesNullable>(TestEnvironment.WorkspaceId,
                $"datatable (DateTime: datetime, Bool:bool, Guid: guid, Int: int, Long:long, Double: double, String: string, Timespan: timespan, Decimal: decimal)" +
                "[" +
                "datetime(null)," +
                "bool(null)," +
                "guid(null)," +
                "int(null)," +
                "long(null)," +
                "double(null)," +
                "'I cant be null'," +
                "timespan(null)," +
                "decimal(null)," +
                "]", _logsTestData.DataTimeRange);

            TestModelForTypesNullable row = results.Value[0];

            Assert.IsNull(row.DateTime);
            Assert.IsNull(row.Bool);
            Assert.IsNull(row.Guid);
            Assert.IsNull(row.Int);
            Assert.IsNull(row.Long);
            Assert.IsNull(row.Double);
            Assert.AreEqual("I cant be null", row.String);
            Assert.IsNull(row.Timespan);
            Assert.IsNull(row.Decimal);
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitive()
        {
            var client = CreateClient();

            Assert.AreEqual(DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00"), (await client.QueryAsync<DateTimeOffset>(TestEnvironment.WorkspaceId, $"datatable (DateTime: datetime) [ datetime(2015-12-31 23:59:59.9) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(false, (await client.QueryAsync<bool>(TestEnvironment.WorkspaceId, $"datatable (Bool: bool) [ false ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), (await client.QueryAsync<Guid>(TestEnvironment.WorkspaceId, $"datatable (Guid: guid) [ guid(74be27de-1e4e-49d9-b579-fe0b331d3642) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(12345, (await client.QueryAsync<int>(TestEnvironment.WorkspaceId, $"datatable (Int: int) [ 12345 ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(1234567890123, (await client.QueryAsync<long>(TestEnvironment.WorkspaceId, $"datatable (Long: long) [ 1234567890123 ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(12345.6789d, (await client.QueryAsync<double>(TestEnvironment.WorkspaceId, $"datatable (Double: double) [ 12345.6789 ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual("string value", (await client.QueryAsync<string>(TestEnvironment.WorkspaceId, $"datatable (String: string) [ \"string value\" ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(TimeSpan.FromSeconds(10), (await client.QueryAsync<TimeSpan>(TestEnvironment.WorkspaceId, $"datatable (Timespan: timespan) [ 10s ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(0.10101m, (await client.QueryAsync<decimal>(TestEnvironment.WorkspaceId, $"datatable (Decimal: decimal) [ decimal(0.10101) ]", _logsTestData.DataTimeRange)).Value[0]);
        }

        [RecordedTest]
        public async Task CanQueryIntoNullablePrimitive()
        {
            var client = CreateClient();

            Assert.IsNull((await client.QueryAsync<DateTimeOffset?>(TestEnvironment.WorkspaceId, $"datatable (DateTime: datetime) [ datetime(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryAsync<bool?>(TestEnvironment.WorkspaceId, $"datatable (Bool: bool) [ bool(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryAsync<Guid?>(TestEnvironment.WorkspaceId, $"datatable (Guid: guid) [ guid(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryAsync<int?>(TestEnvironment.WorkspaceId, $"datatable (Int: int) [ int(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryAsync<long?>(TestEnvironment.WorkspaceId, $"datatable (Long: long) [ long(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryAsync<double?>(TestEnvironment.WorkspaceId, $"datatable (Double: double) [ double(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryAsync<TimeSpan?>(TestEnvironment.WorkspaceId, $"datatable (Timespan: timespan) [ timespan(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryAsync<decimal?>(TestEnvironment.WorkspaceId, $"datatable (Decimal: decimal) [ decimal(null) ]", _logsTestData.DataTimeRange)).Value[0]);
        }

        [RecordedTest]
        public async Task CanQueryIntoNullablePrimitiveNull()
        {
            var client = CreateClient();

            var results = await client.QueryAsync<DateTimeOffset?>(TestEnvironment.WorkspaceId, $"datatable (DateTime: datetime) [ datetime(null) ]", _logsTestData.DataTimeRange);

            Assert.IsNull(results.Value[0]);
        }

        [RecordedTest]
        public async Task CanQueryWithTimespan()
        {
            // Get the time of the second event and add a bit of buffer to it (events are 2d apart)
            var minOffset = (DateTimeOffset)_logsTestData.TableA[1][LogsTestData.TimeGeneratedColumnNameSent];
            var timespan = Recording.UtcNow - minOffset;
            timespan = timespan.Add(TimeSpan.FromDays(1));

            var client = CreateClient();
            var results = await client.QueryAsync<DateTimeOffset>(
                TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | project {LogsTestData.TimeGeneratedColumnName}",
                timespan);

            // We should get the second and the third events
            Assert.AreEqual(2, results.Value.Count);
            // TODO: Switch to querying DateTimeOffset
            Assert.True(results.Value.All(r => r >= minOffset));
        }

        [RecordedTest]
        public async Task CanQueryBatchWithTimespan()
        {
            // Get the time of the second event and add a bit of buffer to it (events are 2d apart)
            var minOffset = (DateTimeOffset)_logsTestData.TableA[1][LogsTestData.TimeGeneratedColumnNameSent];
            var timespan = Recording.UtcNow - minOffset;
            timespan = timespan.Add(TimeSpan.FromDays(1));

            var client = CreateClient();
            LogsBatchQuery batch = new LogsBatchQuery();
            string id1 = batch.AddQuery(TestEnvironment.WorkspaceId, $"{_logsTestData.TableAName} | project {LogsTestData.TimeGeneratedColumnName}", _logsTestData.DataTimeRange);
            string id2 = batch.AddQuery(TestEnvironment.WorkspaceId, $"{_logsTestData.TableAName} | project {LogsTestData.TimeGeneratedColumnName}", timespan);
            Response<LogsBatchQueryResult> response = await client.QueryBatchAsync(batch);

            var result1 = response.Value.GetResult<DateTimeOffset>(id1);
            var result2 = response.Value.GetResult<DateTimeOffset>(id2);

            // All rows
            Assert.AreEqual(3, result1.Count);
            // Filtered by the timestamp
            Assert.AreEqual(2, result2.Count);
            Assert.True(result2.All(r => r >= minOffset));
        }

        [RecordedTest]
        public void ThrowsExceptionWhenQueryFails()
        {
            var client = CreateClient();
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await client.QueryAsync(TestEnvironment.WorkspaceId, "this won't work", _logsTestData.DataTimeRange));

            Assert.AreEqual("BadArgumentError", exception.ErrorCode);
            StringAssert.StartsWith("The request had some invalid properties", exception.Message);
        }

        [RecordedTest]
        public async Task ThrowsExceptionWhenQueryFailsBatch()
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            var queryId = batch.AddQuery(TestEnvironment.WorkspaceId, "this won't work", _logsTestData.DataTimeRange);
            var batchResult = await client.QueryBatchAsync(batch);

            var exception = Assert.Throws<RequestFailedException>(() => batchResult.Value.GetResult(queryId));

            Assert.AreEqual("BadArgumentError", exception.ErrorCode);
            StringAssert.StartsWith("The request had some invalid properties", exception.Message);
        }

        [RecordedTest]
        public async Task ThrowsExceptionWhenBatchQueryNotFound()
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            batch.AddQuery(TestEnvironment.WorkspaceId, _logsTestData.TableAName, _logsTestData.DataTimeRange);
            var batchResult = await client.QueryBatchAsync(batch);

            var exception = Assert.Throws<ArgumentException>(() => batchResult.Value.GetResult("12345"));

            Assert.AreEqual("queryId", exception.ParamName);
            StringAssert.StartsWith("Query with ID '12345' wasn't part of the batch. Please use the return value of the LogsBatchQuery.AddQuery as the 'queryId' argument.", exception.Message);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanQueryWithStatistics(bool include)
        {
            var client = CreateClient();

            var response = await client.QueryAsync(TestEnvironment.WorkspaceId, _logsTestData.TableAName, _logsTestData.DataTimeRange, options: new LogsQueryOptions()
            {
                IncludeStatistics = include
            });

            if (include)
            {
                using JsonDocument document = JsonDocument.Parse(response.Value.Statistics);
                Assert.Greater(document.RootElement.GetProperty("query").GetProperty("executionTime").GetDouble(), 0);
            }
            else
            {
                Assert.AreEqual(default, response.Value.Statistics);
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanQueryWithStatisticsBatch(bool include)
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            var queryId = batch.AddQuery(TestEnvironment.WorkspaceId, _logsTestData.TableAName, _logsTestData.DataTimeRange, options: new LogsQueryOptions()
            {
                IncludeStatistics = include
            });
            var batchResult = await client.QueryBatchAsync(batch);
            var result = batchResult.Value.GetResult(queryId);

            if (include)
            {
                using JsonDocument document = JsonDocument.Parse(result.Statistics);
                Assert.Greater(document.RootElement.GetProperty("query").GetProperty("executionTime").GetDouble(), 0);
            }
            else
            {
                Assert.AreEqual(default, result.Statistics);
            }
        }

        [RecordedTest]
        public async Task CanSetServiceTimeout()
        {
            var client = CreateClient();

            var response = await client.QueryAsync(TestEnvironment.WorkspaceId, _logsTestData.TableAName, _logsTestData.DataTimeRange, options: new LogsQueryOptions()
            {
                Timeout = TimeSpan.FromMinutes(10)
            });

            CollectionAssert.IsNotEmpty(response.Value.PrimaryTable.Rows);
        }

        private record TestModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private record TestModelForTypes
        {
            public DateTimeOffset DateTime { get; set; }
            public bool Bool { get; set; }
            public Guid Guid { get; set; }
            public int Int { get; set; }
            public long Long { get; set; }
            public Double Double { get; set; }
            public String String { get; set; }
            public TimeSpan Timespan { get; set; }
            public Decimal Decimal { get; set; }
        }

        private record TestModelForTypesNullable
        {
            public DateTimeOffset? DateTime { get; set; }
            public bool? Bool { get; set; }
            public Guid? Guid { get; set; }
            public int? Int { get; set; }
            public long? Long { get; set; }
            public Double? Double { get; set; }
            public String String { get; set; }
            public TimeSpan? Timespan { get; set; }
            public Decimal? Decimal { get; set; }
        }
    }
}