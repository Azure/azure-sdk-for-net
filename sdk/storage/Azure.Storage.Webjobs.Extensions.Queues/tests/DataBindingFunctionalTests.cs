// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Xunit;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Bindings.Data
{
    [Collection(AzuriteCollection.Name)]
    public class DataBindingFunctionalTests
    {
        private const string QueueName = "queue-databindingfunctionaltests";
        private readonly StorageAccount account;

        public DataBindingFunctionalTests(AzuriteFixture azuriteFixture)
        {
            account = azuriteFixture.GetAccount();
            account.CreateQueueServiceClient().GetQueueClient(QueueName).DeleteIfExists();
        }

        [Fact]
        public async Task BindStringableParameter_CanInvoke()
        {
            // Arrange
            var builder = new HostBuilder()
                .ConfigureDefaultTestHost<TestFunctions>(b =>
                {
                    b.UseStorage(account);
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
                Assert.Equal(expectedGuidValue, TestFunctions.Result);
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
