// -----------------------------------------------------------------------------------------
// <copyright file="BlobProtocolTest.cs" company="Microsoft">
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
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    [TestClass]
    public class BlobProtocolTest : TestBase
    {
        private static Random random = new Random();

        private static BlobClientTests cloudOwnerSync = new BlobClientTests(true, false, 30);
        private static BlobClientTests cloudAnonSync = new BlobClientTests(false, false, 30);
        private static BlobClientTests cloudOwnerAsync = new BlobClientTests(true, false, 30);
        private static BlobClientTests cloudAnonAsync = new BlobClientTests(false, false, 30);

        private static BlobClientTests cloudSetup = new BlobClientTests(true, false, 30);

        [ClassInitialize]
        public static void InitialInitialize(TestContext testContext)
        {
            cloudSetup.Initialize();
        }

        [ClassCleanup]
        public static void FinalCleanup()
        {
            cloudSetup.Cleanup();

            // sleep for 40s so that if the test is re-run, we can recreate the container
            Thread.Sleep(35000);
        }

        #region PutPageBlob
        [TestMethod]
        [Description("owner, sync : Make a valid Put Index Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutPageBlobCloudOwnerSync()
        {
            BlobProperties properties = new BlobProperties() { BlobType = BlobType.PageBlob };
            cloudOwnerSync.PutBlobScenarioTest(cloudSetup.ContainerName, Guid.NewGuid().ToString(), properties, BlobType.PageBlob, new byte[0], HttpStatusCode.Created);
        }

        [TestMethod]
        [Description("anonymous, sync : Make an invalid Put Index Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutPageBlobCloudAnonSync()
        {
            BlobProperties properties = new BlobProperties() { BlobType = BlobType.PageBlob };
            cloudAnonSync.PutBlobScenarioTest(cloudSetup.ContainerName, Guid.NewGuid().ToString(),
                properties, BlobType.PageBlob, new byte[0], HttpStatusCode.NotFound);
        }

        [TestMethod]
        [Description("owner, isAsync : Make a valid Put Index Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutPageBlobCloudOwnerAsync()
        {
            BlobProperties properties = new BlobProperties() { BlobType = BlobType.PageBlob };
            cloudOwnerAsync.PutBlobScenarioTest(cloudSetup.ContainerName, Guid.NewGuid().ToString(), properties, BlobType.PageBlob, new byte[0], HttpStatusCode.Created);
        }

        [TestMethod]
        [Description("anonymous, isAsync : Make an invalid Put Index Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutPageBlobCloudAnonAsync()
        {
            BlobProperties properties = new BlobProperties() { BlobType = BlobType.PageBlob };
            cloudAnonAsync.PutBlobScenarioTest(cloudSetup.ContainerName, Guid.NewGuid().ToString(),
                properties, BlobType.PageBlob, new byte[0], HttpStatusCode.NotFound);
        }
        #endregion

        #region PutBlockBlob
        [TestMethod]
        [Description("owner, sync : Make a valid Put Stream Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutBlockBlobCloudOwnerSync()
        {
            byte[] content = new byte[6000];
            random.NextBytes(content);
            BlobProperties properties = new BlobProperties() { BlobType = BlobType.BlockBlob };
            cloudOwnerSync.PutBlobScenarioTest(cloudSetup.ContainerName, Guid.NewGuid().ToString(), properties, BlobType.BlockBlob, content, null);
        }

        [TestMethod]
        [Description("anonymous, sync : Make an invalid Put Stream Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutBlockBlobCloudAnonSync()
        {
            byte[] content = new byte[6000];
            random.NextBytes(content);
            BlobProperties properties = new BlobProperties() { BlobType = BlobType.BlockBlob };
            cloudAnonSync.PutBlobScenarioTest(cloudSetup.ContainerName, Guid.NewGuid().ToString(),
                properties, BlobType.BlockBlob, content, HttpStatusCode.NotFound);
        }

        [TestMethod]
        [Description("owner, isAsync : Make a valid Put Stream Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutBlockBlobCloudOwnerAsync()
        {
            byte[] content = new byte[6000];
            random.NextBytes(content);
            BlobProperties properties = new BlobProperties() { BlobType = BlobType.BlockBlob };
            cloudOwnerAsync.PutBlobScenarioTest(cloudSetup.ContainerName, Guid.NewGuid().ToString(), properties, BlobType.BlockBlob, content, null);
        }

        [TestMethod]
        [Description("anonymous, isAsync : Make an invalid Put Stream Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutBlockBlobCloudAnonAsync()
        {
            byte[] content = new byte[6000];
            random.NextBytes(content);
            BlobProperties properties = new BlobProperties() { BlobType = BlobType.BlockBlob };
            cloudAnonAsync.PutBlobScenarioTest(cloudSetup.ContainerName, Guid.NewGuid().ToString(),
                properties, BlobType.BlockBlob, content, HttpStatusCode.NotFound);
        }
        #endregion

        #region Blob
        [TestMethod]
        [Description("owner, sync : Make a valid Get Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetBlobCloudOwnerSync()
        {
            cloudOwnerSync.GetBlobScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.Properties,
                cloudSetup.LeaseId, cloudSetup.Content, null);
        }

        [TestMethod]
        [Description("owner, isAsync : Make a valid Get Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetBlobCloudOwnerAsync()
        {
            cloudOwnerAsync.GetBlobScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.Properties,
                cloudSetup.LeaseId, cloudSetup.Content, null);
        }

        [TestMethod]
        [Description("anonymous, sync : Make an invalid Get Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetBlobCloudAnonSync()
        {
            cloudAnonSync.GetBlobScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.Properties,
                cloudSetup.LeaseId, cloudSetup.Content, HttpStatusCode.NotFound);
        }

        [TestMethod]
        [Description("anonymous, isAsync : Make an invalid Get Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetBlobCloudAnonAsync()
        {
            cloudAnonAsync.GetBlobScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.Properties,
                cloudSetup.LeaseId, cloudSetup.Content, HttpStatusCode.NotFound);
        }

        [TestMethod]
        [Description("owner, sync : Make a public valid Get Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetPublicBlobCloudOwnerSync()
        {
            cloudOwnerSync.GetBlobScenarioTest(cloudSetup.PublicContainerName, cloudSetup.PublicBlobName, cloudSetup.Properties,
                cloudSetup.LeaseId, cloudSetup.Content, null);
        }

        [TestMethod]
        [Description("owner, isAsync : Make a public valid Get Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetPublicBlobCloudOwnerAsync()
        {
            cloudOwnerAsync.GetBlobScenarioTest(cloudSetup.PublicContainerName, cloudSetup.PublicBlobName, cloudSetup.Properties,
                cloudSetup.LeaseId, cloudSetup.Content, null);
        }

        [TestMethod]
        [Description("anonymous, sync : Make a public valid Get Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetPublicBlobCloudAnonSync()
        {
            cloudAnonSync.GetBlobScenarioTest(cloudSetup.PublicContainerName, cloudSetup.PublicBlobName, cloudSetup.Properties,
                cloudSetup.LeaseId, cloudSetup.Content, null);
        }

        [TestMethod]
        [Description("anonymous, isAsync : Make a public valid Get Blob request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetPublicBlobCloudAnonAsync()
        {
            cloudAnonAsync.GetBlobScenarioTest(cloudSetup.PublicContainerName, cloudSetup.PublicBlobName, cloudSetup.Properties,
                cloudSetup.LeaseId, cloudSetup.Content, null);
        }

        [TestMethod]
        [Description("owner, sync, range : Make valid Get Blob range requests and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetBlobRangeCloudOwnerSync()
        {
            int all = cloudSetup.Content.Length;
            int quarter = cloudSetup.Content.Length / 4;
            int half = cloudSetup.Content.Length / 2;

            // Full content, as complete range. (0-end)
            cloudOwnerSync.GetBlobRangeScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.LeaseId, cloudSetup.Content, 0, all, null);

            // Partial content, as complete range. (quarter-quarterPlusHalf)
            cloudOwnerSync.GetBlobRangeScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.LeaseId, cloudSetup.Content, quarter, half, null);

            // Full content, as open range. (0-)
            cloudOwnerSync.GetBlobRangeScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.LeaseId, cloudSetup.Content, 0, null, null);

            // Partial content, as open range. (half-)
            cloudOwnerSync.GetBlobRangeScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.LeaseId, cloudSetup.Content, half, null, null);
        }

        [TestMethod]
        [Description("owner, sync, range : Make a Get Blob range request with an invalid range")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetBlobRangeCloudOwnerSyncInvalidRange()
        {
            int all = cloudSetup.Content.Length;

            // Invalid range starting after the end of the blob (endPlusOne-)
            cloudOwnerSync.GetBlobRangeScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.LeaseId, cloudSetup.Content, all, null, HttpStatusCode.RequestedRangeNotSatisfiable);
        }

        [TestMethod]
        [Description("owner, isAsync, range : Make valid Get Blob range requests and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetBlobRangeCloudOwnerAsync()
        {
            int all = cloudSetup.Content.Length;
            int quarter = cloudSetup.Content.Length / 4;
            int half = cloudSetup.Content.Length / 2;

            // Full content, as complete range. (0-end)
            cloudOwnerAsync.GetBlobRangeScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.LeaseId, cloudSetup.Content, 0, all, null);

            // Partial content, as complete range. (quarter-quarterPlusHalf)
            cloudOwnerAsync.GetBlobRangeScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.LeaseId, cloudSetup.Content, quarter, half, null);

            // Full content, as open range. (0-)
            cloudOwnerAsync.GetBlobRangeScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.LeaseId, cloudSetup.Content, 0, null, null);

            // Partial content, as open range. (half-)
            cloudOwnerAsync.GetBlobRangeScenarioTest(cloudSetup.ContainerName, cloudSetup.BlobName, cloudSetup.LeaseId, cloudSetup.Content, half, null, null);
        }
        #endregion

        #region ListBlobs
        [TestMethod]
        [Description("anonymous, sync : Make a valid List Blobs request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolListBlobsCloudAnonSync()
        {
            BlobListingContext listingContext = new BlobListingContext("p", null, null, BlobListingDetails.All);
            cloudAnonSync.ListBlobsScenarioTest(cloudSetup.PublicContainerName, listingContext, null, cloudSetup.PublicBlobName);

            cloudSetup.CreateBlob(cloudSetup.PublicContainerName, "newblob1", true);
            cloudSetup.CreateBlob(cloudSetup.PublicContainerName, "newblob2", true);

            try
            {
                cloudAnonSync.ListBlobsScenarioTest(cloudSetup.PublicContainerName, listingContext, null, cloudSetup.PublicBlobName);

                // snapshots cannot be listed along with delimiter
                listingContext = new BlobListingContext("n", 10, "/", BlobListingDetails.Metadata);
                cloudAnonSync.ListBlobsScenarioTest(cloudSetup.PublicContainerName, listingContext, null, "newblob1", "newblob2");
            }
            finally
            {
                cloudSetup.DeleteBlob(cloudSetup.PublicContainerName, "newblob1");
                cloudSetup.DeleteBlob(cloudSetup.PublicContainerName, "newblob2");
            }
        }

        [TestMethod]
        [Description("owner, sync : Make a valid List Blobs request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolListBlobsCloudOwnerSync()
        {
            BlobListingContext listingContext = new BlobListingContext("def", null, null, BlobListingDetails.All);
            cloudOwnerSync.ListBlobsScenarioTest(cloudSetup.ContainerName, listingContext, null, cloudSetup.BlobName);

            cloudSetup.CreateBlob(cloudSetup.ContainerName, "newblob1", false);
            cloudSetup.CreateBlob(cloudSetup.ContainerName, "newblob2", false);

            try
            {
                cloudOwnerSync.ListBlobsScenarioTest(cloudSetup.ContainerName, listingContext, null, cloudSetup.BlobName);
                listingContext = new BlobListingContext("n", 10, "/", BlobListingDetails.Metadata);
                cloudOwnerSync.ListBlobsScenarioTest(cloudSetup.ContainerName, listingContext, null, "newblob1", "newblob2");
            }
            finally
            {
                cloudSetup.DeleteBlob(cloudSetup.ContainerName, "newblob1");
                cloudSetup.DeleteBlob(cloudSetup.ContainerName, "newblob2");
            }
        }
        #endregion

        #region ListContainers
        [TestMethod]
        [Description("cloud: Make a valid List Containers request and get the response")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolListContainersCloud()
        {
            ListingContext listingContext = new ListingContext("default", null);
            cloudOwnerAsync.ListContainersScenarioTest(listingContext, null, cloudSetup.ContainerName);

            cloudSetup.CreateContainer("newcontainer1", true);
            cloudSetup.CreateContainer("newcontainer2", true);

            try
            {
                cloudOwnerAsync.ListContainersScenarioTest(listingContext, null, cloudSetup.ContainerName);
                listingContext = new ListingContext("newcontainer", 10);
                cloudOwnerAsync.ListContainersScenarioTest(listingContext, null, "newcontainer1", "newcontainer2");
            }
            finally
            {
                cloudSetup.DeleteContainer("newcontainer1");
                cloudSetup.DeleteContainer("newcontainer2");
            }
        }

        [TestMethod]
        [Description("Get a container with empty header excluded/included from signature and verify request succeeded")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolGetContainerWithEmptyHeader()
        {
            ListingContext listingContext = new ListingContext("default", null);
            cloudOwnerAsync.CreateContainer("emptyheadercontainer", true);

            HttpWebRequest request = BlobTests.ListContainersRequest(cloudOwnerAsync.BlobContext, listingContext);
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            if (cloudOwnerAsync.BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, cloudOwnerAsync.BlobContext);
                request.Headers.Add("x-ms-blob-application-metadata", "");
            }
            using (HttpWebResponse response = BlobTestUtils.GetResponse(request, cloudOwnerAsync.BlobContext))
            {
                BlobTests.ListContainersResponse(response, cloudOwnerAsync.BlobContext, null);
            }

            request = BlobTests.ListContainersRequest(cloudOwnerAsync.BlobContext, listingContext);
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            if (cloudOwnerAsync.BlobContext.Credentials != null)
            {
                request.Headers.Add("x-ms-blob-application-metadata", "");
                BlobTests.SignRequest(request, cloudOwnerAsync.BlobContext);
            }
            using (HttpWebResponse response = BlobTestUtils.GetResponse(request, cloudOwnerAsync.BlobContext))
            {
                BlobTests.ListContainersResponse(response, cloudOwnerAsync.BlobContext, HttpStatusCode.OK);
            }
        }
        #endregion

        #region PutBlock, DownloadBlockList, and PutBlockList
        [TestMethod]
        [Description("owner, isAsync : PutBlock, DownloadBlockList, and PutBlockList scenarios")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutGetBlockListCloudOwnerAsync()
        {
            string blockId1 = Convert.ToBase64String(new byte[] { 99, 100, 101 });
            string blockId2 = Convert.ToBase64String(new byte[] { 102, 103, 104 });

            // use a unique name since temp blocks from previous runs can exist
            string blobName = "blob1" + DateTime.UtcNow.Ticks;
            BlobProperties blobProperties = new BlobProperties();
            List<PutBlockListItem> blocks = new List<PutBlockListItem>();
            PutBlockListItem block1 = new PutBlockListItem(blockId1, BlockSearchMode.Uncommitted);
            blocks.Add(block1);
            PutBlockListItem block2 = new PutBlockListItem(blockId2, BlockSearchMode.Uncommitted);
            blocks.Add(block2);
            try
            {
                cloudOwnerAsync.PutBlockScenarioTest(cloudSetup.ContainerName, blobName, blockId1, cloudSetup.LeaseId, cloudSetup.Content, null);
                cloudOwnerAsync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.All, cloudSetup.LeaseId, null, blockId1);
                cloudOwnerAsync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Uncommitted, cloudSetup.LeaseId, null, blockId1);
                cloudOwnerAsync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Committed, cloudSetup.LeaseId, null);

                cloudOwnerAsync.PutBlockScenarioTest(cloudSetup.ContainerName, blobName, blockId2, cloudSetup.LeaseId, cloudSetup.Content, null);
                cloudOwnerAsync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.All, cloudSetup.LeaseId, null, blockId1, blockId2);
                cloudOwnerAsync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Uncommitted, cloudSetup.LeaseId, null, blockId1, blockId2);
                cloudOwnerAsync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Committed, cloudSetup.LeaseId, null);

                cloudOwnerAsync.PutBlockListScenarioTest(cloudSetup.ContainerName, blobName, blocks, blobProperties, cloudSetup.LeaseId, null);
                cloudOwnerAsync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.All, cloudSetup.LeaseId, null, blockId1, blockId2);
                cloudOwnerAsync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Uncommitted, cloudSetup.LeaseId, null);
                cloudOwnerAsync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Committed, cloudSetup.LeaseId, null, blockId1, blockId2);
            }
            finally
            {
                cloudOwnerAsync.DeleteBlob(cloudSetup.ContainerName, blobName);
            }
        }

        [TestMethod]
        [Description("owner, sync : PutBlock, DownloadBlockList, and PutBlockList scenarios")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobProtocolPutGetBlockListCloudOwnerSync()
        {
            string blockId1 = Convert.ToBase64String(new byte[] { 99, 100, 101 });
            string blockId2 = Convert.ToBase64String(new byte[] { 102, 103, 104 });

            // use a unique name since temp blocks from previous runs can exist
            string blobName = "blob2" + DateTime.UtcNow.Ticks;
            BlobProperties blobProperties = new BlobProperties();
            List<PutBlockListItem> blocks = new List<PutBlockListItem>();
            PutBlockListItem block1 = new PutBlockListItem(blockId1, BlockSearchMode.Uncommitted);
            blocks.Add(block1);
            PutBlockListItem block2 = new PutBlockListItem(blockId2, BlockSearchMode.Uncommitted);
            blocks.Add(block2);
            try
            {
                cloudOwnerSync.PutBlockScenarioTest(cloudSetup.ContainerName, blobName, blockId1, cloudSetup.LeaseId, cloudSetup.Content, null);
                cloudOwnerSync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.All, cloudSetup.LeaseId, null, blockId1);
                cloudOwnerSync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Uncommitted, cloudSetup.LeaseId, null, blockId1);
                cloudOwnerSync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Committed, cloudSetup.LeaseId, null);

                cloudOwnerSync.PutBlockScenarioTest(cloudSetup.ContainerName, blobName, blockId2, cloudSetup.LeaseId, cloudSetup.Content, null);
                cloudOwnerSync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.All, cloudSetup.LeaseId, null, blockId1, blockId2);
                cloudOwnerSync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Uncommitted, cloudSetup.LeaseId, null, blockId1, blockId2);
                cloudOwnerSync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Committed, cloudSetup.LeaseId, null);

                cloudOwnerSync.PutBlockListScenarioTest(cloudSetup.ContainerName, blobName, blocks, blobProperties, cloudSetup.LeaseId, null);
                cloudOwnerSync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.All, cloudSetup.LeaseId, null, blockId1, blockId2);
                cloudOwnerSync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Uncommitted, cloudSetup.LeaseId, null);
                cloudOwnerSync.GetBlockListScenarioTest(cloudSetup.ContainerName, blobName, BlockListingFilter.Committed, cloudSetup.LeaseId, null, blockId1, blockId2);
            }
            finally
            {
                cloudOwnerSync.DeleteBlob(cloudSetup.ContainerName, blobName);
            }
        }
        #endregion
    }
}
