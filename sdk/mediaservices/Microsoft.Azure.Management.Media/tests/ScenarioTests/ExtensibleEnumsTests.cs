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
    public class ExtensibleEnumsTests : MediaScenarioTestBase
    {
        [Fact]
        public void ExtensibleEnumsSetTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                TrackPropertyType x = "NewProperty";
                Assert.True(x.GetType() == typeof(TrackPropertyType));
                var y = TrackPropertyType.FourCC;
                Assert.True(y.GetType() == x.GetType());
            }
        }

        [Fact]
        public void ExtensibleEnumsGetTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
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

                    //  The response file for the Get test - SessionRecords\Media.Tests.ScenarioTests.ExtensibleEnumsTests\ExtensibleEnumsGetTest.json
                    //  was edited after being recorded so we could test an unexpected value being sent by the service and the client code
                    //  correctly deserializing the unexpected value.

                    asset = MediaClient.Assets.Get(ResourceGroup, AccountName, assetName);

                    //  If we get here, the edited AssetStorageEncryptionFormat deserialized.
                    Assert.NotNull(asset);

                    AssetStorageEncryptionFormat assetStorageEncyptionFormatEdited = "Edited";

                    ValidateAsset(asset, assetName, assetDescription, null, assetStorageEncyptionFormatEdited);

                    Assert.True(asset.StorageEncryptionFormat.GetType() == typeof(AssetStorageEncryptionFormat));
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

