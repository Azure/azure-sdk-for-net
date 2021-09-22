// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.Query;
using Azure.Monitor.Query.Tests;
using Azure.Test.Perf;

namespace Azure.Data.AppConfiguration.Perf
{
    public abstract class MonitorQueryPerfTest<T> : PerfTest<T> where T : PerfOptions
    {
        protected static MonitorQueryTestEnvironment TestEnvironment = new MonitorQueryTestEnvironment();
        protected string LogsQuery = @"
let dt = datatable (DateTime: datetime, Bool:bool, Guid: guid, Int: int, Long:long, Double: double, String: string, Timespan: timespan, Decimal: decimal, Dynamic: dynamic)
[
    datetime(2015-12-31 23:59:59.9), false, guid(74be27de-1e4e-49d9-b579-fe0b331d3642), 12345, 1, 12345.6789, 'string value', 10s, decimal(0.10101), dynamic({""a"":123, ""b"":""hello"", ""c"":[1,2,3], ""d"":{}})
];
range x from 1 to 100 step 1 | extend y=1 | join kind=fullouter dt on $left.y == $right.Long";

        protected readonly LogsQueryClient LogsQueryClient;
        protected readonly MetricsQueryClient MetricsQueryClient;

        protected MonitorQueryPerfTest(T options) : base(options)
        {
            LogsQueryClient = new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                ConfigureClientOptions(new LogsQueryClientOptions()));

            MetricsQueryClient = new MetricsQueryClient(
                TestEnvironment.MetricsEndpoint,
                TestEnvironment.Credential,
                ConfigureClientOptions(new MetricsQueryClientOptions())
            );
        }
    }
}