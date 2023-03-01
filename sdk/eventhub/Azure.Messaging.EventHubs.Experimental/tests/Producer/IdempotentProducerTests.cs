// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Experimental.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="IdempotentProducer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class IdempotentProducerTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentProducer.GetPartitionPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPublishingPropertiesAsyncReturnsProperties()
        {
            // Disable idempotent partitions to avoid a live service call.  This will
            // still allow the pass-through invocation to be validated.

            var entityPath = "somePath";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ entityPath }";
            var producer = new IdempotentProducer(new EventHubConnection(fakeConnection), new IdempotentProducerOptions
            {
                EnableIdempotentPartitions = false
            });

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var readProperties = await producer.GetPartitionPublishingPropertiesAsync("0", cancellationSource.Token);
            Assert.That(readProperties, Is.Not.Null, "The read properties should have been created.");
        }
    }
}
