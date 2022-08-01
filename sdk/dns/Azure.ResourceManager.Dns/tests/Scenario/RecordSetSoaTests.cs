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
        public RecordSetSoaTests(bool isAsync) : base(isAsync)
        {
        }
        [OneTimeSetUp]
        public async Task OnetimeSetup()
        {
            string rgName = SessionRecording.GenerateAssetName("Dns-RG-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroup = rgLro.Value;

            // TODO: TestFramework cannot get DnsCollection.Temporary disable global _dnsZone.
            // Create Dns Zone
            //string dnsZoneName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.a.com";
            //_dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);

            await StopSessionRecordingAsync();
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task Exist()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            bool result = await _dnsZone.GetRecordSetSoas().ExistsAsync("@");
            Assert.IsTrue(result);
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task Get()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            var recordSetSoaResource = await _dnsZone.GetRecordSetSoas().GetAsync("@");
            Assert.IsNotNull(recordSetSoaResource);
            Assert.AreEqual("@", recordSetSoaResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetSoaResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/SOA", recordSetSoaResource.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, recordSetSoaResource.Value.Data.TtlInSeconds);
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task GetAll()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            var list = await _dnsZone.GetRecordSetSoas().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual("@", list.FirstOrDefault().Data.Name);
        }
    }
}
