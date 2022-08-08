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
            var recordSetAaaaResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new AaaaRecordData() { });
            Assert.IsNotNull(recordSetAaaaResource);
            Assert.IsNotNull(recordSetAaaaResource.Value.Data.ETag);
            Assert.AreEqual(name, recordSetAaaaResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetAaaaResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/AAAA", recordSetAaaaResource.Value.Data.ResourceType.Type);

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
            await recordSetAaaaResource.Value.DeleteAsync(WaitUntil.Completed);
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
            var recordSetAResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new ARecordData() { });
            Assert.IsNotNull(recordSetAResource);
            Assert.IsNotNull(recordSetAResource.Value.Data.ETag);
            Assert.AreEqual(name, recordSetAResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetAResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/A", recordSetAResource.Value.Data.ResourceType.Type);

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
            await recordSetAResource.Value.DeleteAsync(WaitUntil.Completed);
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
            var recordSetCaaResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CaaRecordData() { });
            Assert.IsNotNull(recordSetCaaResource);
            Assert.IsNotNull(recordSetCaaResource.Value.Data.ETag);
            Assert.AreEqual(name, recordSetCaaResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetCaaResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/CAA", recordSetCaaResource.Value.Data.ResourceType.Type);

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
            await recordSetCaaResource.Value.DeleteAsync(WaitUntil.Completed);
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
            var recordSetCnameResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CnameRecordData() { });
            Assert.IsNotNull(recordSetCnameResource);
            Assert.IsNotNull(recordSetCnameResource.Value.Data.ETag);
            Assert.AreEqual(name, recordSetCnameResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetCnameResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/CNAME", recordSetCnameResource.Value.Data.ResourceType.Type);

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
            await recordSetCnameResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("cname");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task MxRecordE2E()
        {
            var collection = _dnsZone.GetMXRecords();
            string name = "mx";
            var recordSetMXResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new MXRecordData() { });
            Assert.IsNotNull(recordSetMXResource);
            Assert.IsNotNull(recordSetMXResource.Value.Data.ETag);
            Assert.AreEqual(name, recordSetMXResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetMXResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/MX", recordSetMXResource.Value.Data.ResourceType.Type);

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
            await recordSetMXResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("mx");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task NsRecordE2E()
        {
            string _recordSetName = "ns";
            var collection = _dnsZone.GetNSRecords();
            var recordSetNSResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, _recordSetName, new NSRecordData() { });
            Assert.IsNotNull(recordSetNSResource);
            Assert.IsNotNull(recordSetNSResource.Value.Data.ETag);
            Assert.AreEqual(_recordSetName, recordSetNSResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetNSResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/NS", recordSetNSResource.Value.Data.ResourceType.Type);

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
            await recordSetNSResource.Value.DeleteAsync(WaitUntil.Completed);
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
            var recordSetPtrResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new PtrRecordData() { });
            Assert.IsNotNull(recordSetPtrResource);
            Assert.IsNotNull(recordSetPtrResource.Value.Data.ETag);
            Assert.AreEqual(name, recordSetPtrResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetPtrResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/PTR", recordSetPtrResource.Value.Data.ResourceType.Type);

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
            await recordSetPtrResource.Value.DeleteAsync(WaitUntil.Completed);
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
            var recordSetSrvResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new SrvRecordData() { });
            Assert.IsNotNull(recordSetSrvResource);
            Assert.IsNotNull(recordSetSrvResource.Value.Data.ETag);
            Assert.AreEqual(name, recordSetSrvResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetSrvResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/SRV", recordSetSrvResource.Value.Data.ResourceType.Type);

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
            await recordSetSrvResource.Value.DeleteAsync(WaitUntil.Completed);
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
            var recordSetTxtResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new TxtRecordData() { });
            Assert.IsNotNull(recordSetTxtResource);
            Assert.IsNotNull(recordSetTxtResource.Value.Data.ETag);
            Assert.AreEqual(name, recordSetTxtResource.Value.Data.Name);
            Assert.AreEqual("Succeeded", recordSetTxtResource.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/TXT", recordSetTxtResource.Value.Data.ResourceType.Type);

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
            await recordSetTxtResource.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("txt");
            Assert.IsFalse(flag);
        }
    }
}
