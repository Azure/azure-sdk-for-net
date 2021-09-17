// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Test.Perf;

namespace Azure.Data.AppConfiguration.Perf
{
    public sealed class QueryLogs: MonitorQueryPerfTest<PerfOptions>
    {
        public QueryLogs(CountOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            LogsQueryClient.Query(TestEnvironment.WorkspaceId, LogsQuery, DateTimeRange.All, cancellationToken: cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await LogsQueryClient.QueryAsync(TestEnvironment.WorkspaceId, LogsQuery, DateTimeRange.All, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
