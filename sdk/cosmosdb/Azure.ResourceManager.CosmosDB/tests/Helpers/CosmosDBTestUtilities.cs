// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public static class CosmosDBTestUtilities
    {
        internal const string ResourceGroupPrefix = "dotnet-testrecordings-";
        internal const string Location = "West US";
        internal const string DatabaseAccountPrefix = "dotnet-acc-";

        public static async Task TryRegisterResourceGroupAsync(ResourceGroupCollection resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new ResourceGroupData(location));
        }

        public static string GenerateResourceGroupName(TestRecording testRecording)
        {
            return testRecording.GenerateAssetName(ResourceGroupPrefix);
        }

        public static string GenerateDatabaseAccountName(TestRecording testRecording)
        {
            return testRecording.GenerateAssetName(DatabaseAccountPrefix);
        }
    }
}
