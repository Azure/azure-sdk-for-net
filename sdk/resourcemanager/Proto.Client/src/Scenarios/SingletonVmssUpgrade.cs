// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;

namespace Proto.Client
{
    class SingletonVmssUpgrade : Scenario
    {
        public override void Execute()
        {
            ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async Task ExecuteAsync()
        {
            var client = new ArmClient(ScenarioContext.AzureSdkSandboxId, new DefaultAzureCredential());

            // NOTE: due to full test involves creating LB which have another 3-5 resources needs to be in
            // proto, this test relies on pre-created VMSS.
            // 1. Follow instruction here (CLI), https://docs.microsoft.com/en-us/azure/virtual-machine-scale-sets/quick-create-cli
            // 2. Initiate a rolling upgrade az vmss rolling-upgrade start -g [RG] -n myScaleSet --debug
            var vmss1 = client.DefaultSubscription
                .GetResourceGroups().Get("azhang-test").Value
                .GetVirtualMachineScaleSet().Get("myScaleSet").Value;

            var ru = vmss1.GetRollingUpgrade().Get().Value;
            Debug.Assert(ru.Data.Model != null);

            ru = ru.Get().Value;
            Debug.Assert(ru.Data.Model != null);

            try
            {
                vmss1.GetRollingUpgrade().Cancel();
            }
            catch (RequestFailedException e) when (e.Status == 409)
            {
            }
            catch
            {
                throw;
            }

            Console.WriteLine("Test case SingletonVmssUpgrade passed.");
        }
    }
}
