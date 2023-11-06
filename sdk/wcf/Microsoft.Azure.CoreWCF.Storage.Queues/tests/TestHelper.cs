// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.CoreWCF;
using Azure.Storage.Queues;
using Contracts;
using CoreWCF.Configuration;
using CoreWCF.Queue.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace CoreWCF.AzureQueueStorage.Tests
{
    internal class TestHelper
    {
        internal static void ConfigureService(IServiceCollection services,
            string serviceName,
            string queueName,
            out string connectionString,
            out string endpointUrlString,
            string conflictingQueueName = "",
            bool createWithNoQueueName = false,
            QueueMessageEncoding queueMessageEncoding = QueueMessageEncoding.None
            )
        {
            if (conflictingQueueName == "")
            {
                conflictingQueueName = queueName;
            }

            services.AddServiceModelServices();
            services.AddQueueTransport();
            services.AddHttpClient(serviceName)
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (_, _, _, _) => true
                    };
                });

            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var transport = azuriteFixture.GetTransport();
            UriBuilder endpointUriBuilder = null;
            if (createWithNoQueueName)
            {
                connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
                endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint)
                {
                    Scheme = "net.aqs"
                };
            }
            else
            {
                connectionString = azuriteFixture.GetAzureAccount().ConnectionString.TrimEnd(';') + "/" + queueName + ";";
                endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint + "/" + conflictingQueueName)
                {
                    Scheme = "net.aqs"
                };
            }
            endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;
            var queueClient = new QueueClient(connectionString, queueName, new QueueClientOptions { Transport = transport , MessageEncoding = queueMessageEncoding });;
            queueClient.CreateIfNotExists();
            services.AddSingleton(queueClient);
        }
    }
}
