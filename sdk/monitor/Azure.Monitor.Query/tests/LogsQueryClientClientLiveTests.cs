// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class LogsQueryClientClientLiveTests : RecordedTestBase<MonitorQueryTestEnvironment>
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

        private LogsQueryClient CreateClient()
        {
            return InstrumentClient(new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()
                {
                    Diagnostics = { IsLoggingContentEnabled = true }
                })
            ));
        }

        [RecordedTest]
        public async Task CanQuery()
        {
            var client = CreateClient();

            var results = await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | distinct * |" +
                $"project {LogsTestData.StringColumnName}, {LogsTestData.IntColumnName}, {LogsTestData.BoolColumnName}, {LogsTestData.FloatColumnName} |" +
                $"order by {LogsTestData.StringColumnName} asc",
                _logsTestData.DataTimeRange);

            var resultTable = results.Value.Table;
            CollectionAssert.IsNotEmpty(resultTable.Columns);

            Assert.AreEqual(LogsQueryResultStatus.Success, results.Value.Status);

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

            var results = await client.QueryWorkspaceAsync<string>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | distinct * | project {LogsTestData.StringColumnName} | order by {LogsTestData.StringColumnName} asc",
                _logsTestData.DataTimeRange);

            CollectionAssert.AreEqual(new[] {"a", "b", "c"}, results.Value);
        }

        [RecordedTest]
        public async Task CanQueryPartialSuccess()
        {
            var client = CreateClient();

            var results = await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId,
                $"set truncationmaxrecords=1; datatable (s: string) ['a', 'b']",
                _logsTestData.DataTimeRange, new LogsQueryOptions()
                {
                    AllowPartialErrors = true
                });

            Assert.AreEqual(LogsQueryResultStatus.PartialFailure, results.Value.Status);
            Assert.NotNull(results.Value.Error.Code);
            Assert.NotNull(results.Value.Error.Message);
        }

        [RecordedTest]
        public void ThrowsOnQueryPartialSuccess()
        {
            var client = CreateClient();

            var exception = Assert.ThrowsAsync<RequestFailedException>(() => client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId,
                $"set truncationmaxrecords=1; datatable (s: string) ['a', 'b']",
                _logsTestData.DataTimeRange));

            StringAssert.StartsWith("The result was returned but contained a partial error", exception.Message);
        }

        [RecordedTest]
        public async Task CanQueryAdditionalWorkspace()
        {
            var client = CreateClient();

            var results = await client.QueryWorkspaceAsync<string>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | distinct * | project {LogsTestData.StringColumnName} | order by {LogsTestData.StringColumnName} asc",
                _logsTestData.DataTimeRange, new LogsQueryOptions()
                {
                    AdditionalWorkspaces = { TestEnvironment.SecondaryWorkspaceId }
                });

            CollectionAssert.AreEqual(new[] {"a", "a", "b", "b", "c", "c"}, results.Value);
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitiveInt()
        {
            var client = CreateClient();

            var results = await client.QueryWorkspaceAsync<int>(TestEnvironment.WorkspaceId, $"{_logsTestData.TableAName} | distinct * | count",
                _logsTestData.DataTimeRange);

            Assert.AreEqual(_logsTestData.TableA.Count, results.Value[0]);
        }

        [RecordedTest]
        public async Task CanQueryIntoClass()
        {
            var client = CreateClient();

            var results = await client.QueryWorkspaceAsync<TestModel>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | distinct * |" +
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

            var results = await client.QueryWorkspaceAsync<Dictionary<string, object>>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | distinct * |" +
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

            var results = await client.QueryWorkspaceAsync<IDictionary<string, object>>(TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | distinct * |" +
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
            string id1 = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, "Heartbeat", _logsTestData.DataTimeRange);
            string id2 = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, "Heartbeat", _logsTestData.DataTimeRange);
            Response<LogsBatchQueryResultCollection> response = await client.QueryBatchAsync(batch);

            var result1 = response.Value.GetResult(id1);
            var result2 = response.Value.GetResult(id2);

            CollectionAssert.IsNotEmpty(result1.AllTables[0].Columns);
            CollectionAssert.IsNotEmpty(result2.AllTables[0].Columns);
        }

        [RecordedTest]
        public async Task CanQueryBatchMixed()
        {
            var client = CreateClient();
            LogsBatchQuery batch = new LogsBatchQuery();
            string id1 = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, "Heartbeat", _logsTestData.DataTimeRange);
            string id2 = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, "Heartbeats", _logsTestData.DataTimeRange);
            string id3 = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, "set truncationmaxrecords=1; datatable (s: string) ['a', 'b']", _logsTestData.DataTimeRange);

            Response<LogsBatchQueryResultCollection> response = await client.QueryBatchAsync(batch);

            Assert.AreEqual(LogsQueryResultStatus.Success, response.Value.Single(r => r.Id == id1).Status);

            var failedResult = response.Value.Single(r => r.Id == id2);
            Assert.AreEqual(LogsQueryResultStatus.Failure, failedResult.Status);
            Assert.NotNull(failedResult.Error.Code);
            Assert.NotNull(failedResult.Error.Message);

            var partialResult = response.Value.Single(r => r.Id == id3);
            Assert.AreEqual(LogsQueryResultStatus.PartialFailure, partialResult.Status);
            CollectionAssert.IsNotEmpty(partialResult.Table.Rows);
            Assert.NotNull(partialResult.Error.Code);
            Assert.NotNull(partialResult.Error.Message);
        }

        [RecordedTest]
        public async Task CanQueryAllSupportedTypes()
        {
            var client = CreateClient();

            Response<LogsQueryResult> results = await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId,
                $"datatable (DateTime: datetime, Bool:bool, Guid: guid, Int: int, Long:long, Double: double, String: string, Timespan: timespan, Decimal: decimal, NullBool: bool, Dynamic: dynamic)" +
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
                "bool(null)," +
                "dynamic({\"a\":123, \"b\":\"hello\", \"c\":[1,2,3], \"d\":{}})" +
                "]", _logsTestData.DataTimeRange);

            LogsTableRow row = results.Value.Table.Rows[0];

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
            Assert.Null(row.GetBoolean("NullBool"));
            Assert.Null(row.GetBoolean(9));
            Assert.IsNull(row.GetObject("NullBool"));
            Assert.AreEqual("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}", row.GetDynamic(10).ToString());
            Assert.AreEqual("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}", row.GetDynamic("Dynamic").ToString());
            Assert.AreEqual("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}", row.GetObject("Dynamic").ToString());
        }

        [RecordedTest]
        public async Task CanQueryAllSupportedTypesIntoModel()
        {
            var client = CreateClient();

            Response<IReadOnlyList<TestModelForTypes>> results = await client.QueryWorkspaceAsync<TestModelForTypes>(TestEnvironment.WorkspaceId,
                $"datatable (DateTime: datetime, Bool:bool, Guid: guid, Int: int, Long:long, Double: double, String: string, Timespan: timespan, Decimal: decimal, Dynamic: dynamic)" +
                "[" +
                "datetime(2015-12-31 23:59:59.9)," +
                "false," +
                "guid(74be27de-1e4e-49d9-b579-fe0b331d3642)," +
                "12345," +
                "1234567890123," +
                "12345.6789," +
                "'string value'," +
                "10s," +
                "decimal(0.10101)," +
                "dynamic({\"a\":123, \"b\":\"hello\", \"c\":[1,2,3], \"d\":{}})" +
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
            Assert.AreEqual("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}", row.Dynamic.ToString());
        }

        [RecordedTest]
        public async Task CanQueryAllSupportedTypesIntoModelNullable()
        {
            var client = CreateClient();

            Response<IReadOnlyList<TestModelForTypesNullable>> results = await client.QueryWorkspaceAsync<TestModelForTypesNullable>(TestEnvironment.WorkspaceId,
                $"datatable (DateTime: datetime, Bool:bool, Guid: guid, Int: int, Long:long, Double: double, String: string, Timespan: timespan, Decimal: decimal, Dynamic: dynamic)" +
                "[" +
                "datetime(2015-12-31 23:59:59.9)," +
                "false," +
                "guid(74be27de-1e4e-49d9-b579-fe0b331d3642)," +
                "12345," +
                "1234567890123," +
                "12345.6789," +
                "'string value'," +
                "10s," +
                "decimal(0.10101)," +
                "dynamic({\"a\":123, \"b\":\"hello\", \"c\":[1,2,3], \"d\":{}})" +
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
            Assert.AreEqual("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}", row.Dynamic.ToString());
        }

        [RecordedTest]
        public async Task CanQueryAllSupportedTypesIntoModelNulls()
        {
            var client = CreateClient();

            Response<IReadOnlyList<TestModelForTypesNullable>> results = await client.QueryWorkspaceAsync<TestModelForTypesNullable>(TestEnvironment.WorkspaceId,
                $"datatable (DateTime: datetime, Bool:bool, Guid: guid, Int: int, Long:long, Double: double, String: string, Timespan: timespan, Decimal: decimal, Dynamic: dynamic)" +
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
                "dynamic(null)" +
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
            Assert.IsNull(row.Dynamic);
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitive()
        {
            var client = CreateClient();

            Assert.AreEqual(DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00"), (await client.QueryWorkspaceAsync<DateTimeOffset>(TestEnvironment.WorkspaceId, $"datatable (DateTime: datetime) [ datetime(2015-12-31 23:59:59.9) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(false, (await client.QueryWorkspaceAsync<bool>(TestEnvironment.WorkspaceId, $"datatable (Bool: bool) [ false ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), (await client.QueryWorkspaceAsync<Guid>(TestEnvironment.WorkspaceId, $"datatable (Guid: guid) [ guid(74be27de-1e4e-49d9-b579-fe0b331d3642) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(12345, (await client.QueryWorkspaceAsync<int>(TestEnvironment.WorkspaceId, $"datatable (Int: int) [ 12345 ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(1234567890123, (await client.QueryWorkspaceAsync<long>(TestEnvironment.WorkspaceId, $"datatable (Long: long) [ 1234567890123 ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(12345.6789d, (await client.QueryWorkspaceAsync<double>(TestEnvironment.WorkspaceId, $"datatable (Double: double) [ 12345.6789 ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual("string value", (await client.QueryWorkspaceAsync<string>(TestEnvironment.WorkspaceId, $"datatable (String: string) [ \"string value\" ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(TimeSpan.FromSeconds(10), (await client.QueryWorkspaceAsync<TimeSpan>(TestEnvironment.WorkspaceId, $"datatable (Timespan: timespan) [ 10s ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.AreEqual(0.10101m, (await client.QueryWorkspaceAsync<decimal>(TestEnvironment.WorkspaceId, $"datatable (Decimal: decimal) [ decimal(0.10101) ]", _logsTestData.DataTimeRange)).Value[0]);
        }

        [RecordedTest]
        public async Task CanQueryIntoNullablePrimitive()
        {
            var client = CreateClient();

            Assert.IsNull((await client.QueryWorkspaceAsync<DateTimeOffset?>(TestEnvironment.WorkspaceId, $"datatable (DateTime: datetime) [ datetime(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryWorkspaceAsync<bool?>(TestEnvironment.WorkspaceId, $"datatable (Bool: bool) [ bool(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryWorkspaceAsync<Guid?>(TestEnvironment.WorkspaceId, $"datatable (Guid: guid) [ guid(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryWorkspaceAsync<int?>(TestEnvironment.WorkspaceId, $"datatable (Int: int) [ int(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryWorkspaceAsync<long?>(TestEnvironment.WorkspaceId, $"datatable (Long: long) [ long(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryWorkspaceAsync<double?>(TestEnvironment.WorkspaceId, $"datatable (Double: double) [ double(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryWorkspaceAsync<TimeSpan?>(TestEnvironment.WorkspaceId, $"datatable (Timespan: timespan) [ timespan(null) ]", _logsTestData.DataTimeRange)).Value[0]);
            Assert.IsNull((await client.QueryWorkspaceAsync<decimal?>(TestEnvironment.WorkspaceId, $"datatable (Decimal: decimal) [ decimal(null) ]", _logsTestData.DataTimeRange)).Value[0]);
        }

        [RecordedTest]
        public async Task CanQueryIntoNullablePrimitiveNull()
        {
            var client = CreateClient();

            var results = await client.QueryWorkspaceAsync<DateTimeOffset?>(TestEnvironment.WorkspaceId, $"datatable (DateTime: datetime) [ datetime(null) ]", _logsTestData.DataTimeRange);

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
            var results = await client.QueryWorkspaceAsync<DateTimeOffset>(
                TestEnvironment.WorkspaceId,
                $"{_logsTestData.TableAName} | distinct * | project {LogsTestData.TimeGeneratedColumnName}",
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
            string id1 = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, $"{_logsTestData.TableAName} | distinct * | project {LogsTestData.TimeGeneratedColumnName}", _logsTestData.DataTimeRange);
            string id2 = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, $"{_logsTestData.TableAName} | distinct * | project {LogsTestData.TimeGeneratedColumnName}", timespan);
            Response<LogsBatchQueryResultCollection> response = await client.QueryBatchAsync(batch);

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
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId, "this won't work", _logsTestData.DataTimeRange));

            Assert.AreEqual("BadArgumentError", exception.ErrorCode);
            StringAssert.StartsWith("The request had some invalid properties", exception.Message);
        }

        [RecordedTest]
        public async Task ThrowsExceptionWhenQueryFailsBatch()
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            var queryId = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, "this won't work", _logsTestData.DataTimeRange);
            var batchResult = await client.QueryBatchAsync(batch);

            var exception = Assert.Throws<RequestFailedException>(() => batchResult.Value.GetResult(queryId));

            Assert.AreEqual("BadArgumentError", exception.ErrorCode);
            StringAssert.StartsWith("Batch query with id '0' failed.", exception.Message);
        }

        [RecordedTest]
        public async Task ThrowsExceptionWhenPartialSuccess()
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            var queryId = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, "set truncationmaxrecords=1; datatable (s: string) ['a', 'b']", _logsTestData.DataTimeRange);
            var batchResult = await client.QueryBatchAsync(batch);

            var exception = Assert.Throws<RequestFailedException>(() => batchResult.Value.GetResult(queryId));

            Assert.AreEqual("PartialError", exception.ErrorCode);
            StringAssert.StartsWith("The result was returned but contained a partial error", exception.Message);
        }

        [RecordedTest]
        public async Task ThrowsExceptionWhenBatchQueryNotFound()
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, _logsTestData.TableAName, _logsTestData.DataTimeRange);

            var batchResult = await client.QueryBatchAsync(batch);

            var exception = Assert.Throws<ArgumentException>(() => batchResult.Value.GetResult("12345"));

            Assert.AreEqual("queryId", exception.ParamName);
            StringAssert.StartsWith("Query with ID '12345' wasn't part of the batch. Please use the return value of LogsBatchQuery.AddWorkspaceQuery as the 'queryId' argument.", exception.Message);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanQueryWithStatistics(bool include)
        {
            var client = CreateClient();

            var response = await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId, _logsTestData.TableAName, _logsTestData.DataTimeRange, options: new LogsQueryOptions()
            {
                IncludeStatistics = include
            });

            if (include)
            {
                using JsonDocument document = JsonDocument.Parse(response.Value.GetStatistics());
                Assert.GreaterOrEqual(document.RootElement.GetProperty("query").GetProperty("executionTime").GetDouble(), 0);
            }
            else
            {
                Assert.AreEqual(default, response.Value.GetStatistics());
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanQueryWithVisualization(bool include)
        {
            var client = CreateClient();

            var response = await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId, "datatable (s: string, i: long) [ \"a\", 1, \"b\", 2, \"c\", 3 ] | render columnchart", _logsTestData.DataTimeRange, options: new LogsQueryOptions()
            {
                IncludeVisualization = include
            });

            if (include)
            {
                using JsonDocument document = JsonDocument.Parse(response.Value.GetVisualization());
                Assert.AreNotEqual(JsonValueKind.Undefined, document.RootElement.GetProperty("visualization").ValueKind);
            }
            else
            {
                Assert.AreEqual(default, response.Value.GetVisualization());
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanQueryWithStatisticsBatch(bool include)
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            var queryId = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, _logsTestData.TableAName, _logsTestData.DataTimeRange, options: new LogsQueryOptions()
            {
                IncludeStatistics = include
            });
            var batchResult = await client.QueryBatchAsync(batch);
            var result = batchResult.Value.GetResult(queryId);

            if (include)
            {
                using JsonDocument document = JsonDocument.Parse(result.GetStatistics());
                Assert.GreaterOrEqual(document.RootElement.GetProperty("query").GetProperty("executionTime").GetDouble(), 0);
            }
            else
            {
                Assert.AreEqual(default, result.GetStatistics());
            }
        }

        [RecordedTest]
        public async Task CanSetServiceTimeout()
        {
            var client = CreateClient();

            // Sometimes the service doesn't abort the query quickly enough
            // and the request gets aborted instead
            // Retry until we get the service to abort
            while (true)
            {
                // Punch through caching
                var cnt = 100000000000 + Recording.Random.Next(10000);
                try
                {
                    await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId, $"range x from 1 to {cnt} step 1 | count", _logsTestData.DataTimeRange, options: new LogsQueryOptions()
                    {
                        ServerTimeout = TimeSpan.FromSeconds(1)
                    });
                }
                catch (AggregateException)
                {
                    // The client cancelled, retry.
                    continue;
                }
                catch (TaskCanceledException)
                {
                    // The client cancelled, retry.
                    continue;
                }
                catch (RequestFailedException exception)
                {
                    // Cancellation can be observed as either 504 response code from the gateway
                    // or a partial failure 200 response
                    if (exception.Status == 200)
                    {
                        StringAssert.Contains("Query cancelled by the user's request", exception.Message);
                    }
                    else
                    {
                        Assert.AreEqual(504, exception.Status);
                    }
                    return;
                }
            }
        }

        [RecordedTest]
        [TestCaseSource(nameof(Queries))]
        public async Task CanQueryWithFormattedQuery(FormattableStringWrapper query)
        {
            var client = CreateClient();

            var response = await client.QueryWorkspaceAsync<bool>(TestEnvironment.WorkspaceId, LogsQueryClient.CreateQuery(query.Value), _logsTestData.DataTimeRange);
            Assert.True(response.Value.Single());
        }

        public static IEnumerable<FormattableStringWrapper> Queries
        {
            get
            {
                yield return new($"print {true} == true");
                yield return new($"print {false} == false");
                yield return new($"print {(byte)1} == int(1)");
                yield return new($"print {(sbyte)2} == int(2)");
                yield return new($"print {(ushort)3} == int(3)");
                yield return new($"print {(short)4} == int(4)");
                yield return new($"print {(uint)5} == int(5)");
                yield return new($"print {(int)6} == int(6)");

                yield return new($"print {1000000000} == int(1000000000)");
                yield return new($"print {1.1F} == real(1.1)");
                yield return new($"print {1.2D} == real(1.2)");
                yield return new($"print {1.3M} == decimal(1.3)");
                yield return new($"print {1000000000000000000L} == long(1000000000000000000)");
                yield return new($"print {1000000000000000001UL} == long(1000000000000000001)");

                yield return new($"print {Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")} == guid(74be27de-1e4e-49d9-b579-fe0b331d3642)");

                yield return new($"print {DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00", null, DateTimeStyles.RoundtripKind)} == datetime(2015-12-31 23:59:59.9)");
                yield return new($"print {DateTime.Parse("2015-12-31 23:59:59.9+00:00", null, DateTimeStyles.RoundtripKind)} == datetime(2015-12-31 23:59:59.9)");

                yield return new($"print {TimeSpan.FromSeconds(10)} == 10s");

                yield return new($"print {"hello world"} == \"hello world\"");
                yield return new($"print {"hello \" world"} == \"hello \\\" world\"");
                yield return new($"print {"\\\""} == \"\\\\\\\"\"");

                yield return new($"print {"\r\n\t"} == \"\\r\\n\\t\"");

                yield return new($"print {'"'} == \"\\\"\"");
                yield return new($"print {'\''} == \"'\"");
            }
        }

        // To fix recording names
        public readonly struct FormattableStringWrapper
        {
            public FormattableString Value { get; }

            public FormattableStringWrapper(FormattableString value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return string.Format(Value.Format, Value.GetArguments().Select(a => a?.GetType().Name).ToArray());
            }
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
            public BinaryData Dynamic { get; set; }
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
            public BinaryData Dynamic { get; set; }
        }

        [RecordedTest]
        public async Task ValidateNanAndInfResultsDoubleAsync()
        {
            var client = CreateClient();
            var results = await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId, "print real(nan), real(+inf), real(-inf), real(null), real(123)", TimeSpan.FromMinutes(1));

            var resultTable = results.Value.Table;
            CollectionAssert.IsNotEmpty(resultTable.Columns);

            Assert.AreEqual(LogsQueryResultStatus.Success, results.Value.Status);
            Assert.AreEqual(double.NaN, resultTable.Rows[0][0]);
            Assert.AreEqual(double.PositiveInfinity, resultTable.Rows[0][1]);
            Assert.AreEqual(double.NegativeInfinity, resultTable.Rows[0][2]);
            Assert.AreEqual(null, resultTable.Rows[0][3]);
            Assert.AreEqual(123, resultTable.Rows[0][4]);
        }
    }
}
