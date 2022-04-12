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

namespace Azure.ResourceManager.Dns.Tests.Tests
{
    internal class Template : DnsServiceClientTestBase
    {
        //private ResourceGroupResource _resourceGroup;

        //public RecordSetATests(bool isAsync) : base(isAsync)
        //{
        //}

        //[OneTimeSetUp]
        //public async Task GlobalSetUp()
        //{
        //    string rgName = SessionRecording.GenerateAssetName("Dns-RG-");
        //    var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
        //    ResourceGroupResource rg = rgLro.Value;
        //    _resourceGroupIdentifier = rg.Id;

        //    await StopSessionRecordingAsync();
        //}

        //[SetUp]
        //public async Task TestSetUp()
        //{
        //    var client = GetArmClient();
        //    _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        //}

        //public async Task CreateDnsZone()
        //{
        //    Castle.DynamicProxy.Generators.GeneratorException
        //     Can not create proxy for type Azure.ResourceManager.Dns.ResourceGroupResourceExtensionClient because it is not accessible.
        //     Make it public, or internal and mark your assembly with
        //     [assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=*******")] attribute, because assembly Azure.ResourceManager.Dns is strong-named.
        //   var collection = _resourceGroup.GetDnsZones();
        //    string zoneName = "dns20220402.com";
        //    DnsZoneData data = new DnsZoneData(AzureLocation.WestUS2)
        //    {
        //    };
        //    var dns = await collection.CreateOrUpdateAsync(WaitUntil.Completed, zoneName, data);
        //}

        //[Test]
        //[Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        //[RecordedTest]
        //public async Task CreateOrUpdate()
        //{
        //    await CreateDnsZone();
        //    var dns = await _resourceGroup.GetDnsZoneAsync("dns20220402.com");
        //}
    }
}
