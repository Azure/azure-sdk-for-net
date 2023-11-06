// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.CoreWCF;
using Azure.Storage.Queues;
using Contracts;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWCF.AzureQueueStorage.Tests
{
    public class Startup_ReceiveBinaryMessage_Success
    {
        private readonly string queueName = "queue-name";
        private readonly string deadLetterQueueName = "deadletter-queue-name";
        private string connectionString = null;
        private string endpointUrlString = null;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TestService>();
            TestHelper.ConfigureService(services, typeof(TestService).FullName, queueName, out connectionString, out endpointUrlString, "", false, QueueMessageEncoding.Base64);
        }

        public void Configure(IApplicationBuilder app)
        {
            QueueClient queue = app.ApplicationServices.GetRequiredService<QueueClient>();

            app.UseServiceModel(services =>
            {
                services.AddService<TestService>();
                services.AddServiceEndpoint<TestService, ITestContract>(new AzureQueueStorageBinding(connectionString, deadLetterQueueName)
                {
                    MessageEncoding = AzureQueueStorageMessageEncoding.Binary
                },
                endpointUrlString);
            });
        }
    }
}