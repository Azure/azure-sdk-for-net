// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public static class CosmosDBTestUtilities
    {
        internal const string ResourceGroupPrefix = "DefaultCosmosDB";
        internal const string Location = "West US";
        public static async Task TryRegisterResourceGroupAsync(ResourceGroupsOperations resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
        }
    }
}
