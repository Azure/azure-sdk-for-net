// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ElasticSan.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ElasticSan.Tests.Scenario
{
    public class ElasticSanResourceTests : ElasticSanTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ElasticSanCollection _collection;

        public ElasticSanResourceTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private async Task<ElasticSanResource> CreateElasticSanAsync(string name)
        {
            _resourceGroup = await CreateResourceGroupResourceAsync();
            _collection = _resourceGroup.GetElasticSans();
            var lro = await _collection.CreateOrUpdateAsync(WaitUntil.Completed, name, GetDefaultElasticSanParameters(TestLocation));
            return lro.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanResource elasticSan1 = (await elasticSanCollection.GetAsync(ElasticSanName)).Value;
            ElasticSanResource elasticSan2 = (await elasticSan1.GetAsync()).Value;
            Assert.AreEqual(elasticSan1.Id.Name, elasticSan2.Id.Name);
            Assert.AreEqual(elasticSan1.Id.Location, elasticSan2.Id.Location);
            Assert.AreEqual(elasticSan1.Id.ResourceType, elasticSan2.Id.ResourceType);
            Assert.AreEqual(elasticSan1.Data.Id, elasticSan2.Data.Id);
            Assert.AreEqual(elasticSan1.Data.Name, elasticSan2.Data.Name);
            Assert.AreEqual(elasticSan1.Data.Tags, elasticSan2.Data.Tags);
            Assert.AreEqual(elasticSan1.Data.BaseSizeTiB, elasticSan2.Data.BaseSizeTiB);
            Assert.AreEqual(elasticSan1.Data.ExtendedCapacitySizeTiB, elasticSan2.Data.ExtendedCapacitySizeTiB);
            Assert.AreEqual(elasticSan1.Data.AvailabilityZones, elasticSan2.Data.AvailabilityZones);
            Assert.AreEqual(elasticSan1.Data.Tags, elasticSan2.Data.Tags);
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
        public async Task UpdateAndDelete()
        {
            string elasticSanName = Recording.GenerateAssetName("testsan-");
            ElasticSanResource elasticSan1 = await CreateElasticSanAsync(elasticSanName);
            ElasticSanPatch patch = new()
            {
                BaseSizeTiB = 2,
                ExtendedCapacitySizeTiB = 7,
            };
            patch.ScaleUpProperties = new ElasticSanScaleUpProperties
            {
                UnusedSizeTiB = 2,
                IncreaseCapacityUnitByTiB = 2,
                CapacityUnitScaleUpLimitTiB = 25,
                AutoScalePolicyEnforcement = AutoScalePolicyEnforcement.Enabled,
            };
            patch.Tags.Add("tag3", "val3");
            ElasticSanResource elasticSan2 = (await elasticSan1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual(2, elasticSan2.Data.BaseSizeTiB);
            Assert.AreEqual(7, elasticSan2.Data.ExtendedCapacitySizeTiB);
            Assert.AreEqual(elasticSan1.Id.Name, elasticSan2.Id.Name);
            Assert.AreEqual(elasticSan1.Data.Name, elasticSan2.Data.Name);
            Assert.GreaterOrEqual(elasticSan2.Data.Tags.Count, 1);
            Assert.AreEqual(elasticSan2.Data.ScaleUpProperties.CapacityUnitScaleUpLimitTiB, 25);
            Assert.AreEqual(elasticSan2.Data.ScaleUpProperties.UnusedSizeTiB, 2);
            Assert.AreEqual(elasticSan2.Data.ScaleUpProperties.IncreaseCapacityUnitByTiB, 2);
            Assert.AreEqual(elasticSan2.Data.ScaleUpProperties.AutoScalePolicyEnforcement.Value, AutoScalePolicyEnforcement.Enabled);

            await elasticSan1.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await _collection.ExistsAsync(elasticSanName));
        }
    }
}
