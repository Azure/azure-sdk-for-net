// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public sealed class GetAnomaliesForAlert : MetricsAdvisorTest<PerfOptions>
    {
        public GetAnomaliesForAlert(PerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (var _ in Client.GetAnomaliesForAlert(TestEnvironment.AlertConfigurationId, TestEnvironment.AlertId, cancellationToken: cancellationToken))
            {
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var _ in Client.GetAnomaliesForAlertAsync(TestEnvironment.AlertConfigurationId, TestEnvironment.AlertId, cancellationToken: cancellationToken))
            {
            }
        }
    }
}
