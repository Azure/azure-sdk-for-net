// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor.Samples.Infrastructure;
using Azure.Messaging.EventHubs.Tests;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Tests
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
        ///   Provides a set of test cases for each available sample.
        /// </summary>
        ///
        public static IEnumerable<object[]> SampleTestCases() =>
            typeof(Samples.Program)
              .Assembly
              .ExportedTypes
              .Where(type => (type.IsClass && typeof(IEventHubsBlobCheckpointSample).IsAssignableFrom(type)))
              .Select(type => new object[] { (IEventHubsBlobCheckpointSample)Activator.CreateInstance(type) });

        /// <summary>
        ///   Verifies that the specified <see cref="IEventHubsBlobCheckpointSample" /> is able to
        ///   be run without encountering an exception.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(SampleTestCases))]
        public async Task SmokeTestASample(IEventHubsBlobCheckpointSample sample)
        {
            await using (EventHubScope eventHubScope = await EventHubScope.CreateAsync(2))
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;

                Assert.That(async () => await sample.RunAsync(eventHubsConnectionString, eventHubScope.EventHubName, storageConnectionString, storageScope.ContainerName), Throws.Nothing);
            }
        }
    }
}
