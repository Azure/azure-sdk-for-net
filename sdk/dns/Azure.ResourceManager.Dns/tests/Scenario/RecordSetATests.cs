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
    internal class RecordSetATests : DnsServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private DnsZoneResource _dnsZone;
        //public RecordSetATests(bool isAsync) : base(isAsync)
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
            string dnsZoneName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.a.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _dnsZone.GetRecordSetAs().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task Create()
        {
            var collection = _dnsZone.GetRecordSetAs();
            string name = "a";
            var recordSetAResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new ARecordSetData() { });
            Assert.IsNotNull(recordSetAResource);
            Assert.AreEqual(name, recordSetAResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetAResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/A", recordSetAResource.Value.Data.ResourceType.Type);
        }

        [Test]
        public async Task Delete()
        {
            var collection = _dnsZone.GetRecordSetAs();
            string name = "a";
            var recordSetAResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new ARecordSetData() { });
            Assert.IsTrue(collection.Exists(name));

            await recordSetAResource.Value.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(collection.Exists(name));
        }

        [Test]
        public async Task Exist()
        {
            var collection = _dnsZone.GetRecordSetAs();
            string name = "a";
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new ARecordSetData() { });
            Assert.IsTrue(collection.Exists(name));
        }

        [Test]
        public async Task Get()
        {
            var collection = _dnsZone.GetRecordSetAs();
            string name = "a";
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new ARecordSetData() { });

            var recordSetAResource = await collection.GetAsync(name);
            Assert.IsNotNull(recordSetAResource);
            Assert.AreEqual(name, recordSetAResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetAResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/A", recordSetAResource.Value.Data.ResourceType.Type);
        }

        [Test]
        public async Task GetAll()
        {
            var collection = _dnsZone.GetRecordSetAs();
            string name = "a";
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new ARecordSetData() { });

            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual(name, list.FirstOrDefault().Data.Name);
        }
    }
}
