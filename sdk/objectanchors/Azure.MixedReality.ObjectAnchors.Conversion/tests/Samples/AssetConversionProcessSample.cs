// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Tests.Samples
{
    public class AssetConversionProcessSample : SamplesBase<ObjectAnchorsConversionClientTestEnvironment>
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

        public async Task<Guid> StartAssetConversion()
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            string localFilePath = assetLocalFilePath;
            Vector3 assetGravity = new Vector3(assetGravityX, assetGravityY, assetGravityZ);
            float scale = assetScale;

            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.AccountKey);

            ObjectAnchorsConversionClient client = new ObjectAnchorsConversionClient(accountId, accountDomain, credential);

            Uri uploadedInputAssetUri = (await client.GetAssetUploadUriAsync()).Value.UploadUri;

            BlobClient uploadBlobClient = new BlobClient(uploadedInputAssetUri, new BlobClientOptions());

            using (FileStream fs = File.OpenRead(localFilePath))
            {
                await uploadBlobClient.UploadAsync(fs);
            }

            AssetConversionOptions ingestionJobOptions = new AssetConversionOptions(uploadedInputAssetUri, AssetFileType.FromFilePath(localFilePath), assetGravity, scale);

            AssetConversionOperation operation = await client.StartAssetConversionAsync(ingestionJobOptions);

            return new Guid(operation.Id);
        }

        public async Task WaitForAssetConversionToComplete(Guid jobId)
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.AccountKey);
            ObjectAnchorsConversionClient client = new ObjectAnchorsConversionClient(accountId, accountDomain, credential);

            AssetConversionOperation operation = new AssetConversionOperation(jobId, client);

            await operation.WaitForCompletionAsync();

            if (!operation.HasCompletedSuccessfully)
            {
                throw new Exception("The asset conversion operation completed with an unsuccessful status");
            }
        }

        public async Task<FileInfo> DownloadConvertedAsset(Guid jobId)
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.AccountKey);
            ObjectAnchorsConversionClient client = new ObjectAnchorsConversionClient(accountId, accountDomain, credential);

            AssetConversionOperation operation = new AssetConversionOperation(jobId, client);

            string localFileDownloadPath = modelDownloadLocalFilePath;

            BlobClient downloadBlobClient = new BlobClient(operation.Value.OutputModelUri, new BlobClientOptions());

            BlobDownloadInfo downloadInfo = await downloadBlobClient.DownloadAsync();

            using (FileStream file = File.OpenWrite(localFileDownloadPath))
            {
                await downloadInfo.Content.CopyToAsync(file);
                return new FileInfo(localFileDownloadPath);
            }
        }
    }
}
