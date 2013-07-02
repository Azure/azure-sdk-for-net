// -----------------------------------------------------------------------------------------
// <copyright file="CloudBlobClientTest.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CloudBlobClientTest : BlobTestBase
    {
        [TestMethod]
        /// [Description("Create a service client with URI and credentials")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientConstructor()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            Assert.IsTrue(blobClient.BaseUri.ToString().Contains(TestBase.TargetTenantConfig.BlobServiceEndpoint));
            Assert.AreEqual(TestBase.StorageCredentials, blobClient.Credentials);
            Assert.AreEqual(AuthenticationScheme.SharedKey, blobClient.AuthenticationScheme);
        }

        [TestMethod]
        /// [Description("Create a service client with uppercase account name")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobClientWithUppercaseAccountNameAsync()
        {
            StorageCredentials credentials = new StorageCredentials(TestBase.StorageCredentials.AccountName.ToUpper(), Convert.ToBase64String(TestBase.StorageCredentials.ExportKey()));
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.BlobServiceEndpoint);
            CloudBlobClient blobClient = new CloudBlobClient(baseAddressUri, TestBase.StorageCredentials);
            CloudBlobContainer container = blobClient.GetContainerReference("container");
            await container.ExistsAsync();
        }

        [TestMethod]
        /// [Description("Compare service client properties of blob objects")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientObjects()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("container");
            Assert.AreEqual(blobClient, container.ServiceClient);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("blockblob");
            Assert.AreEqual(blobClient, blockBlob.ServiceClient);
            CloudPageBlob pageBlob = container.GetPageBlobReference("pageblob");
            Assert.AreEqual(blobClient, pageBlob.ServiceClient);

            CloudBlobContainer container2 = GetRandomContainerReference();
            Assert.AreNotEqual(blobClient, container2.ServiceClient);
            CloudBlockBlob blockBlob2 = container2.GetBlockBlobReference("blockblob");
            Assert.AreEqual(container2.ServiceClient, blockBlob2.ServiceClient);
            CloudPageBlob pageBlob2 = container2.GetPageBlobReference("pageblob");
            Assert.AreEqual(container2.ServiceClient, pageBlob2.ServiceClient);
        }

        [TestMethod]
        /// [Description("List blobs with prefix")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobClientListBlobsSegmentedWithPrefixAsync()
        {
            string name = "bb" + GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer rootContainer = blobClient.GetRootContainerReference();
            CloudBlobContainer container = blobClient.GetContainerReference(name);

            try
            {
                await rootContainer.CreateIfNotExistsAsync();
                await container.CreateAsync();

                List<string> blobNames = await CreateBlobsAsync(container, 3, BlobType.BlockBlob);
                List<string> rootBlobNames = await CreateBlobsAsync(rootContainer, 2, BlobType.BlockBlob);

                BlobResultSegment results;
                BlobContinuationToken token = null;
                do
                {
                    results = await blobClient.ListBlobsSegmentedAsync("bb", token);
                    token = results.ContinuationToken;

                    foreach (CloudBlockBlob blob in results.Results)
                    {
                        await blob.DeleteAsync();
                        rootBlobNames.Remove(blob.Name);
                    }
                }
                while (token != null);
                Assert.AreEqual(0, rootBlobNames.Count);

                results = await blobClient.ListBlobsSegmentedAsync("bb", token);
                Assert.AreEqual(0, results.Results.Count());
                Assert.IsNull(results.ContinuationToken);

                results = await blobClient.ListBlobsSegmentedAsync(name, token);
                Assert.AreEqual(0, results.Results.Count());
                Assert.IsNull(results.ContinuationToken);

                token = null;
                do
                {
                    results = await blobClient.ListBlobsSegmentedAsync(name + "/", token);
                    token = results.ContinuationToken;

                    foreach (CloudBlockBlob blob in results.Results)
                    {
                        Assert.IsTrue(blobNames.Remove(blob.Name));
                    }
                }
                while (token != null);
                Assert.AreEqual(0, blobNames.Count);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("List containers")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobClientListContainersSegmentedAsync()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                await blobClient.GetContainerReference(containerName).CreateAsync();
            }

            BlobContinuationToken token = null;
            do
            {
                ContainerResultSegment results = await blobClient.ListContainersSegmentedAsync(token);
                token = results.ContinuationToken;

                foreach (CloudBlobContainer container in results.Results)
                {
                    if (containerNames.Remove(container.Name))
                    {
                        await container.DeleteAsync();
                    }
                }
            }
            while (token != null);
            Assert.AreEqual<int>(0, containerNames.Count);
        }

        [TestMethod]
        /// [Description("List containers with prefix using segmented listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobClientListContainersSegmentedWithPrefixAsync()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                await blobClient.GetContainerReference(containerName).CreateAsync();
            }

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;
            do
            {
                ContainerResultSegment resultSegment = await blobClient.ListContainersSegmentedAsync(name, ContainerListingDetails.None, 1, token, null, null);
                token = resultSegment.ContinuationToken;

                int count = 0;
                foreach (CloudBlobContainer container in resultSegment.Results)
                {
                    count++;
                    listedContainerNames.Add(container.Name);
                }
                Assert.IsTrue(count <= 1);
            }
            while (token != null);

            Assert.AreEqual(containerNames.Count, listedContainerNames.Count);
            foreach (string containerName in listedContainerNames)
            {
                Assert.IsTrue(containerNames.Remove(containerName));
                await blobClient.GetContainerReference(containerName).DeleteAsync();
            }
        }

        [TestMethod]
        // [Description("Test Create Container with Shared Key Lite")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobClientCreateContainerSharedKeyLiteAsync()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            blobClient.AuthenticationScheme = AuthenticationScheme.SharedKeyLite;

            string containerName = GetRandomContainerName();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            await blobContainer.CreateAsync();

            bool exists = await blobContainer.ExistsAsync();
            Assert.IsTrue(exists);

            await blobContainer.DeleteAsync();
        }
    }
}
