// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public class GetAnomaliesForAlertTest : MetricsAdvisorTest<MetricsAdvisorPerfOptions>
    {
        public GetAnomaliesForAlertTest(MetricsAdvisorPerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            int count = 0;

            foreach (var _ in Client.GetAnomalies(AlertConfigurationId, AlertId, cancellationToken: cancellationToken))
            {
                if (++count >= Options.Count)
                {
                    break;
                }
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            int count = 0;

            await foreach (var _ in Client.GetAnomaliesAsync(AlertConfigurationId, AlertId, cancellationToken: cancellationToken))
            {
                if (++count >= Options.Count)
                {
                    break;
                }
            }
        }
    }
}
