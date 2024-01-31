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
        private SystemData systemData = default;
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
            var aaaa = ArmDnsModelFactory.DnsAaaaRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, aaaaRecords);
            BasicAssert(aaaa);
            Assert.AreEqual(id, aaaa.Id);
            Assert.AreEqual(resourceType, aaaa.ResourceType);
            Assert.AreEqual(2, aaaa.DnsAaaaRecords.Count);
        }

        private static void BasicAssert(DnsBaseRecordData recordData)
        {
            Assert.AreEqual(name, recordData.Name);
            Assert.AreEqual(provisioningState, recordData.ProvisioningState);
            Assert.AreEqual(fqdn, recordData.Fqdn);
            Assert.AreEqual(etag, recordData.ETag);
            Assert.AreEqual(ttl, recordData.TtlInSeconds);
            Assert.IsNull(recordData.TargetResource);
        }
    }
}
