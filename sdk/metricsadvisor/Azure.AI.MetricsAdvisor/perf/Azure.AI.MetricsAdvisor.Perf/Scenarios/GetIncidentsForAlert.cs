// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public sealed class GetIncidentsForAlert : MetricsAdvisorTest<PerfOptions>
    {
        public GetIncidentsForAlert(PerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (var _ in Client.GetIncidentsForAlert(TestEnvironment.AlertConfigurationId, TestEnvironment.AlertId, cancellationToken: cancellationToken))
            {
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var _ in Client.GetIncidentsForAlertAsync(TestEnvironment.AlertConfigurationId, TestEnvironment.AlertId, cancellationToken: cancellationToken))
            {
            }
        }
    }
}
