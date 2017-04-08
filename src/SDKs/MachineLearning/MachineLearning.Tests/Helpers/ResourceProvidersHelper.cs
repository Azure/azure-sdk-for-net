// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;

namespace MachineLearning.Tests.Helpers
{
    public static class ResourceProvidersHelper
    {
        public static string GetRPApiVersion(ResourceManagementClient resourcesClient, string providerNamespace, string resourceTypeName)
        {
            Provider resourceProvider = resourcesClient.Providers.Get(providerNamespace);
            ProviderResourceType resourceType = resourceProvider.ResourceTypes.First(type => string.Equals(type.ResourceType, resourceTypeName, StringComparison.OrdinalIgnoreCase));
            return resourceType.ApiVersions.Last();
        }
    }
}
