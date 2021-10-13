//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core.Perf.Infrastructure;
using Azure.Identity;
using Azure.Test.Perf;
using NUnit.Framework;
using FluentAssertions;

namespace Azure.DigitalTwins.Core.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on running queries against digital twins instances.
    /// </summary>
    /// <seealso cref="PerfTest{SizeOptions}" />
    public sealed class QueryDigitalTwins : PerfTest<SizeOptions>
    {
        private readonly DigitalTwinsClient _digitalTwinsClient;
        private readonly string _testId;
        private readonly long _size;
        private readonly TimeSpan _delayPeriod = TimeSpan.FromMinutes(1);
        private List<BasicDigitalTwin> _createdTwins = new List<BasicDigitalTwin>();

        public QueryDigitalTwins(SizeOptions options) : base(options)
        {
            _digitalTwinsClient = new DigitalTwinsClient(
                new Uri(PerfTestEnvironment.Instance.DigitalTwinsUrl),
                new ClientSecretCredential(
                    PerfTestEnvironment.Instance.DigitalTwinsTenantId,
                    PerfTestEnvironment.Instance.DigitalTwinsClientId,
                    PerfTestEnvironment.Instance.DigitalTwinsClientSecret));

            _size = options.Size;
            _testId = Guid.NewGuid().ToString().Substring(0, 8);
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            // Global setup code that runs once at the beginning of test execution.
            // Create the model globally so all tests can take advantage of it.
            await AdtInstancePopulator.CreateRoomModelAsync(_digitalTwinsClient).ConfigureAwait(false);
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            _createdTwins = await AdtInstancePopulator.CreateRoomTwinsForTestIdAsync(_digitalTwinsClient, _testId, _size).ConfigureAwait(false);

            // Since it takes some time for the newly created twins to be included in the query result, we have to wait some time.
            await Task.Delay(_delayPeriod);
        }

        public override async Task CleanupAsync()
        {
            // Individual test-level cleanup code that runs for each instance of the test.
            await base.CleanupAsync();

            // We will delete all twins created by this test instance.
            foreach (BasicDigitalTwin twin in _createdTwins)
            {
                await _digitalTwinsClient.DeleteDigitalTwinAsync(twin.Id).ConfigureAwait(false);
            }
        }

        public override async Task GlobalCleanupAsync()
        {
            // Global cleanup code that runs once at the end of test execution.
            await base.GlobalCleanupAsync();

            // List all the models and delete all of them.
            AsyncPageable<DigitalTwinsModelData> allModels = _digitalTwinsClient.GetModelsAsync();

            await foreach (DigitalTwinsModelData model in allModels)
            {
                await _digitalTwinsClient.DeleteModelAsync(model.Id).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Queries for all digital twins using <see cref="DigitalTwinsClient.Query{T}(string, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            Pageable<BasicDigitalTwin> result = _digitalTwinsClient
                .Query<BasicDigitalTwin>($"SELECT * FROM DIGITALTWINS WHERE TestId = '{_testId}'", cancellationToken);
            long resultCount = 0;

            foreach (BasicDigitalTwin a in result)
            {
                resultCount++;
            }

#if DEBUG
            resultCount.Should().Be(_size);
#endif
        }

        /// <summary>
        /// Queries for all digital twins using <see cref="DigitalTwinsClient.QueryAsync{T}(string, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            AsyncPageable<BasicDigitalTwin> result = _digitalTwinsClient
                .QueryAsync<BasicDigitalTwin>($"SELECT * FROM DIGITALTWINS WHERE TestId = '{_testId}'", cancellationToken);
            long resultCount = 0;

            await foreach (BasicDigitalTwin a in result)
            {
                resultCount++;
            }

#if DEBUG
            resultCount.Should().Be(_size);
#endif
        }
    }
}
