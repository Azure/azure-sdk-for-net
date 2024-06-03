// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Storage;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.Storage.Sas;
using Contracts;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WCF.Azure.StorageQueues.Tests
{
    public class AuthenticationTests
    {
        // [TestCase(AzureClientCredentialType.Sas)] // Bugs with Azurite prevents testing with Sas
        [TestCase(AzureClientCredentialType.StorageSharedKey)]
        [TestCase(AzureClientCredentialType.ConnectionString)]
        [TestCase(AzureClientCredentialType.Token)]
        public async Task ConnectionStringAuthentication_SuccessAsync(AzureClientCredentialType clientCredentialType)
        {
            var queueName = "azure-queue";
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var transport = azuriteFixture.GetTransport();
            var connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            var queueClient = CreateQueueClient(clientCredentialType, queueName);
            queueClient.CreateIfNotExists();

            ChannelFactory<ITestContract> channelFactory = CreateChannelFactory(clientCredentialType, queueName);
            string endpointUrlString = channelFactory.Endpoint.Address.Uri.ToString();
            channelFactory.Open();
            ITestContract channel = channelFactory.CreateChannel();
            (channel as IChannel).Open();
            channel.Create("TestService");
            string inputMessage = $"<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://tempuri.org/ITestContract/Create</a:Action><a:To s:mustUnderstand=\"1\">{endpointUrlString}</a:To></s:Header><s:Body><Create xmlns=\"http://tempuri.org/\"><name>TestService</name></Create></s:Body></s:Envelope>";
            using CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(5));
            QueueMessage message = await queueClient.ReceiveMessageAsync(null, cancellationTokenSource.Token);
            Assert.AreEqual(inputMessage, message.MessageText.ToString());
        }

        private static QueueClient CreateQueueClient(AzureClientCredentialType clientCredentialType, string queueName)
        {
            var transport = AzuriteNUnitFixture.Instance.GetTransport();
            switch (clientCredentialType)
            {
                case AzureClientCredentialType.ConnectionString:
                    var connectionString = AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString;
                    return new QueueClient(connectionString, queueName, new QueueClientOptions { Transport = transport });
                case AzureClientCredentialType.StorageSharedKey:
                    var accountName = AzuriteNUnitFixture.Instance.GetAzureAccount().Name;
                    var accountKey = AzuriteNUnitFixture.Instance.GetAzureAccount().Key;
                    return new QueueClient(GetEndpointUri(queueName), new StorageSharedKeyCredential(accountName, accountKey), new QueueClientOptions { Transport = transport });
                case AzureClientCredentialType.Token:
                    var tokenCredential = AzuriteNUnitFixture.Instance.GetCredential();
                    return new QueueClient(GetEndpointUri(queueName), tokenCredential, new QueueClientOptions { Transport = transport });
                default:
                    return null;
            }
        }

        private static Uri GetEndpointUri(string queueName)
        {
            var azuriteAccount = AzuriteNUnitFixture.Instance.GetAzureAccount();
            var uriBuilder = new UriBuilder(azuriteAccount.QueueEndpoint);
            //uriBuilder.Host = "localhost";
            uriBuilder.Path = uriBuilder.Path + "/" + queueName;
            return uriBuilder.Uri;
        }

        private static ChannelFactory<ITestContract> CreateChannelFactory(AzureClientCredentialType clientCredentialType, string queueName)
        {
            var azuriteAccount = AzuriteNUnitFixture.Instance.GetAzureAccount();
            var endpointUriBuilder = new UriBuilder(GetEndpointUri(queueName))
            {
                Scheme = "net.aqs"
            };
            var endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;
            AzureQueueStorageBinding azureQueueStorageBinding = new()
            {
                Security = new()
                {
                    Transport = new()
                    {
                        ClientCredentialType = clientCredentialType
                    }
                },
                MessageEncoding = AzureQueueStorageMessageEncoding.Text
            };
            var channelFactory = new ChannelFactory<ITestContract>(azureQueueStorageBinding, new EndpointAddress(endpointUrlString));
            channelFactory.UseAzureCredentials(creds =>
            {
                switch (clientCredentialType)
                {
                    case AzureClientCredentialType.ConnectionString:
                        creds.ConnectionString = azuriteAccount.ConnectionString;
                        break;
                    case AzureClientCredentialType.StorageSharedKey:
                        var accountName = azuriteAccount.Name;
                        var accountKey = azuriteAccount.Key;
                        creds.StorageSharedKey = new StorageSharedKeyCredential(accountName, accountKey);
                        break;
                    case AzureClientCredentialType.Token:
                        creds.Token = AzuriteNUnitFixture.Instance.GetCredential();
                        break;
                }

                creds.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication
                {
                    CertificateValidationMode = X509CertificateValidationMode.None
                };
            });

            return channelFactory;
        }
    }
}
