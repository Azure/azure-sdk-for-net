// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public static class CosmosDBTestUtilities
    {
        internal const string databaseAccountName = "db2048";
        internal const string location = "West US";
        internal const string resourceGroupPrefix = "Default-CosmosDB-";
        internal const string tableThroughputType = "Microsoft.DocumentDB/databaseAccounts/tables/throughputSettings";
        public static async Task TryRegisterResourceGroupAsync(ResourceGroupsOperations resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
        }
    }
}
