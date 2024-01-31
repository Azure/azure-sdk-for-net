// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Queues.Specialized;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    internal class QueueSasTests : QueueTestBase
    {
        public QueueSasTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Create ServiceClient with Custom Account SAS without invoking other clients
        /// </summary>
        private QueueServiceClient GetQueueServiceClientWithCustomAccountSas(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Use UriBuilder over QueueUriBuilder to apply custom SAS, QueueUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(GetDefaultPrimaryEndpoint())
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            return InstrumentClient(new QueueServiceClient(uriBuilder.Uri, GetOptions()));
        }

        /// <summary>
        /// Create QueueClient with Custom Account SAS without invoking other clients
        /// </summary>
        private async Task<QueueClient> GetQueueClientWithCustomAccountSas(
            string queueName = default,
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            queueName = queueName ?? GetNewQueueName();
            // Use UriBuilder over QueueUriBuilder to apply custom SAS, QueueUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(GetDefaultPrimaryEndpoint())
            {
                Path = queueName,
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            QueueClient queueClient = InstrumentClient(new QueueClient(uriBuilder.Uri, GetOptions()));
            await queueClient.CreateAsync();
            return queueClient;
        }

        private async Task InvokeAccountSasTest(
            string permissions = "rwdylacuptfi",
            string services = "bqtf",
            string resourceType = "sco")
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            QueueClient queue = test.Queue;
            await queue.CreateAsync().ConfigureAwait(false);

            // Generate a SAS that would set the srt / ResourceTypes in a different order than
            // the .NET SDK would normally create the SAS
            TestAccountSasBuilder accountSasBuilder = new TestAccountSasBuilder(
                permissions: permissions,
                expiresOn: Recording.UtcNow.AddDays(1),
                services: services,
                resourceTypes: resourceType);

            string sasQueryParams = GetCustomAccountSas(permissions: permissions, services: services, resourceType: resourceType);
            UriBuilder blobUriBuilder = new UriBuilder(queue.Uri)
            {
                Query = sasQueryParams
            };

            // Assert
            QueueClient sasQueueClient = InstrumentClient(new QueueClient(blobUriBuilder.Uri, GetOptions()));
            await sasQueueClient.GetPropertiesAsync();

            Assert.AreEqual("?" + sasQueryParams, sasQueueClient.Uri.Query);
        }

        [RecordedTest]
        [TestCase("sco")]
        [TestCase("soc")]
        [TestCase("cos")]
        [TestCase("ocs")]
        [TestCase("cs")]
        [TestCase("oc")]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_ResourceTypeOrder(string resourceType)
        {
            await InvokeAccountSasTest(resourceType: resourceType);
        }

        [RecordedTest]
        [TestCase("bfqt")]
        [TestCase("qftb")]
        [TestCase("tqfb")]
        [TestCase("fqt")]
        [TestCase("qb")]
        [TestCase("fq")]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_ServiceOrder(string services)
        {
            await InvokeAccountSasTest(services: services);
        }

        // Creating Client from GetStorageClient
        #region QueueServiceClient
        private async Task InvokeAccountServiceToQueueSasTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            QueueServiceClient serviceClient = GetQueueServiceClientWithCustomAccountSas(
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            QueueClient queueClient = serviceClient.GetQueueClient(GetNewQueueName());

            // Assert
            Assert.AreEqual(serviceClient.Uri.Query, queueClient.Uri.Query);
            await queueClient.CreateAsync();
            await queueClient.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ServiceToQueue()
        {
            string resourceType = "soc";
            await InvokeAccountServiceToQueueSasTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ServiceToQueue()
        {
            string services = "fqt";
            await InvokeAccountServiceToQueueSasTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ServiceToQueue()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountServiceToQueueSasTest(permissions: permissions);
        }
        #endregion

        #region QueueClient
        private async Task InvokeAccountQueueToServiceSasTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            QueueClient queueClient = await GetQueueClientWithCustomAccountSas(
                permissions: permissions,
                services: services,
                resourceType: resourceType);
            try
            {
                // Act
                QueueServiceClient serviceClient = queueClient.GetParentQueueServiceClient();

                // Assert
                Assert.AreEqual(queueClient.Uri.Query, serviceClient.Uri.Query);
                await serviceClient.GetPropertiesAsync();
            }
            finally
            {
                await queueClient.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task AccountSasResources_QueueToService()
        {
            string resourceType = "soc";
            await InvokeAccountQueueToServiceSasTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_QueueToService()
        {
            string services = "fqt";
            await InvokeAccountQueueToServiceSasTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_QueueToService()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountQueueToServiceSasTest(permissions: permissions);
        }
        #endregion
    }
}
