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
using System.Linq;

namespace Azure.Management.Dns.Tests
{
    public class RecordSetTest : DnsManagementClientBase
    {
        private string location;
        private Zone zone;

        public RecordSetTest(bool isAsync)
            : base(isAsync)
        {
            location = "West US";
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
            //A - Get
            RecordSetData recordSetData = new RecordSetData() { TTL = 600 };
            recordSetData.ARecords.Add(new ARecord("127.0.0.1"));
            _ = await zone.GetRecordSetAs().CreateOrUpdateAsync("@", recordSetData);
            //A - Get 2
            RecordSetData recordSetData2 = new RecordSetData() { TTL = 600 };
            recordSetData2.ARecords.Add(new ARecord("127.0.0.1"));
            _ = await zone.GetRecordSetAs().CreateOrUpdateAsync("www2", recordSetData2);
            //AAAA - Delete
            RecordSetData recordAaaaSetData = new RecordSetData() { TTL = 600 };
            recordAaaaSetData.AaaaRecords.Add(new AaaaRecord("::1"));
            _ = await zone.GetRecordSetAaaas().CreateOrUpdateAsync("deleteAAAA", recordAaaaSetData);
            //CAA - Delete
            RecordSetData recordCaaSetData = new RecordSetData() { TTL = 600 };
            recordCaaSetData.CaaRecords.Add(new CaaRecord(0, "issue", "dummydnsrecord.microsoft.com"));
            _ = await zone.GetRecordSetCaas().CreateOrUpdateAsync("deleteCAA", recordCaaSetData);
            //CNAME - Update
            RecordSetData recordCNameSetData = new RecordSetData() { TTL = 600 };
            recordCNameSetData.CnameRecord = new CnameRecord("studiostokens.azurewebsites.net");
            _ = await zone.GetRecordSetCnames().CreateOrUpdateAsync("CName", recordCNameSetData);
            //MX - Get
            RecordSetData recordMXSetData = new RecordSetData() { TTL = 600 };
            recordMXSetData.MxRecords.Add(new MxRecord(0, "studiostokens.azurewebsites.net"));
            _ = await zone.GetRecordSetMxes().CreateOrUpdateAsync("MX", recordMXSetData);
            //NS - Delete
            RecordSetData recordNsSetData = new RecordSetData() { TTL = 600 };
            recordNsSetData.NsRecords.Add(new NsRecord("ns1-04.azure-dns.com"));
            _ = await zone.GetRecordSetNs().CreateOrUpdateAsync("deleteNS", recordNsSetData);
            //PTR - Get
            RecordSetData recordPtrSetData = new RecordSetData() { TTL = 600 };
            recordPtrSetData.PtrRecords.Add(new PtrRecord("invaliddummyrecord.test.outlook.com"));
            _ = await zone.GetRecordSetPtrs().CreateOrUpdateAsync("PTR", recordPtrSetData);
            //SRV - Update
            RecordSetData recordSrvSetData = new RecordSetData() { TTL = 600 };
            recordSrvSetData.SrvRecords.Add(new SrvRecord(100, 1, 443, "sipdir.online.lync.com."));
            _ = await zone.GetRecordSetSrvs().CreateOrUpdateAsync("@", recordSrvSetData);
            //TXT - Update
            RecordSetData recordTxtSetData = new RecordSetData() { TTL = 600 };
            recordTxtSetData.TxtRecords.Add(new TxtRecord(new List<string>() { "testtxtrecord1" }));
            _ = await zone.GetRecordSetTxts().CreateOrUpdateAsync("text", recordTxtSetData);
        }

