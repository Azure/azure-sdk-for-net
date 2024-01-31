// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobBatchSasTests : BlobTestBase
    {
        public BlobBatchSasTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion)
        {
        }

        /// <summary>
        /// Create ServiceClient with Custom Account SAS without invoking other clients
        /// </summary>
        private BlobServiceClient GetServiceWithCustomAccountSas(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(GetDefaultPrimaryEndpoint())
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            return InstrumentClient(new BlobServiceClient(uriBuilder.Uri, GetOptions()));
        }

        #region BlobBatchClient
        private void InvokeAccountSasServiceToBatchTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceWithCustomAccountSas(
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            BlobBatchClient batchClient = serviceClient.GetBlobBatchClient();

            // Assert
            Assert.AreEqual(serviceClient.Uri.Query, batchClient.Uri.Query);
        }

        [RecordedTest]
        public void AccountSasResources_ServiceToBatch()
        {
            string resourceType = "soc";
            InvokeAccountSasServiceToBatchTest(resourceType: resourceType);
        }

        [RecordedTest]
        public void AccountSasServices_ServiceToBatch()
        {
            string services = "fqb";
            InvokeAccountSasServiceToBatchTest(services: services);
        }

        [RecordedTest]
        public void AccountSasPermissions_ServiceToBatch()
        {
            string permissions = "cuprwdyla";
            InvokeAccountSasServiceToBatchTest(permissions: permissions);
        }

        private void InvokeAccountSasContainerToBatchTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            UriBuilder uriBuilder = new UriBuilder(new Uri("http://storageaccount.azure.storage.net/"))
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlobBatchClient batchClient = containerClient.GetBlobBatchClient();

            // Assert
            Assert.AreEqual(containerClient.Uri.Query, batchClient.Uri.Query);
        }

        [RecordedTest]
        public void AccountSasResources_ContainerToBatch()
        {
            string resourceType = "soc";
            InvokeAccountSasContainerToBatchTest(resourceType: resourceType);
        }

        [RecordedTest]
        public void AccountSasServices_ContainerToBatch()
        {
            string services = "fqb";
            InvokeAccountSasContainerToBatchTest(services: services);
        }

        [RecordedTest]
        public void AccountSasPermissions_ContainerToBatch()
        {
            string permissions = "cuprwdyla";
            InvokeAccountSasContainerToBatchTest(permissions: permissions);
        }
        #endregion
    }
}
