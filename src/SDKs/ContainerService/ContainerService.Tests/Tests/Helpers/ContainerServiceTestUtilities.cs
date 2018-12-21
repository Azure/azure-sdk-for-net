// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using ContainerService.Tests;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.ContainerService.Tests
{
    public static class ContainerServiceTestUtilities
    {
        internal const string DnsPrefix = "aksdotnetsdk";
        internal const string ResourceGroupPrefix = "aks-dotnet-sdk-RG-";
        internal const string AgentPoolProfileName = "aksdotnetagent";
        internal const string VMSize = "Standard_A1";

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ResourceManagementClient resourceManagementClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return resourceManagementClient;
        }

        internal static ContainerServiceClient GetContainerServiceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ContainerServiceClient containerServiceClient = context.GetServiceClient<ContainerServiceClient>(handlers: handler);
            return containerServiceClient;
        }

        public static string GetLocationFromProvider(this ResourceManagementClient resourceManagementClient)
        {
            return "westus2";
        }

        public static void TryRegisterResourceGroup(this ResourceManagementClient resourceManagementClient, string location, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));
        }

        public static string TryGetResourceGroup(this ResourceManagementClient resourceManagementClient, string location)
        {
            const string DefaultResourceGroupName = "SDKTests";

            var resourceGroup = resourceManagementClient.ResourceGroups
                    .List().Where(group => string.IsNullOrWhiteSpace(location) || group.Location.Equals(location.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault(group => group.Name.Contains(DefaultResourceGroupName));

            return resourceGroup != null
                ? resourceGroup.Name
                : string.Empty;
        }
    }
}
