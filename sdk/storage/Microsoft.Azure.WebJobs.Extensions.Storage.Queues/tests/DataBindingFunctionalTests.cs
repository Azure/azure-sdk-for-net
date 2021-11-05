// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class DataBindingFunctionalTests
    {
        private const string QueueName = "queue-databindingfunctionaltests";
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            queueServiceClient.GetQueueClient(QueueName).DeleteIfExists();
        }

        [Test]
        public async Task BindStringableParameter_CanInvoke()
        {
            // Arrange
            var builder = new HostBuilder()
                .ConfigureDefaultTestHost<TestFunctions>(b =>
                {
                    b.AddAzureStorageQueues();
                    b.UseQueueService(queueServiceClient);
                });

            var host = builder.Build().GetJobHost<TestFunctions>();

            MethodInfo method = typeof(TestFunctions).GetMethod("BindStringableParameter");
            Assert.NotNull(method); // Guard
            Guid guid = Guid.NewGuid();
            string expectedGuidValue = guid.ToString("D");
            string message = JsonConvert.SerializeObject(new MessageWithStringableProperty { GuidValue = guid });

            try
            {
                // Act
                await host.CallAsync(method, new { message = message });

                // Assert
                Assert.AreEqual(expectedGuidValue, TestFunctions.Result);
            }
            finally
            {
                TestFunctions.Result = null;
            }
        }

        private class MessageWithStringableProperty
        {
            public Guid GuidValue { get; set; }
        }

        private class TestFunctions
        {
            public static string Result { get; set; }

            public static void BindStringableParameter([QueueTrigger(QueueName)] MessageWithStringableProperty message,
                string guidValue)
            {
                Result = guidValue;
            }
        }
    }
}
