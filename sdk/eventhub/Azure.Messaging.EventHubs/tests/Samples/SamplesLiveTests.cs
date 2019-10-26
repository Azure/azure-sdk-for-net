// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples;
using Azure.Messaging.EventHubs.Samples.Infrastructure;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the samples associated with the
    ///   client library.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a dependency on live Azure services and may
    ///   incur costs for the associated Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class SamplesLiveTests
    {

        /// <summary>
        ///   Verifies that each sample is able to
        ///   be run without encountering an exception.
        /// </summary>
        ///
        [Test]
        public async Task SmokeTestSamples()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.EventHubsConnectionString;

                Run_Sample01(scope, connectionString);
                Run_Sample02(scope, connectionString);
                Run_Sample03(scope, connectionString);
                Run_Sample04(scope, connectionString);
                Run_Sample05(scope, connectionString);
                Run_Sample06(scope, connectionString);
                Run_Sample07(scope, connectionString);
                Run_Sample08(scope, connectionString);
                Run_Sample09(scope, connectionString);
                Run_Sample10(scope, connectionString);
                Run_Sample11(scope, connectionString);
                Run_Sample12(scope, connectionString);
            }
        }

        private static void Run_Sample01(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample01_HelloWorld().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample02(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample02_ClientWithCustomOptions().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample03(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample03_PublishAnEvent().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample04(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample04_PublishEventsWithPartitionKey().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample05(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample05_PublishAnEventBatch().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample06(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample06_PublishEventsToSpecificPartitions().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample07(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample07_PublishEventsWithCustomMetadata().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample08(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample08_ConsumeEvents().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample09(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample09_ConsumeEventsWithMaximumWaitTime().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample10(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample10_ConsumeEventsFromAKnownPosition().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample11(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample11_ConsumeEventsByBatch().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }

        private static void Run_Sample12(EventHubScope scope, string connectionString)
        {
            Assert.That(async () => await new Sample12_ConsumeEventsWithEventProcessor().RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
        }
    }
}
