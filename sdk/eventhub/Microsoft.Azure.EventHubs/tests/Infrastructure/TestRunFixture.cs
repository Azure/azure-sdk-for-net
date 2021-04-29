// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Microsoft.Azure.EventHubs.Tests
{
    public class TestRunFixture : XunitTestFramework, IDisposable
    {
        public TestRunFixture(IMessageSink messageSink) : base(messageSink)
        {
            // Initialization for the full test run should appear here.
        }

        public new void Dispose()
        {
            Task namespaceDeleteTask = null;
            Task storageDeleteTask = null;

            if (TestUtility.ShouldRemoveNamespaceAfterTestRunCompletion)
            {
                namespaceDeleteTask = EventHubScope.DeleteNamespaceAsync(TestUtility.EventHubsNamespace);
            }

            if (TestUtility.ShouldRemoveStorageAfterTestRunCompletion)
            {
                storageDeleteTask = EventHubScope.DeleteStorageAsync(TestUtility.StorageAccountName);
            }

            if (namespaceDeleteTask != null || storageDeleteTask != null)
            {
                try
                {
                    Task.WhenAll(namespaceDeleteTask ?? Task.CompletedTask, storageDeleteTask ?? Task.CompletedTask).GetAwaiter().GetResult();
                }
                catch
                {
                    // This should not be considered a critical failure that results in a test run failure.  Due
                    // to ARM being temperamental, some management operations may be rejected.  Throwing here
                    // does not help to ensure resource cleanup.
                    //
                    // Because resources may be orphaned outside of an observed exception, throwing to raise awareness
                    // is not sufficient for all scenarios; since an external process is already needed to manage
                    // orphans, there is no benefit to failing the run; allow the test results to be reported.
                }
            }

            base.Dispose();
        }
    }
}