// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class KubernetesClusterFeatureTests : NetworkCloudManagementTestBase
    {
        public KubernetesClusterFeatureTests  (bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public KubernetesClusterFeatureTests (bool isAsync) : base(isAsync) {}

        [Test, MaxTime(1800000)]
        [RecordedTest]
        public async Task KubernetesClusterFeature()
        {
            string featureName = Recording.GenerateAssetName("csi-volume");
            ResourceIdentifier featureId = NetworkCloudKubernetesClusterFeatureResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.KubernetesClusterRG, TestEnvironment.KubernetesClusterName, featureName);
            NetworkCloudKubernetesClusterFeatureResource feature = Client.GetNetworkCloudKubernetesClusterFeatureResource(featureId);

            NetworkCloudKubernetesClusterResource kubernetesCluster = Client.GetNetworkCloudKubernetesClusterResource(TestEnvironment.KubernetesClusterId);
            kubernetesCluster = await kubernetesCluster.GetAsync();
            NetworkCloudKubernetesClusterFeatureCollection collection = kubernetesCluster.GetNetworkCloudKubernetesClusterFeatures();

            // Create
            NetworkCloudKubernetesClusterFeatureData data = new NetworkCloudKubernetesClusterFeatureData(TestEnvironment.Location)
            {
                Tags =
{
["key1"] = "myvalue1",
["key2"] = "myvalue2",
},
                Options =
{
new StringKeyValuePair("featureOptionName","featureOptionValue")
},
            };
            // Create
            ArmOperation<NetworkCloudKubernetesClusterFeatureResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, featureName, data);
            Assert.AreEqual(featureName, createResult.Value.Data.Name);

            // Get
            var getResult = await feature.GetAsync();
            Assert.AreEqual(featureName, getResult.Value.Data.Name);

            // List
            var listByKubernetesCluster = new List<NetworkCloudKubernetesClusterFeatureResource>();
            await foreach (NetworkCloudKubernetesClusterFeatureResource item in collection.GetAllAsync())
            {
                listByKubernetesCluster.Add(item);
            }
            Assert.IsNotEmpty(listByKubernetesCluster);

            // Update
            NetworkCloudKubernetesClusterFeaturePatch patch = new NetworkCloudKubernetesClusterFeaturePatch()
            {
                Tags =
                {
                    ["key1"] = "newvalue1",
                    ["key2"] = "newvalue2",
                }
            };
            ArmOperation<NetworkCloudKubernetesClusterFeatureResource> updateResult = await feature.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            // Delete
            ArmOperation<NetworkCloudOperationStatusResult> deleteResult = await feature.DeleteAsync(WaitUntil.Completed, "*", "*", CancellationToken.None);
            NetworkCloudOperationStatusResult result = deleteResult.Value;
            Assert.IsNotNull(result);
        }
    }
}
