// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Dns.Tests.Scenario
{
    internal class RecordSetMxTests : DnsServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private DnsZoneResource _dnsZone;
        //public RecordSetMxTests(bool isAsync) : base(isAsync)
        //{
        //}

        [OneTimeSetUp]
        public async Task OnetimeSetup()
        {
            // Create Resource Group
            Random random = new Random();
            string rgName = $"dns-rg-{random.Next(9999)}";
            _resourceGroup = await CreateAResourceGroup(rgName);
            Assert.IsNotNull(_resourceGroup);
            Assert.AreEqual(rgName, _resourceGroup.Data.Name);

            // Create Dns Zone
            string dnsZoneName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.Mx.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _dnsZone.GetRecordSetMxes().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task Create()
        {
            var collection = _dnsZone.GetRecordSetMxes();
            string name = "mx";
            var recordSetMxResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new MxRecordSetData() { });
            Assert.IsNotNull(recordSetMxResource);
            Assert.AreEqual(name, recordSetMxResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetMxResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/MX", recordSetMxResource.Value.Data.ResourceType.Type);
        }

        [Test]
        public async Task Delete()
        {
            var collection = _dnsZone.GetRecordSetMxes();
            string name = "mx";
            var recordSetMxResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new MxRecordSetData() { });
            Assert.IsTrue(collection.Exists(name));

            await recordSetMxResource.Value.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(collection.Exists(name));
        }

        [Test]
        public async Task Exist()
        {
            var collection = _dnsZone.GetRecordSetMxes();
            string name = "mx";
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new MxRecordSetData() { });
            Assert.IsTrue(collection.Exists(name));
        }

        [Test]
        public async Task Get()
        {
            var collection = _dnsZone.GetRecordSetMxes();
            string name = "mx";
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new MxRecordSetData() { });

            var recordSetMxResource = await collection.GetAsync(name);
            Assert.IsNotNull(recordSetMxResource);
            Assert.AreEqual(name, recordSetMxResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetMxResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/MX", recordSetMxResource.Value.Data.ResourceType.Type);
        }

        [Test]
        public async Task GetAll()
        {
            var collection = _dnsZone.GetRecordSetMxes();
            string name = "mx";
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new MxRecordSetData() { });

            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual(name, list.FirstOrDefault().Data.Name);
        }
    }
}
