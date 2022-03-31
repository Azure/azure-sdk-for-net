// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.EdgeOrder.Tests.Helpers
{
    public class EdgeOrderManagementTestUtilities
    {
        public const string DefaultResourceGroupName = "rg-edgeorder-sdk-tests";
        public const string DefaultResourceLocation = "eastus";
        public const string DefaultAddressName = "edgeorder-sdk-tests-Address1";
        public const string DefaultOrderItemName = "edgeorder-sdk-tests-OrderItem1";
        public const string OrderingServiceRpNamespace = "Microsoft.EdgeOrder";
        public const string OrderArmIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/" +
                                               OrderingServiceRpNamespace + "/locations/{2}/orders/{3}";

        public static async Task TryRegisterResourceGroupAsync(ResourceGroupCollection resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new ResourceGroupData(location));
        }
    }
}
