// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.MixedReality.RemoteRendering.Tests.Samples
{
    // These tests assume that the storage account is accessible from the remote rendering account.
    // See https://docs.microsoft.com/azure/remote-rendering/how-tos/create-an-account
    // Since the roles can take a while to propagate, we do not live test these samples.

    public class RemoteRenderingConvertAssetSample : SamplesBase<RemoteRenderingTestEnvironment>
    {
        private RemoteRenderingClient GetClient()
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            string accountKey = TestEnvironment.AccountKey;
            Uri remoteRenderingEndpoint = new Uri(TestEnvironment.ServiceEndpoint);

            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(accountKey);

            RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, accountKeyCredential);
            return client;
        }

        [Test]
        [Explicit("This test assume DRAM is set up, so we do not run them live.")]
        public void ConvertSimpleAsset()
        {
            RemoteRenderingClient client = GetClient();

            Uri storageUri = new Uri($"https://{TestEnvironment.StorageAccountName}.blob.core.windows.net/{TestEnvironment.BlobContainerName}");

            #region Snippet:StartAnAssetConversion

            AssetConversionInputOptions inputOptions = new AssetConversionInputOptions(storageUri, "box.fbx");
            AssetConversionOutputOptions outputOptions = new AssetConversionOutputOptions(storageUri);
            AssetConversionOptions conversionOptions = new AssetConversionOptions(inputOptions, outputOptions);

            // A randomly generated GUID is a good choice for a conversionId.
            string conversionId = Guid.NewGuid().ToString();

            AssetConversionOperation conversionOperation = client.StartConversion(conversionId, conversionOptions);

            #endregion Snippet:StartAnAssetConversion

            AssetConversion conversion = conversionOperation.WaitForCompletionAsync().Result;
            if (conversion.Status == AssetConversionStatus.Succeeded)
            {
                Console.WriteLine($"Conversion succeeded: Output written to {conversion.Output.OutputAssetUri}");
            }
            else if (conversion.Status == AssetConversionStatus.Failed)
            {
                Console.WriteLine($"Conversion failed: {conversion.Error.Code} {conversion.Error.Message}");
            }
        }

        [Test]
        [Explicit("This test assume DRAM is set up, so we do not run them live.")]
        public void ConvertMoreComplexAsset()
        {
            RemoteRenderingClient client = GetClient();

            Uri inputStorageUri = new Uri($"https://{TestEnvironment.StorageAccountName}.blob.core.windows.net/{TestEnvironment.BlobContainerName}");
            Uri outputStorageUri = new Uri($"https://{TestEnvironment.StorageAccountName}.blob.core.windows.net/{TestEnvironment.BlobContainerName}");

            #region Snippet:StartAComplexAssetConversion
            AssetConversionInputOptions inputOptions = new AssetConversionInputOptions(inputStorageUri, "bicycle.gltf")
            {
                BlobPrefix = "Bicycle"
            };
            AssetConversionOutputOptions outputOptions = new AssetConversionOutputOptions(outputStorageUri)
            {
                BlobPrefix = "ConvertedBicycle"
            };
            AssetConversionOptions conversionOptions = new AssetConversionOptions(inputOptions, outputOptions);

            string conversionId = Guid.NewGuid().ToString();

            AssetConversionOperation conversionOperation = client.StartConversion(conversionId, conversionOptions);
            #endregion Snippet:StartAComplexAssetConversion

            #region Snippet:QueryConversionStatus
            AssetConversion conversion = conversionOperation.WaitForCompletionAsync().Result;
            if (conversion.Status == AssetConversionStatus.Succeeded)
            {
                Console.WriteLine($"Conversion succeeded: Output written to {conversion.Output.OutputAssetUri}");
            }
            else if (conversion.Status == AssetConversionStatus.Failed)
            {
                Console.WriteLine($"Conversion failed: {conversion.Error.Code} {conversion.Error.Message}");
            }
            #endregion Snippet:QueryConversionStatus
        }

        [Test]
        [Explicit("This test assume DRAM is set up, so we do not run them live.")]
        public void GetConversions()
        {
            RemoteRenderingClient client = GetClient();

            Console.WriteLine("Successful conversions since yesterday:");
            #region Snippet:GetConversions

            foreach (var conversion in client.GetConversions())
            {
                if ((conversion.Status == AssetConversionStatus.Succeeded) && (conversion.CreatedOn > DateTimeOffset.Now.AddDays(-1)))
                {
                    Console.WriteLine($"output asset URI: {conversion.Output.OutputAssetUri}");
                }
            }

            #endregion Snippet:GetConversions
        }
    }
}
