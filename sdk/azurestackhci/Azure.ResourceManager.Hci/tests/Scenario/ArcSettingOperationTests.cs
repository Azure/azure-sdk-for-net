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
    public class ArcSettingOperationTests: HciManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ArcSettingResource _arcSetting;
        private ArcSettingCollection _arcSettingCollection;

        public ArcSettingOperationTests(bool isAsync)
            : base(isAsync)
        {
        }

        private async Task<ArcSettingResource> CreateArcSettingAsync(string arcSettingName)
        {
            var location = AzureLocation.EastUS;
            _resourceGroup = await CreateResourceGroupAsync(Subscription, "hci-cluster-rg", location);
            var clusterName = Recording.GenerateAssetName("hci-cluster");
            HciClusterResource cluster = await CreateHciClusterAsync(_resourceGroup, clusterName);
            _arcSettingCollection = cluster.GetArcSettings();
            _arcSetting = await CreateArcSettingAsync(cluster, arcSettingName);
            return _arcSetting;
        }

        [TestCase]
        [RecordedTest]
        public async Task GetUpdateDelete()
        {
            var arcSettingName = "default";
            var arcSetting = await CreateArcSettingAsync(arcSettingName);

            var patch = new ArcSettingPatch()
            {
                ConnectivityProperties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "enabled", false }
                })
            };
            ArcSettingResource arcSettingFromUpdate = await arcSetting.UpdateAsync(patch);
            var properties = arcSettingFromUpdate.Data.ConnectivityProperties.ToObjectFromJson() as Dictionary<string, object>;
            Assert.False((bool)properties["enabled"]);

            ArcSettingResource arcSettingFromGet = await arcSettingFromUpdate.GetAsync();
            Assert.AreEqual(arcSettingFromGet.Data.Name, arcSettingName);

            await arcSettingFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
