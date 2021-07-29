// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Azure.Test;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class PublicIpPrefixTests
        : NetworkServiceClientTestBase
    {
        public PublicIpPrefixTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        public async Task<PublicIPPrefixContainer> GetContainer()
        {
            var resourceGroup = await CreateResourceGroup(Recording.GenerateAssetName("test_public_ip_prefix_"));
            return resourceGroup.Value.GetPublicIPPrefixes();
        }

        [Test]
        [RecordedTest]
        public async Task PublicIpPrefixApiTest()
        {
            var container = await GetContainer();
            var name = Recording.GenerateAssetName("test_public_ip_prefix_");

            // create
            var prefixResponse = await container.CreateOrUpdateAsync(name, new PublicIPPrefixData()
            {
                Location = TestEnvironment.Location,
                PrefixLength = 28,
                Sku = new PublicIPPrefixSku()
                {
                    Name = PublicIPPrefixSkuName.Standard,
                }
            });

            Assert.True(await container.CheckIfExistsAsync(name));

            var prefixData = prefixResponse.Value.Data;
            ValidateCommon(prefixData, name);
            Assert.IsEmpty(prefixData.Tags);

            prefixData.Tags.Add("tag1", "value1");
            prefixData.Tags.Add("tag2", "value2");

            // update
            prefixResponse = await container.CreateOrUpdateAsync(name, prefixData);
            prefixData = prefixResponse.Value.Data;

            ValidateCommon(prefixData, name);
            Assert.That(prefixData.Tags, Has.Count.EqualTo(2));
            Assert.That(prefixData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(prefixData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // get
            prefixResponse = await container.GetAsync(name);
            prefixData = prefixResponse.Value.Data;

            ValidateCommon(prefixData, name);
            Assert.That(prefixData.Tags, Has.Count.EqualTo(2));
            Assert.That(prefixData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(prefixData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // update tags
            prefixData.Tags.Remove("tag1");
            prefixData = (await prefixResponse.Value.UpdateTagsAsync(prefixData.Tags)).Value.Data;

            ValidateCommon(prefixData, name);
            Assert.That(prefixData.Tags, Has.Count.EqualTo(1));
            Assert.That(prefixData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // list
            var prefixes = await container.GetAllAsync().ToEnumerableAsync();
            Assert.That(prefixes, Has.Count.EqualTo(1));
            var prefix = prefixes[0];
            prefixData = prefix.Data;

            ValidateCommon(prefixData, name);
            Assert.That(prefixData.Tags, Has.Count.EqualTo(1));
            Assert.That(prefixData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // delete
            await prefix.DeleteAsync();

            Assert.False(await container.CheckIfExistsAsync(name));

            prefixes = await container.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(prefixes);
        }

        private void ValidateCommon(PublicIPPrefixData data, string name)
        {
            Assert.AreEqual(name, data.Name);
            Assert.AreEqual(28, data.PrefixLength);
            Assert.AreEqual(PublicIPPrefixSkuName.Standard, data.Sku.Name);
            Assert.AreEqual(IPVersion.IPv4, data.PublicIPAddressVersion);
        }
    }
}
