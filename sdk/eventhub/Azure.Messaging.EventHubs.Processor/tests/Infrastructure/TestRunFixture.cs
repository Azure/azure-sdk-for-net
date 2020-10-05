// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Tests;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Tests
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
        ///
        [OneTimeTearDown]
        public void Teardown()
        {
            // Clean-up should not be considered a critical failure that results in a test run failure.  Due
            // to ARM being temperamental, some management operations may be rejected.  Throwing here
            // does not help to ensure resource cleanup.
            //
            // Because resources may be orphaned outside of an observed exception, throwing to raise awareness
            // is not sufficient for all scenarios; since an external process is already needed to manage
            // orphans, there is no benefit to failing the run; allow the test results to be reported.

            try
            {
                if (EventHubsTestEnvironment.Instance.ShouldRemoveNamespaceAfterTestRunCompletion)
                {
                    EventHubScope.DeleteNamespaceAsync(EventHubsTestEnvironment.Instance.EventHubsNamespace).GetAwaiter().GetResult();
                }
            }
            catch
            {
            }

            try
            {
                if (StorageTestEnvironment.Instance.ShouldRemoveStorageAccountAfterTestRunCompletion)
                {
                    StorageScope.DeleteStorageAccountAsync(StorageTestEnvironment.Instance.StorageAccountName).GetAwaiter().GetResult();
                }
            }
            catch
            {
            }
        }
    }
}
