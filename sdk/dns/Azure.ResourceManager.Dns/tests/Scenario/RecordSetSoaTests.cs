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
    internal class RecordSetSoaTests : DnsServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private DnsZoneResource _dnsZone;
        //public RecordSetSoaTests(bool isAsync) : base(isAsync)
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
            string dnsZoneName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.Soa.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
        }

        [Test]
        public async Task Exist()
        {
            bool result = await _dnsZone.GetRecordSetSoas().ExistsAsync("@");
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Get()
        {
            var recordSetSoaResource = await _dnsZone.GetRecordSetSoas().GetAsync("@");
            Assert.IsNotNull(recordSetSoaResource);
            Assert.AreEqual("@", recordSetSoaResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetSoaResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/SOA", recordSetSoaResource.Value.Data.ResourceType.Type);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _dnsZone.GetRecordSetSoas().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual("@", list.FirstOrDefault().Data.Name);
        }
    }
}
