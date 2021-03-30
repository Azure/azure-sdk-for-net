// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public sealed class GetAnomaliesForAlert : MetricsAdvisorTest<CountOptions>
    {
        public GetAnomaliesForAlert(CountOptions options) : base(options)
        {
            ValidateOptions();
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

        private void ValidateOptions()
        {
            int count = 0;

            foreach (var _ in Client.GetAnomalies(AlertConfigurationId, AlertId))
            {
                if (++count >= Options.Count)
                {
                    break;
                }
            }

            if (count < Options.Count)
            {
                throw new ArgumentException($"The provided alert does not have enough anomalies for this test. "
                    + $"Expected: {Options.Count}. Actual: {count}. Please set '--count {count}' or lower.");
            }
        }
    }
}
