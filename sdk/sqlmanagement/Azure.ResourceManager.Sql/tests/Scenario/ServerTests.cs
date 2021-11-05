// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ServerTests : SqlManagementClientBase
    {
        public ServerTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            string rgName = "myResourceGroup";
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync(rgName);
            ResourceGroupData data = new ResourceGroupData("westus2")
            {
            };
            var rg2 = await subscription.GetResourceGroups().CreateOrUpdateAsync("testrg1525", data);
        }
    }
}
