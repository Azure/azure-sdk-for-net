// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Test.Perf;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public sealed class GetDataFeeds : MetricsAdvisorTest<PageSizeCountOptions>
    {
        private readonly int _count;

        private readonly GetDataFeedsOptions _options;

        public GetDataFeeds(PageSizeCountOptions options) : base(options)
        {
            _count = options.Count;
            _options = new GetDataFeedsOptions()
            {
                MaxPageSize = options.MaxPageSize
            };
        }

        public override void Run(CancellationToken cancellationToken)
        {
            int i = 0;

            foreach (var _ in AdminClient.GetDataFeeds(_options, cancellationToken))
            {
                if (++i >= _count)
                {
                    break;
                }
            }

#if DEBUG
            Assert.That(i, Is.EqualTo(_count));
#endif
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            int i = 0;

            await foreach (var _ in AdminClient.GetDataFeedsAsync(_options, cancellationToken))
            {
                if (++i >= _count)
                {
                    break;
                }
            }

#if DEBUG
            Assert.That(i, Is.EqualTo(_count));
#endif
        }
    }
}
