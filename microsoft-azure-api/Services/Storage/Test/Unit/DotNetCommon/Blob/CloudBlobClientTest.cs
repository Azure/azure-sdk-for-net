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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

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
        [Description("Create a service client with URI and credentials")]
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
        [Description("Create a service client with uppercase account name")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientWithUppercaseAccountName()
        {
            StorageCredentials credentials = new StorageCredentials(TestBase.StorageCredentials.AccountName.ToUpper(), TestBase.StorageCredentials.ExportKey());
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.BlobServiceEndpoint);
            CloudBlobClient blobClient = new CloudBlobClient(baseAddressUri, TestBase.StorageCredentials);
            CloudBlobContainer container = blobClient.GetContainerReference("container");
            container.Exists();
        }

        [TestMethod]
        [Description("Compare service client properties of blob objects")]
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
        [Description("List blobs with prefix")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListBlobsWithPrefix()
        {
            string name = "bb" + GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer rootContainer = blobClient.GetRootContainerReference();
            CloudBlobContainer container = blobClient.GetContainerReference(name);

            try
            {
                rootContainer.CreateIfNotExists();
                container.Create();

                List<string> blobNames = CreateBlobs(container, 3, BlobType.BlockBlob);
                List<string> rootBlobNames = CreateBlobs(rootContainer, 2, BlobType.BlockBlob);

                IEnumerable<IListBlobItem> results = blobClient.ListBlobs("bb");
                foreach (CloudBlockBlob blob in results)
                {
                    blob.Delete();
                    rootBlobNames.Remove(blob.Name);
                }
                Assert.AreEqual(0, rootBlobNames.Count);
                Assert.AreEqual(0, blobClient.ListBlobs("bb").Count());

                Assert.AreEqual(0, blobClient.ListBlobs(name).Count());
                results = blobClient.ListBlobs(name + "/");
                foreach (CloudBlockBlob blob in results)
                {
                    Assert.IsTrue(blobNames.Remove(blob.Name));
                }
                Assert.AreEqual(0, blobNames.Count);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("List blobs with prefix")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListBlobsSegmentedWithPrefix()
        {
            string name = "bb" + GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer rootContainer = blobClient.GetRootContainerReference();
            CloudBlobContainer container = blobClient.GetContainerReference(name);

            try
            {
                rootContainer.CreateIfNotExists();
                container.Create();

                List<string> blobNames = CreateBlobs(container, 3, BlobType.BlockBlob);
                List<string> rootBlobNames = CreateBlobs(rootContainer, 2, BlobType.BlockBlob);

                BlobResultSegment results;
                BlobContinuationToken token = null;
                do
                {
                    results = blobClient.ListBlobsSegmented("bb", token);
                    token = results.ContinuationToken;

                    foreach (CloudBlockBlob blob in results.Results)
                    {
                        blob.Delete();
                        rootBlobNames.Remove(blob.Name);
                    }
                }
                while (token != null);
                Assert.AreEqual(0, rootBlobNames.Count);

                results = blobClient.ListBlobsSegmented("bb", token);
                Assert.AreEqual(0, results.Results.Count());
                Assert.IsNull(results.ContinuationToken);

                results = blobClient.ListBlobsSegmented(name, token);
                Assert.AreEqual(0, results.Results.Count());
                Assert.IsNull(results.ContinuationToken);

                token = null;
                do
                {
                    results = blobClient.ListBlobsSegmented(name + "/", token);
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
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("List blobs with empty prefix")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListBlobsSegmentedWithEmptyPrefix()
        {
            string name = "bb" + GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer rootContainer = blobClient.GetRootContainerReference();
            CloudBlobContainer container = blobClient.GetContainerReference(name);

            try
            {
                rootContainer.CreateIfNotExists();
                container.Create();
                List<Uri> preExistingBlobs = rootContainer.ListBlobs().Select(b => b.Uri).ToList();

                List<string> blobNames = CreateBlobs(container, 3, BlobType.BlockBlob);
                List<string> rootBlobNames = CreateBlobs(rootContainer, 2, BlobType.BlockBlob);

                BlobResultSegment results;
                BlobContinuationToken token = null;
                List<Uri> listedBlobs = new List<Uri>();
                do
                {
                    results = blobClient.ListBlobsSegmented("", token);
                    token = results.ContinuationToken;

                    foreach (IListBlobItem blob in results.Results)
                    {
                        if (preExistingBlobs.Contains(blob.Uri))
                        {
                            continue;
                        }
                        else
                        {
                            if (blob is CloudPageBlob)
                            {
                                ((CloudPageBlob)blob).Delete();
                            }
                            else
                            {
                                ((CloudBlockBlob)blob).Delete();
                            }

                            listedBlobs.Add(blob.Uri);
                        }
                    }
                }
                while (token != null);

                Assert.AreEqual(2, listedBlobs.Count);
                do
                {
                    results = container.ListBlobsSegmented("", false, BlobListingDetails.None, null, token, null, null);
                    token = results.ContinuationToken;

                    foreach (IListBlobItem blob in results.Results)
                    {
                        if (preExistingBlobs.Contains(blob.Uri))
                        {
                            continue;
                        }
                        else
                        {
                            if (blob is CloudPageBlob)
                            {
                                ((CloudPageBlob)blob).Delete();
                            }
                            else
                            {
                                ((CloudBlockBlob)blob).Delete();
                            }

                            listedBlobs.Add(blob.Uri);
                        }
                    }
                }
                while (token != null);

                Assert.AreEqual(5, listedBlobs.Count);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("List blobs with prefix")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListBlobsSegmentedWithPrefixAPM()
        {
            string name = "bb" + GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer rootContainer = blobClient.GetRootContainerReference();
            CloudBlobContainer container = blobClient.GetContainerReference(name);

            try
            {
                rootContainer.CreateIfNotExists();
                container.Create();

                List<string> blobNames = CreateBlobs(container, 3, BlobType.BlockBlob);
                List<string> rootBlobNames = CreateBlobs(rootContainer, 2, BlobType.BlockBlob);

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result;
                    BlobResultSegment results;
                    BlobContinuationToken token = null;
                    do
                    {
                        result = blobClient.BeginListBlobsSegmented("bb", token,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        results = blobClient.EndListBlobsSegmented(result);
                        token = results.ContinuationToken;

                        foreach (CloudBlockBlob blob in results.Results)
                        {
                            blob.Delete();
                            rootBlobNames.Remove(blob.Name);
                        }
                    }
                    while (token != null);
                    Assert.AreEqual(0, rootBlobNames.Count);

                    result = blobClient.BeginListBlobsSegmented("bb", token,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    results = blobClient.EndListBlobsSegmented(result);
                    Assert.AreEqual(0, results.Results.Count());
                    Assert.IsNull(results.ContinuationToken);

                    result = blobClient.BeginListBlobsSegmented(name, token,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    results = blobClient.EndListBlobsSegmented(result);
                    Assert.AreEqual(0, results.Results.Count());
                    Assert.IsNull(results.ContinuationToken);

                    token = null;
                    do
                    {
                        result = blobClient.BeginListBlobsSegmented(name + "/", token,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        results = blobClient.EndListBlobsSegmented(result);
                        token = results.ContinuationToken;

                        foreach (CloudBlockBlob blob in results.Results)
                        {
                            Assert.IsTrue(blobNames.Remove(blob.Name));
                        }
                    }
                    while (token != null);
                    Assert.AreEqual(0, blobNames.Count);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("List blobs with prefix")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListBlobsSegmentedWithPrefixTask()
        {
            string name = "bb" + GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer rootContainer = blobClient.GetRootContainerReference();
            CloudBlobContainer container = blobClient.GetContainerReference(name);

            try
            {
                rootContainer.CreateIfNotExistsAsync().Wait();
                container.CreateAsync().Wait();

                List<string> blobNames = CreateBlobsTask(container, 3, BlobType.BlockBlob);
                List<string> rootBlobNames = CreateBlobsTask(rootContainer, 2, BlobType.BlockBlob);

                BlobResultSegment results;
                BlobContinuationToken token = null;
                do
                {
                    results = blobClient.ListBlobsSegmentedAsync("bb", token).Result;
                    token = results.ContinuationToken;

                    foreach (CloudBlockBlob blob in results.Results)
                    {
                        blob.DeleteAsync().Wait();
                        rootBlobNames.Remove(blob.Name);
                    }
                }
                while (token != null);
                Assert.AreEqual(0, rootBlobNames.Count);

                results = blobClient.ListBlobsSegmentedAsync("bb", token).Result;
                Assert.AreEqual(0, results.Results.Count());
                Assert.IsNull(results.ContinuationToken);

                results = blobClient.ListBlobsSegmentedAsync(name, token).Result;
                Assert.AreEqual(0, results.Results.Count());
                Assert.IsNull(results.ContinuationToken);

                token = null;
                do
                {
                    results = blobClient.ListBlobsSegmentedAsync(name + "/", token).Result;
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
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test BlobClient ListBlobsSegmented - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListBlobsSegmentedPrefixCurrentTokenTask()
        {
            string containerName = GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            int blobCount = 3;

            string prefix = containerName + "/bb";
            BlobContinuationToken currentToken = null;

            try
            {
                container.CreateAsync().Wait();

                List<string> blobNames = CreateBlobsTask(container, blobCount, BlobType.BlockBlob);

                int totalCount = 0;
                do
                {
                    BlobResultSegment resultSegment = blobClient.ListBlobsSegmentedAsync(prefix, currentToken).Result;
                    currentToken = resultSegment.ContinuationToken;

                    int count = 0;
                    foreach (CloudBlockBlob blockBlob in resultSegment.Results)
                    {
                        Assert.AreEqual(BlobType.BlockBlob, blockBlob.BlobType);
                        Assert.IsTrue(blockBlob.Name.StartsWith("bb"));
                        ++count;
                    }

                    totalCount += count;
                }
                while (currentToken != null);

                Assert.AreEqual(blobCount, totalCount);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test BlobClient ListBlobsSegmented - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListBlobsSegmentedPrefixCurrentTokenCancellationTokenTask()
        {
            string containerName = GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            int blobCount = 3;

            string prefix = containerName + "/bb";
            BlobContinuationToken currentToken = null;
            CancellationToken cancellationToken = new CancellationToken();

            try
            {
                container.CreateAsync().Wait();

                List<string> blobNames = CreateBlobsTask(container, blobCount, BlobType.BlockBlob);

                int totalCount = 0;
                do
                {
                    BlobResultSegment resultSegment = blobClient.ListBlobsSegmentedAsync(prefix, currentToken, cancellationToken).Result;
                    currentToken = resultSegment.ContinuationToken;

                    int count = 0;
                    foreach (CloudBlockBlob blockBlob in resultSegment.Results)
                    {
                        Assert.AreEqual(BlobType.BlockBlob, blockBlob.BlobType);
                        Assert.IsTrue(blockBlob.Name.StartsWith("bb"));
                        ++count;
                    }

                    totalCount += count;
                }
                while (currentToken != null);

                Assert.AreEqual(blobCount, totalCount);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test BlobClient ListBlobsSegmented - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListBlobsSegmentedPrefixUseFlatBlobListingDetailsMaxResultsCurrentTokenOptionsOperationContextTask()
        {
            string containerName = GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            int blobCount = 3;

            string prefix = containerName + "/bb";
            bool useFlatBlobListing = false;
            BlobListingDetails blobListingDetails = BlobListingDetails.None;
            int? maxResults = 10;
            BlobContinuationToken currentToken = null;
            BlobRequestOptions options = new BlobRequestOptions();
            OperationContext operationContext = new OperationContext();

            try
            {
                container.CreateAsync().Wait();

                List<string> blobNames = CreateBlobsTask(container, blobCount, BlobType.BlockBlob);

                int totalCount = 0;
                do
                {
                    BlobResultSegment resultSegment = blobClient.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext).Result;
                    currentToken = resultSegment.ContinuationToken;

                    int count = 0;
                    foreach (CloudBlockBlob blockBlob in resultSegment.Results)
                    {
                        Assert.AreEqual(BlobType.BlockBlob, blockBlob.BlobType);
                        Assert.IsTrue(blockBlob.Name.StartsWith("bb"));
                        ++count;
                    }

                    totalCount += count;

                    Assert.IsTrue(count <= maxResults.Value);
                }
                while (currentToken != null);

                Assert.AreEqual(blobCount, totalCount);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test BlobClient ListBlobsSegmented - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListBlobsSegmentedPrefixUseFlatBlobListingDetailsMaxResultsCurrentTokenOptionsOperationContextCancellationTokenTask()
        {
            string containerName = GetRandomContainerName();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            int blobCount = 3;

            string prefix = containerName + "/bb";
            bool useFlatBlobListing = false;
            BlobListingDetails blobListingDetails = BlobListingDetails.None;
            int? maxResults = 10;
            BlobContinuationToken currentToken = null;
            BlobRequestOptions options = new BlobRequestOptions();
            OperationContext operationContext = new OperationContext();
            CancellationToken cancellationToken = new CancellationToken();

            try
            {
                container.CreateAsync().Wait();

                List<string> blobNames = CreateBlobsTask(container, blobCount, BlobType.BlockBlob);

                int totalCount = 0;
                do
                {
                    BlobResultSegment resultSegment = blobClient.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext, cancellationToken).Result;
                    currentToken = resultSegment.ContinuationToken;

                    int count = 0;
                    foreach (CloudBlockBlob blockBlob in resultSegment.Results)
                    {
                        Assert.AreEqual(BlobType.BlockBlob, blockBlob.BlobType);
                        Assert.IsTrue(blockBlob.Name.StartsWith("bb"));
                        ++count;
                    }

                    totalCount += count;

                    Assert.IsTrue(count <= maxResults.Value);
                }
                while (currentToken != null);

                Assert.AreEqual(blobCount, totalCount);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("List containers")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainers()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).Create();
            }

            IEnumerable<CloudBlobContainer> results = blobClient.ListContainers();

            foreach (CloudBlobContainer container in results)
            {
                if (containerNames.Remove(container.Name))
                {
                    container.Delete();
                }
            }

            Assert.AreEqual(0, containerNames.Count);
        }

        [TestMethod]
        [Description("List containers with prefix")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersWithPrefix()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).Create();
            }

            IEnumerable<CloudBlobContainer> results = blobClient.ListContainers(name, ContainerListingDetails.None, null, null);
            Assert.AreEqual(containerNames.Count, results.Count());
            foreach (CloudBlobContainer container in results)
            {
                Assert.IsTrue(containerNames.Remove(container.Name));
                container.Delete();
            }

            results = blobClient.ListContainers(name, ContainerListingDetails.None, null, null);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        [Description("List containers with prefix using segmented listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersWithPrefixSegmented()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).Create();
            }

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;
            do
            {
                ContainerResultSegment resultSegment = blobClient.ListContainersSegmented(name, ContainerListingDetails.None, 1, token);
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
                blobClient.GetContainerReference(containerName).Delete();
            }
        }

        [TestMethod]
        [Description("List containers with a prefix using segmented listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersWithPrefixSegmented2()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).Create();
            }

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;
            do
            {
                ContainerResultSegment resultSegment = blobClient.ListContainersSegmented(name, token);
                token = resultSegment.ContinuationToken;

                int count = 0;
                foreach (CloudBlobContainer container in resultSegment.Results)
                {
                    count++;
                    listedContainerNames.Add(container.Name);
                }
            }
            while (token != null);

            Assert.AreEqual(containerNames.Count, listedContainerNames.Count);
            foreach (string containerName in listedContainerNames)
            {
                Assert.IsTrue(containerNames.Remove(containerName));
                blobClient.GetContainerReference(containerName).Delete();
            }
            Assert.AreEqual(0, containerNames.Count);
        }

        [TestMethod]
        [Description("List containers")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersWithPrefixSegmentedAPM()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).Create();
            }

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;
                do
                {
                    result = blobClient.BeginListContainersSegmented(name, token, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    ContainerResultSegment resultSegment = blobClient.EndListContainersSegmented(result);
                    token = resultSegment.ContinuationToken;

                    int count = 0;
                    foreach (CloudBlobContainer container in resultSegment.Results)
                    {
                        count++;
                        listedContainerNames.Add(container.Name);
                    }
                }
                while (token != null);

                Assert.AreEqual(containerNames.Count, listedContainerNames.Count);
                foreach (string containerName in listedContainerNames)
                {
                    Assert.IsTrue(containerNames.Remove(containerName));
                    blobClient.GetContainerReference(containerName).Delete();
                }
                Assert.AreEqual(0, containerNames.Count);
            }
        }

#if TASK
        [TestMethod]
        [Description("List containers with prefix using segmented listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersWithPrefixSegmentedTask()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).CreateAsync().Wait();
            }

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;

            do
            {
                ContainerResultSegment resultSegment = blobClient.ListContainersSegmentedAsync(name, token).Result;
                token = resultSegment.ContinuationToken;

                int count = 0;
                foreach (CloudBlobContainer container in resultSegment.Results)
                {
                    count++;
                    listedContainerNames.Add(container.Name);
                }
            }
            while (token != null);

            Assert.AreEqual(containerNames.Count, listedContainerNames.Count);
            foreach (string containerName in listedContainerNames)
            {
                Assert.IsTrue(containerNames.Remove(containerName));
                blobClient.GetContainerReference(containerName).DeleteAsync().Wait();
            }
            Assert.AreEqual(0, containerNames.Count);
        }
#endif

        [TestMethod]
        [Description("List more than 5K containers with prefix using segmented listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric)]
        public void CloudBlobClientListManyContainersSegmentedWithPrefix()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 5050; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).Create();
            }

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;
            do
            {
                ContainerResultSegment resultSegment = blobClient.ListContainersSegmented(name, ContainerListingDetails.None, 1, token);
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
                blobClient.GetContainerReference(containerName).Delete();
            }
        }

        [TestMethod]
        [Description("Test Create Container with Shared Key Lite")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientCreateContainerSharedKeyLite()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            blobClient.AuthenticationScheme = AuthenticationScheme.SharedKeyLite;

            string containerName = GetRandomContainerName();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            blobContainer.Create();

            bool exists = blobContainer.Exists();
            Assert.IsTrue(exists);

            blobContainer.Delete();
        }

        [TestMethod]
        [Description("List containers using segmented listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersSegmented()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).Create();
            }

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;
            do
            {
                ContainerResultSegment resultSegment = blobClient.ListContainersSegmented(token);
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
                    blobClient.GetContainerReference(containerName).Delete();
                }
            }

            Assert.AreEqual(0, containerNames.Count);
        }

        [TestMethod]
        [Description("List containers")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersSegmentedAPM()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).Create();
            }

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;
                do
                {
                    result = blobClient.BeginListContainersSegmented(token, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    ContainerResultSegment resultSegment = blobClient.EndListContainersSegmented(result);
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
                        blobClient.GetContainerReference(containerName).Delete();
                    }
                }

                Assert.AreEqual(0, containerNames.Count);
            }
        }

#if TASK
        [TestMethod]
        [Description("List containers using segmented listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersSegmentedTask()
        {
            string name = GetRandomContainerName();
            List<string> containerNames = new List<string>();
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            for (int i = 0; i < 3; i++)
            {
                string containerName = name + i.ToString();
                containerNames.Add(containerName);
                blobClient.GetContainerReference(containerName).CreateAsync().Wait();
            }

            List<string> listedContainerNames = new List<string>();
            BlobContinuationToken token = null;
            do
            {
                ContainerResultSegment resultSegment = blobClient.ListContainersSegmentedAsync(token).Result;
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
                    blobClient.GetContainerReference(containerName).DeleteAsync().Wait();
                }
            }

            Assert.AreEqual(0, containerNames.Count);
        }

        [TestMethod]
        [Description("CloudBlobClient ListContainersSegmentedAsync - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersSegmentedContinuationTokenTask()
        {
            int containerCount = 3;
            string containerNamePrefix = GetRandomContainerName();
            List<string> containerNames = new List<string>(containerCount);
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            BlobContinuationToken continuationToken = null;

            try
            {
                for (int i = 0; i < containerCount; ++i)
                {
                    string containerName = containerNamePrefix + i.ToString();
                    containerNames.Add(containerName);
                    blobClient.GetContainerReference(containerName).CreateAsync().Wait();
                }

                int totalCount = 0;
                do
                {
                    ContainerResultSegment resultSegment = blobClient.ListContainersSegmentedAsync(continuationToken).Result;
                    continuationToken = resultSegment.ContinuationToken;

                    foreach (CloudBlobContainer container in resultSegment.Results)
                    {
                        if (containerNames.Contains(container.Name))
                        {
                            ++totalCount;
                        }
                    }
                }
                while (continuationToken != null);

                Assert.AreEqual(containerCount, totalCount);
            }
            finally
            {
                foreach (string containerName in containerNames)
                {
                    blobClient.GetContainerReference(containerName).DeleteAsync().Wait();
                }
            }
        }

        [TestMethod]
        [Description("CloudBlobClient ListContainersSegmentedAsync - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersSegmentedContinuationTokenCancellationTokenTask()
        {
            int containerCount = 3;
            string containerNamePrefix = GetRandomContainerName();
            List<string> containerNames = new List<string>(containerCount);
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            BlobContinuationToken continuationToken = null;
            CancellationToken cancellationToken = CancellationToken.None;

            try
            {
                for (int i = 0; i < containerCount; ++i)
                {
                    string containerName = containerNamePrefix + i.ToString();
                    containerNames.Add(containerName);
                    blobClient.GetContainerReference(containerName).CreateAsync().Wait();
                }

                int totalCount = 0;
                do
                {
                    ContainerResultSegment resultSegment = blobClient.ListContainersSegmentedAsync(continuationToken, cancellationToken).Result;
                    continuationToken = resultSegment.ContinuationToken;

                    foreach (CloudBlobContainer container in resultSegment.Results)
                    {
                        if (containerNames.Contains(container.Name))
                        {
                            ++totalCount;
                        }
                    }
                }
                while (continuationToken != null);

                Assert.AreEqual(containerCount, totalCount);
            }
            finally
            {
                foreach (string containerName in containerNames)
                {
                    blobClient.GetContainerReference(containerName).DeleteAsync().Wait();
                }
            }
        }

        [TestMethod]
        [Description("CloudBlobClient ListContainersSegmentedAsync - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersSegmentedPrefixContinuationToken()
        {
            int containerCount = 3;
            string containerNamePrefix = GetRandomContainerName();
            List<string> containerNames = new List<string>(containerCount);
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            string prefix = containerNamePrefix;
            BlobContinuationToken continuationToken = null;

            try
            {
                for (int i = 0; i < containerCount; ++i)
                {
                    string containerName = containerNamePrefix + i.ToString();
                    containerNames.Add(containerName);
                    blobClient.GetContainerReference(containerName).CreateAsync().Wait();
                }

                int totalCount = 0;
                do
                {
                    ContainerResultSegment resultSegment = blobClient.ListContainersSegmentedAsync(prefix, continuationToken).Result;
                    continuationToken = resultSegment.ContinuationToken;

                    foreach (CloudBlobContainer container in resultSegment.Results)
                    {
                        if (containerNames.Contains(container.Name))
                        {
                            ++totalCount;
                        }
                    }
                }
                while (continuationToken != null);

                Assert.AreEqual(containerCount, totalCount);
            }
            finally
            {
                foreach (string containerName in containerNames)
                {
                    blobClient.GetContainerReference(containerName).DeleteAsync().Wait();
                }
            }
        }

        [TestMethod]
        [Description("CloudBlobClient ListContainersSegmentedAsync - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersSegmentedPrefixContinuationTokenCancellationTokenTask()
        {
            int containerCount = 3;
            string containerNamePrefix = GetRandomContainerName();
            List<string> containerNames = new List<string>(containerCount);
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            string prefix = containerNamePrefix;
            BlobContinuationToken continuationToken = null;
            CancellationToken cancellationToken = CancellationToken.None;

            try
            {
                for (int i = 0; i < containerCount; ++i)
                {
                    string containerName = containerNamePrefix + i.ToString();
                    containerNames.Add(containerName);
                    blobClient.GetContainerReference(containerName).CreateAsync().Wait();
                }

                int totalCount = 0;
                do
                {
                    ContainerResultSegment resultSegment = blobClient.ListContainersSegmentedAsync(prefix, continuationToken, cancellationToken).Result;
                    continuationToken = resultSegment.ContinuationToken;

                    foreach (CloudBlobContainer container in resultSegment.Results)
                    {
                        if (containerNames.Contains(container.Name))
                        {
                            ++totalCount;
                        }
                    }
                }
                while (continuationToken != null);

                Assert.AreEqual(containerCount, totalCount);
            }
            finally
            {
                foreach (string containerName in containerNames)
                {
                    blobClient.GetContainerReference(containerName).DeleteAsync().Wait();
                }
            }
        }

        [TestMethod]
        [Description("CloudBlobClient ListContainersSegmentedAsync - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersSegmentedPrefixDetailsIncludedMaxResultsContinuationTokenOptionsOperationContextTask()
        {
            int containerCount = 3;
            string containerNamePrefix = GetRandomContainerName();
            List<string> containerNames = new List<string>(containerCount);
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            string prefix = containerNamePrefix;
            ContainerListingDetails detailsIncluded = ContainerListingDetails.None;
            int? maxResults = 10;
            BlobContinuationToken continuationToken = null;
            BlobRequestOptions options = new BlobRequestOptions();
            OperationContext operationContext = new OperationContext();

            try
            {
                for (int i = 0; i < containerCount; ++i)
                {
                    string containerName = containerNamePrefix + i.ToString();
                    containerNames.Add(containerName);
                    blobClient.GetContainerReference(containerName).CreateAsync().Wait();
                }

                int totalCount = 0;
                do
                {
                    ContainerResultSegment resultSegment = blobClient.ListContainersSegmentedAsync(prefix, detailsIncluded, maxResults, continuationToken, options, operationContext).Result;
                    continuationToken = resultSegment.ContinuationToken;

                    int count = 0;
                    foreach (CloudBlobContainer container in resultSegment.Results)
                    {
                        if (containerNames.Contains(container.Name))
                        {
                            ++totalCount;
                        }
                        ++count;
                    }

                    Assert.IsTrue(count <= maxResults.Value);
                }
                while (continuationToken != null);

                Assert.AreEqual(containerCount, totalCount);
            }
            finally
            {
                foreach (string containerName in containerNames)
                {
                    blobClient.GetContainerReference(containerName).DeleteAsync().Wait();
                }
            }
        }

        [TestMethod]
        [Description("CloudBlobClient ListContainersSegmentedAsync - Task")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientListContainersSegmentedPrefixDetailsIncludedMaxResultsContinuationTokenOptionsOperationContextCancellationTokenTask()
        {
            int containerCount = 3;
            string containerNamePrefix = GetRandomContainerName();
            List<string> containerNames = new List<string>(containerCount);
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            string prefix = containerNamePrefix;
            ContainerListingDetails detailsIncluded = ContainerListingDetails.None;
            int? maxResults = 10;
            BlobContinuationToken continuationToken = null;
            BlobRequestOptions options = new BlobRequestOptions();
            OperationContext operationContext = new OperationContext();
            CancellationToken cancellationToken = CancellationToken.None;

            try
            {
                for (int i = 0; i < containerCount; ++i)
                {
                    string containerName = containerNamePrefix + i.ToString();
                    containerNames.Add(containerName);
                    blobClient.GetContainerReference(containerName).CreateAsync().Wait();
                }

                int totalCount = 0;
                do
                {
                    ContainerResultSegment resultSegment = blobClient.ListContainersSegmentedAsync(prefix, detailsIncluded, maxResults, continuationToken, options, operationContext, cancellationToken).Result;
                    continuationToken = resultSegment.ContinuationToken;

                    int count = 0;
                    foreach (CloudBlobContainer container in resultSegment.Results)
                    {
                        if (containerNames.Contains(container.Name))
                        {
                            ++totalCount;
                        }
                        ++count;
                    }

                    Assert.IsTrue(count <= maxResults.Value);
                }
                while (continuationToken != null);

                Assert.AreEqual(containerCount, totalCount);
            }
            finally
            {
                foreach (string containerName in containerNames)
                {
                    blobClient.GetContainerReference(containerName).DeleteAsync().Wait();
                }
            }
        }
#endif

        [TestMethod]
        [Description("Upload a blob with a small maximum execution time")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientMaximumExecutionTimeout()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(Guid.NewGuid().ToString("N"));
            byte[] buffer = BlobTestBase.GetRandomBuffer(40 * 1024 * 1024);

            try
            {
                container.Create();

                blobClient.MaximumExecutionTime = TimeSpan.FromSeconds(5);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    try
                    {
                        blockBlob.UploadFromStream(ms);
                    }
                    catch (TimeoutException ex)
                    {
                        Assert.IsInstanceOfType(ex, typeof(TimeoutException));
                    }
                    catch (StorageException ex)
                    {
                        Assert.IsInstanceOfType(ex.InnerException, typeof(TimeoutException));
                    }
                }

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    try
                    {
                        pageBlob.UploadFromStream(ms);
                    }
                    catch (TimeoutException ex)
                    {
                        Assert.IsInstanceOfType(ex, typeof(TimeoutException));
                    }
                    catch (StorageException ex)
                    {
                        Assert.IsInstanceOfType(ex.InnerException, typeof(TimeoutException));
                    }
                }
            }

            finally
            {
                blobClient.MaximumExecutionTime = null;
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Make sure MaxExecutionTime is not enforced when using streams")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobClientMaximumExecutionTimeoutShouldNotBeHonoredForStreams()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(Guid.NewGuid().ToString("N"));
            byte[] buffer = BlobTestBase.GetRandomBuffer(1024 * 1024);

            try
            {
                container.Create();

                blobClient.MaximumExecutionTime = TimeSpan.FromSeconds(30);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                blockBlob.StreamWriteSizeInBytes = 1024 * 1024;
                blockBlob.StreamMinimumReadSizeInBytes = 1024 * 1024;
                pageBlob.StreamWriteSizeInBytes = 1024 * 1024;
                pageBlob.StreamMinimumReadSizeInBytes = 1024 * 1024;

                using (CloudBlobStream bos = blockBlob.OpenWrite())
                {
                    DateTime start = DateTime.Now;

                    for (int i = 0; i < 7; i++)
                    {
                        bos.Write(buffer, 0, buffer.Length);
                    }

                    // Sleep to ensure we are over the Max execution time when we do the last write
                    int msRemaining = (int)(blobClient.MaximumExecutionTime.Value - (DateTime.Now - start)).TotalMilliseconds;

                    if (msRemaining > 0)
                    {
                        Thread.Sleep(msRemaining);
                    }

                    bos.Write(buffer, 0, buffer.Length);
                }

                using (Stream bis = blockBlob.OpenRead())
                {
                    DateTime start = DateTime.Now;
                    int total = 0;
                    while (total < 7 * 1024 * 1024)
                    {
                        total += bis.Read(buffer, 0, buffer.Length);
                    }

                    // Sleep to ensure we are over the Max execution time when we do the last read
                    int msRemaining = (int)(blobClient.MaximumExecutionTime.Value - (DateTime.Now - start)).TotalMilliseconds;

                    if (msRemaining > 0)
                    {
                        Thread.Sleep(msRemaining);
                    }

                    while (true)
                    {
                        int count = bis.Read(buffer, 0, buffer.Length);
                        total += count;
                        if (count == 0)
                            break;
                    }
                }

                using (CloudBlobStream bos = pageBlob.OpenWrite(8 * 1024 * 1024))
                {
                    DateTime start = DateTime.Now;

                    for (int i = 0; i < 7; i++)
                    {
                        bos.Write(buffer, 0, buffer.Length);
                    }

                    // Sleep to ensure we are over the Max execution time when we do the last write
                    int msRemaining = (int)(blobClient.MaximumExecutionTime.Value - (DateTime.Now - start)).TotalMilliseconds;

                    if (msRemaining > 0)
                    {
                        Thread.Sleep(msRemaining);
                    }

                    bos.Write(buffer, 0, buffer.Length);
                }

                using (Stream bis = pageBlob.OpenRead())
                {
                    DateTime start = DateTime.Now;
                    int total = 0;
                    while (total < 7 * 1024 * 1024)
                    {
                        total += bis.Read(buffer, 0, buffer.Length);
                    }

                    // Sleep to ensure we are over the Max execution time when we do the last read
                    int msRemaining = (int)(blobClient.MaximumExecutionTime.Value - (DateTime.Now - start)).TotalMilliseconds;

                    if (msRemaining > 0)
                    {
                        Thread.Sleep(msRemaining);
                    }

                    while (true)
                    {
                        int count = bis.Read(buffer, 0, buffer.Length);
                        total += count;
                        if (count == 0)
                            break;
                    }
                }
            }

            finally
            {

                blobClient.MaximumExecutionTime = null;
                container.DeleteIfExists();
            }
        }
    }
}
