//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Perf;

namespace Azure.DigitalTwins.Core.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on running queries against digital twins instances.
    /// </summary>
    /// <seealso cref="PerfTest{SizeOptions}" />
    public sealed class QueryDigitalTwins : PerfTest<SizeOptions>
    {
        private DigitalTwinsClient _digitalTwinsClient;

        public QueryDigitalTwins(SizeOptions options) : base(options)
        {
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            _digitalTwinsClient = new DigitalTwinsClient(
                new Uri(PerfTestEnvironment.Instance.ClientId),
                new ClientSecretCredential(
                    PerfTestEnvironment.Instance.DigitalTwinsTenantId,
                    PerfTestEnvironment.Instance.DigitalTwinsClientId,
                    PerfTestEnvironment.Instance.DigitalTwinsClientSecret));
        }

        /// <summary>
        /// Queries for all digital twins using <see cref="DigitalTwinsClient.Query{T}(string, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            Pageable<BasicDigitalTwin> result = _digitalTwinsClient.Query<BasicDigitalTwin>("SELECT * FROM DIGITALTWINS");
            int resultCount = 0;

            foreach (BasicDigitalTwin a in result)
            {
                resultCount++;
            }
        }

        /// <summary>
        /// Queries for all digital twins using <see cref="DigitalTwinsClient.QueryAsync{T}(string, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            AsyncPageable<BasicDigitalTwin> result = _digitalTwinsClient.QueryAsync<BasicDigitalTwin>("SELECT * FROM DIGITALTWINS");
            int resultCount = 0;

            await foreach (BasicDigitalTwin a in result)
            {
                resultCount++;
            }
        }
    }
}
