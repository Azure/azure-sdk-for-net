// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER

using Azure.Storage;
using Azure.Storage.Queues;
using Contracts;
using CoreWCF.Configuration;
using CoreWCF.Queue.Common.Configuration;
using CoreWCF.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests
{
    public class AuthenticationTests
    {
        [TestCase(AzureClientCredentialType.StorageSharedKey)]
        [TestCase(AzureClientCredentialType.ConnectionString)]
        [TestCase(AzureClientCredentialType.Token)]
        public async Task ConnectionStringAuthentication_SuccessAsync(AzureClientCredentialType clientCredentialType)
        {
            var builder = WebApplication.CreateBuilder();
            // Work around bug in CoreWCF which prevents using a Generic Host when using an ITransportServiceBuilder
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Loopback, 0);
            });
            builder.Services.AddServiceModelServices();
            builder.Services.AddQueueTransport();
            builder.Services.AddSingleton<TestService>();
            var app = builder.Build();
            var queueName = TestHelper.GenerateUniqueQueueName();
            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder.AddService<TestService>();
                AddAQSEndpoint(serviceBuilder, clientCredentialType, queueName);
            });
            await app.StartAsync();
            var connectionString = AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString;
            var queueClientOptions = new QueueClientOptions { Transport = AzuriteNUnitFixture.Instance.GetTransport(), MessageEncoding = QueueMessageEncoding.None };
            var queueClient = new QueueClient(connectionString, queueName, queueClientOptions);
            await queueClient.CreateIfNotExistsAsync();
            await queueClient.SendMessageAsync("<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://tempuri.org/ITestContract/Create</a:Action></s:Header><s:Body><Create xmlns=\"http://tempuri.org/\"><name>test</name></Create></s:Body></s:Envelope>");
            var testService = app.Services.GetRequiredService<TestService>();
            Assert.True(testService.ManualResetEvent.Wait(TimeSpan.FromSeconds(5)));
        }

        private static void AddAQSEndpoint(IServiceBuilder serviceBuilder, AzureClientCredentialType clientCredentialType, string queueName)
        {
            var binding = new AzureQueueStorageBinding();
            binding.Security.Transport.ClientCredentialType = clientCredentialType;
            binding.MessageEncoding = AzureQueueStorageMessageEncoding.Text;
            var azuriteAccount = AzuriteNUnitFixture.Instance.GetAzureAccount();
            var endpointUriBuilder = new UriBuilder(azuriteAccount.QueueEndpoint + "/" + queueName)
            {
                Scheme = "net.aqs"
            };
            serviceBuilder.AddServiceEndpoint<TestService, ITestContract>(binding, endpointUriBuilder.Uri.AbsoluteUri);

            serviceBuilder.UseAzureCredentials<TestService>(credentials =>
            {
                switch (clientCredentialType)
                {
                    case AzureClientCredentialType.ConnectionString:
                        credentials.ConnectionString = azuriteAccount.ConnectionString;
                        break;
                    case AzureClientCredentialType.StorageSharedKey:
                        var accountName = azuriteAccount.Name;
                        var accountKey = azuriteAccount.Key;
                        credentials.StorageSharedKey = new StorageSharedKeyCredential(accountName, accountKey);
                        break;
                    case AzureClientCredentialType.Token:
                        credentials.Token = AzuriteNUnitFixture.Instance.GetCredential();
                        break;
                }

                credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            });
        }
    }
}
#endif