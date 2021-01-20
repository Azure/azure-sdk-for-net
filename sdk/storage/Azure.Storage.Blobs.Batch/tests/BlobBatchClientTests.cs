// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobBatchClientTests : BlobTestBase
    {
        public BlobBatchClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            // Batch delimiters are random so disable body comparison
            Matcher = new RecordMatcher(compareBodies: false);
        }

        [SetUp]
        public void ResetDiagnostics()
        {
            // Some tests currently disable test diagnostics so we turn it back on
            TestDiagnostics = true;

            // Force multipart boundaries to be repeatably random
            Multipart.GetRandomGuid = () => Recording.Random.NewGuid();

            // Remove the x-ms-client-request-id headers from the batch
            // sub-operations because there's no convenient way to set them to
            // predictable values
            ((RemoveVersionHeaderPolicy)RemoveVersionHeaderPolicy.Shared).RemoveClientRequestIdHeaders = true;
        }

        #region Batch Mechanics
        [Test]
        public async Task Batch_EmptyFails()
        {
            TestDiagnostics = false;

            await using TestScenario scenario = Scenario();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await client.SubmitBatchAsync(batch));

            StringAssert.Contains("Cannot submit an empty batch", ex.Message);
        }

        [Test]
        public async Task Batch_Limit()
        {
            await using TestScenario scenario = Scenario();
            Uri[] blobs = await scenario.CreateBlobUrisAsync(257);
            BlobBatchClient client = scenario.GetBlobBatchClient();

            // One over the limit
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.DeleteBlobsAsync(blobs));
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual("ExceedsMaxBatchRequestCount", ex.ErrorCode);

            // The exact limit
            await client.DeleteBlobsAsync(blobs.Take(256).ToArray());
        }

        [Test]
        public async Task Batch_Homogenous_Delete()
        {
            await using TestScenario scenario = Scenario();
            Uri[] uris = scenario.GetInvalidBlobUris(2);
            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();

            batch.DeleteBlob(uris[0]);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => batch.SetBlobAccessTier(uris[1], AccessTier.Cool));
            batch.Dispose();

            StringAssert.Contains("already being used for Delete operations", ex.Message);
        }

        [Test]
        public async Task Batch_Homogenous_SetTier()
        {
            await using TestScenario scenario = Scenario();
            Uri[] uris = scenario.GetInvalidBlobUris(2);
            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();

            batch.SetBlobAccessTier(uris[0], AccessTier.Cool);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => batch.DeleteBlob(uris[1]));

            StringAssert.Contains("already being used for SetAccessTier operations", ex.Message);
        }

        [Test]
        public async Task Batch_StatusIndicatesCannotRead()
        {
            await using TestScenario scenario = Scenario();
            Uri uri = scenario.GetInvalidBlobUris(1)[0];

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response = batch.DeleteBlob(uri);
            batch.Dispose();

            Assert.AreEqual(0, response.Status);
        }

        [Test]
        public async Task Batch_CannotReadBeforeSubmit()
        {
            await using TestScenario scenario = Scenario();
            Uri uri = scenario.GetInvalidBlobUris(1)[0];

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response = batch.DeleteBlob(uri);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => { var _ = response.ClientRequestId; });

            StringAssert.Contains("Cannot use the Response before calling BlobBatchClient.SubmitBatch", ex.Message);
        }

        [Test]
        public async Task Batch_CanUseResponseAfterException()
        {
            await using TestScenario scenario = Scenario();
            Uri[] good = await scenario.CreateBlobUrisAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response1 = batch.DeleteBlob(good[0]);
            Response response2 = batch.DeleteBlob(bad[0]);
            try
            {
                await client.SubmitBatchAsync(batch);
            }
            catch (AggregateException)
            {
                // Swallow the exception
            }

            scenario.AssertStatus(202, response1);
            scenario.AssertStatus(404, response2);
        }

        [Test]
        public async Task Batch_CannotChangeClients()
        {
            TestDiagnostics = false;

            await using TestScenario scenario1 = Scenario();
            BlobBatchClient client1 = scenario1.GetBlobBatchClient();
            Uri uri = scenario1.GetInvalidBlobUris(1)[0];
            using BlobBatch batch1 = client1.CreateBatch();
            Response response = batch1.DeleteBlob(uri);

            await using TestScenario scenario2 = Scenario();
            BlobBatchClient client2 = scenario2.GetBlobBatchClient();

            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await client2.SubmitBatchAsync(batch1));

            StringAssert.Contains("BlobBatchClient used to create the BlobBatch must be used to submit it", ex.Message);
        }

        [Test]
        public async Task Batch_AcrossContainers()
        {
            await using TestScenario scenario = Scenario();
            BlobContainerClient container1 = await scenario.CreateContainerAsync();
            Uri[] blobs1 = await scenario.CreateBlobUrisAsync(container1, 2);
            BlobContainerClient container2 = await scenario.CreateContainerAsync();
            Uri[] blobs2 = await scenario.CreateBlobUrisAsync(container2, 3);
            Uri[] blobs = blobs1.Concat(blobs2).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            Response[] responses = await client.DeleteBlobsAsync(blobs);

            scenario.AssertStatus(202, responses);
        }

        [Test]
        public async Task Batch_SasUri_NotOwner()
        {
            // Create a container using SAS for Auth
            string containerName = GetNewContainerName();
            await using DisposingContainer test = await GetTestContainerAsync();

            await using TestScenario scenario = Scenario(GetServiceClient_BlobServiceSas_Container(containerName));
            Uri[] blobs = await scenario.CreateBlobUrisAsync(test.Container, 2);
            BlobBatchClient client = scenario.GetBlobBatchClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.DeleteBlobsAsync(blobs));

            Assert.AreEqual(403, ex.Status);
        }

        [Test]
        [LiveOnly]
        public async Task Batch_AzureSasCredential()
        {
            // Create a container using SAS for Auth
            await using DisposingContainer test = await GetTestContainerAsync();

            var serviceClient = GetServiceClient_SharedKey();
            var sas = GetAccountSasCredentials().SasToken;
            var sasServiceClient = InstrumentClient(new BlobServiceClient(serviceClient.Uri, new AzureSasCredential(sas), GetOptions()));
            await using TestScenario scenario = Scenario(sasServiceClient);
            Uri[] blobs = await scenario.CreateBlobUrisAsync(test.Container, 2);
            BlobBatchClient client = scenario.GetBlobBatchClient();
            Response[] responses = await client.DeleteBlobsAsync(blobs);

            scenario.AssertStatus(202, responses);
        }

        // TODO: Add a requirement that one of the test tenants is in a
        // different account so we can verify batch requests fail across
        // multiple storage accounts

        #endregion Batch Mechanics

        #region Delete
        [Test]
        public async Task Delete_Basic()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] blobs = await scenario.CreateBlobsAsync(3);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response[] responses = new Response[]
            {
                batch.DeleteBlob(blobs[0].Uri),
                batch.DeleteBlob(blobs[1].Uri),
                batch.DeleteBlob(blobs[2].Uri)
            };
            Response response = await client.SubmitBatchAsync(batch);

            scenario.AssertStatus(202, response);
            scenario.AssertStatus(202, responses);
            await scenario.AssertDeleted(blobs);
        }

        [Test]
        public async Task Delete_Basic_Convenience()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] blobs = await scenario.CreateBlobsAsync(3);
            Uri[] uris = blobs.Select(b => b.Uri).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            Response[] responses = await client.DeleteBlobsAsync(uris);

            scenario.AssertStatus(202, responses);
            await scenario.AssertDeleted(blobs);
        }

        [Test]
        public async Task Delete_OneFails()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response1 = batch.DeleteBlob(good[0].Uri);
            Response response2 = batch.DeleteBlob(good[1].Uri);
            Response response3 = batch.DeleteBlob(bad[0]);
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SubmitBatchAsync(batch, throwOnAnyFailure: true));

            RequestFailedException ex = exes.InnerException as RequestFailedException;
            Assert.IsNotNull(ex);
            Assert.AreEqual(404, ex.Status);
            Assert.IsTrue(BlobErrorCode.ContainerNotFound == ex.ErrorCode);
            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_OneFails_Convenience()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);
            Uri[] uris = good.Select(b => b.Uri).Concat(bad).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.DeleteBlobsAsync(uris));

            RequestFailedException ex = exes.InnerException as RequestFailedException;
            Assert.IsNotNull(ex);
            Assert.AreEqual(404, ex.Status);
            Assert.IsTrue(BlobErrorCode.ContainerNotFound == ex.ErrorCode);

            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_OneFails_NoThrow()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response1 = batch.DeleteBlob(good[0].Uri);
            Response response2 = batch.DeleteBlob(good[1].Uri);
            Response response3 = batch.DeleteBlob(bad[0]);
            Response response = await client.SubmitBatchAsync(batch, throwOnAnyFailure: false);

            Assert.AreEqual(3, batch.RequestCount);
            scenario.AssertStatus(202, response, response1, response2);
            scenario.AssertStatus(404, response3);
            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_MultipleFail()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response1 = batch.DeleteBlob(good[0].Uri);
            Response response2 = batch.DeleteBlob(bad[0]);
            Response response3 = batch.DeleteBlob(bad[1]);
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SubmitBatchAsync(batch, throwOnAnyFailure: true));

            Assert.AreEqual(2, exes.InnerExceptions.Count);
            Assert.AreEqual(404, (exes.InnerExceptions[0] as RequestFailedException)?.Status);
            Assert.AreEqual(404, (exes.InnerExceptions[1] as RequestFailedException)?.Status);
            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_MultipleFail_Convenience()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);
            Uri[] uris = good.Select(b => b.Uri).Concat(bad).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.DeleteBlobsAsync(uris));

            Assert.AreEqual(2, exes.InnerExceptions.Count);
            Assert.AreEqual(404, (exes.InnerExceptions[0] as RequestFailedException)?.Status);
            Assert.AreEqual(404, (exes.InnerExceptions[1] as RequestFailedException)?.Status);
            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_MultipleFail_NoThrow()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response1 = batch.DeleteBlob(good[0].Uri);
            Response response2 = batch.DeleteBlob(bad[0]);
            Response response3 = batch.DeleteBlob(bad[1]);
            Response response = await client.SubmitBatchAsync(batch, throwOnAnyFailure: false);

            scenario.AssertStatus(202, response, response1);
            scenario.AssertStatus(404, response2, response3);
            await scenario.AssertDeleted(good);
        }
        #endregion Delete

        #region SetBlobAccessTier
        [Test]
        public async Task SetBlobAccessTier_Basic()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] blobs = await scenario.CreateBlobsAsync(3);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response[] responses = new Response[]
            {
                batch.SetBlobAccessTier(blobs[0].Uri, AccessTier.Cool),
                batch.SetBlobAccessTier(blobs[1].Uri, AccessTier.Cool),
                batch.SetBlobAccessTier(blobs[2].Uri, AccessTier.Cool)
            };
            Response response = await client.SubmitBatchAsync(batch);

            scenario.AssertStatus(202, response);
            scenario.AssertStatus(200, responses);
            await scenario.AssertTiers(AccessTier.Cool, blobs);
        }

        [Test]
        public async Task SetBlobAccessTier_Basic_Convenience()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] blobs = await scenario.CreateBlobsAsync(3);
            Uri[] uris = blobs.Select(b => b.Uri).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            Response[] responses = await client.SetBlobsAccessTierAsync(uris, AccessTier.Cool);

            scenario.AssertStatus(200, responses);
            await scenario.AssertTiers(AccessTier.Cool, blobs);
        }

        [Test]
        public async Task SetBlobAccessTier_OneFails()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response1 = batch.SetBlobAccessTier(good[0].Uri, AccessTier.Cool);
            Response response2 = batch.SetBlobAccessTier(good[1].Uri, AccessTier.Cool);
            Response response3 = batch.SetBlobAccessTier(bad[0], AccessTier.Cool);
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SubmitBatchAsync(batch, throwOnAnyFailure: true));

            RequestFailedException ex = exes.InnerException as RequestFailedException;
            Assert.IsNotNull(ex);
            Assert.AreEqual(404, ex.Status);
            Assert.IsTrue(BlobErrorCode.ContainerNotFound == ex.ErrorCode);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_OneFails_Convenience()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);
            Uri[] uris = good.Select(b => b.Uri).Concat(bad).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SetBlobsAccessTierAsync(uris, AccessTier.Cool));

            RequestFailedException ex = exes.InnerException as RequestFailedException;
            Assert.IsNotNull(ex);
            Assert.AreEqual(404, ex.Status);
            Assert.IsTrue(BlobErrorCode.ContainerNotFound == ex.ErrorCode);

            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_OneFails_NoThrow()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response1 = batch.SetBlobAccessTier(good[0].Uri, AccessTier.Cool);
            Response response2 = batch.SetBlobAccessTier(good[1].Uri, AccessTier.Cool);
            Response response3 = batch.SetBlobAccessTier(bad[0], AccessTier.Cool);
            Response response = await client.SubmitBatchAsync(batch, throwOnAnyFailure: false);

            scenario.AssertStatus(202, response);
            scenario.AssertStatus(200, response1, response2);
            scenario.AssertStatus(404, response3);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_MultipleFail()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response1 = batch.SetBlobAccessTier(good[0].Uri, AccessTier.Cool);
            Response response2 = batch.SetBlobAccessTier(bad[0], AccessTier.Cool);
            Response response3 = batch.SetBlobAccessTier(bad[1], AccessTier.Cool);
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SubmitBatchAsync(batch, throwOnAnyFailure: true));

            Assert.AreEqual(2, exes.InnerExceptions.Count);
            Assert.AreEqual(404, (exes.InnerExceptions[0] as RequestFailedException)?.Status);
            Assert.AreEqual(404, (exes.InnerExceptions[1] as RequestFailedException)?.Status);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_MultipleFail_Convenience()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);
            Uri[] uris = good.Select(b => b.Uri).Concat(bad).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SetBlobsAccessTierAsync(uris, AccessTier.Cool));

            Assert.AreEqual(2, exes.InnerExceptions.Count);
            Assert.AreEqual(404, (exes.InnerExceptions[0] as RequestFailedException)?.Status);
            Assert.AreEqual(404, (exes.InnerExceptions[1] as RequestFailedException)?.Status);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_MultipleFail_NoThrow()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response response1 = batch.SetBlobAccessTier(good[0].Uri, AccessTier.Cool);
            Response response2 = batch.SetBlobAccessTier(bad[0], AccessTier.Cool);
            Response response3 = batch.SetBlobAccessTier(bad[1], AccessTier.Cool);
            Response response = await client.SubmitBatchAsync(batch, throwOnAnyFailure: false);

            scenario.AssertStatus(202, response);
            scenario.AssertStatus(200, response1);
            scenario.AssertStatus(404, response2, response3);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task Batch_Dispose_Response_Still_Available()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] blobs = await scenario.CreateBlobsAsync(3);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            Response[] responses = new Response[3];
            Response response;
            using (BlobBatch batch = client.CreateBatch())
            {
                responses[0] = batch.DeleteBlob(blobs[0].Uri);
                responses[1] = batch.DeleteBlob(blobs[1].Uri);
                responses[2] = batch.DeleteBlob(blobs[2].Uri);
                response = await client.SubmitBatchAsync(batch);
            }
            scenario.AssertStatus(202, response);
            scenario.AssertStatus(202, responses);
            await scenario.AssertDeleted(blobs);
        }

        [Test]
        public async Task Batch_Double_Dispose_Response_Still_Available()
        {
            await using TestScenario scenario = Scenario();
            BlobClient[] blobs = await scenario.CreateBlobsAsync(3);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            Response[] responses = new Response[3];
            Response response;
            using (BlobBatch batch = client.CreateBatch())
            {
                responses[0] = batch.DeleteBlob(blobs[0].Uri);
                responses[1] = batch.DeleteBlob(blobs[1].Uri);
                responses[2] = batch.DeleteBlob(blobs[2].Uri);
                response = await client.SubmitBatchAsync(batch);
                batch.Dispose();
                Assert.AreEqual(3, batch.RequestCount);
            }
            scenario.AssertStatus(202, response);
            scenario.AssertStatus(202, responses);
            await scenario.AssertDeleted(blobs);
        }

        [Test]
        [Ignore("service bug - https://github.com/Azure/azure-sdk-for-net/issues/13507")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetBlobAccessTier_Snapshot()
        {
            await using TestScenario scenario = Scenario();
            BlockBlobClient[] blobs = await scenario.CreateBlockBlobsAsync(1);
            Response<BlobSnapshotInfo> blobSnapshotResponse = await blobs[0].CreateSnapshotAsync();
            blobs[0] = blobs[0].WithSnapshot(blobSnapshotResponse.Value.Snapshot);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response[] responses = new Response[]
            {
                batch.SetBlobAccessTier(blobs[0].Uri, AccessTier.Cool),
            };
            Response response = await client.SubmitBatchAsync(batch);

            scenario.AssertStatus(202, response);
            scenario.AssertStatus(200, responses);
            await scenario.AssertTiers(AccessTier.Cool, blobs);
        }

        [Test]
        [Ignore("service bug - https://github.com/Azure/azure-sdk-for-net/issues/13507")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetBlobAccessTier_Version()
        {
            await using TestScenario scenario = Scenario();
            BlockBlobClient[] blobs = await scenario.CreateBlockBlobsAsync(1);
            Response<BlobInfo> setMetadataResponse = await blobs[0].SetMetadataAsync(BuildMetadata());

            blobs[0] = blobs[0].WithVersion(setMetadataResponse.Value.VersionId);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            using BlobBatch batch = client.CreateBatch();
            Response[] responses = new Response[]
            {
                batch.SetBlobAccessTier(blobs[0].Uri, AccessTier.Cool),
            };
            Response response = await client.SubmitBatchAsync(batch);

            scenario.AssertStatus(202, response);
            scenario.AssertStatus(200, responses);
            await scenario.AssertTiers(AccessTier.Cool, blobs);
        }
        #endregion SetBlobAccessTier

        #region Scenario helper
        private TestScenario Scenario() => Scenario(GetServiceClient_SharedKey());
        private TestScenario Scenario(BlobServiceClient client) => new TestScenario(this, client);

        /// <summary>
        /// Helper to create and cleanup test resources
        /// </summary>
        private class TestScenario : IAsyncDisposable
        {
            public BlobServiceClient Service { get; }
            private readonly BlobBatchClientTests _test = null;
            private int _blobId = 0;
            private readonly List<DisposingContainer> _containers = new List<DisposingContainer>();

            public TestScenario(BlobBatchClientTests test, BlobServiceClient service)
            {
                _test = test;
                Service = service;
            }

            public async Task<BlobContainerClient> CreateContainerAsync()
            {
                DisposingContainer test = await _test.GetTestContainerAsync(service: Service);
                _containers.Add(test);
                return test.Container;
            }

            public async Task<BlobClient[]> CreateBlobsAsync(BlobContainerClient container, int count)
            {
                BlobClient[] blobs = new BlobClient[count];
                for (int i = 0; i < count; i++)
                {
                    blobs[i] = _test.InstrumentClient(container.GetBlobClient("blob" + (++_blobId)));
                    await blobs[i].UploadAsync(new MemoryStream(_test.GetRandomBuffer(Constants.KB)));
                }
                return blobs;
            }

            public async Task<BlockBlobClient[]> CreateBlockBlobsAsync(BlobContainerClient container, int count)
            {
                BlockBlobClient[] blobs = new BlockBlobClient[count];
                for (int i = 0; i < count; i++)
                {
                    blobs[i] = _test.InstrumentClient(container.GetBlockBlobClient("blob" + (++_blobId)));
                    await blobs[i].UploadAsync(new MemoryStream(_test.GetRandomBuffer(Constants.KB)));
                }
                return blobs;
            }

            public async Task<BlobClient[]> CreateBlobsAsync(int count) =>
                await CreateBlobsAsync(await CreateContainerAsync(), count);

            public async Task<BlockBlobClient[]> CreateBlockBlobsAsync(int count) =>
                await CreateBlockBlobsAsync(await CreateContainerAsync(), count);

            public async Task<Uri[]> CreateBlobUrisAsync(BlobContainerClient container, int count) =>
                (await CreateBlobsAsync(container, count)).Select(b => b.Uri).ToArray();

            public async Task<Uri[]> CreateBlobUrisAsync(int count) =>
                await CreateBlobUrisAsync(await CreateContainerAsync(), count);

            public Uri[] GetInvalidBlobUris(BlobContainerClient container, int count)
            {
                var blobs = new Uri[count];
                for (int i = 0; i < count; i++)
                {
                    blobs[i] = container.GetBlobClient("blob" + (++_blobId)).Uri;
                }
                return blobs;
            }

            public Uri[] GetInvalidBlobUris(int count) =>
                GetInvalidBlobUris(Service.GetBlobContainerClient("invalidcontainer"), count);

            public BlobBatchClient GetBlobBatchClient() =>
                _test.InstrumentClient(Service.GetBlobBatchClient());

            public async Task AssertDeleted(BlobClient blob)
            {
                try
                {
                    await blob.GetPropertiesAsync();
                    Assert.Fail($"Blob {blob.Uri} still exists!");
                }
                catch (RequestFailedException)
                {
                }
            }

            public Task AssertDeleted(BlobClient[] blobs) =>
                Task.WhenAll(blobs.Select(b => AssertDeleted(b)));

            public async Task AssertTiers(AccessTier tier, BlobClient blob)
            {
                try
                {
                    BlobProperties properties = await blob.GetPropertiesAsync();
                    Assert.AreEqual(tier.ToString(), properties.AccessTier.ToString());
                }
                catch (RequestFailedException)
                {
                }
            }

            public async Task AssertTiers(AccessTier tier, BlockBlobClient blob)
            {
                try
                {
                    BlobProperties properties = await blob.GetPropertiesAsync();
                    Assert.AreEqual(tier.ToString(), properties.AccessTier.ToString());
                }
                catch (RequestFailedException)
                {
                }
            }

            public Task AssertTiers(AccessTier tier, BlobClient[] blobs) =>
                Task.WhenAll(blobs.Select(b => AssertTiers(tier, b)));

            public Task AssertTiers(AccessTier tier, BlockBlobClient[] blobs) =>
                Task.WhenAll(blobs.Select(b => AssertTiers(tier, b)));

            public void AssertStatus(int status, params Response[] responses) =>
                Assert.IsTrue(responses.All(r => r.Status == status));

            public async ValueTask DisposeAsync()
            {
                foreach (IAsyncDisposable container in _containers)
                {
                    await container.DisposeAsync();
                }
                _containers.Clear();
            }
        }
        #endregion Scenario helper
    }
}
