// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public sealed class GetDataFeed : MetricsAdvisorTest<PerfOptions>
    {
        private static DataFeed s_dataFeed;

        public GetDataFeed(PerfOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
            s_dataFeed = GetDataFeedInstance();
            s_dataFeed = await AdminClient.CreateDataFeedAsync(s_dataFeed);
        }

        public override async Task GlobalCleanupAsync()
        {
            await AdminClient.DeleteDataFeedAsync(s_dataFeed.Id);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            AdminClient.GetDataFeed(s_dataFeed.Id, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await AdminClient.GetDataFeedAsync(s_dataFeed.Id, cancellationToken);
        }
    }
}
