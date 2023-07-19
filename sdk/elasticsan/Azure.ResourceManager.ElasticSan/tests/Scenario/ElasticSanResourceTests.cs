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
using Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.Internal;
using Microsoft.Identity.Client;
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
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string elasticSanName = Recording.GenerateAssetName("testsan-");
            ElasticSanResource elasticSan1 = await CreateElasticSanAsync(elasticSanName);
            await elasticSan1.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await _collection.ExistsAsync(elasticSanName));
        }

        [Test]
        [RecordedTest]
        public async Task Update()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanResource elasticSan1 = (await elasticSanCollection.GetAsync(ElasticSanName)).Value;
            ElasticSanPatch patch = new ElasticSanPatch()
            {
                BaseSizeTiB = 2,
                ExtendedCapacitySizeTiB = 7,
            };
            patch.Tags.Add("tag3", "val3");

            ElasticSanResource elasticSan2 = (await elasticSan1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual(elasticSan1.Data.Name, elasticSan2.Data.Name);
            Assert.AreEqual(2, elasticSan2.Data.BaseSizeTiB);
            Assert.AreEqual(7, elasticSan2.Data.ExtendedCapacitySizeTiB);
            Assert.GreaterOrEqual(elasticSan2.Data.Tags.Count, 1);
            Assert.AreEqual("val3", elasticSan2.Data.Tags["tag3"]);
        }
    }
}
