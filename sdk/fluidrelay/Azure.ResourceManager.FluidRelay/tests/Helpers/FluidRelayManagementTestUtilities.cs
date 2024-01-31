// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.FluidRelay.Tests.Helpers
{
    public class FluidRelayManagementTestUtilities
    {
        public const string DefaultResourceGroupName = "rg-fluidrelay-sdk-tests";
        public const string DefaultResourceLocation = "westus2";
        public const string DefaultAddressName = "edgeorder-sdk-tests-fluidRelayServers1";
        public const string FluidRelayRpNamespace = "Microsoft.FluidRelay";
        public const string FluidRelayArmIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/" +
                                               FluidRelayRpNamespace + "/locations/{2}/fluidRelayServers/{3}";

        public static async Task TryRegisterResourceGroupAsync(ResourceGroupCollection resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new ResourceGroupData(location));
        }
    }
}
