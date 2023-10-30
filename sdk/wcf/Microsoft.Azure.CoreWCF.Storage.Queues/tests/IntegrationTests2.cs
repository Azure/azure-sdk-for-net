// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Contracts;
using CoreWCF.AzureQueueStorage.Tests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CoreWCF.AzureQueueStorage.Tests
{
    public class IntegrationTests2
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
            Assert.That(exception.Message, Is.EqualTo("Queue Name passed in as queuename on connection string and End point Uri do not match."));
        }

        [Test]
        public void QueueConfigurationWithNoQueueName_ThrowArgumentException()
        {
            host = ServiceHelper.CreateWebHostBuilder<Startup2_NoQueueName>().Build();
            System.ArgumentException exception = Assert.Throws<System.ArgumentException>(() => host.Start());
            Assert.That(exception.Message, Is.EqualTo("Queue name could not be found."));
        }
    }
}
