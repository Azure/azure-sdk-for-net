// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public sealed class GetIncidentRootCauses : MetricsAdvisorTest<CountOptions>
    {
        public GetIncidentRootCauses(CountOptions options) : base(options)
        {
            ValidateOptions();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            int count = 0;

            foreach (var _ in Client.GetIncidentRootCauses(DetectionConfigurationId, IncidentId, cancellationToken: cancellationToken))
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

            await foreach (var _ in Client.GetIncidentRootCausesAsync(DetectionConfigurationId, IncidentId, cancellationToken: cancellationToken))
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

            foreach (var _ in Client.GetIncidentRootCauses(DetectionConfigurationId, IncidentId))
            {
                if (++count >= Options.Count)
                {
                    break;
                }
            }

            if (count < Options.Count)
            {
                throw new ArgumentException($"The provided incident does not have enough root causes for this test. "
                    + $"Expected: {Options.Count}. Actual: {count}. Please set '--count {count}' or lower.");
            }
        }
    }
}
