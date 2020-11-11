// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources;
using System.Collections.Generic;

namespace Azure.Core.TestFramework
{
    public static class ResourceCleanup
    {

        public static void cleanUpResources(IEnumerable<string> resourceGroups, string subscriptionId, TokenCredential credential)
        {
            var resourceGroupsClient = new ResourcesManagementClient(
                        subscriptionId, credential).ResourceGroups;
            foreach (string rgName in resourceGroups)
                _ = resourceGroupsClient.StartDeleteAsync(rgName);
        }
    }
}