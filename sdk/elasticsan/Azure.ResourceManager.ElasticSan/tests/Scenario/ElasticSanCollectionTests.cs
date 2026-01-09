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
            Assert.Multiple(() =>
            {
                Assert.That(elasticSan1.Id.Name, Is.EqualTo(elasticSanName));
                Assert.That(elasticSan1.Data.BaseSizeTiB, Is.EqualTo(1));
                Assert.That(elasticSan1.Data.ExtendedCapacitySizeTiB, Is.EqualTo(6));
                Assert.That(elasticSan1.Data.Tags.ContainsKey("tag1"), Is.True);
                Assert.That(elasticSan1.Data.Tags["tag1"], Is.EqualTo("value1"));
                Assert.That(elasticSan1.Data.PublicNetworkAccess.Value.ToString(), Is.EqualTo("Enabled"));
                Assert.That(Models.AutoScalePolicyEnforcement.Disabled, Is.EqualTo(elasticSan1.Data.ScaleUpProperties.AutoScalePolicyEnforcement));
                Assert.That(elasticSan1.Data.ScaleUpProperties.IncreaseCapacityUnitByTiB, Is.EqualTo(1));
                Assert.That(elasticSan1.Data.ScaleUpProperties.CapacityUnitScaleUpLimitTiB, Is.EqualTo(24));
                Assert.That(elasticSan1.Data.ScaleUpProperties.UnusedSizeTiB, Is.EqualTo(5));
            });
            // Skip the validation for AvailabilityZone as the server won't return the property

            elasticSan1 = (await elasticSanCollection.CreateOrUpdateAsync(WaitUntil.Completed, elasticSanName, GetDefaultElasticSanParameters(TestLocation, 2, 7))).Value;
            Assert.That(elasticSan1.Id.Name, Is.EqualTo(elasticSanName));
            Assert.That(elasticSan1.Data.BaseSizeTiB, Is.EqualTo(2));
            Assert.That(elasticSan1.Data.ExtendedCapacitySizeTiB, Is.EqualTo(7));
            Assert.That(elasticSan1.Data.Tags, Is.Empty);
            Assert.That(elasticSan1.Data.AvailabilityZones, Is.Empty);
            Assert.That(elasticSan1.Data.PublicNetworkAccess, Is.EqualTo(null));
            Assert.That(elasticSan1.Data.ScaleUpProperties, Is.Null);

            await elasticSan1.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanResource elasticSan1 = (await elasticSanCollection.GetAsync(ElasticSanName)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(elasticSan1.Id.Name, Is.EqualTo(ElasticSanName));
                Assert.That(elasticSan1.Data.BaseSizeTiB, Is.EqualTo(1));
                Assert.That(elasticSan1.Data.ExtendedCapacitySizeTiB, Is.EqualTo(6));

                // Test for ElasticSan PE properties
                Assert.That(elasticSan1.Data.PrivateEndpointConnections.Count, Is.EqualTo(3));
            });
            Assert.Multiple(() =>
            {
                Assert.That(elasticSan1.Data.PrivateEndpointConnections[0].Name, Is.Not.Empty);
                Assert.That((string)elasticSan1.Data.PrivateEndpointConnections[0].PrivateEndpointId, Is.Not.Empty);
                Assert.That(elasticSan1.Data.PrivateEndpointConnections[0].ConnectionState.Status.ToString(), Is.EqualTo("Approved"));
                Assert.That(elasticSan1.Data.PrivateEndpointConnections[1].Name, Is.Not.Empty);
                Assert.That(elasticSan1.Data.PrivateEndpointConnections[1].ConnectionState.Status.ToString(), Is.EqualTo("Approved"));
                Assert.That((string)elasticSan1.Data.PrivateEndpointConnections[1].PrivateEndpointId, Is.Not.Empty);
                Assert.That(elasticSan1.Data.PrivateEndpointConnections[2].Name, Is.Not.Empty);
                Assert.That(elasticSan1.Data.PrivateEndpointConnections[2].ConnectionState.Status.ToString(), Is.EqualTo("Pending"));
                Assert.That((string)elasticSan1.Data.PrivateEndpointConnections[2].PrivateEndpointId, Is.Not.Empty);
            });
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
            Assert.That(count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        [RecordedTest]
        public async Task Exists()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();

            Assert.Multiple(async () =>
            {
                Assert.That((bool)await elasticSanCollection.ExistsAsync(ElasticSanName), Is.True);
                Assert.That((bool)await elasticSanCollection.ExistsAsync(ElasticSanName + "111"), Is.False);
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await elasticSanCollection.ExistsAsync(null));
        }
    }
}
