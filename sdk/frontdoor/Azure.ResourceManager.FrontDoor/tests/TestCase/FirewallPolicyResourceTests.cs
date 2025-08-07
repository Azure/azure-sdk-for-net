// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.FrontDoor.Models;
using Azure.ResourceManager.FrontDoor.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.FrontDoor.Tests.TestCase
{
    public class FirewallPolicyResourceTests : FrontDoorManagementTestBase
    {
        public FirewallPolicyResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<FrontDoorWebApplicationFirewallPolicyResource> CreateAccountResourceAsync(string firewallName)
        {
            var collection = (await CreateResourceGroupAsync()).GetFrontDoorWebApplicationFirewallPolicies();
            var input = ResourceDataHelpers.GetPolicyData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, firewallName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task FrontDoorResourceApiTests()
        {
            //1.Get
            var firewallName = Recording.GenerateAssetName("testfirewall");
            var firewall1 = await CreateAccountResourceAsync(firewallName);
            FrontDoorWebApplicationFirewallPolicyResource firewall2 = await firewall1.GetAsync();

            ResourceDataHelpers.AssertPolicy(firewall1.Data, firewall2.Data);
            //2.Delete
            await firewall1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
