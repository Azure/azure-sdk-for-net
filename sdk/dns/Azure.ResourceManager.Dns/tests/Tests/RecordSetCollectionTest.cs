// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Dns.Tests;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Resources;

namespace Azure.Management.Dns.Tests
{
    public class RecordSetCollectionTest : DnsManagementClientBase
    {
        private string location;
        private Zone zone;
        private Dictionary<string, string> metadata;

        public RecordSetCollectionTest(bool isAsync)
            : base(isAsync)
        {
            location = "West US";
            metadata = new Dictionary<string, string>
            {
                {"tag1", "value1"}
            };
        }

        [SetUp]
        public async Task SetupResource()
        {
            var client = GetArmClient();
            var subscription = await client.GetDefaultSubscriptionAsync();
            var resourceGroupCollection = subscription.GetResourceGroups();
            string resourceGroupName = Recording.GenerateAssetName("Test-Dns-");
            await Helper.TryRegisterResourceGroupAsync(resourceGroupCollection, this.location, resourceGroupName);
            //Create Zone
            var resourceGroup = (await resourceGroupCollection.GetAsync(resourceGroupName)).Value;
            var zoneCollection = resourceGroup.GetZones();
            zone = await (await zoneCollection.CreateOrUpdateAsync(TestEnvironment.TestDomain, new ZoneData("global"))).WaitForCompletionAsync();
            RecordSetACollection recordSetACollection = zone.GetRecordSetAs();
            //Add Records
            //AAAA - Get
            RecordSetData recordAaaaSetData = new RecordSetData() { TTL = 600 };
            recordAaaaSetData.AaaaRecords.Add(new AaaaRecord("::1"));
            _ = await zone.GetRecordSetAaaas().CreateOrUpdateAsync("Aaaa", recordAaaaSetData);
            //CAA 1 - GetAll
            RecordSetData recordCaaSetData1 = new RecordSetData() { TTL = 600 };
            recordCaaSetData1.CaaRecords.Add(new CaaRecord(0, "issue", "dummydnsrecord1.microsoft.com"));
            _ = await zone.GetRecordSetCaas().CreateOrUpdateAsync("CAA1", recordCaaSetData1);
            //CAA 2 - GetAll
            RecordSetData recordCaaSetData2 = new RecordSetData() { TTL = 600 };
            recordCaaSetData2.CaaRecords.Add(new CaaRecord(1, "issue", "dummydnsrecord2.microsoft.com"));
            _ = await zone.GetRecordSetCaas().CreateOrUpdateAsync("CAA2", recordCaaSetData2);
            //CNAME - CheckIfExists
            RecordSetData recordCnameSetData = new RecordSetData() { TTL = 600 };
            recordCnameSetData.CnameRecord = new CnameRecord("studiostokens.azurewebsites.net");
            _ = await zone.GetRecordSetCNames().CreateOrUpdateAsync("CNAME", recordCnameSetData);
            //PTR - GetIfExists
            RecordSetData recordPtrSetData = new RecordSetData() { TTL = 600 };
            recordPtrSetData.PtrRecords.Add(new PtrRecord("invaliddummyrecord.test.outlook.com"));
            _ = await zone.GetRecordSetPtrs().CreateOrUpdateAsync("PTR", recordPtrSetData);
        }

        [TestCase]
        public async Task CreateOrUpdate()
        {
            RecordSetData recordSrvSetData = new RecordSetData() { TTL = 600 };
            recordSrvSetData.SrvRecords.Add(new SrvRecord(100, 1, 443, "sipdir.online.lync.com."));
            var srvResult = await zone.GetRecordSetSrvs().CreateOrUpdateAsync("@", recordSrvSetData);
            Assert.AreEqual(201, srvResult.GetRawResponse().Status);
        }
        [TestCase]
        public async Task Get()
        {
            RecordSetAaaa aaaaResult = await zone.GetRecordSetAaaas().GetAsync("Aaaa");
            Assert.AreEqual("::1", aaaaResult.Data.AaaaRecords[0].Ipv6Address);
        }
        [TestCase]
        public async Task GetIfExists()
        {
            var result = await zone.GetRecordSetPtrs().GetIfExistsAsync("PTR");
            Assert.AreEqual("invaliddummyrecord.test.outlook.com",result.Value.Data.PtrRecords[0].Ptrdname);
            var nullResult = await zone.GetRecordSetPtrs().GetIfExistsAsync("PTR" + "dummy");
            Assert.AreEqual(404, nullResult.GetRawResponse().Status);
        }
        [TestCase]
        public async Task CheckIfExists()
        {
            bool result = await zone.GetRecordSetCNames().CheckIfExistsAsync("CNAME");
            Assert.AreEqual(true, result);
            bool nullResult = await zone.GetRecordSetCNames().CheckIfExistsAsync("CNAME" + "dummy");
            Assert.AreEqual(false, nullResult);
        }
        [TestCase]
        public async Task GetAll()
        {
            var list = await zone.GetRecordSetCaas().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("dummydnsrecord2.microsoft.com", list[1].Data.CaaRecords[0].Value);
        }
        [OneTimeTearDown]
        public void CleanupResourceGroup()
        {
            CleanupResourceGroups();
        }
    }
}
