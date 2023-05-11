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
    public class HciClusterOperationTests: HciManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private HciClusterResource _cluster;

        public HciClusterOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<HciClusterResource> CreateHciClusterAsync(string clusterName)
        {
            var location = AzureLocation.EastUS;
            _resourceGroup = await CreateResourceGroupAsync(Subscription, "hci-cluster-rg", location);
            _cluster = await CreateHciClusterAsync(_resourceGroup, clusterName);
            return _cluster;
        }

        [TestCase]
        [RecordedTest]
        public async Task GetUpdateDelete()
        {
            var clusterName = Recording.GenerateAssetName("hci-cluster");
            var cluster = await CreateHciClusterAsync(clusterName);

            var patch = new HciClusterPatch()
            {
                DesiredProperties = new HciClusterDesiredProperties()
                {
                    DiagnosticLevel = HciClusterDiagnosticLevel.Enhanced
                },
                ManagedServiceIdentityType = Models.HciManagedServiceIdentityType.None
            };

            HciClusterResource clusterFromUpdate = await cluster.UpdateAsync(patch);
            Assert.AreEqual(HciClusterDiagnosticLevel.Enhanced, clusterFromUpdate.Data.DesiredProperties.DiagnosticLevel);

            HciClusterResource clusterFromGet = await clusterFromUpdate.GetAsync();
            Assert.AreEqual(clusterFromGet.Data.Name, clusterName);
            Assert.AreEqual(clusterFromGet.Data.AadClientId, new Guid(TestEnvironment.ClientId));
            Assert.AreEqual(clusterFromGet.Data.AadTenantId, new Guid(TestEnvironment.TenantId));
            Assert.AreEqual(HciClusterDiagnosticLevel.Enhanced, clusterFromGet.Data.DesiredProperties.DiagnosticLevel);

            await clusterFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var clusterName = Recording.GenerateAssetName("hci-cluster");
            var cluster = await CreateHciClusterAsync(clusterName);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            HciClusterResource updatedCluster = await cluster.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedCluster.Data.Tags);
        }
    }
}
