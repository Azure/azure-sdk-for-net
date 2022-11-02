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

        public RecordSetsBasicE2ETest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _dnsZone = await CreateADnsZone($"2022{Recording.GenerateAssetName("dnszone")}.com", resourceGroup);
        }

        [Test]
        [RecordedTest]
        public async Task AaaaRecordE2E()
        {
            var collection = _dnsZone.GetAaaaRecords();
            string name = "aaaa";
            var aaaaRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new AaaaRecordData() { TtlInSeconds = 3600 });
            Assert.IsNotNull(aaaaRecord);
            Assert.IsNotNull(aaaaRecord.Value.Data.ETag);
            Assert.AreEqual(name, aaaaRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", aaaaRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/AAAA", aaaaRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, aaaaRecord.Value.Data.TtlInSeconds);

            // exist
            bool flag = await collection.ExistsAsync("aaaa");
            Assert.IsTrue(flag);

            // update
            await aaaaRecord.Value.UpdateAsync(new AaaaRecordData() { TtlInSeconds = 7200 });

            // get
            var getResponse = await collection.GetAsync("aaaa");
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(name, getResponse.Value.Data.Name);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await aaaaRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("aaaa");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        public async Task ARecordE2E()
        {
            var collection = _dnsZone.GetARecords();
            string name = "a";
            var aRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new ARecordData() { TtlInSeconds = 3600 });
            Assert.IsNotNull(aRecord);
            Assert.IsNotNull(aRecord.Value.Data.ETag);
            Assert.AreEqual(name, aRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", aRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/A", aRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, aRecord.Value.Data.TtlInSeconds);

            // exist
            bool flag = await collection.ExistsAsync("a");
            Assert.IsTrue(flag);

            // update
            await aRecord.Value.UpdateAsync(new ARecordData() { TtlInSeconds = 7200 });

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(name, getResponse.Value.Data.Name);
            Assert.AreEqual("Succeeded", getResponse.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/A", getResponse.Value.Data.ResourceType.Type);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await aRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("a");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        public async Task CaaRecordE2E()
        {
            var collection = _dnsZone.GetCaaRecords();
            string name = "caa";
            var caaRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CaaRecordData() { TtlInSeconds = 3600 });
            Assert.IsNotNull(caaRecord);
            Assert.IsNotNull(caaRecord.Value.Data.ETag);
            Assert.AreEqual(name, caaRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", caaRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/CAA", caaRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, caaRecord.Value.Data.TtlInSeconds);

            // exist
            bool flag = await collection.ExistsAsync("caa");
            Assert.IsTrue(flag);

            // update
            await caaRecord.Value.UpdateAsync(new CaaRecordData() { TtlInSeconds = 7200 });

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await caaRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("caa");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        public async Task CnameRecordE2E()
        {
            var collection = _dnsZone.GetCnameRecords();
            string name = "cname";
            var cnameRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new CnameRecordData() { TtlInSeconds = 3600 });
            Assert.IsNotNull(cnameRecord);
            Assert.IsNotNull(cnameRecord.Value.Data.ETag);
            Assert.AreEqual(name, cnameRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", cnameRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/CNAME", cnameRecord.Value.Data.ResourceType.Type);

            // exist
            bool flag = await collection.ExistsAsync("cname");
            Assert.IsTrue(flag);

            // update
            await cnameRecord.Value.UpdateAsync(new CnameRecordData() { TtlInSeconds = 7200 });

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await cnameRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("cname");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        public async Task MXRecordE2E()
        {
            var collection = _dnsZone.GetMXRecords();
            string name = "mx";
            var MXRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new MXRecordData() { TtlInSeconds = 3600 });
            Assert.IsNotNull(MXRecord);
            Assert.IsNotNull(MXRecord.Value.Data.ETag);
            Assert.AreEqual(name, MXRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", MXRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/MX", MXRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, MXRecord.Value.Data.TtlInSeconds);

            // exist
            bool flag = await collection.ExistsAsync("mx");
            Assert.IsTrue(flag);

            // update
            await MXRecord.Value.UpdateAsync(new MXRecordData() { TtlInSeconds = 7200 });

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await MXRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("mx");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        public async Task NSRecordE2E()
        {
            string _recordSetName = "ns";
            var collection = _dnsZone.GetNSRecords();
            var NSRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, _recordSetName, new NSRecordData() { TtlInSeconds = 3600 });
            Assert.IsNotNull(NSRecord);
            Assert.IsNotNull(NSRecord.Value.Data.ETag);
            Assert.AreEqual(_recordSetName, NSRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", NSRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/NS", NSRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, NSRecord.Value.Data.TtlInSeconds);

            // exist
            bool flag = await collection.ExistsAsync(_recordSetName);
            Assert.IsTrue(flag);

            // update
            await NSRecord.Value.UpdateAsync(new NSRecordData() { TtlInSeconds = 7200 });

            // get
            var getResponse = await collection.GetAsync(_recordSetName);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await NSRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(_recordSetName);
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        public async Task PtrRecordE2E()
        {
            var collection = _dnsZone.GetPtrRecords();
            string name = "ptr";
            var ptrRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new PtrRecordData() { TtlInSeconds = 3600 });
            Assert.IsNotNull(ptrRecord);
            Assert.IsNotNull(ptrRecord.Value.Data.ETag);
            Assert.AreEqual(name, ptrRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", ptrRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/PTR", ptrRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, ptrRecord.Value.Data.TtlInSeconds);

            // exist
            bool flag = await collection.ExistsAsync("ptr");
            Assert.IsTrue(flag);

            // update
            await ptrRecord.Value.UpdateAsync(new PtrRecordData() { TtlInSeconds = 7200 });

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await ptrRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("ptr");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
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
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task SrvRecordE2E()
        {
            var collection = _dnsZone.GetSrvRecords();
            string name = "srv";
            var srvRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new SrvRecordData() { TtlInSeconds = 3600 });
            Assert.IsNotNull(srvRecord);
            Assert.IsNotNull(srvRecord.Value.Data.ETag);
            Assert.AreEqual(name, srvRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", srvRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/SRV", srvRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, srvRecord.Value.Data.TtlInSeconds);

            // exist
            bool flag = await collection.ExistsAsync("srv");
            Assert.IsTrue(flag);

            // update
            await srvRecord.Value.UpdateAsync(new SrvRecordData() { TtlInSeconds = 7200 });

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await srvRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("srv");
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        public async Task TxtRecordE2E()
        {
            var collection = _dnsZone.GetTxtRecords();
            string name = "txt";
            var txtRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new TxtRecordData() { TtlInSeconds = 3600 });
            Assert.IsNotNull(txtRecord);
            Assert.IsNotNull(txtRecord.Value.Data.ETag);
            Assert.AreEqual(name, txtRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", txtRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/TXT", txtRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, txtRecord.Value.Data.TtlInSeconds);

            // exist
            bool flag = await collection.ExistsAsync("txt");
            Assert.IsTrue(flag);

            // update
            await txtRecord.Value.UpdateAsync(new TxtRecordData() { TtlInSeconds = 7200 });

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await txtRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("txt");
            Assert.IsFalse(flag);
        }
    }
}
