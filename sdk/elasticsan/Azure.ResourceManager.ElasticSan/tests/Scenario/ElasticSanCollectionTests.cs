// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ElasticSan.Tests.Scenario
{
    public class ElasticSanCollectionTests : ElasticSanTestBase
    {
        public ElasticSanCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();

            ElasticSanData data = GetDefaultElasticSanParameters(TestLocation);
            data.Tags.Add("tag1", "value1");
            data.PublicNetworkAccess = Models.ElasticSanPublicNetworkAccess.Enabled;
            data.ScaleUpProperties = new Models.ElasticSanScaleUpProperties
            {
                AutoScalePolicyEnforcement = Models.AutoScalePolicyEnforcement.Disabled,
                CapacityUnitScaleUpLimitTiB  = 24,
                IncreaseCapacityUnitByTiB = 1,
                UnusedSizeTiB = 5
            };

            string elasticSanName = Recording.GenerateAssetName("testsan-");
            ElasticSanResource elasticSan1 = (await elasticSanCollection.CreateOrUpdateAsync(WaitUntil.Completed, elasticSanName, data)).Value;
            Assert.AreEqual(elasticSanName, elasticSan1.Id.Name);
            Assert.AreEqual(1, elasticSan1.Data.BaseSizeTiB);
            Assert.AreEqual(6, elasticSan1.Data.ExtendedCapacitySizeTiB);
            Assert.IsTrue(elasticSan1.Data.Tags.ContainsKey("tag1"));
            Assert.AreEqual("value1", elasticSan1.Data.Tags["tag1"]);
            Assert.AreEqual("Enabled", elasticSan1.Data.PublicNetworkAccess.Value.ToString());
            Assert.AreEqual(elasticSan1.Data.ScaleUpProperties.AutoScalePolicyEnforcement, Models.AutoScalePolicyEnforcement.Disabled);
            Assert.AreEqual(elasticSan1.Data.ScaleUpProperties.IncreaseCapacityUnitByTiB, 1);
            Assert.AreEqual(elasticSan1.Data.ScaleUpProperties.CapacityUnitScaleUpLimitTiB, 24);
            Assert.AreEqual(elasticSan1.Data.ScaleUpProperties.UnusedSizeTiB, 5);
            // Skip the validation for AvailabilityZone as the server won't return the property

            elasticSan1 = (await elasticSanCollection.CreateOrUpdateAsync(WaitUntil.Completed, elasticSanName, GetDefaultElasticSanParameters(TestLocation, 2, 7))).Value;
            Assert.AreEqual(elasticSanName, elasticSan1.Id.Name);
            Assert.AreEqual(2, elasticSan1.Data.BaseSizeTiB);
            Assert.AreEqual(7, elasticSan1.Data.ExtendedCapacitySizeTiB);
            Assert.IsEmpty(elasticSan1.Data.Tags);
            Assert.IsEmpty(elasticSan1.Data.AvailabilityZones);
            Assert.AreEqual(null, elasticSan1.Data.PublicNetworkAccess);
            Assert.IsNull(elasticSan1.Data.ScaleUpProperties);

            await elasticSan1.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanResource elasticSan1 = (await elasticSanCollection.GetAsync(ElasticSanName)).Value;
            Assert.AreEqual(ElasticSanName, elasticSan1.Id.Name);
            Assert.AreEqual(1, elasticSan1.Data.BaseSizeTiB);
            Assert.AreEqual(6, elasticSan1.Data.ExtendedCapacitySizeTiB);

            // Test for ElasticSan PE properties
            Assert.AreEqual(3, elasticSan1.Data.PrivateEndpointConnections.Count);
            Assert.IsNotEmpty(elasticSan1.Data.PrivateEndpointConnections[0].Name);
            Assert.IsNotEmpty(elasticSan1.Data.PrivateEndpointConnections[0].PrivateEndpointId);
            Assert.AreEqual("Approved", elasticSan1.Data.PrivateEndpointConnections[0].ConnectionState.Status.ToString());
            Assert.IsNotEmpty(elasticSan1.Data.PrivateEndpointConnections[1].Name);
            Assert.AreEqual("Approved", elasticSan1.Data.PrivateEndpointConnections[1].ConnectionState.Status.ToString());
            Assert.IsNotEmpty(elasticSan1.Data.PrivateEndpointConnections[1].PrivateEndpointId);
            Assert.IsNotEmpty(elasticSan1.Data.PrivateEndpointConnections[2].Name);
            Assert.AreEqual("Pending", elasticSan1.Data.PrivateEndpointConnections[2].ConnectionState.Status.ToString());
            Assert.IsNotEmpty(elasticSan1.Data.PrivateEndpointConnections[2].PrivateEndpointId);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            int count = 0;
            await foreach (ElasticSanResource _ in elasticSanCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [Test]
        [RecordedTest]
        public async Task Exists()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();

            Assert.IsTrue(await elasticSanCollection.ExistsAsync(ElasticSanName));
            Assert.IsFalse(await elasticSanCollection.ExistsAsync(ElasticSanName + "111"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await elasticSanCollection.ExistsAsync(null));
        }
    }
}
