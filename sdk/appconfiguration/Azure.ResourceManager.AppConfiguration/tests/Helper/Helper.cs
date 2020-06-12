// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public static class Helper
    {
        public static async Task TryRegisterResourceGroupAsync(ResourceGroupsClient resourceGroupsClient, string location, string resourceGroupName)
        {
            await resourceGroupsClient.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
        }
    }
}
