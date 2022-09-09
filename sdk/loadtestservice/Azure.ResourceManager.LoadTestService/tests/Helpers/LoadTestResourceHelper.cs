// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.LoadTestService.Tests.Helpers
{
    public class LoadTestResourceHelper
    {
        public const string DefaultResourceGroupName = "rg-loadtestservice-sdk-tests";
        public const string DefaultResourceLocation = "westus2";
        public const string LoadTestRpNamespace = "Microsoft.LoadTestService";
        public const string LoadTestResourceArmIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/" +
                                               LoadTestRpNamespace + "/loadtests/{2}";

        public static async Task TryRegisterResourceGroupAsync(ResourceGroupCollection resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new ResourceGroupData(location));
        }
    }
}
