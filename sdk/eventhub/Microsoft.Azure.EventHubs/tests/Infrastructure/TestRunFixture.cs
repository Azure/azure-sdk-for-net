// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
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
            if (TestUtility.WasEventHubsNamespaceCreated)
            {
                EventHubScope.DeleteNamespaceAsync(TestUtility.EventHubsNamespace).GetAwaiter().GetResult();
            }

            base.Dispose();
        }
    }
}
