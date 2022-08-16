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
    internal class RecordSetsBasicE2ETest : DnsServiceClientTestBase
    {
        private DnsZoneResource _dnsZone;
        private ResourceIdentifier _dnsZoneIdentifier;

        public RecordSetsBasicE2ETest(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Dns-RG-"), new ResourceGroupData(AzureLocation.WestUS2));

            // TODO: Castle.DynamicProxy.Generators.GeneratorException
            //var dnsLro = await CreateADnsZone($"2022{SessionRecording.GenerateAssetName("dnszone")}.com", rgLro.Value);
            //_dnsZoneIdentifier = dnsLro.Data.Id;
            _dnsZoneIdentifier = null;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _dnsZone = await Client.GetDnsZoneResource(_dnsZoneIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task AaaaRecordE2E()
        {
            var collection = _dnsZone.GetAaaaRecords();
            string name = "aaaa";
            var aaaaRecordResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new AaaaRecordData() { });
            Assert.IsNotNull(aaaaRecordResource);
            Assert.IsNotNull(aaaaRecordResource.Value.Data.ETag);
            Assert.AreEqual(name, aaaaRecordResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", aaaaRecordResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/AAAA", aaaaRecordResource.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync("aaaa");
            Assert.IsTrue(flag);

            // get
            var getResponse = await collection.GetAsync("aaaa");
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(name, getResponse.Value.Data.Name);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }

            // delete
            await aaaaRecordResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("aaaa");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task ARecordE2E()
        {
            var collection = _dnsZone.GetARecords();
            string name = "a";
            var aRecordResourcea = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new ARecordData() { });
            Assert.IsNotNull(aRecordResourcea);
            Assert.IsNotNull(aRecordResourcea.Value.Data.ETag);
            Assert.AreEqual(name, aRecordResourcea.Value.Data.Name);
            Assert.AreEqual("Succeeded", aRecordResourcea.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/A", aRecordResourcea.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync("a");
            Assert.IsTrue(flag);

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(name, getResponse.Value.Data.Name);
            Assert.AreEqual("Succeeded", getResponse.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/A", getResponse.Value.Data.ResourceType.Type);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }

            // delete
            await aRecordResourcea.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("a");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task CaaRecordE2E()
        {
            var collection = _dnsZone.GetCaaRecords();
            string name = "caa";
            var caaRecordResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CaaRecordData() { });
            Assert.IsNotNull(caaRecordResource);
            Assert.IsNotNull(caaRecordResource.Value.Data.ETag);
            Assert.AreEqual(name, caaRecordResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", caaRecordResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/CAA", caaRecordResource.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync("caa");
            Assert.IsTrue(flag);

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }

            // delete
            await caaRecordResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("caa");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task CnameRecordE2E()
        {
            var collection = _dnsZone.GetCnameRecords();
            string name = "cname";
            var cnameRecordResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CnameRecordData() { });
            Assert.IsNotNull(cnameRecordResource);
            Assert.IsNotNull(cnameRecordResource.Value.Data.ETag);
            Assert.AreEqual(name, cnameRecordResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", cnameRecordResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/CNAME", cnameRecordResource.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync("cname");
            Assert.IsTrue(flag);

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }

            // delete
            await cnameRecordResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("cname");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task MXRecordE2E()
        {
            var collection = _dnsZone.GetMXRecords();
            string name = "mx";
            var MXRecordResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new MXRecordData() { });
            Assert.IsNotNull(MXRecordResource);
            Assert.IsNotNull(MXRecordResource.Value.Data.ETag);
            Assert.AreEqual(name, MXRecordResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", MXRecordResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/MX", MXRecordResource.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync("mx");
            Assert.IsTrue(flag);

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }

            // delete
            await MXRecordResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("mx");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task NSRecordE2E()
        {
            string _recordSetName = "ns";
            var collection = _dnsZone.GetNSRecords();
            var NSRecordResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, _recordSetName, new NSRecordData() { });
            Assert.IsNotNull(NSRecordResource);
            Assert.IsNotNull(NSRecordResource.Value.Data.ETag);
            Assert.AreEqual(_recordSetName, NSRecordResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", NSRecordResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/NS", NSRecordResource.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync(_recordSetName);
            Assert.IsTrue(flag);

            // get
            var getResponse = await collection.GetAsync(_recordSetName);
            Assert.IsNotNull(getResponse);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }

            // delete
            await NSRecordResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(_recordSetName);
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task PtrRecordE2E()
        {
            var collection = _dnsZone.GetPtrRecords();
            string name = "ptr";
            var PtrRecordResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new PtrRecordData() { });
            Assert.IsNotNull(PtrRecordResource);
            Assert.IsNotNull(PtrRecordResource.Value.Data.ETag);
            Assert.AreEqual(name, PtrRecordResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", PtrRecordResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/PTR", PtrRecordResource.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync("ptr");
            Assert.IsTrue(flag);

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }

            // delete
            await PtrRecordResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("ptr");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task SoaRecordE2E()
        {
            var collection = _dnsZone.GetSoaRecords();
            // exist
            bool result = await collection.ExistsAsync("@");
            Assert.IsTrue(result);

            // get
            var getResponse = await collection.GetAsync("@");
            Assert.IsNotNull(getResponse);
            Assert.AreEqual("@", getResponse.Value.Data.Name);
            Assert.AreEqual("Succeeded", getResponse.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/SOA", getResponse.Value.Data.ResourceType.Type);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task SrvRecordE2E()
        {
            var collection = _dnsZone.GetSrvRecords();
            string name = "srv";
            var SrvRecordResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new SrvRecordData() { });
            Assert.IsNotNull(SrvRecordResource);
            Assert.IsNotNull(SrvRecordResource.Value.Data.ETag);
            Assert.AreEqual(name, SrvRecordResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", SrvRecordResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/SRV", SrvRecordResource.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync("srv");
            Assert.IsTrue(flag);

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }

            // delete
            await SrvRecordResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("srv");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task TxtRecordE2E()
        {
            var collection = _dnsZone.GetTxtRecords();
            string name = "txt";
            var TxtRecordResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new TxtRecordData() { });
            Assert.IsNotNull(TxtRecordResource);
            Assert.IsNotNull(TxtRecordResource.Value.Data.ETag);
            Assert.AreEqual(name, TxtRecordResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", TxtRecordResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/TXT", TxtRecordResource.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync("txt");
            Assert.IsTrue(flag);

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.IsNotNull(getResponse.Value.Data.TtlInSeconds);
            Console.WriteLine(getResponse.Value.Data.TtlInSeconds);

            // getall
            await foreach (var item in collection.GetAllAsync())
            {
                Console.WriteLine(item.Data.Name);
            }

            // delete
            await TxtRecordResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("txt");
            Assert.IsFalse(flag);
        }
    }
}
