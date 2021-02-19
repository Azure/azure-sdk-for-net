// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.MixedReality.ObjectAnchors.Tests.Samples
{
    public class AssetConversionProcessSample : SamplesBase<ObjectAnchorsClientTestEnvironment>
    {
        private readonly Guid accountId;
        private readonly string accountDomain;

        public AssetConversionProcessSample()
        {
            this.accountId = new Guid(TestEnvironment.AccountId);
            this.accountDomain = TestEnvironment.AccountDomain;
        }

        public async Task RunIngestion()
        {
            string localFilePath = TestEnvironment.AssetLocalFilePath;
            Vector3 assetGravity = new Vector3(TestEnvironment.AssetGravityX, TestEnvironment.AssetGravityY, TestEnvironment.AssetGravityZ);
            float scale = TestEnvironment.AssetScale;

            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.AccountKey);

            ObjectAnchorsClient client = new ObjectAnchorsClient(accountId, accountDomain, credential);

            Uri uploadedInputAssetUri = (await client.GetAssetUploadUriAsync()).Value.UploadUri;

            BlobClient uploadBlobClient = new BlobClient(uploadedInputAssetUri);

            using (FileStream fs = File.OpenRead(localFilePath))
            {
                await uploadBlobClient.UploadAsync(fs);
            }

            StartAssetConversionOptions ingestionJobOptions = new StartAssetConversionOptions(uploadedInputAssetUri, AssetFileType.FromFilePath(localFilePath), assetGravity, scale);

            AssetConversionOperation operation = await client.StartAssetConversionAsync(ingestionJobOptions);

            Guid jobId = new Guid(operation.Id);

            await operation.WaitForCompletionAsync();

            if (!operation.HasCompletedSuccessfully)
            {
                throw new Exception("The asset conversion operation completed with an unsuccessful status");
            }

            string localFileDownloadPath = TestEnvironment.ModelDownloadLocalFilePath;

            BlobClient downloadBlobClient = new BlobClient(operation.Value.OutputModelUri);

            BlobDownloadInfo downloadInfo = await downloadBlobClient.DownloadAsync();

            using (FileStream file = File.OpenWrite(localFileDownloadPath))
            {
                await downloadInfo.Content.CopyToAsync(file);
                var fileInfo = new FileInfo(localFileDownloadPath);
            }
        }
    }
}
