// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    internal static class TransportFailureTestHelpers
    {
        private const string FailureMessage = "Simulated connection failure.";

        public static MockTransport ConfigureConnectionFailure(ClientOptions options, bool isAsync)
        {
            // Simulate the transport boundary instead of resolving a nonexistent host.
            var transport = new MockTransport(_ => throw new RequestFailedException(FailureMessage))
            {
                ExpectSyncPipeline = !isAsync
            };
            options.Transport = transport;
            options.Retry.Delay = TimeSpan.Zero;
            options.Retry.MaxDelay = TimeSpan.Zero;
            options.Retry.Mode = RetryMode.Fixed;
            return transport;
        }

        public static void AssertRetryFailure(AsyncTestDelegate operation, ClientOptions options, MockTransport transport)
        {
            AggregateException exception = Assert.ThrowsAsync<AggregateException>(operation);
            Assert.AreEqual(options.Retry.MaxRetries + 1, transport.Requests.Count);
            Assert.AreEqual(transport.Requests.Count, exception.InnerExceptions.Count);
            Assert.IsTrue(exception.InnerExceptions.All(error =>
                error is RequestFailedException requestFailed &&
                requestFailed.Status == 0 &&
                requestFailed.Message == FailureMessage));
        }
    }
}
