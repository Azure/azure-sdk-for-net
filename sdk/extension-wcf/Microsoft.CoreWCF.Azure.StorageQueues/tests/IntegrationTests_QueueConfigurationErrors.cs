// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests
{
    public class IntegrationTests_QueueConfigurationErrors
    {
        private IWebHost host;

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
            host.StopAsync().Wait();
            host.Dispose();
        }

        [Test]
        public void QueueConfigurationWithConflictingQueueName_ThrowArgumentException()
        {
            host = ServiceHelper.CreateWebHostBuilder<Startup2_ConflictingQueueName>().Build();
            System.ArgumentException exception = Assert.Throws<System.ArgumentException>(() => host.Start());
            Assert.That(exception.Message, Is.EqualTo($"Queue name mismatch. The connection string is using queue name '{Startup2_ConflictingQueueName.QueueName}', and the channel uri is using queue name 'conflicting-queue-name'. When specifying the queue name using both methods, they must match."));
        }

        [Test]
        public void QueueConfigurationWithNoQueueName_ThrowArgumentException()
        {
            host = ServiceHelper.CreateWebHostBuilder<Startup2_NoQueueName>().Build();
            System.ArgumentException exception = Assert.Throws<System.ArgumentException>(() => host.Start());
            var expectedExceptionMessage = $"The endpoint Uri '{TestHelper.GetEndpointWithNoQueueName()}' should have two path segments when not using an Azure dns hostname.";
            Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}