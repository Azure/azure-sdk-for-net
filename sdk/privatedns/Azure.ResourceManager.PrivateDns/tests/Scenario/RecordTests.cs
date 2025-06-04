// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PrivateDns.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PrivateDns.Tests
{
    internal class RecordTests : PrivateDnsManagementTestBase
    {
        private PrivateDnsZoneResource _privateDns;

        public RecordTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _privateDns = await CreatePrivateZone(resourceGroup, $"{Recording.GenerateAssetName("sample")}.com");
        }

        [TearDown]
        public async Task TearDown()
        {
            await _privateDns.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task AaaaRecordOperationTest()
        {
            var collection = _privateDns.GetPrivateDnsAaaaRecords();
            string aaaaRecordName = Recording.GenerateAssetName("aaaa");
            string ipv6AddressValue1 = "3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d55";
            string ipv6AddressValue2 = "3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d66";

            // CreateOrUpdate
            var data = new PrivateDnsAaaaRecordData()
            {
                TtlInSeconds = 3600,
                PrivateDnsAaaaRecords =
                {
                    new PrivateDnsAaaaRecordInfo()
                    {
                        IPv6Address = IPAddress.Parse(ipv6AddressValue1)
                    },
                    new PrivateDnsAaaaRecordInfo()
                    {
                        IPv6Address = IPAddress.Parse(ipv6AddressValue2)
                    },
                }
            };
            var aaaaRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, aaaaRecordName, data);
            ValidateRecordBaseInfo(aaaaRecord.Value.Data, aaaaRecordName);
            Assert.AreEqual("privateDnsZones/AAAA", aaaaRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, aaaaRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(ipv6AddressValue1, aaaaRecord.Value.Data.PrivateDnsAaaaRecords[0].IPv6Address.ToString());
            Assert.AreEqual(ipv6AddressValue2, aaaaRecord.Value.Data.PrivateDnsAaaaRecords[1].IPv6Address.ToString());

            // Exist
            bool flag = await collection.ExistsAsync(aaaaRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await aaaaRecord.Value.UpdateAsync(new PrivateDnsAaaaRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(aaaaRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, aaaaRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(ipv6AddressValue1, getResponse.Value.Data.PrivateDnsAaaaRecords[0].IPv6Address.ToString());
            Assert.AreEqual(ipv6AddressValue2, getResponse.Value.Data.PrivateDnsAaaaRecords[1].IPv6Address.ToString());

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == aaaaRecordName).Data, aaaaRecordName);

            // Delete
            await aaaaRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(aaaaRecordName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task ARecordOperationTest()
        {
            var collection = _privateDns.GetPrivateDnsARecords();
            string aRecordName = Recording.GenerateAssetName("a");
            string ipv4AddressValue1 = "10.10.0.1";
            string ipv4AddressValue2 = "10.10.0.2";

            // CreateOrUpdate
            var data = new PrivateDnsARecordData()
            {
                TtlInSeconds = 3600,
                PrivateDnsARecords =
                {
                    new PrivateDnsARecordInfo()
                    {
                        IPv4Address =  IPAddress.Parse(ipv4AddressValue1)
                    },
                    new PrivateDnsARecordInfo()
                    {
                        IPv4Address =  IPAddress.Parse(ipv4AddressValue2)
                    },
                }
            };
            var aRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, aRecordName, data);
            ValidateRecordBaseInfo(aRecord.Value.Data, aRecordName);
            Assert.AreEqual("privateDnsZones/A", aRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, aRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(ipv4AddressValue1, aRecord.Value.Data.PrivateDnsARecords[0].IPv4Address.ToString());
            Assert.AreEqual(ipv4AddressValue2, aRecord.Value.Data.PrivateDnsARecords[1].IPv4Address.ToString());

            // Exist
            bool flag = await collection.ExistsAsync(aRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await aRecord.Value.UpdateAsync(new PrivateDnsARecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(aRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, aRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(ipv4AddressValue1, getResponse.Value.Data.PrivateDnsARecords[0].IPv4Address.ToString());
            Assert.AreEqual(ipv4AddressValue2, getResponse.Value.Data.PrivateDnsARecords[1].IPv4Address.ToString());

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == aRecordName).Data, aRecordName);

            // Delete
            await aRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(aRecordName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task CnameRecordOperationTest()
        {
            var collection = _privateDns.GetPrivateDnsCnameRecords();
            string cnameRecordName = Recording.GenerateAssetName("cname");
            string aliasValue = "mycontoso.com";

            // CreateOrUpdate
            var data = new PrivateDnsCnameRecordData()
            {
                TtlInSeconds = 3600,
                Cname = aliasValue
            };
            var cnameRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, cnameRecordName, data);
            ValidateRecordBaseInfo(cnameRecord.Value.Data, cnameRecordName);
            Assert.AreEqual("privateDnsZones/CNAME", cnameRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, cnameRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(aliasValue, cnameRecord.Value.Data.Cname);

            // Exist
            bool flag = await collection.ExistsAsync(cnameRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await cnameRecord.Value.UpdateAsync(new PrivateDnsCnameRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(cnameRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, cnameRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(aliasValue, getResponse.Value.Data.Cname);

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == cnameRecordName).Data, cnameRecordName);

            // Delete
            await cnameRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(cnameRecordName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task MXRecordOperationTest()
        {
            var collection = _privateDns.GetPrivateDnsMXRecords();
            string mxRecordName = Recording.GenerateAssetName("mx");
            string mailExchangeValue1 = "mymail1.contoso.com";
            string mailExchangeValue2 = "mymail2.contoso.com";

            // CreateOrUpdate
            var data = new PrivateDnsMXRecordData()
            {
                TtlInSeconds = 3600,
                PrivateDnsMXRecords =
                {
                    new PrivateDnsMXRecordInfo()
                    {
                        Preference = 10,
                        Exchange = mailExchangeValue1
                    },
                    new PrivateDnsMXRecordInfo()
                    {
                        Preference = 11,
                        Exchange = mailExchangeValue2
                    },
                }
            };
            var mxRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, mxRecordName, data);
            ValidateRecordBaseInfo(mxRecord.Value.Data, mxRecordName);
            Assert.AreEqual("privateDnsZones/MX", mxRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, mxRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(10, mxRecord.Value.Data.PrivateDnsMXRecords[0].Preference);
            Assert.AreEqual(11, mxRecord.Value.Data.PrivateDnsMXRecords[1].Preference);
            Assert.AreEqual(mailExchangeValue1, mxRecord.Value.Data.PrivateDnsMXRecords[0].Exchange);
            Assert.AreEqual(mailExchangeValue2, mxRecord.Value.Data.PrivateDnsMXRecords[1].Exchange);

            // Exist
            bool flag = await collection.ExistsAsync(mxRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await mxRecord.Value.UpdateAsync(new PrivateDnsMXRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(mxRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, mxRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(10, getResponse.Value.Data.PrivateDnsMXRecords[0].Preference);
            Assert.AreEqual(11, getResponse.Value.Data.PrivateDnsMXRecords[1].Preference);
            Assert.AreEqual(mailExchangeValue1, getResponse.Value.Data.PrivateDnsMXRecords[0].Exchange);
            Assert.AreEqual(mailExchangeValue2, getResponse.Value.Data.PrivateDnsMXRecords[1].Exchange);

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == mxRecordName).Data, mxRecordName);

            // Delete
            await mxRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(mxRecordName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task PtrRecordOperationTest()
        {
            var collection = _privateDns.GetPrivateDnsPtrRecords();
            string ptrRecordName = Recording.GenerateAssetName("ptr");
            string domainNameValue1 = "contoso1.com";
            string domainNameValue2 = "contoso2.com";

            // CreateOrUpdate
            var data = new PrivateDnsPtrRecordData()
            {
                TtlInSeconds = 3600,
                PrivateDnsPtrRecords =
                {
                    new PrivateDnsPtrRecordInfo()
                    {
                        PtrDomainName = domainNameValue1
                    },
                    new PrivateDnsPtrRecordInfo()
                    {
                        PtrDomainName = domainNameValue2
                    },
                }
            };
            var ptrRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ptrRecordName, data);
            ValidateRecordBaseInfo(ptrRecord.Value.Data, ptrRecordName);
            Assert.AreEqual("privateDnsZones/PTR", ptrRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, ptrRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(domainNameValue1, ptrRecord.Value.Data.PrivateDnsPtrRecords[0].PtrDomainName);
            Assert.AreEqual(domainNameValue2, ptrRecord.Value.Data.PrivateDnsPtrRecords[1].PtrDomainName);

            // Exist
            bool flag = await collection.ExistsAsync(ptrRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await ptrRecord.Value.UpdateAsync(new PrivateDnsPtrRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(ptrRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, ptrRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(domainNameValue1, getResponse.Value.Data.PrivateDnsPtrRecords[0].PtrDomainName);
            Assert.AreEqual(domainNameValue2, getResponse.Value.Data.PrivateDnsPtrRecords[1].PtrDomainName);

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == ptrRecordName).Data, ptrRecordName);

            // Delete
            await ptrRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(ptrRecordName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task SoaRecordOperationTest()
        {
            var collection = _privateDns.GetPrivateDnsSoaRecords();
            string soaRecordName = "@";

            // CreateOrUpdate
            var data = new PrivateDnsSoaRecordData()
            {
                TtlInSeconds = 3600
            };
            var soaRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, soaRecordName, data);
            ValidateRecordBaseInfo(soaRecord.Value.Data, soaRecordName);
            Assert.IsNotNull(soaRecord.Value.Data.PrivateDnsSoaRecord.Email);
            Assert.AreEqual("privateDnsZones/SOA", soaRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, soaRecord.Value.Data.TtlInSeconds);
            Assert.IsTrue(soaRecord.Value.Data.PrivateDnsSoaRecord.RefreshTimeInSeconds > 0);
            Assert.IsTrue(soaRecord.Value.Data.PrivateDnsSoaRecord.RetryTimeInSeconds > 0);
            Assert.IsTrue(soaRecord.Value.Data.PrivateDnsSoaRecord.ExpireTimeInSeconds > 0);
            Assert.IsTrue(soaRecord.Value.Data.PrivateDnsSoaRecord.MinimumTtlInSeconds > 0);

            // Exist
            bool flag = await collection.ExistsAsync(soaRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await soaRecord.Value.UpdateAsync(new PrivateDnsSoaRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(soaRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, soaRecordName);
            Assert.IsNotNull(getResponse.Value.Data.PrivateDnsSoaRecord.Email);
            Assert.AreEqual("privateDnsZones/SOA", getResponse.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.IsTrue(getResponse.Value.Data.PrivateDnsSoaRecord.RefreshTimeInSeconds > 0);
            Assert.IsTrue(getResponse.Value.Data.PrivateDnsSoaRecord.RetryTimeInSeconds > 0);
            Assert.IsTrue(getResponse.Value.Data.PrivateDnsSoaRecord.ExpireTimeInSeconds > 0);
            Assert.IsTrue(getResponse.Value.Data.PrivateDnsSoaRecord.MinimumTtlInSeconds > 0);

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == soaRecordName).Data, soaRecordName);
        }

        [RecordedTest]
        public async Task SrvRecordOperationTest()
        {
            var collection = _privateDns.GetPrivateDnsSrvRecords();
            string srvRecordName = Recording.GenerateAssetName("srv");
            string targetValue1 = "target1.contoso.com";
            string targetValue2 = "target2.contoso.com";

            // CreateOrUpdate
            var data = new PrivateDnsSrvRecordData()
            {
                TtlInSeconds = 3600,
                PrivateDnsSrvRecords =
                {
                    new PrivateDnsSrvRecordInfo()
                    {
                        Priority = 1,
                        Weight = 1,
                        Port = 1,
                        Target = targetValue1,
                    },
                    new PrivateDnsSrvRecordInfo()
                    {
                        Priority = 1,
                        Weight = 1,
                        Port = 1,
                        Target = targetValue2,
                    }
                }
            };
            var srvRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, srvRecordName, data);
            ValidateRecordBaseInfo(srvRecord.Value.Data, srvRecordName);
            Assert.AreEqual("privateDnsZones/SRV", srvRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, srvRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(targetValue1, srvRecord.Value.Data.PrivateDnsSrvRecords[0].Target);
            Assert.AreEqual(targetValue2, srvRecord.Value.Data.PrivateDnsSrvRecords[1].Target);

            // Exist
            bool flag = await collection.ExistsAsync(srvRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await srvRecord.Value.UpdateAsync(new PrivateDnsSrvRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(srvRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, srvRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(targetValue1, getResponse.Value.Data.PrivateDnsSrvRecords[0].Target);
            Assert.AreEqual(targetValue2, getResponse.Value.Data.PrivateDnsSrvRecords[1].Target);

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == srvRecordName).Data, srvRecordName);

            // Delete
            await srvRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(srvRecordName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task TxtRecordOperationTest()
        {
            var collection = _privateDns.GetPrivateDnsTxtRecords();
            string txtRecordName = Recording.GenerateAssetName("txt");

            // CreateOrUpdate
            var data = new PrivateDnsTxtRecordData()
            {
                TtlInSeconds = 3600,
                PrivateDnsTxtRecords =
                {
                    new PrivateDnsTxtRecordInfo()
                    {
                        Values  ={"value1", "value2" }
                    },
                    new PrivateDnsTxtRecordInfo()
                    {
                        Values  ={"value3", "value4", "value5" }
                    },
                }
            };
            var txtRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, txtRecordName, data);
            ValidateRecordBaseInfo(txtRecord.Value.Data, txtRecordName);
            Assert.AreEqual("privateDnsZones/TXT", txtRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, txtRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(2, txtRecord.Value.Data.PrivateDnsTxtRecords.Count);

            // Exist
            bool flag = await collection.ExistsAsync(txtRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await txtRecord.Value.UpdateAsync(new PrivateDnsTxtRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(txtRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, txtRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(2, getResponse.Value.Data.PrivateDnsTxtRecords.Count);

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == txtRecordName).Data, txtRecordName);

            // Delete
            await txtRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(txtRecordName);
            Assert.IsFalse(flag);
        }

        private void ValidateRecordBaseInfo(PrivateDnsBaseRecordData recordData, string recordDataName)
        {
            Assert.IsNotNull(recordData);
            Assert.IsNotNull(recordData.ETag);
            Assert.AreEqual(recordDataName, recordData.Name);
        }
    }
}
