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
            Assert.That(elasticSan2.Id.Name, Is.EqualTo(elasticSan1.Id.Name));
            Assert.That(elasticSan2.Id.Location, Is.EqualTo(elasticSan1.Id.Location));
            Assert.That(elasticSan2.Id.ResourceType, Is.EqualTo(elasticSan1.Id.ResourceType));
            Assert.That(elasticSan2.Data.Id, Is.EqualTo(elasticSan1.Data.Id));
            Assert.That(elasticSan2.Data.Name, Is.EqualTo(elasticSan1.Data.Name));
            Assert.That(elasticSan2.Data.Tags, Is.EqualTo(elasticSan1.Data.Tags));
            Assert.That(elasticSan2.Data.BaseSizeTiB, Is.EqualTo(elasticSan1.Data.BaseSizeTiB));
            Assert.That(elasticSan2.Data.ExtendedCapacitySizeTiB, Is.EqualTo(elasticSan1.Data.ExtendedCapacitySizeTiB));
            Assert.That(elasticSan2.Data.AvailabilityZones, Is.EqualTo(elasticSan1.Data.AvailabilityZones));
            Assert.That(elasticSan2.Data.Tags, Is.EqualTo(elasticSan1.Data.Tags));
            Assert.That(elasticSan1.Data.PrivateEndpointConnections.Count, Is.EqualTo(3));
            Assert.That(elasticSan1.Data.PrivateEndpointConnections[0].Name, Is.Not.Empty);
            Assert.That((string)elasticSan1.Data.PrivateEndpointConnections[0].PrivateEndpointId, Is.Not.Empty);
            Assert.That(elasticSan1.Data.PrivateEndpointConnections[0].ConnectionState.Status.ToString(), Is.EqualTo("Approved"));
            Assert.That(elasticSan1.Data.PrivateEndpointConnections[1].Name, Is.Not.Empty);
            Assert.That(elasticSan1.Data.PrivateEndpointConnections[1].ConnectionState.Status.ToString(), Is.EqualTo("Approved"));
            Assert.That((string)elasticSan1.Data.PrivateEndpointConnections[1].PrivateEndpointId, Is.Not.Empty);
            Assert.That(elasticSan1.Data.PrivateEndpointConnections[2].Name, Is.Not.Empty);
            Assert.That(elasticSan1.Data.PrivateEndpointConnections[2].ConnectionState.Status.ToString(), Is.EqualTo("Pending"));
            Assert.That((string)elasticSan1.Data.PrivateEndpointConnections[2].PrivateEndpointId, Is.Not.Empty);
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
            Assert.That(elasticSan2.Data.BaseSizeTiB, Is.EqualTo(2));
            Assert.That(elasticSan2.Data.ExtendedCapacitySizeTiB, Is.EqualTo(7));
            Assert.That(elasticSan2.Id.Name, Is.EqualTo(elasticSan1.Id.Name));
            Assert.That(elasticSan2.Data.Name, Is.EqualTo(elasticSan1.Data.Name));
            Assert.That(elasticSan2.Data.Tags.Count, Is.GreaterThanOrEqualTo(1));
            Assert.That(elasticSan2.Data.ScaleUpProperties.CapacityUnitScaleUpLimitTiB, Is.EqualTo(25));
            Assert.That(elasticSan2.Data.ScaleUpProperties.UnusedSizeTiB, Is.EqualTo(2));
            Assert.That(elasticSan2.Data.ScaleUpProperties.IncreaseCapacityUnitByTiB, Is.EqualTo(2));
            Assert.That(AutoScalePolicyEnforcement.Enabled, Is.EqualTo(elasticSan2.Data.ScaleUpProperties.AutoScalePolicyEnforcement.Value));

            await elasticSan1.DeleteAsync(WaitUntil.Completed);
            Assert.That((bool)await _collection.ExistsAsync(elasticSanName), Is.False);
        }
    }
}
