// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public class GetIncidentRootCausesTest : MetricsAdvisorTest<MetricsAdvisorPerfOptions>
    {
        public GetIncidentRootCausesTest(MetricsAdvisorPerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (var _ in Client.GetIncidentRootCauses(DetectionConfigurationId, IncidentId, cancellationToken: cancellationToken))
            {
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var _ in Client.GetIncidentRootCausesAsync(DetectionConfigurationId, IncidentId, cancellationToken: cancellationToken))
            {
            }
        }
    }
}
