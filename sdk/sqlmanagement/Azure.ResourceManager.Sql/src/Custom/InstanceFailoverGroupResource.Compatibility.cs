// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    public partial class InstanceFailoverGroupResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, AzureLocation locationName, string name)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, locationName.ToString(), name);
    }
}
