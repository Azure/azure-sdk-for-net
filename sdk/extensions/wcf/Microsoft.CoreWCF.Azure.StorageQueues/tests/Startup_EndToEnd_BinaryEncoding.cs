// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER
using Azure.Storage.Queues;
using Contracts;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests
{
    public class Startup_EndToEnd_BinaryEncoding
    {
        private readonly string queueName = "azure-queue";
        private readonly string deadLetterQueueName = "deadletter-queue-name";
        private string connectionString = null;
        private string endpointUrlString = null;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TestService_EndToEnd>();
            TestHelper.ConfigureService(services, typeof(TestService_EndToEnd).FullName, queueName, out connectionString, out endpointUrlString, "", false, QueueMessageEncoding.Base64);
        }

        public void Configure(IApplicationBuilder app)
        {
            QueueClient queue = app.ApplicationServices.GetRequiredService<QueueClient>();

            app.UseServiceModel(services =>
            {
                services.AddService<TestService_EndToEnd>();
                services.AddServiceEndpoint<TestService_EndToEnd, ITestContract_EndToEndTest>(new AzureQueueStorageBinding(connectionString, deadLetterQueueName)
                {
                    MessageEncoding = AzureQueueStorageMessageEncoding.Binary
                },
                endpointUrlString);
            });
        }
    }
}
#endif