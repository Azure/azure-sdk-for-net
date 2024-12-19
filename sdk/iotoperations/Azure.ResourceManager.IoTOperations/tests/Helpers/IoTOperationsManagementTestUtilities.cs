// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.IoTOperations.Tests.Helpers
{
    public class IoTOperationsManagementTestUtilities
    {
        public const string DefaultResourceGroupName = "sdk-test-cluster-110596935";
        public const string DefaultResourceLocation = "eastus2";

        // public const string DefaultAddressName = "edgeorder-sdk-tests-Address1";
        // public const string DefaultOrderItemName = "edgeorder-sdk-tests-OrderItem1";
        // public const string OrderingServiceRpNamespace = "Microsoft.EdgeOrder";
        // public const string OrderArmIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/" + OrderingServiceRpNamespace + "/locations/{2}/orders/{3}";

        public static async Task TryRegisterResourceGroupAsync(
            ResourceGroupCollection resourceGroupsOperations,
            string location,
            string resourceGroupName
        )
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(
                WaitUntil.Completed,
                DefaultResourceGroupName,
                new ResourceGroupData(location)
            );
        }
    }
}
