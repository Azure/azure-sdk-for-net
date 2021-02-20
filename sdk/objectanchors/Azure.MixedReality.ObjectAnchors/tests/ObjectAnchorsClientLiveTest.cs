// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.MixedReality.Authentication;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.MixedReality.ObjectAnchors.Tests
{
    public class ObjectAnchorsClientLiveTest : RecordedTestBase<ObjectAnchorsClientTestEnvironment>
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

        public ObjectAnchorsClientLiveTest(bool isAsync)
            : base(isAsync/*, RecordedTestMode.Record*/)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;

            Matcher = new MixedRealityRecordMatcher();
        }

        [RecordedTest]
        public async Task RunIngestion()
        {
            Recording.DisableIdReuse();
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            ObjectAnchorsClientOptions options = new ObjectAnchorsClientOptions();
            options.MixedRealityAuthenticationOptions = InstrumentClientOptions(new MixedRealityStsClientOptions());
            string localFilePath = assetLocalFilePath;
            Vector3 assetGravity = new Vector3(assetGravityX, assetGravityY, assetGravityZ);
            float scale = assetScale;

            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.AccountKey);

            ObjectAnchorsClient client = InstrumentClient(new ObjectAnchorsClient(accountId, accountDomain, credential, InstrumentClientOptions(options)));

            Uri uploadedInputAssetUri = (await client.GetAssetUploadUriAsync()).Value.UploadUri;

            BlobClient uploadBlobClient = InstrumentClient(new BlobClient(uploadedInputAssetUri, InstrumentClientOptions(new BlobClientOptions())));

            using (FileStream fs = File.OpenRead(localFilePath))
            {
                await uploadBlobClient.UploadAsync(fs);
            }

            AssetConversionOptions ingestionJobOptions = new AssetConversionOptions(uploadedInputAssetUri, AssetFileType.FromFilePath(localFilePath), assetGravity, scale);

            ingestionJobOptions.JobId = Recording.Random.NewGuid();

            AssetConversionOperation operation = await client.StartAssetConversionAsync(ingestionJobOptions);

            Guid jobId = new Guid(operation.Id);

            await operation.WaitForCompletionAsync();

            if (!operation.HasCompletedSuccessfully)
            {
                throw new Exception("The asset conversion operation completed with an unsuccessful status");
            }

            string localFileDownloadPath = modelDownloadLocalFilePath;

            BlobClient downloadBlobClient = InstrumentClient(new BlobClient(operation.Value.OutputModelUri, InstrumentClientOptions(new BlobClientOptions())));

            BlobDownloadInfo downloadInfo = await downloadBlobClient.DownloadAsync();

            using (FileStream file = File.OpenWrite(localFileDownloadPath))
            {
                await downloadInfo.Content.CopyToAsync(file);
                var fileInfo = new FileInfo(localFileDownloadPath);
                Assert.Greater(fileInfo.Length, 0);
            }
        }
    }
}
