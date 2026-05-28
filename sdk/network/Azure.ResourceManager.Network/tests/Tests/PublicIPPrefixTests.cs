// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Azure.Test;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class PublicIpPrefixTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;

        public PublicIpPrefixTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            _subscription = await ArmClient.GetDefaultSubscriptionAsync();
        }

        public async Task<PublicIPPrefixCollection> GetCollection()
        {
            var resourceGroup = await CreateResourceGroup(Recording.GenerateAssetName("test_public_ip_prefix_"));
            return resourceGroup.GetPublicIPPrefixes();
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task PublicIpPrefixApiTest(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            var container = await GetCollection();
            var name = Recording.GenerateAssetName("test_public_ip_prefix_");

            // create
            PublicIPPrefixResource prefix = await (await container.CreateOrUpdateAsync(WaitUntil.Completed, name, new PublicIPPrefixData()
            {
                Location = TestEnvironment.Location,
                PrefixLength = 28,
                Sku = new PublicIPPrefixSku()
                {
                    Name = PublicIPPrefixSkuName.Standard,
                }
            })).WaitForCompletionAsync();

            Assert.True(await container.ExistsAsync(name));

            var prefixData = prefix.Data;
            ValidateCommon(prefixData, name);
            Assert.IsEmpty(prefixData.Tags);

            prefixData.Tags.Add("tag1", "value1");
            prefixData.Tags.Add("tag2", "value2");

            // update
            prefix = await (await container.CreateOrUpdateAsync(WaitUntil.Completed, name, prefixData)).WaitForCompletionAsync();
            prefixData = prefix.Data;

            ValidateCommon(prefixData, name);
            Assert.That(prefixData.Tags, Has.Count.EqualTo(2));
            Assert.That(prefixData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(prefixData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // get
            prefix = await container.GetAsync(name);
            prefixData = prefix.Data;

            ValidateCommon(prefixData, name);
            Assert.That(prefixData.Tags, Has.Count.EqualTo(2));
            Assert.That(prefixData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(prefixData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // update tags
            var tags = new Dictionary<string, string>();
            tags.Add("tag2", "value2");
            prefixData = (await prefix.SetTagsAsync(tags)).Value.Data;

            ValidateCommon(prefixData, name);
            Assert.That(prefixData.Tags, Has.Count.EqualTo(1));
            Assert.That(prefixData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // list
            var prefixes = await container.GetAllAsync().ToEnumerableAsync();
            Assert.That(prefixes, Has.Count.EqualTo(1));
            prefix = prefixes[0];
            prefixData = prefix.Data;

            ValidateCommon(prefixData, name);
            Assert.That(prefixData.Tags, Has.Count.EqualTo(1));
            Assert.That(prefixData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // delete
            await prefix.DeleteAsync(WaitUntil.Completed);

            Assert.False(await container.ExistsAsync(name));

            prefixes = await container.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(prefixes);
        }

        private void ValidateCommon(PublicIPPrefixData data, string name)
        {
            Assert.AreEqual(name, data.Name);
            Assert.AreEqual(28, data.PrefixLength);
            Assert.AreEqual(PublicIPPrefixSkuName.Standard, data.Sku.Name);
            Assert.AreEqual(NetworkIPVersion.IPv4, data.PublicIPAddressVersion);
        }
    }
}
