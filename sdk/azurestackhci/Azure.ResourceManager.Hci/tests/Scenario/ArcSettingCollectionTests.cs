// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class ArcSettingCollectionTests: HciManagementTestBase
    {
        public ArcSettingCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetList()
        {
            var location = AzureLocation.EastUS;
            var resourceGroup = await CreateResourceGroupAsync(Subscription, "hci-cluster-rg", location);
            var clusterName = Recording.GenerateAssetName("hci-cluster");
            var cluster = await CreateHciClusterAsync(resourceGroup, clusterName);
            var arcSettingCollection = cluster.GetArcSettings();
            var arcSettingName = "default";//Recording.GenerateAssetName("hci-arc-setting");
            var arcSetting = await CreateArcSettingAsync(cluster, arcSettingName);
            Assert.AreEqual(arcSetting.Data.Name, arcSettingName);

            ArcSettingResource arcSettingFromGet = await arcSettingCollection.GetAsync(arcSettingName);
            Assert.AreEqual(arcSettingFromGet.Data.Name, arcSettingName);

            await foreach (ArcSettingResource arcSettingFromList in arcSettingCollection)
            {
                Assert.AreEqual(arcSettingFromList.Data.Name, arcSettingName);
            }
        }
    }
}
