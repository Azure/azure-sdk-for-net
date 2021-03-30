// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public class GetIncidentsForAlertTest : MetricsAdvisorTest<MetricsAdvisorPerfOptions>
    {
        public GetIncidentsForAlertTest(MetricsAdvisorPerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            int count = 0;

            foreach (var _ in Client.GetIncidents(AlertConfigurationId, AlertId, cancellationToken: cancellationToken))
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

            await foreach (var _ in Client.GetIncidentsAsync(AlertConfigurationId, AlertId, cancellationToken: cancellationToken))
            {
                if (++count >= Options.Count)
                {
                    break;
                }
            }
        }
    }
}
