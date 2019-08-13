// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Serves as a fixture for operations that are scoped to the entire
    ///   test run pass, rather than specific to a given test or test fixture.
    /// </summary>
    ///
    [SetUpFixture]
    public class TestRunFixture
    {
        /// <summary>
        ///  Performs the tasks needed to clean up after a test run
        ///  has completed.
        /// </summary>
        [OneTimeTearDown]
        public void Teardown()
        {
            if (TestEnvironment.WasEventHubsNamespaceCreated)
            {
                EventHubScope.DeleteNamespaceAsync(TestEnvironment.EventHubsNamespace).GetAwaiter().GetResult();
            }
        }
    }
}
