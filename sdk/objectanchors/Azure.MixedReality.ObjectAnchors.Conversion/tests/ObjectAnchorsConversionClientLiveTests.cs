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
        private const float assetGravityX = 0;
        private const float assetGravityY = -1;
        private const float assetGravityZ = 0;
        private const float assetScale = 0.001f;

        private static string currentWorkingDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly string assetLocalFilePath = Path.Combine(currentWorkingDirectory, assetsFolderName, assetsFileName);
        public string modelDownloadLocalFilePath => Path.Combine(currentWorkingDirectory, modelDownloadFileName);

        public ObjectAnchorsConversionClientLiveTests(bool isAsync)
            : base(isAsync)
        {
            Matcher = new MixedRealityRecordMatcher();
        }

        [RecordedTest]
        public async Task RunAssetConversion()
        {
            Recording.DisableIdReuse();

            string localFilePath = assetLocalFilePath;
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
        public async Task ObserveExistingAssetConversion()
        {
            Recording.DisableIdReuse();

            string localFilePath = assetLocalFilePath;
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
