// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public class CheckIngestionStatusTest : MetricsAdvisorTest<PerfOptions>
    {
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        private readonly GetDataFeedIngestionStatusesOptions _requestOptions;

        public CheckIngestionStatusTest(PerfOptions options) : base(options)
        {
            var uri = new Uri(MetricsAdvisorUri);
            var credential = new MetricsAdvisorKeyCredential(MetricsAdvisorSubscriptionKey, MetricsAdvisorApiKey);

            _adminClient = new MetricsAdvisorAdministrationClient(uri, credential);
            _requestOptions = new GetDataFeedIngestionStatusesOptions(SamplingStartTime, SamplingEndTime);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (var status in _adminClient.GetDataFeedIngestionStatuses(DataFeedId, _requestOptions))
            {
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var status in _adminClient.GetDataFeedIngestionStatusesAsync(DataFeedId, _requestOptions))
            {
            }
        }
    }
}
