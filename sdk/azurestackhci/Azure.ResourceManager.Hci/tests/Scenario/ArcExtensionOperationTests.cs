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
    public class ArcExtensionOperationTests: HciManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ArcExtensionResource _arcExtension;
        private ArcExtensionCollection _arcExtensionCollection;

        public ArcExtensionOperationTests(bool isAsync)
            : base(isAsync)
        {
        }

        private async Task<ArcExtensionResource> CreateArcExtensionAsync(string arcExtensionName)
        {
            var location = AzureLocation.EastUS;
            _resourceGroup = await CreateResourceGroupAsync(Subscription, "hci-cluster-rg", location);
            var clusterName = Recording.GenerateAssetName("hci-cluster");
            var cluster = await CreateHciClusterAsync(_resourceGroup, clusterName);
            var arcSetting = await CreateArcSettingAsync(cluster, "default");

            _arcExtension = await CreateArcExtensionAsync(arcSetting, arcExtensionName);
            _arcExtensionCollection = arcSetting.GetArcExtensions();
            return _arcExtension;
        }

        [TestCase]
        [RecordedTest]
        public async Task GetUpdateDelete()
        {
            var arcExtensionName = "MicrosoftMonitoringAgent";
            var arcExtension = await CreateArcExtensionAsync(arcExtensionName);

            var data = new ArcExtensionData()
            {
                ShouldAutoUpgradeMinorVersion = true,
            };
            var lro = await arcExtension.UpdateAsync(WaitUntil.Completed, data);
            var arcExtensionFromUpdate = lro.Value;
            Assert.True(arcExtensionFromUpdate.Data.ShouldAutoUpgradeMinorVersion);

            ArcExtensionResource arcExtensionFromGet = await arcExtensionFromUpdate.GetAsync();
            Assert.AreEqual(arcExtensionFromGet.Data.Name, arcExtensionName);

            await arcExtensionFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
