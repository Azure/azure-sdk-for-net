// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Logs.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Monitor.Query.Logs.Tests
{
    public class LogsQueryClientLiveTests : RecordedTestBase<MonitorQueryLogsTestEnvironment>
    {
        private const string MockQuery =
            "let dt = datatable (Int: int, String: string, Bool:bool, Double: double)\n" +
            "[" +
            "1, 'a', false, 0.0, " +
            "2, 'b', true, 1.2," +
            "3, 'c', false, 1.1]; " +
            "dt |distinct * | project String, Int, Bool, Double | order by String asc";

        private LogsTestData _logsTestData;

        public LogsQueryClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _logsTestData = new LogsTestData(this);

            if (TestEnvironment.Mode == RecordedTestMode.Playback)
            {
                return;
            }

            // If we're not in playback mode, attempt to query some data
            // and if not found, initialize.

            try
            {
                var client = new LogsQueryClient(
                    new Uri(TestEnvironment.GetLogsAudience()),
                    TestEnvironment.Credential,
                    new LogsQueryClientOptions
                    { Audience = TestEnvironment.GetLogsAudience() });

                var result = await client.QueryWorkspaceAsync(
                    TestEnvironment.WorkspaceId,
                    $@"{MockQuery} | limit 1",
                    _logsTestData.DataTimeRange,
                    new LogsQueryOptions { AllowPartialErrors = true });

                if (result.Value.Table.Rows.Count > 0)
                {
                    // Data exists, return.
                    return;
                }
            }
            catch (RequestFailedException)
            {
                // Swallow any exception and attempt to initialize.
            }

            await _logsTestData.InitializeAsync();
        }

        private LogsQueryClient CreateClient()
        {
            return InstrumentClient(new LogsQueryClient(
                new Uri(TestEnvironment.GetLogsAudience()),
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()
                {
                    Diagnostics = { IsLoggingContentEnabled = true },
                    Audience = TestEnvironment.GetLogsAudience()
                })
            ));
        }

        [RecordedTest]
        public async Task CanQuery()
        {
            var client = CreateClient();

            var results = await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId,
                MockQuery,
                _logsTestData.DataTimeRange);
            var resultTable = results.Value.Table;
            Assert.That(resultTable.Columns, Is.Not.Empty);

            Assert.Multiple(() =>
            {
                Assert.That(results.Value.Status, Is.EqualTo(LogsQueryResultStatus.Success));

                Assert.That(resultTable.Rows[0].GetString(0), Is.EqualTo("a"));
                Assert.That(resultTable.Rows[0].GetString(LogsTestData.StringColumnName), Is.EqualTo("a"));

                Assert.That(resultTable.Rows[0].GetInt32(1), Is.EqualTo(1));
                Assert.That(resultTable.Rows[0].GetInt32(LogsTestData.IntColumnName), Is.EqualTo(1));

                Assert.That(resultTable.Rows[0].GetBoolean(2), Is.EqualTo(false));
                Assert.That(resultTable.Rows[0].GetBoolean(LogsTestData.BoolColumnName), Is.EqualTo(false));

                Assert.That(resultTable.Rows[0].GetDouble(3), Is.EqualTo(0.0));
                Assert.That(resultTable.Rows[0].GetDouble(LogsTestData.DoubleColumnName), Is.EqualTo(0.0));
            });
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitiveString()
        {
            var client = CreateClient();

            string mockQuery = "let dt = datatable (Int: int, String: string, Bool:bool, Double: double)\n" +
                "[" +
                "1, 'a', false, 0.0, " +
                "2, 'b', true, 1.2," +
                "3, 'c', false, 1.1]; " +
                "dt |distinct * | project String, Int, Bool, Double | order by String asc";

            var results = await client.QueryWorkspaceAsync<string>(TestEnvironment.WorkspaceId,
               mockQuery,
                _logsTestData.DataTimeRange);

            Assert.That(results.Value, Is.EqualTo(new[] { "a", "b", "c" }).AsCollection);
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

            Assert.Multiple(() =>
            {
                Assert.That(results.Value.Status, Is.EqualTo(LogsQueryResultStatus.PartialFailure));
                Assert.That(results.Value.Error.Code, Is.Not.Null);
                Assert.That(results.Value.Error.Message, Is.Not.Null);
            });
        }

        [RecordedTest]
        public void ThrowsOnQueryPartialSuccess()
        {
            var client = CreateClient();

            var exception = Assert.ThrowsAsync<RequestFailedException>(() => client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId,
                $"set truncationmaxrecords=1; datatable (s: string) ['a', 'b']",
                _logsTestData.DataTimeRange));

            Assert.That(exception.Message, Does.StartWith("The result was returned but contained a partial error"));
        }

        [RecordedTest]
        public async Task CanQueryAdditionalWorkspace()
        {
            var client = CreateClient();

            string mockQuery = "let dt = datatable (Int: int, String: string, Bool:bool, Double: double)\n" +
                "[" +
                "1, 'a', false, 0.0, " +
                "2, 'b', true, 1.2," +
                "3, 'c', false, 1.1]; " +
                "dt |distinct * | project String, Int, Bool, Double | order by String asc";

            var results = await client.QueryWorkspaceAsync<string>(TestEnvironment.WorkspaceId,
                mockQuery,
                _logsTestData.DataTimeRange, new LogsQueryOptions()
                {
                    AdditionalWorkspaces = { TestEnvironment.SecondaryWorkspaceId }
                });

            Assert.That(results.Value, Has.Member("a"));
            Assert.That(results.Value, Has.Member("b"));
            Assert.That(results.Value, Has.Member("c"));
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitiveInt()
        {
            var client = CreateClient();

            string mockQuery = "let dt = datatable (Int: int, String: string, Bool:bool, Double: double)\n" +
                "[" +
                "1, 'a', false, 0.0, " +
                "2, 'b', true, 1.2," +
                "3, 'c', false, 1.1]; " +
                "dt |distinct String, Int | count";

            var results = await client.QueryWorkspaceAsync<int>(TestEnvironment.WorkspaceId,
                mockQuery,
                _logsTestData.DataTimeRange);

            Assert.That(_logsTestData.TableA, Has.Count.GreaterThanOrEqualTo(results.Value[0]));
        }

        [RecordedTest]
        public async Task CanQueryIntoClass()
        {
            var client = CreateClient();

            string mockQuery = "let dt = datatable (Int: int, String: string, Bool:bool, Double: double)\n" +
                "[" +
                "1, 'a', false, 0.0, " +
                "2, 'b', true, 1.2," +
                "3, 'c', false, 1.1]; " +
                "dt |distinct * | project-rename Name = String, Age = Int | order by Name asc";

            var results = await client.QueryWorkspaceAsync<TestModel>(TestEnvironment.WorkspaceId,
                mockQuery,
                _logsTestData.DataTimeRange);

            Assert.That(results.Value, Does.Contain(new TestModel() { Age = 1, Name = "a" }));
            Assert.That(results.Value, Does.Contain(new TestModel() { Age = 2, Name = "b" }));
            Assert.That(results.Value, Does.Contain(new TestModel() { Age = 3, Name = "c" }));
        }

        [RecordedTest]
        public async Task CanQueryIntoDictionary()
        {
            var client = CreateClient();

            string mockQuery = "let dt = datatable (Int: int, String: string, Bool:bool, Double: double)\n" +
                "[" +
                "1, 'a', false, 0.0, " +
                "2, 'b', true, 1.2," +
                "3, 'c', false, 1.1]; " +
                "dt |distinct * | project-rename Name = String, Age = Int | project Name, Age | order by Name asc";

            var results = await client.QueryWorkspaceAsync<Dictionary<string, object>>(TestEnvironment.WorkspaceId,
               mockQuery,
                _logsTestData.DataTimeRange);

            Assert.That(results.Value, Is.EqualTo(new[]
            {
                new Dictionary<string, object>() {{"Age", 1}, {"Name", "a"}},
                new Dictionary<string, object>() {{"Age", 2}, {"Name", "b"}},
                new Dictionary<string, object>() {{"Age", 3}, {"Name", "c"}}
            }).AsCollection);
        }

        [RecordedTest]
        public async Task CanQueryIntoIDictionary()
        {
            var client = CreateClient();

            string mockQuery = "let dt = datatable (Int: int, String: string, Bool:bool, Double: double)\n" +
                "[" +
                "1, 'a', false, 0.0, " +
                "2, 'b', true, 1.2," +
                "3, 'c', false, 1.1]; " +
                "dt |distinct * | project-rename Name = String, Age = Int | project Name, Age | order by Name asc";

            Response<IReadOnlyList<IDictionary<string, object>>> results = await client.QueryWorkspaceAsync<IDictionary<string, object>>(TestEnvironment.WorkspaceId,
                mockQuery,
                _logsTestData.DataTimeRange);

            Assert.That(results.Value, Is.EqualTo(new[]
            {
                new Dictionary<string, object>() {{"Age", 1}, {"Name", "a"}},
                new Dictionary<string, object>() {{"Age", 2}, {"Name", "b"}},
                new Dictionary<string, object>() {{"Age", 3}, {"Name", "c"}}
            }).AsCollection);
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

            Assert.That(result1.AllTables[0].Columns, Is.Not.Empty);
            Assert.That(result2.AllTables[0].Columns, Is.Not.Empty);
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

            Assert.That(response.Value.Single(r => r.Id == id1).Status, Is.EqualTo(LogsQueryResultStatus.Success));

            var failedResult = response.Value.Single(r => r.Id == id2);
            Assert.Multiple(() =>
            {
                Assert.That(failedResult.Status, Is.EqualTo(LogsQueryResultStatus.Failure));
                Assert.That(failedResult.Error.Code, Is.Not.Null);
                Assert.That(failedResult.Error.Message, Is.Not.Null);
            });

            var partialResult = response.Value.Single(r => r.Id == id3);
            Assert.That(partialResult.Status, Is.EqualTo(LogsQueryResultStatus.PartialFailure));
            Assert.That(partialResult.Table.Rows, Is.Not.Empty);
            Assert.Multiple(() =>
            {
                Assert.That(partialResult.Error.Code, Is.Not.Null);
                Assert.That(partialResult.Error.Message, Is.Not.Null);
            });
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
            Assert.Multiple(() =>
            {
                Assert.That(row.GetDateTimeOffset("DateTime"), Is.EqualTo(expectedDate));
                Assert.That(row.GetDateTimeOffset(0), Is.EqualTo(expectedDate));
                Assert.That(row.GetObject("DateTime"), Is.EqualTo(expectedDate));
                Assert.That(row.GetBoolean("Bool"), Is.EqualTo(false));
                Assert.That(row.GetBoolean(1), Is.EqualTo(false));
                Assert.That(row.GetObject("Bool"), Is.EqualTo(false));
                Assert.That(row.GetGuid("Guid"), Is.EqualTo(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")));
                Assert.That(row.GetGuid(2), Is.EqualTo(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")));
                Assert.That(row.GetObject("Guid"), Is.EqualTo(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")));
                Assert.That(row.GetInt32("Int"), Is.EqualTo(12345));
                Assert.That(row.GetInt32(3), Is.EqualTo(12345));
                Assert.That(row.GetObject("Int"), Is.EqualTo(12345));
                Assert.That(row.GetInt64("Long"), Is.EqualTo(1234567890123));
                Assert.That(row.GetInt64(4), Is.EqualTo(1234567890123));
                Assert.That(row.GetObject("Long"), Is.EqualTo(1234567890123));
                Assert.That(row.GetDouble("Double"), Is.EqualTo(12345.6789d));
                Assert.That(row.GetDouble(5), Is.EqualTo(12345.6789d));
                Assert.That(row.GetObject("Double"), Is.EqualTo(12345.6789d));
                Assert.That(row.GetString("String"), Is.EqualTo("string value"));
                Assert.That(row.GetString(6), Is.EqualTo("string value"));
                Assert.That(row.GetObject("String"), Is.EqualTo("string value"));
                Assert.That(row.GetTimeSpan("Timespan"), Is.EqualTo(TimeSpan.FromSeconds(10)));
                Assert.That(row.GetTimeSpan(7), Is.EqualTo(TimeSpan.FromSeconds(10)));
                Assert.That(row.GetObject("Timespan"), Is.EqualTo(TimeSpan.FromSeconds(10)));
                Assert.That(row.GetDecimal("Decimal"), Is.EqualTo(0.10101m));
                Assert.That(row.GetDecimal(8), Is.EqualTo(0.10101m));
                Assert.That(row.GetObject("Decimal"), Is.EqualTo(0.10101m));
                Assert.That(row.GetBoolean("NullBool"), Is.Null);
                Assert.That(row.GetBoolean(9), Is.Null);
                Assert.That(row.GetObject("NullBool"), Is.Null);
                Assert.That(row.GetDynamic(10).ToString(), Is.EqualTo("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}"));
                Assert.That(row.GetDynamic("Dynamic").ToString(), Is.EqualTo("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}"));
                Assert.That(row.GetObject("Dynamic").ToString(), Is.EqualTo("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}"));
            });
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

            Assert.That(row.DateTime, Is.EqualTo(DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00")));
            Assert.That(row.Bool, Is.EqualTo(false));
            Assert.That(row.Guid, Is.EqualTo(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")));
            Assert.That(row.Int, Is.EqualTo(12345));
            Assert.That(row.Long, Is.EqualTo(1234567890123));
            Assert.That(row.Double, Is.EqualTo(12345.6789d));
            Assert.That(row.String, Is.EqualTo("string value"));
            Assert.That(row.Timespan, Is.EqualTo(TimeSpan.FromSeconds(10)));
            Assert.That(row.Decimal, Is.EqualTo(0.10101m));
            Assert.That(row.Dynamic.ToString(), Is.EqualTo("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}"));
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

            Assert.That(row.DateTime, Is.EqualTo(DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00")));
            Assert.That(row.Bool, Is.EqualTo(false));
            Assert.That(row.Guid, Is.EqualTo(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")));
            Assert.That(row.Int, Is.EqualTo(12345));
            Assert.That(row.Long, Is.EqualTo(1234567890123));
            Assert.That(row.Double, Is.EqualTo(12345.6789d));
            Assert.That(row.String, Is.EqualTo("string value"));
            Assert.That(row.Timespan, Is.EqualTo(TimeSpan.FromSeconds(10)));
            Assert.That(row.Decimal, Is.EqualTo(0.10101m));
            Assert.That(row.Dynamic.ToString(), Is.EqualTo("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}"));
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

            Assert.That(row.DateTime, Is.Null);
            Assert.That(row.Bool, Is.Null);
            Assert.That(row.Guid, Is.Null);
            Assert.That(row.Int, Is.Null);
            Assert.That(row.Long, Is.Null);
            Assert.That(row.Double, Is.Null);
            Assert.That(row.String, Is.EqualTo("I cant be null"));
            Assert.That(row.Timespan, Is.Null);
            Assert.That(row.Decimal, Is.Null);
            Assert.That(row.Dynamic, Is.Null);
        }

        [RecordedTest]
        public async Task CanQueryIntoPrimitive()
        {
            var client = CreateClient();

            Assert.That((await client.QueryWorkspaceAsync<DateTimeOffset>(TestEnvironment.WorkspaceId, $"datatable (DateTime: datetime) [ datetime(2015-12-31 23:59:59.9) ]", _logsTestData.DataTimeRange)).Value[0], Is.EqualTo(DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00")));
            Assert.That((await client.QueryWorkspaceAsync<bool>(TestEnvironment.WorkspaceId, $"datatable (Bool: bool) [ false ]", _logsTestData.DataTimeRange)).Value[0], Is.EqualTo(false));
            Assert.That((await client.QueryWorkspaceAsync<Guid>(TestEnvironment.WorkspaceId, $"datatable (Guid: guid) [ guid(74be27de-1e4e-49d9-b579-fe0b331d3642) ]", _logsTestData.DataTimeRange)).Value[0], Is.EqualTo(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")));
            Assert.That((await client.QueryWorkspaceAsync<int>(TestEnvironment.WorkspaceId, $"datatable (Int: int) [ 12345 ]", _logsTestData.DataTimeRange)).Value[0], Is.EqualTo(12345));
            Assert.That((await client.QueryWorkspaceAsync<long>(TestEnvironment.WorkspaceId, $"datatable (Long: long) [ 1234567890123 ]", _logsTestData.DataTimeRange)).Value[0], Is.EqualTo(1234567890123));
            Assert.That((await client.QueryWorkspaceAsync<double>(TestEnvironment.WorkspaceId, $"datatable (Double: double) [ 12345.6789 ]", _logsTestData.DataTimeRange)).Value[0], Is.EqualTo(12345.6789d));
            Assert.That((await client.QueryWorkspaceAsync<string>(TestEnvironment.WorkspaceId, $"datatable (String: string) [ \"string value\" ]", _logsTestData.DataTimeRange)).Value[0], Is.EqualTo("string value"));
            Assert.That((await client.QueryWorkspaceAsync<TimeSpan>(TestEnvironment.WorkspaceId, $"datatable (Timespan: timespan) [ 10s ]", _logsTestData.DataTimeRange)).Value[0], Is.EqualTo(TimeSpan.FromSeconds(10)));
            Assert.That((await client.QueryWorkspaceAsync<decimal>(TestEnvironment.WorkspaceId, $"datatable (Decimal: decimal) [ decimal(0.10101) ]", _logsTestData.DataTimeRange)).Value[0], Is.EqualTo(0.10101m));
        }

        [RecordedTest]
        public async Task CanQueryIntoNullablePrimitive()
        {
            var client = CreateClient();

            Assert.That((await client.QueryWorkspaceAsync<DateTimeOffset?>(TestEnvironment.WorkspaceId, $"datatable (DateTime: datetime) [ datetime(null) ]", _logsTestData.DataTimeRange)).Value[0], Is.Null);
            Assert.That((await client.QueryWorkspaceAsync<bool?>(TestEnvironment.WorkspaceId, $"datatable (Bool: bool) [ bool(null) ]", _logsTestData.DataTimeRange)).Value[0], Is.Null);
            Assert.That((await client.QueryWorkspaceAsync<Guid?>(TestEnvironment.WorkspaceId, $"datatable (Guid: guid) [ guid(null) ]", _logsTestData.DataTimeRange)).Value[0], Is.Null);
            Assert.That((await client.QueryWorkspaceAsync<int?>(TestEnvironment.WorkspaceId, $"datatable (Int: int) [ int(null) ]", _logsTestData.DataTimeRange)).Value[0], Is.Null);
            Assert.That((await client.QueryWorkspaceAsync<long?>(TestEnvironment.WorkspaceId, $"datatable (Long: long) [ long(null) ]", _logsTestData.DataTimeRange)).Value[0], Is.Null);
            Assert.That((await client.QueryWorkspaceAsync<double?>(TestEnvironment.WorkspaceId, $"datatable (Double: double) [ double(null) ]", _logsTestData.DataTimeRange)).Value[0], Is.Null);
            Assert.That((await client.QueryWorkspaceAsync<TimeSpan?>(TestEnvironment.WorkspaceId, $"datatable (Timespan: timespan) [ timespan(null) ]", _logsTestData.DataTimeRange)).Value[0], Is.Null);
            Assert.That((await client.QueryWorkspaceAsync<decimal?>(TestEnvironment.WorkspaceId, $"datatable (Decimal: decimal) [ decimal(null) ]", _logsTestData.DataTimeRange)).Value[0], Is.Null);
        }

        [RecordedTest]
        public async Task CanQueryIntoNullablePrimitiveNull()
        {
            var client = CreateClient();

            var results = await client.QueryWorkspaceAsync<DateTimeOffset?>(TestEnvironment.WorkspaceId, $"datatable (DateTime: datetime) [ datetime(null) ]", _logsTestData.DataTimeRange);

            Assert.That(results.Value[0], Is.Null);
        }

        [RecordedTest]
        public async Task CanQueryWithTimespan()
        {
            var timespan = TimeSpan.FromSeconds(5);
            DateTime recordingUtcNow = DateTime.SpecifyKind(Recording.UtcNow.Date, DateTimeKind.Utc).AddDays(-14);
            string mockQuery = "let dt = datatable (Int: int, String: string, Bool: bool, TimeGenerated: datetime)\n" +
                "[" +
                $"1, 'a', false, datetime(\"{recordingUtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\"), " +
                $"2, 'b', true, datetime(\"{recordingUtcNow.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")," +
                $"3, 'c', false, datetime(\"{recordingUtcNow.AddDays(5).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")]; " +
                "dt | distinct * | project TimeGenerated";

            var client = CreateClient();
            var results = await client.QueryWorkspaceAsync<DateTimeOffset>(
                TestEnvironment.WorkspaceId,
                mockQuery,
                timespan);

            Assert.That(results.Value, Has.Count.GreaterThanOrEqualTo(3));
        }

        [RecordedTest]
        public async Task CanQueryBatchWithTimespan()
        {
            var timespan = TimeSpan.FromSeconds(5);

            var client = CreateClient();

            DateTime recordingUtcNow = DateTime.SpecifyKind(Recording.UtcNow.Date, DateTimeKind.Utc).AddDays(-14);
            string mockQuery = "let dt = datatable (Int: int, String: string, Bool: bool, TimeGenerated: datetime)\n" +
                "[" +
                $"1, 'a', false, datetime(\"{recordingUtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\"), " +
                $"2, 'b', true, datetime(\"{recordingUtcNow.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")," +
                $"3, 'c', false, datetime(\"{recordingUtcNow.AddDays(5).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")]; " +
                "dt | distinct * | project TimeGenerated";

            // empty check
            LogsBatchQuery batch = new LogsBatchQuery();
            string id1 = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, mockQuery, timespan);

            // check if all rows in table were uploaded
            var maxOffset = (DateTimeOffset)_logsTestData.TableA[2][LogsTestData.TimeGeneratedColumnNameSent];
            timespan = Recording.UtcNow - maxOffset;
            timespan = timespan.Add(TimeSpan.FromDays(7));
            string id2 = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, mockQuery, timespan);

            Response<LogsBatchQueryResultCollection> response = await client.QueryBatchAsync(batch);

            var result1 = response.Value.GetResult<DateTimeOffset>(id1);
            var result2 = response.Value.GetResult<DateTimeOffset>(id2);

            Assert.That(result2, Has.Count.GreaterThanOrEqualTo(3));
        }

        [RecordedTest]
        public void ThrowsExceptionWhenQueryFails()
        {
            var client = CreateClient();
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId, "this won't work", _logsTestData.DataTimeRange));

            Assert.That(exception.ErrorCode, Is.EqualTo("BadArgumentError"));
            Assert.That(exception.Message, Does.StartWith("The request had some invalid properties"));
        }

        [RecordedTest]
        public async Task ThrowsExceptionWhenQueryFailsBatch()
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            var queryId = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, "this won't work", _logsTestData.DataTimeRange);
            var batchResult = await client.QueryBatchAsync(batch);

            var exception = Assert.Throws<RequestFailedException>(() => batchResult.Value.GetResult(queryId));

            Assert.That(exception.ErrorCode, Is.EqualTo("BadArgumentError"));
            Assert.That(exception.Message, Does.StartWith("Batch query with id '0' failed."));
        }

        [RecordedTest]
        public async Task ThrowsExceptionWhenPartialSuccess()
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            var queryId = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, "set truncationmaxrecords=1; datatable (s: string) ['a', 'b']", _logsTestData.DataTimeRange);
            var batchResult = await client.QueryBatchAsync(batch);

            var exception = Assert.Throws<RequestFailedException>(() => batchResult.Value.GetResult(queryId));

            Assert.That(exception.ErrorCode, Is.EqualTo("PartialError"));
            Assert.That(exception.Message, Does.StartWith("The result was returned but contained a partial error"));
        }

        [RecordedTest]
        public async Task ThrowsExceptionWhenBatchQueryNotFound()
        {
            var client = CreateClient();

            LogsBatchQuery batch = new LogsBatchQuery();
            batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, _logsTestData.TableAName, _logsTestData.DataTimeRange);

            var batchResult = await client.QueryBatchAsync(batch);

            var exception = Assert.Throws<ArgumentException>(() => batchResult.Value.GetResult("12345"));

            Assert.That(exception.ParamName, Is.EqualTo("queryId"));
            Assert.That(exception.Message, Does.StartWith("Query with ID '12345' wasn't part of the batch. Please use the return value of LogsBatchQuery.AddWorkspaceQuery as the 'queryId' argument."));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanQueryWithStatistics(bool include)
        {
            var client = CreateClient();
            string mockQuery = "let dt = datatable (Int: int, String: string, Bool:bool, Double: double)\n" +
                "[" +
                "1, 'a', false, 0.0, " +
                "2, 'b', true, 1.2," +
                "3, 'c', false, 1.1, " +
                "4, 'd', true, 3.14]; " +
                "dt";

            var response = await client.QueryWorkspaceAsync(TestEnvironment.WorkspaceId, mockQuery, _logsTestData.DataTimeRange, options: new LogsQueryOptions()
            {
                IncludeStatistics = include
            });

            if (include)
            {
                using JsonDocument document = JsonDocument.Parse(response.Value.GetStatistics());
                Assert.That(document.RootElement.GetProperty("query").GetProperty("executionTime").GetDouble(), Is.GreaterThanOrEqualTo(0));
            }
            else
            {
                Assert.That(response.Value.GetStatistics(), Is.EqualTo(default(BinaryData)));
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
                Assert.That(document.RootElement.GetProperty("visualization").ValueKind, Is.Not.EqualTo(JsonValueKind.Undefined));
            }
            else
            {
                Assert.That(response.Value.GetVisualization(), Is.EqualTo(default(BinaryData)));
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanQueryWithStatisticsBatch(bool include)
        {
            var client = CreateClient();

            string mockQuery = "let dt = datatable (Int: int, String: string, Bool:bool, Double: double)\n" +
                "[" +
                "1, 'a', false, 0.0, " +
                "2, 'b', true, 1.2," +
                "3, 'c', false, 1.1]; " +
                "dt";
            LogsBatchQuery batch = new LogsBatchQuery();
            var queryId = batch.AddWorkspaceQuery(TestEnvironment.WorkspaceId, mockQuery, _logsTestData.DataTimeRange, options: new LogsQueryOptions()
            {
                IncludeStatistics = include
            });
            var batchResult = await client.QueryBatchAsync(batch);
            var result = batchResult.Value.GetResult(queryId);

            if (include)
            {
                using JsonDocument document = JsonDocument.Parse(result.GetStatistics());
                Assert.That(document.RootElement.GetProperty("query").GetProperty("executionTime").GetDouble(), Is.GreaterThanOrEqualTo(0));
            }
            else
            {
                Assert.That(result.GetStatistics(), Is.EqualTo(default(BinaryData)));
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
                        Assert.That(exception.Message, Does.Contain("PartialError"));
                    }
                    else
                    {
                        Assert.That(exception.Status, Is.EqualTo(504));
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
            Assert.That(response.Value.Single(), Is.True);
        }

        [Test]
        public async Task CanQueryResourceGenericPrimaryWorkspace()
        {
            var timespan = TimeSpan.FromSeconds(5);

            var client = CreateClient();

            DateTime recordingUtcNow = DateTime.SpecifyKind(Recording.UtcNow.Date, DateTimeKind.Utc).AddDays(-14);
            string mockQuery = "let dt = datatable (Int: int, String: string, Bool: bool, TimeGenerated: datetime)\n" +
                "[" +
                $"1, 'a', false, datetime(\"{recordingUtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\"), " +
                $"2, 'b', true, datetime(\"{recordingUtcNow.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")," +
                $"3, 'c', false, datetime(\"{recordingUtcNow.AddDays(5).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")]; " +
                "dt | distinct * | project TimeGenerated";

            // Make sure there is some data in the range specified
            var results = await client.QueryResourceAsync<DateTimeOffset>(
                new ResourceIdentifier(TestEnvironment.WorkspacePrimaryResourceId),
                mockQuery,
                timespan);

            Assert.That(results.Value, Has.Count.GreaterThanOrEqualTo(3));
        }

        [Test]
        public async Task CanQueryResourcePrimaryWorkspace()
        {
            var timespan = TimeSpan.FromSeconds(5);

            var client = CreateClient();
            DateTime recordingUtcNow = DateTime.SpecifyKind(Recording.UtcNow.Date, DateTimeKind.Utc).AddDays(-14);
            string mockQuery = "let dt = datatable (Int: int, String: string, Bool: bool, TimeGenerated: datetime)\n" +
                "[" +
                $"1, 'a', false, datetime(\"{recordingUtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\"), " +
                $"2, 'b', true, datetime(\"{recordingUtcNow.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")," +
                $"3, 'c', false, datetime(\"{recordingUtcNow.AddDays(5).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")]; " +
                "dt | distinct * | project TimeGenerated";

            var results = await client.QueryResourceAsync(
                new ResourceIdentifier(TestEnvironment.WorkspacePrimaryResourceId),
                mockQuery,
                timespan);

            Assert.That(results.Value.Table.Rows, Has.Count.GreaterThanOrEqualTo(3));
        }

        [Test]
        public async Task CanQueryResourceSecondaryWorkspace()
        {
            var timespan = TimeSpan.FromSeconds(5);

            var client = CreateClient();

            DateTime recordingUtcNow = DateTime.SpecifyKind(Recording.UtcNow.Date, DateTimeKind.Utc).AddDays(-14);
            string mockQuery = "let dt = datatable (Int: int, String: string, Bool: bool, TimeGenerated: datetime)\n" +
                "[" +
                $"1, 'a', false, datetime(\"{recordingUtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\"), " +
                $"2, 'b', true, datetime(\"{recordingUtcNow.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")," +
                $"3, 'c', false, datetime(\"{recordingUtcNow.AddDays(5).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")]; " +
                "dt | distinct * | project TimeGenerated";

            var results = await client.QueryResourceAsync(
                new ResourceIdentifier(TestEnvironment.WorkspaceSecondaryResourceId),
                mockQuery,
                timespan);

            Assert.That(results.Value.Table.Rows, Has.Count.GreaterThanOrEqualTo(3));
        }

        [Test]
        public async Task CanQueryResourceGenericSecondaryWorkspace()
        {
            var timespan = TimeSpan.FromSeconds(5);

            var client = CreateClient();

            DateTime recordingUtcNow = DateTime.SpecifyKind(Recording.UtcNow.Date, DateTimeKind.Utc).AddDays(-14);
            string mockQuery = "let dt = datatable (Int: int, String: string, Bool: bool, TimeGenerated: datetime)\n" +
                "[" +
                $"1, 'a', false, datetime(\"{recordingUtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\"), " +
                $"2, 'b', true, datetime(\"{recordingUtcNow.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")," +
                $"3, 'c', false, datetime(\"{recordingUtcNow.AddDays(5).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\")]; " +
                "dt | distinct * | project TimeGenerated";

            var results = await client.QueryResourceAsync<DateTimeOffset>(
                new ResourceIdentifier(TestEnvironment.WorkspaceSecondaryResourceId),
                mockQuery,
                timespan);

            Assert.That(results.Value, Has.Count.GreaterThanOrEqualTo(3));
        }

        [Test]
        public void QueryResourceValidatesTheResourceIdentifier()
        {
            var client = CreateClient();
            LogsQueryOptions options = new LogsQueryOptions();
            options.IncludeStatistics = true;
            var resourceId = new ResourceIdentifier("///" + TestEnvironment.WorkspacePrimaryResourceId);
            var exception = Assert.ThrowsAsync<ArgumentException>(() => client.QueryResourceAsync(
                resourceId,
                "search *",
                _logsTestData.DataTimeRange,
                options));

            Assert.That(exception.ParamName, Is.EqualTo("resourceId").IgnoreCase);
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
            Assert.That(resultTable.Columns, Is.Not.Empty);

            Assert.That(results.Value.Status, Is.EqualTo(LogsQueryResultStatus.Success));
            Assert.That(resultTable.Rows[0][0], Is.EqualTo(double.NaN));
            Assert.That(resultTable.Rows[0][1], Is.EqualTo(double.PositiveInfinity));
            Assert.That(resultTable.Rows[0][2], Is.EqualTo(double.NegativeInfinity));
            Assert.That(resultTable.Rows[0][3], Is.EqualTo(null));
            Assert.That(resultTable.Rows[0][4], Is.EqualTo(123));
        }
    }
}