        [TestCase]
        public async Task Get()
        {
            //A
            RecordSetA aResult = await zone.GetRecordSetAs().GetAsync("@");
            RecordSetA aGet = await aResult.GetAsync();
            Assert.AreEqual(aGet.Data.ARecords.Count, 1);
            Assert.AreEqual("127.0.0.1", aGet.Data.ARecords[0].Ipv4Address);
            //MX
            RecordSetMx mxResult = await zone.GetRecordSetMxes().GetAsync("MX");
            RecordSetMx mxGet = await mxResult.GetAsync();
            Assert.AreEqual("studiostokens.azurewebsites.net", mxGet.Data.MxRecords[0].Exchange);
            //PTR
            RecordSetPtr ptrResult = await zone.GetRecordSetPtrs().GetAsync("PTR");
            RecordSetPtr ptrGet = await ptrResult.GetAsync();
            Assert.AreEqual("invaliddummyrecord.test.outlook.com", ptrGet.Data.PtrRecords[0].Ptrdname);
            //SOA
            RecordSetSoa soaResult = await zone.GetRecordSetSoas().GetAsync("@");
            RecordSetSoa soaGet = await soaResult.GetAsync();
            Assert.AreEqual("azuredns-hostmaster.microsoft.com", soaGet.Data.SoaRecord.Email);
        }

        [TestCase]
        public async Task Update()
        {
            //CNAME
            RecordSetCname recordSetCName = await zone.GetRecordSetCnames().GetAsync("CName");
            recordSetCName = await recordSetCName.UpdateAsync(new RecordSetData {CnameRecord = new CnameRecord("microsoft.com")});
            Assert.AreEqual("microsoft.com", recordSetCName.Data.CnameRecord.Cname);
            //SRV
            RecordSetSrv recordSetSrv = await zone.GetRecordSetSrvs().GetAsync("@");
            RecordSetData recordSrvSetData = new RecordSetData() { TTL = 600 };
            recordSrvSetData.SrvRecords.Add(new SrvRecord(100, 1, 443, "new.sipdir.online.lync.com."));
            recordSetSrv = await recordSetSrv.UpdateAsync(recordSrvSetData);
            Assert.AreEqual("new.sipdir.online.lync.com.", recordSetSrv.Data.SrvRecords[0].Target);
            //TXT
            RecordSetTxt recordSetTxt = await zone.GetRecordSetTxts().GetAsync("text");
            RecordSetData recordTxtSetData = new RecordSetData() { TTL = 600 };
            recordTxtSetData.TxtRecords.Add(new TxtRecord(new List<string>() { "updatedtext","helloworld" }));
            recordSetTxt = await recordSetTxt.UpdateAsync(recordTxtSetData);
            Assert.AreEqual("updatedtext", recordSetTxt.Data.TxtRecords[0].Value[0]);
        }

        [TestCase]
        public async Task Delete()
        {
            //AAAA
            RecordSetAaaa recordSetAaaa = await zone.GetRecordSetAaaas().GetAsync("deleteAAAA");
            var aaaaResult = await (await recordSetAaaa.DeleteAsync()).WaitForCompletionResponseAsync();
            Assert.AreEqual(200, aaaaResult.Status);
            //NS
            RecordSetNs recordSetNs = await zone.GetRecordSetNs().GetAsync("deleteNS");
            var nsResult = await (await recordSetNs.DeleteAsync()).WaitForCompletionResponseAsync();
            Assert.AreEqual(200,nsResult.Status);
            //CAA
            RecordSetCaa recordSetCaa = await zone.GetRecordSetCaas().GetAsync("deleteCAA");
            var caaResult = await (await recordSetCaa.DeleteAsync()).WaitForCompletionResponseAsync();
            Assert.AreEqual(200, caaResult.Status);
        }

        //[TestCase]
        public async Task GetAvailableLocations()
        {
            RecordSetA aResult = await zone.GetRecordSetAs().GetAsync("@");
            var list = (await aResult.GetAvailableLocationsAsync()).ToList();
            Assert.GreaterOrEqual(1, list.Count);
        }
        [OneTimeTearDown]
        public void CleanupResourceGroup()
        {
            CleanupResourceGroups();
        }
    }
}
