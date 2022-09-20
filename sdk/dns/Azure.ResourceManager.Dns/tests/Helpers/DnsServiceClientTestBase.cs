// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Azure.Core;
using Azure.Identity;

namespace Azure.ResourceManager.Dns.Tests
{
    public abstract class DnsServiceClientTestBase : ManagementRecordedTestBase<DnsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";
        public DnsServiceClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        public async Task<DnsZoneResource> CreateADnsZone(string dnsZoneName, ResourceGroupResource rg)
        {
            DnsZoneCollection collection = rg.GetDnsZones();
            DnsZoneData data = new DnsZoneData("Global")
            {
            };
            var dns = await collection.CreateOrUpdateAsync(WaitUntil.Completed, dnsZoneName, data);
            return dns.Value;
        }
    }
}
