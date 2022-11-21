﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Dns.Tests.Scenario
{
    internal class RecordTest : DnsServiceClientTestBase
    {
        private DnsZoneResource _dnsZone;

        public RecordTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _dnsZone = await CreateDnsZone($"2022{Recording.GenerateAssetName("dnszone")}.com", resourceGroup);
        }

        [RecordedTest]
        public async Task AaaaRecordOperationTest()
        {
            var collection = _dnsZone.GetDnsAaaaRecords();
            string aaaaRecordName = Recording.GenerateAssetName("aaaa");
            string ipv6AddressValue1 = "3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d55";
            string ipv6AddressValue2 = "3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d66";

            // CreateOrUpdate
            var data = new DnsAaaaRecordData()
            {
                TtlInSeconds = 3600,
                DnsAaaaRecords =
                {
                    new DnsAaaaRecordInfo()
                    {
                        IPv6Address =  IPAddress.Parse(ipv6AddressValue1)
                    },
                    new DnsAaaaRecordInfo()
                    {
                        IPv6Address = IPAddress.Parse(ipv6AddressValue2)
                    },
                }
            };
            var aaaaRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, aaaaRecordName, data);
            ValidateRecordBaseInfo(aaaaRecord.Value.Data, aaaaRecordName);
            Assert.AreEqual("dnszones/AAAA", aaaaRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, aaaaRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(ipv6AddressValue1, aaaaRecord.Value.Data.DnsAaaaRecords[0].IPv6Address.ToString());
            Assert.AreEqual(ipv6AddressValue2, aaaaRecord.Value.Data.DnsAaaaRecords[1].IPv6Address.ToString());

            // Exist
            bool flag = await collection.ExistsAsync(aaaaRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await aaaaRecord.Value.UpdateAsync(new DnsAaaaRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(aaaaRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, aaaaRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(ipv6AddressValue1, getResponse.Value.Data.DnsAaaaRecords[0].IPv6Address.ToString());
            Assert.AreEqual(ipv6AddressValue2, getResponse.Value.Data.DnsAaaaRecords[1].IPv6Address.ToString());

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
            var collection = _dnsZone.GetDnsARecords();
            string aRecordName = Recording.GenerateAssetName("a");
            string ipv4AddressValue1 = "10.10.0.1";
            string ipv4AddressValue2 = "10.10.0.2";

            // CreateOrUpdate
            var data = new DnsARecordData()
            {
                TtlInSeconds = 3600,
                DnsARecords =
                {
                    new DnsARecordInfo()
                    {
                        IPv4Address = IPAddress.Parse(ipv4AddressValue1)
                    },
                    new DnsARecordInfo()
                    {
                        IPv4Address = IPAddress.Parse(ipv4AddressValue2)
                    },
                }
            };
            var aRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, aRecordName, data);
            ValidateRecordBaseInfo(aRecord.Value.Data, aRecordName);
            Assert.AreEqual("dnszones/A", aRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, aRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(ipv4AddressValue1, aRecord.Value.Data.DnsARecords[0].IPv4Address.ToString());
            Assert.AreEqual(ipv4AddressValue2, aRecord.Value.Data.DnsARecords[1].IPv4Address.ToString());

            // Exist
            bool flag = await collection.ExistsAsync(aRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await aRecord.Value.UpdateAsync(new DnsARecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(aRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, aRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(ipv4AddressValue1, getResponse.Value.Data.DnsARecords[0].IPv4Address.ToString());
            Assert.AreEqual(ipv4AddressValue2, getResponse.Value.Data.DnsARecords[1].IPv4Address.ToString());

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
        public async Task CaaRecordOperationTest()
        {
            var collection = _dnsZone.GetDnsCaaRecords();
            string name = "caa";
            var caaRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new DnsCaaRecordData()
            {
                TtlInSeconds = 3600,
                DnsCaaRecords =
                {
                    new DnsCaaRecordInfo()
                    {
                        Flags = 1,
                        Tag = "test1",
                        Value = "caa1.contoso.com"
                    },
                    new DnsCaaRecordInfo()
                    {
                        Flags = 2,
                        Tag = "test2",
                        Value = "caa2.contoso.com"
                    }
                }
            });
            Assert.IsNotNull(caaRecord);
            Assert.IsNotNull(caaRecord.Value.Data.ETag);
            Assert.AreEqual(name, caaRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", caaRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/CAA", caaRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, caaRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual("caa1.contoso.com", caaRecord.Value.Data.DnsCaaRecords[0].Value);
            Assert.AreEqual("caa2.contoso.com", caaRecord.Value.Data.DnsCaaRecords[1].Value);

            // exist
            bool flag = await collection.ExistsAsync("caa");
            Assert.IsTrue(flag);

            // update
            var updateResponse = await caaRecord.Value.UpdateAsync(new DnsCaaRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // get
            var getResponse = await collection.GetAsync(name);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual("caa1.contoso.com", getResponse.Value.Data.DnsCaaRecords[0].Value);
            Assert.AreEqual("caa2.contoso.com", getResponse.Value.Data.DnsCaaRecords[1].Value);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await caaRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync("caa");
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task CnameRecordOperationTest()
        {
            var collection = _dnsZone.GetDnsCnameRecords();
            string cnameRecordName = Recording.GenerateAssetName("cname");
            string aliasValue = "mycontoso.com";

            // CreateOrUpdate
            var data = new DnsCnameRecordData()
            {
                TtlInSeconds = 3600,
                Cname = aliasValue
            };
            var cnameRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, cnameRecordName, data);
            ValidateRecordBaseInfo(cnameRecord.Value.Data, cnameRecordName);
            Assert.AreEqual("dnszones/CNAME", cnameRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, cnameRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(aliasValue, cnameRecord.Value.Data.Cname);

            // Exist
            bool flag = await collection.ExistsAsync(cnameRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await cnameRecord.Value.UpdateAsync(new DnsCnameRecordData() { TtlInSeconds = 7200 });
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
            var collection = _dnsZone.GetDnsMXRecords();
            string mxRecordName = Recording.GenerateAssetName("mx");
            string mailExchangeValue1 = "mymail1.contoso.com";
            string mailExchangeValue2 = "mymail2.contoso.com";

            // CreateOrUpdate
            var data = new DnsMXRecordData()
            {
                TtlInSeconds = 3600,
                DnsMXRecords =
                {
                    new DnsMXRecordInfo()
                    {
                        Preference = 10,
                        Exchange = mailExchangeValue1
                    },
                    new DnsMXRecordInfo()
                    {
                        Preference = 11,
                        Exchange = mailExchangeValue2
                    },
                }
            };
            var mxRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, mxRecordName, data);
            ValidateRecordBaseInfo(mxRecord.Value.Data, mxRecordName);
            Assert.AreEqual("dnszones/MX", mxRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, mxRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(10, mxRecord.Value.Data.DnsMXRecords[0].Preference);
            Assert.AreEqual(11, mxRecord.Value.Data.DnsMXRecords[1].Preference);
            Assert.AreEqual(mailExchangeValue1, mxRecord.Value.Data.DnsMXRecords[0].Exchange);
            Assert.AreEqual(mailExchangeValue2, mxRecord.Value.Data.DnsMXRecords[1].Exchange);

            // Exist
            bool flag = await collection.ExistsAsync(mxRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await mxRecord.Value.UpdateAsync(new DnsMXRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(mxRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, mxRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(10, getResponse.Value.Data.DnsMXRecords[0].Preference);
            Assert.AreEqual(11, getResponse.Value.Data.DnsMXRecords[1].Preference);
            Assert.AreEqual(mailExchangeValue1, getResponse.Value.Data.DnsMXRecords[0].Exchange);
            Assert.AreEqual(mailExchangeValue2, getResponse.Value.Data.DnsMXRecords[1].Exchange);

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
        public async Task NSRecordOperationTest()
        {
            string _recordSetName = "ns";
            string dnsNSDomainValue1 = "ns1.contoso.com";
            string dnsNSDomainValue2 = "ns2.contoso.com";
            var collection = _dnsZone.GetDnsNSRecords();
            var NSRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, _recordSetName, new DnsNSRecordData()
            {
                TtlInSeconds = 3600,
                DnsNSRecords =
                {
                    new DnsNSRecordInfo(){ DnsNSDomainName  = dnsNSDomainValue1},
                    new DnsNSRecordInfo(){ DnsNSDomainName  = dnsNSDomainValue2},
                }
            });
            Assert.IsNotNull(NSRecord);
            Assert.IsNotNull(NSRecord.Value.Data.ETag);
            Assert.AreEqual(_recordSetName, NSRecord.Value.Data.Name);
            Assert.AreEqual("Succeeded", NSRecord.Value.Data.ProvisioningState);
            Assert.AreEqual("dnszones/NS", NSRecord.Value.Data.ResourceType.Type);
            Assert.AreEqual(3600, NSRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(dnsNSDomainValue1, NSRecord.Value.Data.DnsNSRecords[0].DnsNSDomainName);
            Assert.AreEqual(dnsNSDomainValue2, NSRecord.Value.Data.DnsNSRecords[1].DnsNSDomainName);

            // exist
            bool flag = await collection.ExistsAsync(_recordSetName);
            Assert.IsTrue(flag);

            // update
            var updateResponse = await NSRecord.Value.UpdateAsync(new DnsNSRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // get
            var getResponse = await collection.GetAsync(_recordSetName);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(dnsNSDomainValue1, getResponse.Value.Data.DnsNSRecords[0].DnsNSDomainName);
            Assert.AreEqual(dnsNSDomainValue2, getResponse.Value.Data.DnsNSRecords[1].DnsNSDomainName);

            // getall
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // delete
            await NSRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(_recordSetName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task PtrRecordOperationTest()
        {
            var collection = _dnsZone.GetDnsPtrRecords();
            string ptrRecordName = Recording.GenerateAssetName("ptr");
            string domainNameValue1 = "contoso1.com";
            string domainNameValue2 = "contoso2.com";

            // CreateOrUpdate
            var data = new DnsPtrRecordData()
            {
                TtlInSeconds = 3600,
                DnsPtrRecords =
                {
                    new DnsPtrRecordInfo()
                    {
                        DnsPtrDomainName = domainNameValue1
                    },
                    new DnsPtrRecordInfo()
                    {
                        DnsPtrDomainName = domainNameValue2
                    },
                }
            };
            var ptrRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ptrRecordName, data);
            ValidateRecordBaseInfo(ptrRecord.Value.Data, ptrRecordName);
            Assert.AreEqual("dnszones/PTR", ptrRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, ptrRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(domainNameValue1, ptrRecord.Value.Data.DnsPtrRecords[0].DnsPtrDomainName);
            Assert.AreEqual(domainNameValue2, ptrRecord.Value.Data.DnsPtrRecords[1].DnsPtrDomainName);

            // Exist
            bool flag = await collection.ExistsAsync(ptrRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await ptrRecord.Value.UpdateAsync(new DnsPtrRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(ptrRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, ptrRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(domainNameValue1, getResponse.Value.Data.DnsPtrRecords[0].DnsPtrDomainName);
            Assert.AreEqual(domainNameValue2, getResponse.Value.Data.DnsPtrRecords[1].DnsPtrDomainName);

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
            var collection = _dnsZone.GetDnsSoaRecords();
            string soaRecordName = "@";

            // CreateOrUpdate
            var data = new DnsSoaRecordData()
            {
                TtlInSeconds = 3600,
                DnsSoaRecord = new DnsSoaRecordInfo
                {
                    Email = "azuredns-hostmaster.microsoft.com",
                    ExpireTimeInSeconds = 2419200,
                    MinimumTtlInSeconds = 300,
                    RefreshTimeInSeconds = 3600,
                    RetryTimeInSeconds = 300,
                    SerialNumber = 1,
                    Host = "ns1-03.azure-dns.com."
                }
            };
            var soaRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, soaRecordName, data);
            ValidateRecordBaseInfo(soaRecord.Value.Data, soaRecordName);
            Assert.IsNotNull(soaRecord.Value.Data.DnsSoaRecord.Email);
            Assert.AreEqual("dnszones/SOA", soaRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, soaRecord.Value.Data.TtlInSeconds);
            Assert.IsTrue(soaRecord.Value.Data.DnsSoaRecord.RefreshTimeInSeconds > 0);
            Assert.IsTrue(soaRecord.Value.Data.DnsSoaRecord.RetryTimeInSeconds > 0);
            Assert.IsTrue(soaRecord.Value.Data.DnsSoaRecord.ExpireTimeInSeconds > 0);
            Assert.IsTrue(soaRecord.Value.Data.DnsSoaRecord.MinimumTtlInSeconds > 0);

            // Exist
            bool flag = await collection.ExistsAsync(soaRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await soaRecord.Value.UpdateAsync(new DnsSoaRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(soaRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, soaRecordName);
            Assert.IsNotNull(getResponse.Value.Data.DnsSoaRecord.Email);
            Assert.AreEqual("dnszones/SOA", getResponse.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.IsTrue(getResponse.Value.Data.DnsSoaRecord.RefreshTimeInSeconds > 0);
            Assert.IsTrue(getResponse.Value.Data.DnsSoaRecord.RetryTimeInSeconds > 0);
            Assert.IsTrue(getResponse.Value.Data.DnsSoaRecord.ExpireTimeInSeconds > 0);
            Assert.IsTrue(getResponse.Value.Data.DnsSoaRecord.MinimumTtlInSeconds > 0);

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == soaRecordName).Data, soaRecordName);

            // Delete - Type SOA cannot delete
            // Description: https://github.com/Azure/azure-rest-api-specs/blob/main/specification/dns/resource-manager/Microsoft.Network/stable/2020-06-01/dns.json#L1015
        }

        [RecordedTest]
        public async Task SrvRecordOperationTest()
        {
            var collection = _dnsZone.GetDnsSrvRecords();
            string srvRecordName = Recording.GenerateAssetName("srv");
            string targetValue1 = "target1.contoso.com";
            string targetValue2 = "target2.contoso.com";

            // CreateOrUpdate
            var data = new DnsSrvRecordData()
            {
                TtlInSeconds = 3600,
                DnsSrvRecords =
                {
                    new DnsSrvRecordInfo()
                    {
                        Priority = 1,
                        Weight = 1,
                        Port = 1,
                        Target = targetValue1,
                    },
                    new DnsSrvRecordInfo()
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
            Assert.AreEqual("dnszones/SRV", srvRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, srvRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(targetValue1, srvRecord.Value.Data.DnsSrvRecords[0].Target);
            Assert.AreEqual(targetValue2, srvRecord.Value.Data.DnsSrvRecords[1].Target);

            // Exist
            bool flag = await collection.ExistsAsync(srvRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await srvRecord.Value.UpdateAsync(new DnsSrvRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(srvRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, srvRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(targetValue1, getResponse.Value.Data.DnsSrvRecords[0].Target);
            Assert.AreEqual(targetValue2, getResponse.Value.Data.DnsSrvRecords[1].Target);

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
            var collection = _dnsZone.GetDnsTxtRecords();
            string txtRecordName = Recording.GenerateAssetName("txt");

            // CreateOrUpdate
            var data = new DnsTxtRecordData()
            {
                TtlInSeconds = 3600,
                DnsTxtRecords =
                {
                    new DnsTxtRecordInfo()
                    {
                        Values  ={"value1", "value2" }
                    },
                    new DnsTxtRecordInfo()
                    {
                        Values  ={"value3", "value4", "value5" }
                    },
                }
            };
            var txtRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, txtRecordName, data);
            ValidateRecordBaseInfo(txtRecord.Value.Data, txtRecordName);
            Assert.AreEqual("dnszones/TXT", txtRecord.Value.Data.ResourceType.Type.ToString());
            Assert.AreEqual(3600, txtRecord.Value.Data.TtlInSeconds);
            Assert.AreEqual(2, txtRecord.Value.Data.DnsTxtRecords.Count);

            // Exist
            bool flag = await collection.ExistsAsync(txtRecordName);
            Assert.IsTrue(flag);

            // Update
            var updateResponse = await txtRecord.Value.UpdateAsync(new DnsTxtRecordData() { TtlInSeconds = 7200 });
            Assert.AreEqual(7200, updateResponse.Value.Data.TtlInSeconds);

            // Get
            var getResponse = await collection.GetAsync(txtRecordName);
            ValidateRecordBaseInfo(getResponse.Value.Data, txtRecordName);
            Assert.AreEqual(7200, getResponse.Value.Data.TtlInSeconds);
            Assert.AreEqual(2, getResponse.Value.Data.DnsTxtRecords.Count);

            // GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRecordBaseInfo(list.First(item => item.Data.Name == txtRecordName).Data, txtRecordName);

            // Delete
            await txtRecord.Value.DeleteAsync(WaitUntil.Completed);
            flag = await collection.ExistsAsync(txtRecordName);
            Assert.IsFalse(flag);
        }

        private void ValidateRecordBaseInfo(DnsBaseRecordData recordData, string recordName)
        {
            Assert.IsNotNull(recordData);
            Assert.IsNotNull(recordData.ETag);
            Assert.AreEqual(recordName, recordData.Name);
        }
    }
}
