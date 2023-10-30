// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.CoreWCF;
using Azure.Storage.CoreWCF.Channels;
using Azure.Storage.Queues;
using Contracts;
using CoreWCF.Configuration;
using CoreWCF.Queue.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Security;
using System.Web.Services.Description;

namespace CoreWCF.AzureQueueStorage.Tests
{
    public class Startup2_NoQueueName
    {
        private readonly string queueName = "queue-name";
        private readonly string deadLetterQueueName = "deadletter-queue-name";
        private string connectionString = null;
        private string endpointUrlString = null;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TestService>();
            services.AddServiceModelServices();
            services.AddQueueTransport();
            services.AddHttpClient(typeof(TestService).FullName)
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (_, _, _, _) => true
                    };
                });

            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var transport = azuriteFixture.GetTransport();
            connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            var endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint);
            endpointUriBuilder.Scheme = "net.aqs";
            endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;
            var queueClient = new QueueClient(connectionString, queueName, new QueueClientOptions { Transport = transport });
            queueClient.CreateIfNotExists();
            services.AddSingleton(queueClient);
        }

        public void Configure(IApplicationBuilder app)
        {
            QueueClient queue = app.ApplicationServices.GetRequiredService<QueueClient>();

            app.UseServiceModel(services =>
            {
                services.AddService<TestService>();
                services.AddServiceEndpoint<TestService, ITestContract>(new AzureQueueStorageBinding(connectionString, deadLetterQueueName),
                endpointUrlString);
            });
        }
    }
}