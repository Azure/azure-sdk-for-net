// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Contracts;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests
{
    public class Startup_BinaryServiceQueueTextClientQueue
    {
        private readonly string queueName = "queue-name";
        private readonly string deadLetterQueueName = "deadletter-queue-name";
        private string connectionString = null;
        private string endpointUrlString = null;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TestService>();
            TestHelper.ConfigureService(services, typeof(TestService).FullName, queueName, out connectionString, out endpointUrlString);
        }

        public void Configure(IApplicationBuilder app)
        {
            QueueClient queue = app.ApplicationServices.GetRequiredService<QueueClient>();

            app.UseServiceModel(services =>
            {
                services.AddService<TestService>();
                services.AddServiceEndpoint<TestService, ITestContract>(new AzureQueueStorageBinding(connectionString, deadLetterQueueName)
                {
                    MessageEncoding = AzureQueueStorageMessageEncoding.Text
                },
                endpointUrlString);
            });
        }
    }
}