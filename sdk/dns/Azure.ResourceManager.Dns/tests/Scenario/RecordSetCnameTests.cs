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
using Azure.ResourceManager.Dns.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Dns.Tests.Scenario
{
    internal class RecordSetCnameTests : DnsCutomizeTestBase //: DnsServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private DnsZoneResource _dnsZone;

        [OneTimeSetUp]
        public async Task OnetimeSetup()
        {
            #region TODO: When we solve the [Castle.DynamicProxy.Generators.GeneratorException], should uncomment this region and delete other code of OnetimeSetup
            //string rgName = SessionRecording.GenerateAssetName("Dns-RG-");
            //var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            //_resourceGroup = rgLro.Value;

            //// Create Dns Zone
            //string dnsZoneName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.a.com";
            //_dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);

            //await StopSessionRecordingAsync();
            #endregion
            string rgName = GenerateAssetName("Dns-RG-");
            _resourceGroup = await CreateAResourceGroup(rgName);
            _dnsZone = await CreateADnsZone(_resourceGroup);
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _dnsZone.GetRecordSetCnames().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task Create()
        {
            var collection = _dnsZone.GetRecordSetCnames();
            string name = "cname";
            var recordSetCnameResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CnameRecordSetData() { });
            Assert.IsNotNull(recordSetCnameResource);
            Assert.AreEqual(name, recordSetCnameResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetCnameResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/CNAME", recordSetCnameResource.Value.Data.ResourceType.Type);
        }

        [Test]
        public async Task Delete()
        {
            var collection = _dnsZone.GetRecordSetCnames();
            string name = "cname";
            var recordSetCnameResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CnameRecordSetData() { });
            Assert.IsTrue(collection.Exists(name));

            await recordSetCnameResource.Value.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(collection.Exists(name));
        }

        [Test]
        public async Task Exist()
        {
            var collection = _dnsZone.GetRecordSetCnames();
            string name = "cname";
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CnameRecordSetData() { });
            Assert.IsTrue(collection.Exists(name));
        }

        [Test]
        public async Task Get()
        {
            var collection = _dnsZone.GetRecordSetCnames();
            string name = "cname";
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CnameRecordSetData() { });

            var recordSetCnameResource = await collection.GetAsync(name);
            Assert.IsNotNull(recordSetCnameResource);
            Assert.AreEqual(name, recordSetCnameResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetCnameResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/CNAME", recordSetCnameResource.Value.Data.ResourceType.Type);
        }

        [Test]
        public async Task GetAll()
        {
            var collection = _dnsZone.GetRecordSetCnames();
            string name = "cname";
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CnameRecordSetData() { });

            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual(name, list.FirstOrDefault().Data.Name);
        }
    }
}
