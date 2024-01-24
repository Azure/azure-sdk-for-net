// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        private const string provisioningState = "Succeeded";

        [Test]
        public void AaaaRecordDataTest()
        {
            var id = new ResourceIdentifier("{/subscriptions/000000000-0000-0000-0000-000000000/resourceGroups/dnsrg2497/providers/Microsoft.Network/dnszones/2022dnszone9605.com/AAAA/aaaa9739}");
            string name = "aaaa";
            ResourceType resourceType = "Microsoft.Network/dnszones/AAAA";
            SystemData systemData = default;
            ETag? etag = new ETag("75a9c76c-eeee-5555-9999-109960666a19");
            IDictionary<string, string> metadata = default;
            long? ttl = 3600;
            string fqdn = "aaaa3349.2022dnszone6060.com.";
            WritableSubResource targetResource = null;
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
            Assert.AreEqual(3600, aaaa.TtlInSeconds);
        }
    }
}
