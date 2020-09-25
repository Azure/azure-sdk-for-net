﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public static class Helper
    {
        public static async Task TryRegisterResourceGroupAsync(ResourceGroupsOperations resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
        }
    }
}
