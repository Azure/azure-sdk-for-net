// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Dns.Tests.Scenario
{
    internal class ModelFactoryTests
    {
        private const string name = "foo";
        private const string provisioningState = "Succeeded";
        private const string fqdn = "foo.contoso.com.";
        private static ETag? etag = new ETag("11111111-eeee-5555-9999-000000000000");
        private static long? ttl = 3600;
        private ResourceManager.Models.SystemData systemData = default;
        private IDictionary<string, string> metadata = default;
        private WritableSubResource targetResource = null;

        [Test]
        public void AaaaRecordData_Empty_Test()
        {
            DnsAaaaRecordData aaaa = ArmDnsModelFactory.DnsAaaaRecordData(null, null, default, null, null, null, null, null, null, null);
            Assert.IsNull(aaaa.Id);
            Assert.IsNull(aaaa.Name);
            Assert.IsNull(aaaa.SystemData);
            Assert.IsEmpty(aaaa.Metadata);
            Assert.IsNull(aaaa.TtlInSeconds);
            Assert.IsNull(aaaa.Fqdn);
            Assert.IsNull(aaaa.ProvisioningState);
            Assert.IsNull(aaaa.TargetResource);
            Assert.IsEmpty(aaaa.DnsAaaaRecords);
        }

        [Test]
        public void AaaaRecordDataTest()
        {
            ResourceIdentifier id = new ResourceIdentifier("{/subscriptions/000000000-0000-0000-0000-000000000/resourceGroups/rg0000/providers/Microsoft.Network/dnszones/contoso.com/AAAA/foo}");
            ResourceType resourceType = "Microsoft.Network/dnszones/AAAA";
            List<DnsAaaaRecordInfo> aaaaRecords = new List<DnsAaaaRecordInfo>
            {
                new DnsAaaaRecordInfo()
                {
                    IPv6Address = IPAddress.Parse("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d55")
                },
                new DnsAaaaRecordInfo()
                {
                    IPv6Address = IPAddress.Parse("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d56")
                }
            };
            DnsAaaaRecordData aaaa = ArmDnsModelFactory.DnsAaaaRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, aaaaRecords);
            BasicAssert(aaaa);
            Assert.That(aaaa.Id, Is.EqualTo(id));
            Assert.That(aaaa.ResourceType, Is.EqualTo(resourceType));
            Assert.That(aaaa.DnsAaaaRecords.Count, Is.EqualTo(2));
        }

        [Test]
        public void CnameRecordDataTest()
        {
            ResourceIdentifier id = new ResourceIdentifier("{/subscriptions/000000000-0000-0000-0000-000000000/resourceGroups/rg0000/providers/Microsoft.Network/dnszones/contoso.com/CNAME/foo}");
            ResourceType resourceType = "Microsoft.Network/dnszones/CNAME";
            string aliasValue = "mycontoso.com";

            DnsCnameRecordData cname = ArmDnsModelFactory.DnsCnameRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, aliasValue);
            BasicAssert(cname);
            Assert.That(cname.Id, Is.EqualTo(id));
            Assert.That(cname.ResourceType, Is.EqualTo(resourceType));
            Assert.That(cname.DnsCnameRecord.Cname, Is.EqualTo(aliasValue));
        }

        [Test]
        public void SoaRecordDataTest()
        {
            ResourceIdentifier id = new ResourceIdentifier("{/subscriptions/000000000-0000-0000-0000-000000000/resourceGroups/rg0000/providers/Microsoft.Network/dnszones/contoso.com/SOA/foo}");
            ResourceType resourceType = "Microsoft.Network/dnszones/SOA";
            DnsSoaRecordInfo soaRecord = new DnsSoaRecordInfo
            {
                Email = "azuredns-hostmaster.microsoft.com",
                ExpireTimeInSeconds = 2419200,
                RefreshTimeInSeconds = 3600,
                RetryTimeInSeconds = 300,
                MinimumTtlInSeconds = 300,
                SerialNumber = 1,
                Host = "ns1-03.azure-dns.com."
            };

            DnsSoaRecordData soa = ArmDnsModelFactory.DnsSoaRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, soaRecord);
            BasicAssert(soa);
            Assert.That(soa.Id, Is.EqualTo(id));
            Assert.That(soa.ResourceType, Is.EqualTo(resourceType));
            Assert.That(soa.DnsSoaRecord.Email, Is.EqualTo("azuredns-hostmaster.microsoft.com"));
            Assert.That(soa.DnsSoaRecord.Host, Is.EqualTo("ns1-03.azure-dns.com."));
            Assert.That(soa.DnsSoaRecord.ExpireTimeInSeconds, Is.EqualTo(2419200));
            Assert.That(soa.DnsSoaRecord.RefreshTimeInSeconds, Is.EqualTo(3600));
            Assert.That(soa.DnsSoaRecord.RetryTimeInSeconds, Is.EqualTo(300));
            Assert.That(soa.DnsSoaRecord.MinimumTtlInSeconds, Is.EqualTo(300));
            Assert.That(soa.DnsSoaRecord.SerialNumber, Is.EqualTo(1));
        }

        private static void BasicAssert(DnsBaseRecordData recordData)
        {
            Assert.That(recordData.Name, Is.EqualTo(name));
            Assert.That(recordData.ProvisioningState, Is.EqualTo(provisioningState));
            Assert.That(recordData.Fqdn, Is.EqualTo(fqdn));
            Assert.That(recordData.ETag, Is.EqualTo(etag));
            Assert.That(recordData.TtlInSeconds, Is.EqualTo(ttl));
            Assert.IsNull(recordData.TargetResource);
        }
    }
}
