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
        private DataFeed _dataFeed;

        public GetDataFeed(PerfOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
            _dataFeed = GetDataFeedInstance();
            _dataFeed = await AdminClient.CreateDataFeedAsync(_dataFeed);
        }

        public override async Task GlobalCleanupAsync()
        {
            await AdminClient.DeleteDataFeedAsync(_dataFeed.Id);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            AdminClient.GetDataFeed(_dataFeed.Id, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await AdminClient.GetDataFeedAsync(_dataFeed.Id, cancellationToken);
        }
    }
}
