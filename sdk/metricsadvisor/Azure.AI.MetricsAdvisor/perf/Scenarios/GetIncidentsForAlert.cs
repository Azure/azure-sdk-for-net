// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public class GetIncidentsForAlert : MetricsAdvisorTest<MetricsAdvisorPerfOptions>
    {
        public GetIncidentsForAlert(MetricsAdvisorPerfOptions options) : base(options)
        {
            ValidateOptions();
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

        private void ValidateOptions()
        {
            int count = 0;

            foreach (var _ in Client.GetIncidents(AlertConfigurationId, AlertId))
            {
                if (++count >= Options.Count)
                {
                    break;
                }
            }

            if (count < Options.Count)
            {
                throw new ArgumentException($"The provided alert does not have enough incidents for this test. "
                    + $"Expected: {Options.Count}. Actual: {count}. Please set '--count {count}' or lower.");
            }
        }
    }
}
