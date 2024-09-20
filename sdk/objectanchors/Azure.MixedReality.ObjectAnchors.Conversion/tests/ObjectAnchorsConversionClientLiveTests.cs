// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.MixedReality.Authentication;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Tests
{
    public class ObjectAnchorsConversionClientLiveTests : RecordedTestBase<ObjectAnchorsConversionClientTestEnvironment>
    {
        private const string assetsFolderName = "Assets";
        private const string assetsFileName = "switchgear02_obj.obj";
        private const string modelDownloadFileName = "switchgear02_obj_model.ply";
        private const string fakeAssetFileName = "fake.ply";
        private const float assetGravityX = 0;
        private const float assetGravityY = -1;
        private const float assetGravityZ = 0;
        private const float assetScale = 0.001f;
        private const string ClientCorrelationVectorHeaderName = "X-MRC-CV";

        private static string currentWorkingDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly string assetLocalFilePath = Path.Combine(currentWorkingDirectory, assetsFolderName, assetsFileName);
        private static readonly string fakeAssetLocalFilePath = Path.Combine(currentWorkingDirectory, assetsFolderName, fakeAssetFileName);
        public string modelDownloadLocalFilePath => Path.Combine(currentWorkingDirectory, modelDownloadFileName);

        public ObjectAnchorsConversionClientLiveTests(bool isAsync)
            : base(isAsync)
        {
#if NET462
            CompareBodies = true;
#else
            CompareBodies = false;
#endif
            IgnoredHeaders.Add(ClientCorrelationVectorHeaderName);
        }

        [RecordedTest]
        [LiveOnly(Reason = "https://github.com/Azure/azure-sdk-for-net/issues/43387")]
        public async Task RunAssetConversion()
        {
            (
                ObjectAnchorsConversionClient clientWithWorkingInternalMethods,
                ObjectAnchorsConversionClient client,
                AssetConversionOptions assetConversionOptions
            ) = await GetClientsAndConversionOptionsForAsset(assetLocalFilePath);

            AssetConversionOperation operation = await client.StartAssetConversionAsync(assetConversionOptions);

            await operation.WaitForCompletionAsync();

            if (!operation.HasCompletedSuccessfully)
            {
                throw new Exception("The asset conversion operation completed with an unsuccessful status");
            }

            string localFileDownloadPath = modelDownloadLocalFilePath;

            BlobClient downloadBlobClient = InstrumentClient(new BlobClient(operation.Value.OutputModelUri, InstrumentClientOptions(new BlobClientOptions(BlobClientOptions.ServiceVersion.V2019_12_12))));

            BlobDownloadInfo downloadInfo = await downloadBlobClient.DownloadAsync();

            using (FileStream file = File.OpenWrite(localFileDownloadPath))
            {
                await downloadInfo.Content.CopyToAsync(file);
                var fileInfo = new FileInfo(localFileDownloadPath);
                Assert.Greater(fileInfo.Length, 0);
            }
        }

        [RecordedTest]
        [LiveOnly(Reason = "https://github.com/Azure/azure-sdk-for-net/issues/43387")]
        public async Task ObserveExistingAssetConversion()
        {
            (
                ObjectAnchorsConversionClient clientWithWorkingInternalMethods,
                ObjectAnchorsConversionClient client,
                AssetConversionOptions assetConversionOptions
            ) = await GetClientsAndConversionOptionsForAsset(assetLocalFilePath);

            Guid jobId = new Guid((await client.StartAssetConversionAsync(assetConversionOptions)).Id);

            AssetConversionOperation operation = InstrumentOperation(new AssetConversionOperation(jobId, clientWithWorkingInternalMethods));

            await operation.WaitForCompletionAsync();

            if (!operation.HasCompletedSuccessfully)
            {
                throw new Exception("The asset conversion operation completed with an unsuccessful status");
            }

            string localFileDownloadPath = modelDownloadLocalFilePath;

            BlobClient downloadBlobClient = InstrumentClient(new BlobClient(operation.Value.OutputModelUri, InstrumentClientOptions(new BlobClientOptions(BlobClientOptions.ServiceVersion.V2019_12_12))));

            BlobDownloadInfo downloadInfo = await downloadBlobClient.DownloadAsync();

            using (FileStream file = File.OpenWrite(localFileDownloadPath))
            {
                await downloadInfo.Content.CopyToAsync(file);
                var fileInfo = new FileInfo(localFileDownloadPath);
                Assert.Greater(fileInfo.Length, 0);
            }
        }

        [RecordedTest]
        [LiveOnly(Reason = "https://github.com/Azure/azure-sdk-for-net/issues/43387")]
        public async Task RunFailedAssetConversion()
        {
            (
                ObjectAnchorsConversionClient clientWithWorkingInternalMethods,
                ObjectAnchorsConversionClient client,
                AssetConversionOptions assetConversionOptions
            ) = await GetClientsAndConversionOptionsForAsset(fakeAssetLocalFilePath);

            AssetConversionOperation operation = await client.StartAssetConversionAsync(assetConversionOptions);

            await operation.WaitForCompletionAsync();

            if (operation.HasCompletedSuccessfully)
            {
                throw new Exception("The asset conversion operation completed with an unexpected successful status");
            }

            // ScaledAssetDimensions should be null when asset conversion fails due to an invalid asset file format
            // But should not throw an exception trying to access it
            if (operation.Value.ScaledAssetDimensions != null)
            {
                throw new Exception("ScaledAssetDimensions isn't null for a failed job on an invalid asset");
            }
        }

        private async Task<(
            ObjectAnchorsConversionClient Client,
            ObjectAnchorsConversionClient InstrumentedClient,
            AssetConversionOptions AssetConversionOptions)>
            GetClientsAndConversionOptionsForAsset(string assetName)
        {
            string localFilePath = assetName;
            Vector3 assetGravity = new Vector3(assetGravityX, assetGravityY, assetGravityZ);
            float scale = assetScale;

            var clientWithWorkingInternalMethods = CreateClient();
            ObjectAnchorsConversionClient client = InstrumentClient(clientWithWorkingInternalMethods);

            AssetUploadUriResult uploadUriResult = await client.GetAssetUploadUriAsync();

            Uri uploadedInputAssetUri = uploadUriResult.UploadUri;

            BlobClient uploadBlobClient = InstrumentClient(new BlobClient(uploadedInputAssetUri, InstrumentClientOptions(new BlobClientOptions(BlobClientOptions.ServiceVersion.V2019_12_12))));

            using (FileStream fs = File.OpenRead(localFilePath))
            {
                await uploadBlobClient.UploadAsync(fs);
            }

            AssetConversionOptions assetConversionOptions = new AssetConversionOptions(uploadedInputAssetUri, AssetFileType.FromFilePath(localFilePath), assetGravity, scale);

            assetConversionOptions.JobId = Recording.Random.NewGuid();

            return (clientWithWorkingInternalMethods, client, assetConversionOptions);
        }

        private ObjectAnchorsConversionClient CreateClient()
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            var options = InstrumentClientOptions(new ObjectAnchorsConversionClientOptions());

            // We can't use record the authentication calls because the token returned would be
            // expired by the time we play the test back
            if (Mode == RecordedTestMode.Playback)
            {
                return new ObjectAnchorsConversionClient(accountId, accountDomain, new StaticAccessTokenCredential(new AccessToken("TOKEN", DateTimeOffset.MaxValue)), options);
            }

            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.AccountKey);

            return new ObjectAnchorsConversionClient(accountId, accountDomain, credential, options);
        }
    }
}
