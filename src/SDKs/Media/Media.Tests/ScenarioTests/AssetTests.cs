// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class AssetTests : MediaScenarioTestBase
    {
        [Fact]
        public void AssetComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                try
                {
                    CreateMediaServicesAccount();

                    // List Assets, which should be empty
                    var assets = MediaClient.Assets.List(ResourceGroup, AccountName);
                    Assert.Empty(assets);

                    string assetName = TestUtilities.GenerateName("asset");
                    string assetDescription = "A test asset";

                    // Get asset, which should not exist
                    Asset asset = MediaClient.Assets.Get(ResourceGroup, AccountName, assetName);
                    Assert.Null(asset);

                    // Create an asset
                    Asset input = new Asset(description: assetDescription);
                    Asset createdAsset = MediaClient.Assets.CreateOrUpdate(ResourceGroup, AccountName, assetName, input);
                    ValidateAsset(createdAsset, assetName, assetDescription, null, AssetStorageEncryptionFormat.None);

                    // List assets and validate the created asset shows up
                    assets = MediaClient.Assets.List(ResourceGroup, AccountName);
                    Assert.Single(assets);
                    ValidateAsset(assets.First(), assetName, assetDescription, null, AssetStorageEncryptionFormat.None);

                    // Get the newly created asset
                    asset = MediaClient.Assets.Get(ResourceGroup, AccountName, assetName);
                    Assert.NotNull(asset);
                    ValidateAsset(asset, assetName, assetDescription, null, AssetStorageEncryptionFormat.None);

                    // Update the asset
                    string alternateId = "1234567890-7865";
                    Asset input2 = new Asset(description: assetDescription, alternateId: alternateId, storageAccountName: createdAsset.StorageAccountName, container: createdAsset.Container);
                    Asset updatedByPutAsset = MediaClient.Assets.CreateOrUpdate(ResourceGroup, AccountName, assetName, input2);
                    ValidateAsset(updatedByPutAsset, assetName, assetDescription, input2.AlternateId, AssetStorageEncryptionFormat.None);

                    // List assets and validate the updated asset shows up as expected
                    assets = MediaClient.Assets.List(ResourceGroup, AccountName);
                    Assert.Single(assets);
                    ValidateAsset(assets.First(), assetName, assetDescription, input2.AlternateId, AssetStorageEncryptionFormat.None);

                    // Get the newly updated asset
                    asset = MediaClient.Assets.Get(ResourceGroup, AccountName, assetName);
                    Assert.NotNull(asset);
                    ValidateAsset(asset, assetName, assetDescription, input2.AlternateId, AssetStorageEncryptionFormat.None);

                    // Update the asset again
                    string alternateId2 = "1234567890";
                    Asset input3 = new Asset(alternateId: alternateId2);
                    Asset updatedByPatchAsset = MediaClient.Assets.Update(ResourceGroup, AccountName, assetName, input3);
                    ValidateAsset(updatedByPatchAsset, assetName, assetDescription, input3.AlternateId, AssetStorageEncryptionFormat.None);

                    // List assets and validate the updated asset shows up as expected
                    assets = MediaClient.Assets.List(ResourceGroup, AccountName);
                    Assert.Single(assets);
                    ValidateAsset(assets.First(), assetName, assetDescription, input3.AlternateId, AssetStorageEncryptionFormat.None);

                    // Get the newly updated asset
                    asset = MediaClient.Assets.Get(ResourceGroup, AccountName, assetName);
                    Assert.NotNull(asset);
                    ValidateAsset(asset, assetName, assetDescription, input3.AlternateId, AssetStorageEncryptionFormat.None);

                    // Delete the asset
                    MediaClient.Assets.Delete(ResourceGroup, AccountName, assetName);

                    // List assets, which should be empty again
                    assets = MediaClient.Assets.List(ResourceGroup, AccountName);
                    Assert.Empty(assets);

                    // Get tranform, which should not exist
                    asset = MediaClient.Assets.Get(ResourceGroup, AccountName, assetName);
                    Assert.Null(asset);                    
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateAsset(Asset asset, string expectedAssetName, string expectedAssetDescription, string expectedAlternateId, AssetStorageEncryptionFormat expectedStorageEncryptionFormat)
        {
            Assert.Equal(expectedAssetDescription, asset.Description);
            Assert.Equal(expectedAssetName, asset.Name);
            Assert.Equal(expectedAlternateId, asset.AlternateId);
            Assert.Equal(expectedStorageEncryptionFormat, asset.StorageEncryptionFormat);
            Assert.NotEqual(Guid.Empty, asset.AssetId);
            //Assert.False(string.IsNullOrEmpty(asset.Container)); // TODO: This is currently not implemented.  Verify it once it is
            Assert.False(string.IsNullOrEmpty(asset.StorageAccountName));
        }
    }
}
