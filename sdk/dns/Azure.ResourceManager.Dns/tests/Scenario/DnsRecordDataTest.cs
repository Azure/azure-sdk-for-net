// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Dns.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Dns.Tests.Scenario
{
    internal class DnsRecordDataTest : DnsServiceClientTestBase
    {
        private DnsZoneResource _dnsZone;

        public DnsRecordDataTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _dnsZone = await CreateDnsZone($"2022{Recording.GenerateAssetName("dnszone")}.com", resourceGroup);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dnsZone.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task RecordTypeRetrive()
        {
            int count = 0;
            await Create_A();
            await Create_Aaaa();
            await Create_CAA();
            await Create_CNAME();
            await Create_MX();
            await Create_SRV();
            await Create_TXT();
            await Create_PTR();
            await Create_NAPTR();
            var allRecordData = _dnsZone.GetAllRecordDataAsync();
            // NS SOA is created by default
            await foreach (Dns.DnsRecordData item in allRecordData)
            {
                var resourceType = item.ResourceType;
                DnsRecordType recordType = item.RecordType;
                Console.WriteLine(recordType.ToString());
                count++;
            }
            Assert.AreEqual(count, 11);
        }

        private async Task Create_A()
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
        }

        private async Task Create_Aaaa()
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
        }

        private async Task Create_CAA()
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
        }

        private async Task Create_CNAME()
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
        }

        private async Task Create_MX()
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
        }

        private async Task Create_NAPTR()
        {
            var collection = _dnsZone.GetDnsNaptrRecords();
            string naptrRecordName = Recording.GenerateAssetName("naptr");
            int orderValue1 = 1;
            int orderValue2 = 2;
            int preferenceValue1 = 10;
            int preferenceValue2 = 20;
            string flagsValue1 = "s";
            string flagsValue2 = "a";
            string servicesValue1 = "e2u";
            string servicesValue2 = "sip";
            string regexpValue1 = "!^(\\+441632960083)$!sip:\\1@example.com!";
            string regexpValue2 = "";
            string replacementValue1 = ".";
            string replacementValue2 = "customer-service.example.com";

            // CreateOrUpdate
            var data = new DnsNaptrRecordData()
            {
                TtlInSeconds = 3600,
                DnsNaptrRecords =
                {
                    new DnsNaptrRecordInfo()
                    {
                        Order = orderValue1,
                        Preference = preferenceValue1,
                        Flags = flagsValue1,
                        Services = servicesValue1,
                        Regexp = regexpValue1,
                        Replacement = replacementValue1
                    },
                    new DnsNaptrRecordInfo()
                    {
                        Order = orderValue2,
                        Preference = preferenceValue2,
                        Flags = flagsValue2,
                        Services = servicesValue2,
                        Regexp = regexpValue2,
                        Replacement = replacementValue2
                    },
                }
            };
            var naptrRecord = await collection.CreateOrUpdateAsync(WaitUntil.Completed, naptrRecordName, data);
        }

        private async Task Create_SRV()
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
        }

        private async Task Create_TXT()
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
        }

        private async Task Create_PTR()
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
        }
    }
}
