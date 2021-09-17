// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Data.AppConfiguration.Perf
{
    public sealed class QueryMetrics : MonitorQueryPerfTest<PerfOptions>
    {
        private string[] _metrics = { "Event" };

        public QueryMetrics(PerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            MetricsQueryClient.Query(TestEnvironment.MetricsResource, _metrics, cancellationToken: cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await MetricsQueryClient.QueryAsync(TestEnvironment.MetricsResource, _metrics, cancellationToken: cancellationToken);
        }
    }
}