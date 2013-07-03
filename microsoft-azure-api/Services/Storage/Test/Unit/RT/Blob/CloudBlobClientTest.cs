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

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CloudBlobClientTest : BlobTestBase
    {
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestBase.BlobBufferManager != null)
            {
                TestBase.BlobBufferManager.OutstandingBufferCount = 0;
            }
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (TestBase.BlobBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.BlobBufferManager.OutstandingBufferCount);
            }
        }

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

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;
            do
            {
                ContainerResultSegment resultSegment = await blobClient.ListContainersSegmentedAsync(token);
                token = resultSegment.ContinuationToken;

                foreach (CloudBlobContainer container in resultSegment.Results)
                {
                    listedContainerNames.Add(container.Name);
                }
            }
            while (token != null);

            foreach (string containerName in listedContainerNames)
            {
                if (containerNames.Remove(containerName))
                {
                    await blobClient.GetContainerReference(containerName).DeleteAsync();
                }
            }

            Assert.AreEqual(0, containerNames.Count);
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

        [TestMethod]
        /// [Description("Upload a blob with a small maximum execution time")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobClientMaximumExecutionTimeoutAsync()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(Guid.NewGuid().ToString("N"));
            byte[] buffer = BlobTestBase.GetRandomBuffer(20 * 1024 * 1024);

            try
            {
                await container.CreateAsync();
                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                blobClient.MaximumExecutionTime = TimeSpan.FromSeconds(5);

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    try
                    {
                        await blockBlob.UploadFromStreamAsync(ms.AsInputStream());
                    }
                    catch (Exception ex)
                    {
                        Assert.AreEqual("The client could not finish the operation within specified timeout.", RequestResult.TranslateFromExceptionMessage(ex.Message).ExceptionInfo.Message);
                    }
                }

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    try
                    {
                        await pageBlob.UploadFromStreamAsync(ms.AsInputStream());
                    }
                    catch (AggregateException ex)
                    {
                        Assert.AreEqual("The client could not finish the operation within specified timeout.", RequestResult.TranslateFromExceptionMessage(ex.InnerException.InnerException.Message).ExceptionInfo.Message);
                    }
                }
            }

            finally
            {
                blobClient.MaximumExecutionTime = null;
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Make sure MaxExecutionTime is not enforced when using streams")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobClientMaximumExecutionTimeoutShouldNotBeHonoredForStreamsAsync()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(Guid.NewGuid().ToString("N"));
            byte[] buffer = BlobTestBase.GetRandomBuffer(1024 * 1024);

            try
            {
                await container.CreateAsync();

                blobClient.MaximumExecutionTime = TimeSpan.FromSeconds(30);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                blockBlob.StreamWriteSizeInBytes = 1024 * 1024;
                blockBlob.StreamMinimumReadSizeInBytes = 1024 * 1024;
                blockBlob.StreamMinimumReadSizeInBytes = 1024 * 1024;
                pageBlob.StreamMinimumReadSizeInBytes = 1024 * 1024;

                using (ICloudBlobStream bos = await blockBlob.OpenWriteAsync())
                {
                    DateTime start = DateTime.Now;
                    for (int i = 0; i < 7; i++)
                    {
                        await bos.WriteAsync(buffer.AsBuffer());
                    }

                    // Sleep to ensure we are over the Max execution time when we do the last write
                    int msRemaining = (int)(blobClient.MaximumExecutionTime.Value - (DateTime.Now - start)).TotalMilliseconds;

                    if (msRemaining > 0)
                    {
                        await Task.Delay(msRemaining);
                    }

                    await bos.WriteAsync(buffer.AsBuffer());
                    await bos.CommitAsync();
                }

                using (Stream bis = (await blockBlob.OpenReadAsync()).AsStreamForRead())
                {
                    DateTime start = DateTime.Now;
                    int total = 0;
                    while (total < 7 * 1024 * 1024)
                    {
                        total += await bis.ReadAsync(buffer, 0, buffer.Length);
                    }

                    // Sleep to ensure we are over the Max execution time when we do the last read
                    int msRemaining = (int)(blobClient.MaximumExecutionTime.Value - (DateTime.Now - start)).TotalMilliseconds;

                    if (msRemaining > 0)
                    {
                        await Task.Delay(msRemaining);
                    }

                    while (true)
                    {
                        int count = await bis.ReadAsync(buffer, 0, buffer.Length);
                        total += count;
                        if (count == 0)
                            break;
                    }
                }

                using (ICloudBlobStream bos = await pageBlob.OpenWriteAsync(8 * 1024 * 1024))
                {
                    DateTime start = DateTime.Now;
                    for (int i = 0; i < 7; i++)
                    {
                        await bos.WriteAsync(buffer.AsBuffer());
                    }

                    // Sleep to ensure we are over the Max execution time when we do the last write
                    int msRemaining = (int)(blobClient.MaximumExecutionTime.Value - (DateTime.Now - start)).TotalMilliseconds;

                    if (msRemaining > 0)
                    {
                        await Task.Delay(msRemaining);
                    }

                    await bos.WriteAsync(buffer.AsBuffer());
                    await bos.CommitAsync();
                }

                using (Stream bis = (await pageBlob.OpenReadAsync()).AsStreamForRead())
                {
                    DateTime start = DateTime.Now;
                    int total = 0;
                    while (total < 7 * 1024 * 1024)
                    {
                        total += await bis.ReadAsync(buffer, 0, buffer.Length);
                    }

                    // Sleep to ensure we are over the Max execution time when we do the last read
                    int msRemaining = (int)(blobClient.MaximumExecutionTime.Value - (DateTime.Now - start)).TotalMilliseconds;

                    if (msRemaining > 0)
                    {
                        await Task.Delay(msRemaining);
                    }

                    while (true)
                    {
                        int count = await bis.ReadAsync(buffer, 0, buffer.Length);
                        total += count;
                        if (count == 0)
                            break;
                    }
                }
            }

            finally
            {
                blobClient.MaximumExecutionTime = null;
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }
    }
}
