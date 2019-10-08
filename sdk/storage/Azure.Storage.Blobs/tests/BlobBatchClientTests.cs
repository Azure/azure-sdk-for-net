// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobBatchClientTests : BlobTestBase
    {
        public BlobBatchClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
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
        public void Batch_EmptyFails()
        {
            TestDiagnostics = false;

            using TestScenario scenario = Scenario();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await client.SubmitBatchAsync(batch));

            StringAssert.Contains("Cannot submit an empty batch", ex.Message);
        }

        [Test]
        public async Task Batch_Limit()
        {
            using TestScenario scenario = Scenario();
            Uri[] blobs = await scenario.CreateBlobUrisAsync(257);
            BlobBatchClient client = scenario.GetBlobBatchClient();

            // One over the limit
            StorageRequestFailedException ex = Assert.ThrowsAsync<StorageRequestFailedException>(
                async () => await client.DeleteBlobsAsync(blobs));
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual("ExceedsMaxBatchRequestCount", ex.ErrorCode);

            // The exact limit
            await client.DeleteBlobsAsync(blobs.Take(256).ToArray());
        }

        [Test]
        public void Batch_Homogenous_Delete()
        {
            using TestScenario scenario = Scenario();
            Uri[] uris = scenario.GetInvalidBlobUris(2);
            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();

            batch.DeleteBlob(uris[0]);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => batch.SetBlobAccessTier(uris[1], AccessTier.Cool));

            StringAssert.Contains("already being used for Delete operations", ex.Message);
        }

        [Test]
        public void Batch_Homogenous_SetTier()
        {
            using TestScenario scenario = Scenario();
            Uri[] uris = scenario.GetInvalidBlobUris(2);
            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();

            batch.SetBlobAccessTier(uris[0], AccessTier.Cool);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => batch.DeleteBlob(uris[1]));

            StringAssert.Contains("already being used for SetAccessTier operations", ex.Message);
        }

        [Test]
        public void Batch_CannotReadBeforeSubmit()
        {
            using TestScenario scenario = Scenario();
            Uri uri = scenario.GetInvalidBlobUris(1)[0];

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            Response response = batch.DeleteBlob(uri);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => { int status = response.Status; });

            StringAssert.Contains("Cannot use the Response before calling BlobBatchClient.SubmitBatch", ex.Message);
        }

        [Test]
        public async Task Batch_CanUseResponseAfterException()
        {
            using TestScenario scenario = Scenario();
            Uri[] good = await scenario.CreateBlobUrisAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
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
        public void Batch_CannotChangeClients()
        {
            TestDiagnostics = false;

            using TestScenario scenario1 = Scenario();
            BlobBatchClient client1 = scenario1.GetBlobBatchClient();
            Uri uri = scenario1.GetInvalidBlobUris(1)[0];
            BlobBatch batch1 = client1.CreateBatch();
            Response response = batch1.DeleteBlob(uri);

            using TestScenario scenario2 = Scenario();
            BlobBatchClient client2 = scenario2.GetBlobBatchClient();

            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await client2.SubmitBatchAsync(batch1));

            StringAssert.Contains("BlobBatchClient used to create the BlobBatch must be used to submit it", ex.Message);
        }

        [Test]
        public async Task Batch_AcrossContainers()
        {
            using TestScenario scenario = Scenario();
            BlobContainerClient container1 = scenario.CreateContainer();
            Uri[] blobs1 = await scenario.CreateBlobUrisAsync(container1, 2);
            BlobContainerClient container2 = scenario.CreateContainer();
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
            using IDisposable _ = GetNewContainer(out BlobContainerClient container);

            using TestScenario scenario = Scenario(GetServiceClient_BlobServiceSas_Container(containerName));
            Uri[] blobs = await scenario.CreateBlobUrisAsync(container, 2);
            BlobBatchClient client = scenario.GetBlobBatchClient();
            StorageRequestFailedException ex = Assert.ThrowsAsync<StorageRequestFailedException>(
                async () => await client.DeleteBlobsAsync(blobs));

            Assert.AreEqual(403, ex.Status);
        }

        // TODO: Add a requirement that one of the test tenants is in a
        // different account so we can verify batch requests fail across
        // multiple storage accounts

        #endregion Batch Mechanics

        #region Delete
        [Test]
        public async Task Delete_Basic()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] blobs = await scenario.CreateBlobsAsync(3);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
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
            using TestScenario scenario = Scenario();
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
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            Response response1 = batch.DeleteBlob(good[0].Uri);
            Response response2 = batch.DeleteBlob(good[1].Uri);
            Response response3 = batch.DeleteBlob(bad[0]);
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SubmitBatchAsync(batch));

            StorageRequestFailedException ex = exes.InnerException as StorageRequestFailedException;
            Assert.IsNotNull(ex);
            Assert.AreEqual(404, ex.Status);
            Assert.IsTrue(BlobErrorCode.ContainerNotFound == ex.ErrorCode);
            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_OneFails_Convenience()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);
            Uri[] uris = good.Select(b => b.Uri).Concat(bad).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.DeleteBlobsAsync(uris));

            StorageRequestFailedException ex = exes.InnerException as StorageRequestFailedException;
            Assert.IsNotNull(ex);
            Assert.AreEqual(404, ex.Status);
            Assert.IsTrue(BlobErrorCode.ContainerNotFound == ex.ErrorCode);

            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_OneFails_NoThrow()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            Response response1 = batch.DeleteBlob(good[0].Uri);
            Response response2 = batch.DeleteBlob(good[1].Uri);
            Response response3 = batch.DeleteBlob(bad[0]);
            Response response = await client.SubmitBatchAsync(batch, throwOnFailure: false);

            scenario.AssertStatus(202, response, response1, response2);
            scenario.AssertStatus(404, response3);
            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_MultipleFail()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            Response response1 = batch.DeleteBlob(good[0].Uri);
            Response response2 = batch.DeleteBlob(bad[0]);
            Response response3 = batch.DeleteBlob(bad[1]);
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SubmitBatchAsync(batch));

            Assert.AreEqual(2, exes.InnerExceptions.Count);
            Assert.AreEqual(404, (exes.InnerExceptions[0] as StorageRequestFailedException)?.Status);
            Assert.AreEqual(404, (exes.InnerExceptions[1] as StorageRequestFailedException)?.Status);
            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_MultipleFail_Convenience()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);
            Uri[] uris = good.Select(b => b.Uri).Concat(bad).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.DeleteBlobsAsync(uris));

            Assert.AreEqual(2, exes.InnerExceptions.Count);
            Assert.AreEqual(404, (exes.InnerExceptions[0] as StorageRequestFailedException)?.Status);
            Assert.AreEqual(404, (exes.InnerExceptions[1] as StorageRequestFailedException)?.Status);
            await scenario.AssertDeleted(good);
        }

        [Test]
        public async Task Delete_MultipleFail_NoThrow()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            Response response1 = batch.DeleteBlob(good[0].Uri);
            Response response2 = batch.DeleteBlob(bad[0]);
            Response response3 = batch.DeleteBlob(bad[1]);
            Response response = await client.SubmitBatchAsync(batch, throwOnFailure: false);

            scenario.AssertStatus(202, response, response1);
            scenario.AssertStatus(404, response2, response3);
            await scenario.AssertDeleted(good);
        }
        #endregion Delete

        #region SetBlobAccessTier
        [Test]
        public async Task SetBlobAccessTier_Basic()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] blobs = await scenario.CreateBlobsAsync(3);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
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
            using TestScenario scenario = Scenario();
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
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            Response response1 = batch.SetBlobAccessTier(good[0].Uri, AccessTier.Cool);
            Response response2 = batch.SetBlobAccessTier(good[1].Uri, AccessTier.Cool);
            Response response3 = batch.SetBlobAccessTier(bad[0], AccessTier.Cool);
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SubmitBatchAsync(batch));

            StorageRequestFailedException ex = exes.InnerException as StorageRequestFailedException;
            Assert.IsNotNull(ex);
            Assert.AreEqual(404, ex.Status);
            Assert.IsTrue(BlobErrorCode.ContainerNotFound == ex.ErrorCode);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_OneFails_Convenience()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);
            Uri[] uris = good.Select(b => b.Uri).Concat(bad).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SetBlobsAccessTierAsync(uris, AccessTier.Cool));

            StorageRequestFailedException ex = exes.InnerException as StorageRequestFailedException;
            Assert.IsNotNull(ex);
            Assert.AreEqual(404, ex.Status);
            Assert.IsTrue(BlobErrorCode.ContainerNotFound == ex.ErrorCode);

            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_OneFails_NoThrow()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(2);
            Uri[] bad = scenario.GetInvalidBlobUris(1);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            Response response1 = batch.SetBlobAccessTier(good[0].Uri, AccessTier.Cool);
            Response response2 = batch.SetBlobAccessTier(good[1].Uri, AccessTier.Cool);
            Response response3 = batch.SetBlobAccessTier(bad[0], AccessTier.Cool);
            Response response = await client.SubmitBatchAsync(batch, throwOnFailure: false);

            scenario.AssertStatus(202, response);
            scenario.AssertStatus(200, response1, response2);
            scenario.AssertStatus(404, response3);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_MultipleFail()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            Response response1 = batch.SetBlobAccessTier(good[0].Uri, AccessTier.Cool);
            Response response2 = batch.SetBlobAccessTier(bad[0], AccessTier.Cool);
            Response response3 = batch.SetBlobAccessTier(bad[1], AccessTier.Cool);
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SubmitBatchAsync(batch));

            Assert.AreEqual(2, exes.InnerExceptions.Count);
            Assert.AreEqual(404, (exes.InnerExceptions[0] as StorageRequestFailedException)?.Status);
            Assert.AreEqual(404, (exes.InnerExceptions[1] as StorageRequestFailedException)?.Status);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_MultipleFail_Convenience()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);
            Uri[] uris = good.Select(b => b.Uri).Concat(bad).ToArray();

            BlobBatchClient client = scenario.GetBlobBatchClient();
            AggregateException exes = Assert.ThrowsAsync<AggregateException>(
                async () => await client.SetBlobsAccessTierAsync(uris, AccessTier.Cool));

            Assert.AreEqual(2, exes.InnerExceptions.Count);
            Assert.AreEqual(404, (exes.InnerExceptions[0] as StorageRequestFailedException)?.Status);
            Assert.AreEqual(404, (exes.InnerExceptions[1] as StorageRequestFailedException)?.Status);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }

        [Test]
        public async Task SetBlobAccessTier_MultipleFail_NoThrow()
        {
            using TestScenario scenario = Scenario();
            BlobClient[] good = await scenario.CreateBlobsAsync(1);
            Uri[] bad = scenario.GetInvalidBlobUris(2);

            BlobBatchClient client = scenario.GetBlobBatchClient();
            BlobBatch batch = client.CreateBatch();
            Response response1 = batch.SetBlobAccessTier(good[0].Uri, AccessTier.Cool);
            Response response2 = batch.SetBlobAccessTier(bad[0], AccessTier.Cool);
            Response response3 = batch.SetBlobAccessTier(bad[1], AccessTier.Cool);
            Response response = await client.SubmitBatchAsync(batch, throwOnFailure: false);

            scenario.AssertStatus(202, response);
            scenario.AssertStatus(200, response1);
            scenario.AssertStatus(404, response2, response3);
            await scenario.AssertTiers(AccessTier.Cool, good);
        }
        #endregion SetBlobAccessTier

        #region Scenario helper
        private TestScenario Scenario() => Scenario(GetServiceClient_SharedKey());
        private TestScenario Scenario(BlobServiceClient client) => new TestScenario(this, client);

        /// <summary>
        /// Helper to create and cleanup test resources
        /// </summary>
        private class TestScenario : IDisposable
        {
            public BlobServiceClient Service { get; }
            private readonly BlobBatchClientTests _test = null;
            private int _blobId = 0;
            private readonly List<IDisposable> _containers = new List<IDisposable>();

            public TestScenario(BlobBatchClientTests test, BlobServiceClient service)
            {
                _test = test;
                Service = service;
            }

            public BlobContainerClient CreateContainer()
            {
                _containers.Add(_test.GetNewContainer(out BlobContainerClient container, service: Service));
                return container;
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

            public async Task<BlobClient[]> CreateBlobsAsync(int count) =>
                await CreateBlobsAsync(CreateContainer(), count);

            public async Task<Uri[]> CreateBlobUrisAsync(BlobContainerClient container, int count) =>
                (await CreateBlobsAsync(container, count)).Select(b => b.Uri).ToArray();

            public async Task<Uri[]> CreateBlobUrisAsync(int count) =>
                await CreateBlobUrisAsync(CreateContainer(), count);

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
                catch (StorageRequestFailedException)
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
                catch (StorageRequestFailedException)
                {
                }
            }

            public Task AssertTiers(AccessTier tier, BlobClient[] blobs) =>
                Task.WhenAll(blobs.Select(b => AssertTiers(tier, b)));

            public void AssertStatus(int status, params Response[] responses) =>
                Assert.IsTrue(responses.All(r => r.Status == status));

            public void Dispose()
            {
                foreach (IDisposable container in _containers)
                {
                    container.Dispose();
                }
                _containers.Clear();
            }
        }
        #endregion Scenario helper
    }
}
