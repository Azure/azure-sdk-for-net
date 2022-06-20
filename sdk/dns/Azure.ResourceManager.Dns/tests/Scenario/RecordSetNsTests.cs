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
    internal class RecordSetNsTests : DnsServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private DnsZoneResource _dnsZone;
        private string _recordSetName;
        public RecordSetNsTests(bool isAsync) : base(isAsync)
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

            _recordSetName = "ns";
            await StopSessionRecordingAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var collection = _dnsZone.GetRecordSetNs();
            if (collection.Exists(_recordSetName))
            {
                var recordSetNsResource = await collection.GetAsync(_recordSetName);
                await recordSetNsResource.Value.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task Create()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            var collection = _dnsZone.GetRecordSetNs();
            var recordSetNsResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, _recordSetName, new NsRecordSetData() { });
            Assert.IsNotNull(recordSetNsResource);
            Assert.AreEqual(_recordSetName, recordSetNsResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetNsResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/NS", recordSetNsResource.Value.Data.ResourceType.Type);
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task Delete()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            var collection = _dnsZone.GetRecordSetNs();
            var recordSetNsResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, _recordSetName, new NsRecordSetData() { });
            Assert.IsTrue(collection.Exists(_recordSetName));

            await recordSetNsResource.Value.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(collection.Exists(_recordSetName));
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task Exist()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            var collection = _dnsZone.GetRecordSetNs();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, _recordSetName, new NsRecordSetData() { });
            Assert.IsTrue(collection.Exists(_recordSetName));
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task Get()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            var collection = _dnsZone.GetRecordSetNs();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, _recordSetName, new NsRecordSetData() { });

            var recordSetNsResource = await collection.GetAsync(_recordSetName);
            Assert.IsNotNull(recordSetNsResource);
            Assert.AreEqual(_recordSetName, recordSetNsResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetNsResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/NS", recordSetNsResource.Value.Data.ResourceType.Type);
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task GetAll()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            _dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            var collection = _dnsZone.GetRecordSetNs();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, _recordSetName, new NsRecordSetData() { });

            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("@", list.FirstOrDefault().Data.Name);
            Assert.AreEqual(_recordSetName, list[1].Data.Name);
        }
    }
}
