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
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CloudBlobClientTest : BlobTestBase
    {
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
        public void CloudBlobClientListContainersSegmentedWithPrefix()
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
    }
}
