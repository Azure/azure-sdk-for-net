// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Monitor.Query;
using Azure.Test.Perf;

namespace Azure.Data.AppConfiguration.Perf
{
    public sealed class QueryLogsModels : MonitorQueryPerfTest<PerfOptions>
    {
        public QueryLogsModels(CountOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            LogsQueryClient.QueryWorkspace<TestModelForTypes>(TestEnvironment.WorkspaceId, LogsQuery, QueryTimeRange.All, cancellationToken: cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await LogsQueryClient.QueryWorkspaceAsync<TestModelForTypes>(TestEnvironment.WorkspaceId, LogsQuery, QueryTimeRange.All, cancellationToken: cancellationToken).ConfigureAwait(false);
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
    }
}
