// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    ///   These tests have a depenency on live Azure services and may
    ///   incur costs for the assocaied Azure subscription.
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
              .Where(type => (type.IsClass && typeof(ISample).IsAssignableFrom(type)))
              .Select(type => new object[] { (ISample)Activator.CreateInstance(type) });

        /// <summary>
        ///   Verifies that the specified <see cref="ISample" /> is able to
        ///   be run without encountering an exception.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(SampleTestCases))]
        public async Task SmokeTestASample(ISample sample)
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.EventHubsConnectionString;
                Assert.That(async () => await sample.RunAsync(connectionString, scope.EventHubName), Throws.Nothing);
            }
        }
    }
}
