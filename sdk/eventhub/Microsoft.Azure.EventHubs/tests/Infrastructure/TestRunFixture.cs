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

            if (TestUtility.WasEventHubsNamespaceCreated)
            {
                namespaceDeleteTask = EventHubScope.DeleteNamespaceAsync(TestUtility.EventHubsNamespace);
            }

            if (TestUtility.WasStorageAccountCreated)
            {
                storageDeleteTask = EventHubScope.DeleteStorageAsync(TestUtility.StorageAccountName);
            }

            if (namespaceDeleteTask != null || storageDeleteTask != null)
            {
                Task.WhenAll(namespaceDeleteTask ?? Task.CompletedTask, storageDeleteTask ?? Task.CompletedTask).GetAwaiter().GetResult();
            }

            base.Dispose();
        }
    }
}