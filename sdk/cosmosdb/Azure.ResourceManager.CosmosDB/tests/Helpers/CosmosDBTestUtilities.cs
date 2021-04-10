// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public static class CosmosDBTestUtilities
    {
        internal const string ResourceGroupPrefix = "Default-CosmosDB-";
        internal const string Location = "West US";
        public static async Task TryRegisterResourceGroupAsync(ResourceGroupsOperations resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
        }
    }
}
